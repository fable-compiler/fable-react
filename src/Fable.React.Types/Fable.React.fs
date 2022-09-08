namespace Fable.React

open System
open Fable.Core

type [<AllowNullLiteral>] ReactElement =
    interface end

type ReactElementType =
    interface end

type ReactElementType<'props> =
    inherit ReactElementType

type IRefValue<'T> =
    abstract current: 'T with get, set

type IContext<'T> =
    interface end

type ISSRContext<'T> =
    inherit IContext<'T>
    abstract DefaultValue: 'T

type IReactExports =
    /// Create and return a new React element of the given type. The type argument can be either a tag name string (such as 'div' or 'span'), a React component type (a class or a function), or a React fragment type.
    abstract createElement: comp: obj * props: obj * [<ParamList>] children: ReactElement seq -> ReactElement

    /// Creates a Context object. When React renders a component that subscribes to this Context object it will read the current context value from the closest matching Provider above it in the tree.
    abstract createContext: defaultValue: 'T -> IContext<'T>

    /// React.createRef creates a ref that can be attached to React elements via the ref attribute.
    abstract createRef: initialValue: 'T -> IRefValue<'T>

    /// React.forwardRef creates a React component that forwards the ref attribute it receives to another component below in the tree.
    abstract forwardRef: fn: ('props -> IRefValue<'T> option -> ReactElement) -> ReactElementType<'props>

    /// If your component renders the same result given the same props, you can wrap it in a call to React.memo for a performance boost in some cases by memoizing the result. This means that React will skip rendering the component, and reuse the last rendered result.
    abstract memo: render: ('props -> ReactElement) * areEqual: ('props -> 'props -> bool) -> ReactElementType<'props>

    /// The React.Fragment component lets you return multiple elements in a render() method without creating an additional DOM element.
    abstract Fragment: ReactElementType<obj>

    /// React.Suspense lets you specify the loading indicator in case some components in the tree below it are not yet ready to render. In the future we plan to let Suspense handle more scenarios such as data fetching.
    abstract Suspense: ReactElementType<obj>
    
    /// React.lazy() lets you define a component that is loaded dynamically. This helps reduce the bundle size to delay loading components that aren’t used during the initial render.
    abstract ``lazy``: f: (unit -> JS.Promise<'TIn>) -> 'TOut

    /// React.startTransition lets you mark updates inside the provided callback as transitions. This method is designed to be used when React.useTransition is not available.
    /// Requires React 18.
    abstract startTransition: callback: (unit -> unit) -> unit

    /// The React version.
    abstract version: string

module ReactBindings =
    /// Mainly intended for internal use
    #if FABLE_REPL_LIB
    [<Global("React")>]
    #else
    [<Import("*", "react")>]
    #endif
    let React: IReactExports = jsNative

/// Create a React component by inheriting this class as follows
///
/// ```
/// type MyComponent(initialProps) =
///     inherit React.Component<MyProps, MyState>(initialProps)
///     base.setInitState({ value = 5 })
///
///     override this.render() =
///         // Don't use captured `initialProps` from constructor,
///         // use `this.props` instead (updated version)
///         let msg = sprintf "Hello %s, you have %i €"
///                     this.props.name this.state.value
///         div [] [ofString msg]
/// ```
type [<AbstractClass; Import("Component", "react")>] Component<'P,'S>(initProps: 'P) =
    [<Emit("$0.props")>]
    member __.props: 'P = initProps

    [<Emit("Array.prototype.concat($0.props.children || [])")>]
    member val children: ReactElement array = [| |] with get, set

    [<Emit("$0.state")>]
    member val state: 'S = Unchecked.defaultof<'S> with get, set

    /// ATTENTION: Within the constructor, use `setInitState`
    /// Enqueues changes to the component state and tells React that this component and its children need to be re-rendered with the updated state. This is the primary method you use to update the user interface in response to event handlers and server responses.
    /// Think of setState() as a request rather than an immediate command to update the component. For better perceived performance, React may delay it, and then update several components in a single pass. React does not guarantee that the state changes are applied immediately.
    /// setState() does not always immediately update the component. It may batch or defer the update until later. This makes reading this.state right after calling setState() a potential pitfall. Instead, use componentDidUpdate or a setState callback (setState(updater, callback)), either of which are guaranteed to fire after the update has been applied. If you need to set the state based on the previous state, read about the updater argument below.
    /// setState() will always lead to a re-render unless shouldComponentUpdate() returns false. If mutable objects are being used and conditional rendering logic cannot be implemented in shouldComponentUpdate(), calling setState() only when the new state differs from the previous state will avoid unnecessary re-renders.
    [<Obsolete("This overload is unsafe because it forces use of this.state. Use this.setState(updater: 'S->'P->'S) instead.")>]
    [<Emit("$0.setState($1)")>]
    member x.setState(value: 'S): unit = x.state <- value

    /// Overload of `setState` accepting updater function with the signature: `(prevState, props) => stateChange`
    /// prevState is a reference to the previous state. It should not be directly mutated. Instead, changes should be represented by building a new object based on the input from prevState and props.
    /// Both prevState and props received by the updater function are guaranteed to be up-to-date. The output of the updater is shallowly merged with prevState.
    [<Emit("$0.setState($1)")>]
    member x.setState(updater: 'S->'P->'S): unit = x.state <- updater x.state x.props

    /// This method can only be called in the constructor
    [<Emit("this.state = $1")>]
    member x.setInitState(value: 'S): unit = x.state <- value

    /// By default, when your component’s state or props change, your component will re-render. If your render() method depends on some other data, you can tell React that the component needs re-rendering by calling forceUpdate().
    /// Calling forceUpdate() will cause render() to be called on the component, skipping shouldComponentUpdate(). This will trigger the normal lifecycle methods for child components, including the shouldComponentUpdate() method of each child. React will still only update the DOM if the markup changes.
    /// Normally you should try to avoid all uses of forceUpdate() and only read from this.props and this.state in render().
    [<Emit("$0.forceUpdate($1)")>]
    member __.forceUpdate(?callBack: unit->unit): unit = ()

    [<Emit("$0.isMounted()")>]
    member __.isMounted(): bool = false

    /// Invoked immediately before mounting occurs. It is called before render(), therefore calling setState() synchronously in this method will not trigger an extra rendering. Generally, we recommend using the constructor() instead.
    /// Avoid introducing any side-effects or subscriptions in this method. For those use cases, use componentDidMount() instead.
    /// This is the only lifecycle hook called on server rendering.
    abstract componentWillMount: unit -> unit
    default __.componentWillMount () = ()

    /// Invoked immediately after a component is mounted. Initialization that requires DOM nodes should go here. If you need to load data from a remote endpoint, this is a good place to instantiate the network request.
    /// This method is a good place to set up any subscriptions. If you do that, don’t forget to unsubscribe in componentWillUnmount().
    /// Calling setState() in this method will trigger an extra rendering, but it is guaranteed to flush during the same tick. This guarantees that even though the render() will be called twice in this case, the user won’t see the intermediate state. Use this pattern with caution because it often causes performance issues. It can, however, be necessary for cases like modals and tooltips when you need to measure a DOM node before rendering something that depends on its size or position.
    abstract componentDidMount: unit -> unit
    default __.componentDidMount () = ()

    /// Invoked before a mounted component receives new props. If you need to update the state in response to prop changes (for example, to reset it), you may compare this.props and nextProps and perform state transitions using this.setState() in this method.
    /// Note that React may call this method even if the props have not changed, so make sure to compare the current and next values if you only want to handle changes. This may occur when the parent component causes your component to re-render.
    /// React doesn’t call componentWillReceiveProps() with initial props during mounting. It only calls this method if some of component’s props may update. Calling this.setState() generally doesn’t trigger componentWillReceiveProps().
    abstract componentWillReceiveProps: nextProps: 'P -> unit
    default __.componentWillReceiveProps (_) = ()

    /// Use shouldComponentUpdate() to let React know if a component’s output is not affected by the current change in state or props. The default behavior is to re-render on every state change, and in the vast majority of cases you should rely on the default behavior.
    /// shouldComponentUpdate() is invoked before rendering when new props or state are being received. Defaults to true. This method is not called for the initial render or when forceUpdate() is used.
    /// Returning false does not prevent child components from re-rendering when their state changes.
    /// Currently, if shouldComponentUpdate() returns false, then componentWillUpdate(), render(), and componentDidUpdate() will not be invoked. Note that in the future React may treat shouldComponentUpdate() as a hint rather than a strict directive, and returning false may still result in a re-rendering of the component.
    /// If you determine a specific component is slow after profiling, you may change it to inherit from React.PureComponent which implements shouldComponentUpdate() with a shallow prop and state comparison. If you are confident you want to write it by hand, you may compare this.props with nextProps and this.state with nextState and return false to tell React the update can be skipped.
    /// We do not recommend doing deep equality checks or using JSON.stringify() in shouldComponentUpdate(). It is very inefficient and will harm performance.
    abstract shouldComponentUpdate: nextProps: 'P * nextState: 'S -> bool
    default __.shouldComponentUpdate (_, _) = true

    /// Invoked immediately before rendering when new props or state are being received. Use this as an opportunity to perform preparation before an update occurs. This method is not called for the initial render.
    /// Note that you cannot call this.setState() here; nor should you do anything else (e.g. dispatch a Redux action) that would trigger an update to a React component before componentWillUpdate() returns.
    /// If you need to update state in response to props changes, use componentWillReceiveProps() instead.
    /// > componentWillUpdate() will not be invoked if shouldComponentUpdate() returns false.
    abstract componentWillUpdate: nextProps: 'P * nextState: 'S -> unit
    default __.componentWillUpdate (_, _) = ()

    /// Invoked immediately after updating occurs. This method is not called for the initial render.
    /// Use this as an opportunity to operate on the DOM when the component has been updated. This is also a good place to do network requests as long as you compare the current props to previous props (e.g. a network request may not be necessary if the props have not changed).
    /// > componentDidUpdate() will not be invoked if shouldComponentUpdate() returns false.
    abstract componentDidUpdate: prevProps: 'P * prevState: 'S -> unit
    default __.componentDidUpdate (_, _) = ()

    /// Invoked immediately before a component is unmounted and destroyed. Perform any necessary cleanup in this method, such as invalidating timers, canceling network requests, or cleaning up any subscriptions that were created in componentDidMount().
    abstract componentWillUnmount: unit -> unit
    default __.componentWillUnmount () = ()

    /// Error boundaries are React components that catch JavaScript errors anywhere in their child component tree, log those errors, and display a fallback UI instead of the component tree that crashed. Error boundaries catch errors during rendering, in lifecycle methods, and in constructors of the whole tree below them.
    /// A class component becomes an error boundary if it defines this lifecycle method. Calling setState() in it lets you capture an unhandled JavaScript error in the below tree and display a fallback UI. Only use error boundaries for recovering from unexpected exceptions; don’t try to use them for control flow.
    /// For more details, see [Error Handling in React 16](https://reactjs.org/blog/2017/07/26/error-handling-in-react-16.html).
    /// > Error boundaries only catch errors in the components below them in the tree. An error boundary can’t catch an error within itself.
    abstract componentDidCatch: error: Exception * info: obj -> unit
    default __.componentDidCatch (_, _) = ()

    /// This function should be pure, meaning that it does not modify component state, it returns the same result each time it’s invoked, and it does not directly interact with the browser. If you need to interact with the browser, perform your work in componentDidMount() or the other lifecycle methods instead. Keeping render() pure makes components easier to think about.
    /// > render() will not be invoked if shouldComponentUpdate() returns false.
    abstract render: unit -> ReactElement

    interface ReactElement

/// A react component that implements `shouldComponentUpdate()` with a shallow prop and state comparison.
///
/// Usage:
/// ```
/// type MyComponent(initialProps) =
///     inherit React.PureComponent<MyProps, MyState>(initialProps)
///     base.setInitState({ value = 5 })
///     override this.render() =
///         let msg = sprintf "Hello %s, you have %i €"
///                     this.props.name this.state.value
///         div [] [ofString msg]
/// ```
type [<AbstractClass; Import("PureComponent", "react")>] PureComponent<'P, 'S>(props: 'P) =
    inherit Component<'P, 'S>(props)

/// A react component that implements `shouldComponentUpdate()` with a shallow prop comparison.
///
/// Usage:
/// ```
/// type MyComponent(initialProps) =
///     inherit React.PureStatelessComponent<MyProps>(initialProps)
///     override this.render() =
///         let msg = sprintf "Hello %s, you have %i €"
///                     this.props.name this.props.value
///         div [] [ofString msg]
/// ```
type [<AbstractClass; Import("PureComponent", "react")>] PureStatelessComponent<'P>(props: 'P) =
    inherit Component<'P, obj>(props)

type FragmentProps = { key: string }

type [<Import("Fragment", "react")>] Fragment(props: FragmentProps) =
    interface ReactElement

// These are not React interfaces but we add them here in case other Fable libraries need them

type IProp =
    interface end

type IHTMLProp =
    inherit IProp

type IFragmentProp =
    inherit IProp
