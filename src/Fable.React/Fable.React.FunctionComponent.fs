namespace Fable.React

open System
open System.Runtime.CompilerServices
open Fable.Core
open Fable.Core.JsInterop

#if FABLE_COMPILER
type FunctionComponentPreparedRenderFunctionCache() =
    static let cache =
        let cache = JS.Constructors.Map.Create<string, obj>()
#if DEBUG
        // Clear the cache when HMR is fired
        FunctionComponentPreparedRenderFunctionCache.OnHMR(fun () -> cache.clear())
#endif
        cache

    static member GetOrAdd(
            cacheKey: string,
            displayName: string,
            render: 'Props -> ReactElement,
            memoizeWith: ('Props -> 'Props -> bool) option,
            withKey: ('Props -> string) option,
            [<CallerMemberName>] ?__callingMemberName: string) =
        let prepareRenderFunction () =
            render?displayName <- displayName
            let elemType =
                match memoizeWith with
                | Some areEqual ->
#if DEBUG
                    // In development mode, force rerenders always when HMR is fired
                    let areEqual x y =
                        not FunctionComponentPreparedRenderFunctionCache.IsHMRApplied && areEqual x y
#endif
                    let memoElement = ReactElementType.memoWith areEqual render
                    memoElement?displayName <- "Memo(" + displayName + ")"
                    memoElement
                | None -> ReactElementType.ofFunction render
            fun props ->
                let props =
                    match withKey with
                    | Some f -> props?key <- f props; props
                    | None -> props
                ReactElementType.create elemType props []

        if cache.has(cacheKey) then
            cache.get(cacheKey) :?> ('Props -> ReactElement)
        else
            let v = prepareRenderFunction ()
            cache.set(cacheKey, box v) |> ignore
            v

    [<Emit("""typeof module === 'object'
&& typeof module.hot === 'object'
&& typeof module.hot.addStatusHandler === 'function'
? module.hot.addStatusHandler(status => { if (status === 'apply') $0(); })
: void 0""")>]
    static member OnHMR(callback: unit->unit): unit = jsNative

    [<Emit("""typeof module === 'object'
&& typeof module.hot === 'object'
&& typeof module.hot.status === 'function'
&& module.hot.status() === 'apply'""")>]
    static member IsHMRApplied: bool = jsNative
#endif

type FunctionComponent =
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
        f // No React.lazy for SSR, just return component as is
#endif
#endif

    /// Creates a function React component that can use hooks to manage the component's life cycle,
    /// and is displayed in React dev tools (use `displayName` to customize the name).
    /// Uses React.memo if `memoizeWith` is specified (check `equalsButFunctions` and `memoEqualsButFunctions` helpers).
    /// When you need a key to optimize collections in React you can use `withKey` argument or define a `key` field in the props object.
    static member inline Of(render: 'Props->ReactElement,
                        ?displayName: string,
                        ?memoizeWith: 'Props -> 'Props -> bool,
                        ?withKey: 'Props -> string
#if FABLE_COMPILER
                        ,[<CallerMemberName>] ?__callingMemberName: string
                        ,[<CallerFilePath>] ?__callingSourceFile: string
                        ,[<CallerLineNumber>] ?__callingSourceLine: int
#endif
                    ): 'Props -> ReactElement =
#if FABLE_COMPILER
        // Cache the render function to prevent recreating the component every time when FunctionComponent.Of
        // is called inside another function (including generic values: let MyCom<'T> = ...)
        let cacheKey =
            __callingSourceFile.Value +
            "#L" + (string __callingSourceLine.Value) +
            // direct caller can also be generic, need separate cached func per 'Props argument
            ";" + typeof<'Props>.FullName
        let displayName = defaultArg displayName __callingMemberName.Value

        FunctionComponentPreparedRenderFunctionCache.GetOrAdd (cacheKey, displayName, render, memoizeWith, withKey)
#else
        let elemType = ReactElementType.ofFunction render
        fun props ->
            ReactElementType.create elemType props []
#endif
