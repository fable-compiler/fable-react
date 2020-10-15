namespace Fable.React

open Fable
open Fable.AST

module internal AstUtil =
    open System.Text.RegularExpressions

    let cleanFullDisplayName str =
        Regex.Replace(str, @"`\d+", "").Replace(".", "_")

    let makeIdent name: Fable.Ident =
        { Name = name
          Type = Fable.Any
          // It's important to set this to false
          // so Fable doesn't optimize the binding
          IsCompilerGenerated = false
          IsThisArgument = false
          IsMutable = false
          Range = None }

    let makeValue r value =
        Fable.Value(value, r)

    let makeStrConst (x: string) =
        Fable.StringConstant x |> makeValue None

    let makeImport selector path =
        Fable.Import({ Selector = makeStrConst selector
                       Path = makeStrConst path
                       IsCompilerGenerated = true }, Fable.Any, None)        

    let makeCall callee args =
        let callInfo: Fable.CallInfo =
            { ThisArg = None
              Args = args
              SignatureArgTypes = []
              HasSpread = false
              IsJsConstructor = false }
        Fable.Call(callee, callInfo, Fable.Any, None)

    type MemberInfo(?info: Fable.MemberInfo,
                    ?isValue: bool) =

        let infoOr f v =
            match info with
            | Some i -> f i
            | None -> v

        let argOrInfoOr arg f v =
            match arg, info with
            | Some arg, _ -> arg
            | None, Some i -> f i
            | None, None -> v

        interface Fable.MemberInfo with
            member _.IsValue = argOrInfoOr isValue (fun i -> i.IsValue) false
            member _.Attributes = infoOr (fun i -> i.Attributes) Seq.empty
            member _.HasSpread = infoOr (fun i -> i.HasSpread) false
            member _.IsPublic = infoOr (fun i -> i.IsPublic) true
            member _.IsInstance = infoOr (fun i -> i.IsInstance) true
            member _.IsMutable = infoOr (fun i -> i.IsMutable) false
            member _.IsGetter = infoOr (fun i -> i.IsGetter) false
            member _.IsSetter = infoOr (fun i -> i.IsSetter) false
            member _.IsEnumerator = infoOr (fun i -> i.IsEnumerator) false
            member _.IsMangled = infoOr (fun i -> i.IsMangled) false

    let objValue (k, v): Fable.MemberDecl =
        {
            Name = k
            FullDisplayName = k
            Args = []
            Body = v
            UsedNames = Set.empty
            Info = MemberInfo(isValue=true)
        }

    let objExpr kvs =
        Fable.ObjectExpr(List.map objValue kvs, Fable.Any, None)


type ReactComponentAttribute() =
    inherit MemberDeclarationPluginAttribute()
    override _.FableMinimumVersion = "3.0"
    override _.Transform(logger, decl) =
        if decl.Info.IsValue || decl.Info.IsGetter || decl.Info.IsSetter then
            logger.LogWarning("Expecting a function for ReactComponent")
            decl
        else
            let propsArg = AstUtil.makeIdent "$props"
            let renderIdent = AstUtil.cleanFullDisplayName decl.FullDisplayName |> AstUtil.makeIdent
            let renderBody =
                ([], decl.Args) ||> List.fold (fun bindings arg ->
                    let getterKind = Fable.ByKey(Fable.ExprKey(AstUtil.makeStrConst arg.DisplayName))
                    let getter = Fable.Get(Fable.IdentExpr propsArg, getterKind, Fable.Any, None)
                    (arg, getter)::bindings)
                |> List.rev
                |> fun bindings -> Fable.Let(bindings, decl.Body)

            let propsObj =
                decl.Args
                |> List.map (fun arg -> arg.DisplayName, Fable.IdentExpr arg)
                |> AstUtil.objExpr
            let body =
                let createEl = AstUtil.makeCall (AstUtil.makeImport "createElement" "react") [Fable.IdentExpr renderIdent; propsObj]
                Fable.Let([renderIdent, Fable.Delegate([propsArg], renderBody, None)],
                    Fable.Delegate(decl.Args, createEl, None))
            { decl with Args = []; Body = body; Info = AstUtil.MemberInfo(decl.Info, isValue=true) }
