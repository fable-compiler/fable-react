namespace Fable.React

open Fable.Core
open Fable.Core.JsInterop

type ComponentType<'Props> =
    U2<FunctionComponent<'Props>, Component<'Props, obj>>

[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ComponentType =
    let ofFunc f: ComponentType<'Props> = f |> U2.Case1
    let ofComp (c:Component<'Props, 'state>) : ComponentType<'Props> = unbox c |> U2.Case2

type ComponentType = ComponentType<obj>