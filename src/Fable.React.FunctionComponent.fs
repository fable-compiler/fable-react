namespace Fable.React

open System
open Fable.Core
open Fable.Core.JsInterop

module private Cache =
#if FABLE_COMPILER
    let private cache = JS.Constructors.Map.Create<obj, ReactElementType>()
    let getOrAdd<'P> (key: obj) (valueFactory: obj->ReactElementType<'P>): ReactElementType<'P> =
        if cache.has(key) then cache.get(key) :?> _
        else let v = valueFactory key in cache.set(key, v) |> ignore; v
#else
    let private cache = System.Collections.Concurrent.ConcurrentDictionary<Type, ReactElementType>()
    let getOrAdd (key: Type) (valueFactory: Type->ReactElementType): ReactElementType =
        cache.GetOrAdd(key, valueFactory)
#endif

type FunctionComponentInfo<'P> =
    { Render: 'P->ReactElement
      MemoizeWith: ('P->'P->bool) option
      WithKey: ('P->string) option }

/// A React component that can use hooks to manage the life cycle and is displayed in React dev tools.
/// Uses React.memo if `memoizeWith` is specified. To optimize collections, use `withKey` argument
/// or define a `key` field in the props object.
type FunctionComponent<'P>(render: 'P->ReactElement, ?memoizeWith: 'P->'P->bool, ?withKey: 'P->string) =
    member __.Info =
        { Render = render
          MemoizeWith = memoizeWith
          WithKey = withKey }

type FunctionComponent =
#if FABLE_COMPILER
    static member createElement(constructor: obj, props: 'P) =
        let getReactElementType (constructor: obj) =
            let com = createNew constructor () :?> FunctionComponent<'P>
            let render =
                let render =
                    match com.Info.WithKey with
                    | None -> com.Info.Render
                    | Some f ->
                        fun props ->
                            props?key <- f props
                            com.Info.Render props
#if DEBUG
                render?displayName <- constructor?name
#endif
                render
            match com.Info.MemoizeWith with
            | Some areEqual -> ReactElementType.memoWith areEqual render
            | None -> ReactElementType.ofFunction render

        let elType = Cache.getOrAdd constructor getReactElementType
        ReactElementType.create elType props []

    static member inline Render<'T,'P when 'T :> FunctionComponent<'P> and 'T: (new : unit -> 'T)> (props: 'P): ReactElement =
        FunctionComponent.createElement(jsConstructor<'T>, props)
#else
    static member Render<'T,'P when 'T :> FunctionComponent<'P> and 'T: (new : unit -> 'T)> (props: 'P): ReactElement =
        let getReactElementType (t: Type) =
            let com = Activator.CreateInstance(t) :?> FunctionComponent<'P>
            ReactElementType.ofFunction com.Info.Render :> ReactElementType
        let elType = Cache.getOrAdd typeof<'T> getReactElementType :?> ReactElementType<'P>
        ReactElementType.create elType props []
#endif

#if !FABLE_REPL_LIB
    /// Creates a lazy React component from a function in another file
    /// ATTENTION: Requires fable-compiler 2.3 or above
    /// Pass the external reference directly into the argument (avoid pipes)
    static member inline Lazy(f: 'Props -> ReactElement, fallback: ReactElement): 'Props -> ReactElement =
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
#endif