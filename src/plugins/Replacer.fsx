#r "../../node_modules/fable-core/Fable.Core.dll"
#load "../react/Fable.React.Internal.fs"

// We need the plugin because Fable.React.Internal.Emitter cannot
// be instantiated when we're compiling fable-react itself

open Fable
open Fable.AST
open Fable.React.Internal

type Replacer() =
    let emitter = Emitter()
    interface IReplacePlugin with
        member x.TryReplace (com: Fable.ICompiler) (i: Fable.ApplyInfo) =
            match i.ownerFullName, i.methodName with
            | "Fable.Helpers.React", "from" -> emitter.From(com, i) |> Some
            | _ -> None