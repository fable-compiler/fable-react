[<Fable.Core.Erase>]
module Fable.React.Internal

open Fable.AST
open Fable.AST.Fable.Util

/// Only used internally to emit inline Fable AST
type Emitter() =
    let (|CoreMeth|_|) coreMod meth = function
        | Fable.Value(Fable.ImportRef(meth', coreMod', Fable.CoreLib))
            when meth' = meth && coreMod' = coreMod -> Some CoreMeth
        | _ -> None
    let (|ArrayConst|_|) = function
        | Fable.Value(Fable.ArrayConst(Fable.ArrayValues vals, _)) -> Some vals
        | _ -> None
    let spread args =
        match args with
        | Fable.Apply(CoreMeth "List" "default",[],_,_,_) -> []
        | Fable.Apply(CoreMeth "List" "ofArray", [ArrayConst vals], Fable.ApplyMeth,_,_) -> vals
        | expr -> [Fable.Value(Fable.Spread expr)]
    let createEl = makeImport "createElement" "react"

    member x.Com(_com: Fable.ICompiler, i: Fable.ApplyInfo) =
        let args =
            let com = makeNonGenTypeRef _com i.methodTypeArgs.Head
            match i.args with
            | [props; children] -> [com; props] @ spread children
            | [props] -> [com; props]
            | _ -> failwith "Unexpected arguments"
        Fable.Apply(createEl, args, Fable.ApplyMeth, i.returnType, i.range)

    member x.From(_com: Fable.ICompiler, i: Fable.ApplyInfo) =
        let args =
            match i.args with
            | [el; props; children] -> [el; props] @ spread children
            | [el; props] -> [el; props]
            | _ -> failwith "Unexpected arguments"
        Fable.Apply(createEl, args, Fable.ApplyMeth, i.returnType, i.range)

    member x.Tagged(_com: Fable.ICompiler, i: Fable.ApplyInfo, tag: string) =
        let args =
            let tag = Fable.Value(Fable.StringConst tag)
            match i.args with
            | [props; children] -> [tag; props] @ spread children
            | [props] -> [tag; props]
            | _ -> failwith "Unexpected arguments"
        Fable.Apply(createEl, args, Fable.ApplyMeth, i.returnType, i.range)

    member x.Imported(_com: Fable.ICompiler, i: Fable.ApplyInfo, import: string) =
        let args =
            let import =
                let splits = import.Split([|" from "|], System.StringSplitOptions.RemoveEmptyEntries)
                Fable.Value(Fable.ImportRef(splits.[0], splits.[1], Fable.CustomImport))
            match i.args with
            | [props; children] ->
                match children.Type with
                | Fable.DeclaredType(ent, _) when ent.Name = "FSharpList" ->
                    [import; props] @ spread children
                | _ -> [import; props; children]
            | [props] -> [import; props]
            | _ -> failwith "Unexpected arguments"
        Fable.Apply(createEl, args, Fable.ApplyMeth, i.returnType, i.range)
