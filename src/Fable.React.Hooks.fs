namespace Fable.React

open Fable.Core
open ReactBindings

type IStateHook<'T> =
    [<Emit("$0[0]")>]
    abstract current: 'T
    [<Emit("$0[1]($1)")>]
    abstract update: 'T -> unit
    [<Emit("$0[1]($1)")>]
    abstract update: ('T -> 'T) -> unit

type IRefHook<'T> =
    abstract current: 'T with get, set

type Hooks =
    /// Returns the current state with a function to update it.
    /// https://reactjs.org/docs/hooks-reference.html#usestate
    static member inline useState<'T> (initialState: 'T): IStateHook<'T> =
        React.useState(initialState) :?> _

    /// Returns the current state with a function to update it.
    /// https://reactjs.org/docs/hooks-reference.html#usestate
    static member inline useStateLazy<'T> (initialState: unit->'T): IStateHook<'T> =
        React.useState(initialState) :?> _

    /// Accepts a function that contains imperative, possibly effectful code
    /// More info at https://reactjs.org/docs/hooks-reference.html#useeffect
    static member inline useEffect<'T> (effect: unit -> unit, ?dependencies: obj[]): unit =
        React.useEffect(effect, ?deps=dependencies)

    /// Accepts a function that contains effectful code and returns a disposable for clean-up
    /// More info at https://reactjs.org/docs/hooks-reference.html#useeffect
    static member inline useEffectDisposable<'T> (effect: unit -> System.IDisposable, ?dependencies: obj[]): unit =
        React.useEffect((fun () -> effect().Dispose), ?deps=dependencies)

    // static member useCallback<'T> (callback: unit -> unit, dependencies: obj[]): unit -> unit

    /// Accepts a "create" function and an array of dependencies and returns a memoized value
    /// More info at https://reactjs.org/docs/hooks-reference.html#usememo
    static member inline useMemo<'T> (callback: unit -> 'T, dependencies: obj[]): 'T =
        React.useMemo(callback, dependencies) :?> _

    /// The returned object will persist for the full lifetime of the component.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedebugvalue
    static member inline useRef(initialValue: 'T): IRefHook<'T> =
        React.useRef(initialValue) :?> _

    /// Display a label for custom hooks in React DevTools.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedebugvalue
    static member inline useDebugValue(label: string): unit =
        React.useDebugValue(label)

    /// Defers formatting of debug value until the Hook is actually inspected
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedebugvalue
    static member inline useDebugValue(value: 'T, format: 'T->string): unit =
        React.useDebugValue(value, format)
