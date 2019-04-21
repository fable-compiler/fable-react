namespace Fable.React

open Fable.Core
open Fable.Core.JsInterop

type FunctionComponent<'Props> = 'Props -> ReactElement
type LazyFunctionComponent<'Props> = 'Props -> ReactElement

type FunctionComponent =
    /// Creates a lazy React component from a function in another file
    /// ATTENTION: Requires fable-compiler 2.3, pass the external reference directly to the argument position (avoid pipes)
    static member inline Lazy(f: 'Props -> ReactElement,
                                fallback: ReactElement)
                            : LazyFunctionComponent<'Props> =
#if FABLE_COMPILER
        let elemType = ReactBindings.React.``lazy``(fun () ->
            // React.lazy requires a default export
            (importValueDynamic f).``then``(fun x -> createObj ["default" ==> x]))
        fun props ->
            ReactElementType.create
                ReactBindings.React.Suspense
                (createObj ["fallback" ==> fallback])
                [ReactElementType.create elemType props []]
#else
        fun _ ->
            div [] [] // React.lazy is not compatible with SSR, so just use an empty div
#endif

    /// Creates a functional React component. Uses React.memo if `memoizeWith` is specified.
    static member Of(render: 'Props->ReactElement,
                       ?displayName: string,
                       ?memoizeWith: 'Props -> 'Props -> bool)
                    : FunctionComponent<'Props> =
#if FABLE_COMPILER
        match displayName with
        | Some name -> render?displayName <- name
        | None -> ()
#endif
        let elemType =
            match memoizeWith with
            | Some areEqual ->
                let memoElement = ReactElementType.memoWith areEqual render
#if FABLE_COMPILER
                match displayName with
                | Some name -> memoElement?displayName <- "Memo(" + name + ")"
                | None -> ()
#endif
                memoElement
            | None -> ReactElementType.ofFunction render
        fun props ->
            ReactElementType.create elemType props []
