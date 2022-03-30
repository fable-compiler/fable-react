namespace Fable.React

open Fable.Core

type IStateHook<'T> =
    [<Emit("$0[0]")>]
    abstract current: 'T
    [<Emit("$0[1]($1)")>]
    abstract update: 'T -> unit
    [<Emit("$0[1]($1)")>]
    abstract update: ('T -> 'T) -> unit

// Alias kept for backwards compatibility
type IRefHook<'T> = IRefValue<'T>

type IReducerHook<'State,'Msg> =
    [<Emit("$0[0]")>]
    abstract current: 'State
    [<Emit("$0[1]($1)")>]
    abstract update: 'Msg -> unit

type ITransitionHook =
    [<Emit("$0[0]")>]
    abstract isPending: bool
    [<Emit("$0[1]($1)")>]
    abstract startTransition: callback: (unit -> unit) -> unit

type IHooks =
    /// Returns the current state with a function to update it.
    /// More info at  https://reactjs.org/docs/hooks-reference.html#usestate
    abstract useState: initialState: 'T -> IStateHook<'T>

    /// Returns the current state with a function to update it.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usestate
    [<Emit("$0.useState($1)")>]
    abstract useStateLazy: initialState: (unit->'T) -> IStateHook<'T>

    /// Accepts a function that contains imperative, possibly effectful code.
    /// More info at https://reactjs.org/docs/hooks-reference.html#useeffect
    abstract useEffect: effect: (unit->unit) * ?dependencies: obj[] -> unit

    /// Accepts a function that contains imperative, possibly effectful code.
    /// The signature is identical to useEffect, but it fires synchronously after 
    /// all DOM mutations. Use this to read layout from the DOM and synchronously 
    /// re-render. Updates scheduled inside useLayoutEffect will be flushed 
    /// synchronously, before the browser has a chance to paint.
    /// More info at https://reactjs.org/docs/hooks-reference.html#uselayouteffect
    abstract useLayoutEffect: effect: (unit->unit) * ?dependencies: obj[] -> unit

    /// Accepts a function that contains effectful code and returns a disposable for clean-up
    /// More info at https://reactjs.org/docs/hooks-reference.html#useeffect
    [<Emit("""$0.useEffect(() => {
        const disp = $1();
        return () => disp.Dispose();
    }{{, $2}})""")>]
    abstract useEffectDisposable: effect: (unit->System.IDisposable) * ?dependencies: obj[] -> unit

    // abstract useCallback (callback: unit -> unit, dependencies: obj[]): unit -> unit

    /// Accepts a "create" function and an array of dependencies and returns a memoized value
    /// More info at https://reactjs.org/docs/hooks-reference.html#usememo
    abstract useMemo: callback: (unit->'T) * dependencies: obj[] -> 'T

    /// The returned object will persist for the full lifetime of the component.
    /// More info at https://reactjs.org/docs/hooks-reference.html#useref
    abstract useRef: initialValue: 'T -> IRefValue<'T>

    /// Accepts a context object (the value returned from createContext) and
    /// returns the current context value for that context. The current context
    /// value is determined by the value prop of the nearest <MyContext.Provider>
    /// above the calling component in the tree.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usecontext
    abstract useContext: ctx: IContext<'T> -> 'T

    /// Display a label for custom hooks in React DevTools.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedebugvalue
    abstract useDebugValue: label: string -> unit

    /// Defers formatting of debug value until the Hook is actually inspected
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedebugvalue
    abstract useDebugValue: value: 'T * format: ('T->string) -> unit

    /// An alternative to useState. Accepts a reducer of type (state, action) => newState, and returns the current state paired with a dispatch method.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usereducer
    abstract useReducer: reducer: ('State -> 'Msg -> 'State) * initialState: 'State -> IReducerHook<'State, 'Msg>

    /// An alternative to useState. Accepts a reducer of type (state, action) => newState, and returns the current state paired with a dispatch method.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usereducer
    abstract useReducer: reducer: ('State -> 'Msg -> 'State) * initialArg: 'I * init: ('I -> 'State) -> IReducerHook<'State, 'Msg>

    /// Returns a stateful value for the pending state of the transition, and a function to start it.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usetransition
    /// Requires React 18.
    abstract useTransition: unit -> ITransitionHook

    /// useId is a hook for generating unique IDs that are stable across the server and client, while avoiding hydration mismatches.
    /// More info at https://reactjs.org/docs/hooks-reference.html#useid
    /// Requires React 18.
    abstract useId: unit -> string

    /// useDeferredValue accepts a value and returns a new copy of the value that will defer to more urgent updates. If the current render is the result of an urgent update, like user input, React will return the previous value and then render the new value after the urgent render has completed.
    /// More info at https://reactjs.org/docs/hooks-reference.html#usedeferredvalue
    /// Requires React 18.
    abstract useDeferredValue: 'T -> 'T

[<AutoOpen>]
module HookBindings =
    let private makeDummyStateHook value =
        { new IStateHook<'T> with
            member __.current = value
            member __.update(x: 'T) = ()
            member __.update(f: 'T->'T) = () }

    let private makeDummyReducerHook state =
        { new IReducerHook<'State,'Msg> with
            member __.current = state
            member __.update(msg: 'Msg) = () }

    let private makeDummyTransitionHook () =
        { new ITransitionHook with
            member __.isPending = false
            member __.startTransition callback = () }

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
                { new IRefValue<_> with
                    member __.current with get() = initialValue and set _ = () }
            member __.useContext ctx =
                (ctx :?> ISSRContext<_>).DefaultValue
            member __.useDebugValue(label): unit = ()
            member __.useDebugValue(value, format): unit = ()
            member __.useReducer(reducer,initialState) = makeDummyReducerHook initialState
            member __.useReducer(reducer, initialArgument, init) = makeDummyReducerHook (init initialArgument)
            member __.useTransition() = makeDummyTransitionHook()
            member __.useDeferredValue value = value
            member __.useId() = ""
            member __.useLayoutEffect(effect, dependencies) = ()
        }