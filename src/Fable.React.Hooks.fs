namespace Fable.React

open Fable.Core

type IStateHook<'T> =
    [<Emit("$0[0]")>]
    abstract current: 'T
    [<Emit("$0[1]($1)")>]
    abstract update: 'T -> unit
    [<Emit("$0[1]($1)")>]
    abstract update: ('T -> 'T) -> unit

type IRefHook<'T> =
    abstract current: 'T with get, set

type IHooks =
    /// Returns the current state with a function to update it.
    /// https://reactjs.org/docs/hooks-reference.html#usestate
    abstract useState: initialState: 'T -> IStateHook<'T>

    /// Returns the current state with a function to update it.
    /// https://reactjs.org/docs/hooks-reference.html#usestate
    [<Emit("$0.useState")>]
    abstract useStateLazy: initialState: (unit->'T) -> IStateHook<'T>

    /// Accepts a function that contains imperative, possibly effectful code
    /// More info at https://reactjs.org/docs/hooks-reference.html#useeffect
    abstract useEffect: effect: (unit->unit) * ?dependencies: obj[] -> unit

    /// Accepts a function that contains effectful code and returns a disposable for clean-up
    /// More info at https://reactjs.org/docs/hooks-reference.html#useeffect
    [<Emit("$0.useEffect(() => $1().Dispose{{, $2}})")>]
    abstract useEffectDisposable: effect: (unit->System.IDisposable) * ?dependencies: obj[] -> unit

    // abstract useCallback (callback: unit -> unit, dependencies: obj[]): unit -> unit

    /// Accepts a "create" function and an array of dependencies and returns a memoized value
    /// More info at https://reactjs.org/docs/hooks-reference.html#usememo
    abstract useMemo: callback: (unit->'T) * dependencies: obj[] -> 'T

    /// The returned object will persist for the full lifetime of the component.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedebugvalue
    abstract useRef: initialValue: 'T -> IRefHook<'T>

    /// Display a label for custom hooks in React DevTools.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedebugvalue
    abstract useDebugValue: label: string -> unit

    /// Defers formatting of debug value until the Hook is actually inspected
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedebugvalue
    abstract useDebugValue: value: 'T * format: ('T->string) -> unit

[<AutoOpen>]
module HookBindings =
    let private makeDummyStateHook value =
        { new IStateHook<'T> with
            member __.current = value
            member __.update(x: 'T) = ()
            member __.update(f: 'T->'T) = () }

    #if FABLE_REPL_LIB
    [<Global("React")>]
    #else
    [<Import("*", "react")>]
    #endif
    let Hooks: IHooks =
        // Placeholder for SSR
        { new IHooks with
            member __.useState(initialState: 'T) =
                makeDummyStateHook initialState
            member __.useStateLazy(initialState) =
                makeDummyStateHook (initialState())
            member __.useEffect(effect, dependencies) = ()
            member __.useEffectDisposable(effect, dependencies) = ()
            member __.useMemo(callback, dependencies) = callback()
            member __.useRef(initialValue) =
                { new IRefHook<_> with
                    member __.current with get() = initialValue and set _ = () }
            member __.useDebugValue(label): unit = ()
            member __.useDebugValue(value, format): unit = ()
        }