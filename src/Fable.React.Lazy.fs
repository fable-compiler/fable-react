namespace Fable.React

open Fable.Core
open Fable.Core.JsInterop

module LazyBindings =
    [<Import("Suspense", from="react")>]
    let suspense: ReactElementType<obj> = jsNative

    [<Import("lazy", from="react")>]
    let create (f: unit -> JS.Promise<'TIn>): 'TOut = jsNative

type LazyComponent =
    /// Creates a lazy React component from a function in another file
    /// ATTENTION: Requires fable-compiler 2.3, pass the external reference directly to the argument position (avoid pipes)
    static member inline FromExternalFunction(f: 'Props -> ReactElement, fallback: ReactElement): 'Props -> ReactElement =
        let lazyType = LazyBindings.create (fun () ->
            // React.lazy requires a default export
            (importValueDynamic f).``then``(fun x -> createObj ["default" ==> x]))
        fun props ->
            ReactElementType.create
                LazyBindings.suspense
                (createObj ["fallback" ==> fallback])
                [ReactElementType.create lazyType props []]
