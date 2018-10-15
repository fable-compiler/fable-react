namespace Fable.Import
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

[<Erase>]
module React =
    type ReactType =
        U3<string, ComponentClass<obj>, StatelessComponent<obj>>

    and [<AllowNullLiteral>] ReactElement =
        interface end

    and ClassicElement<'P> =
        inherit ReactElement
        abstract ``type``: ClassicComponentClass<'P> with get, set
        abstract ref: U2<string, Func<ClassicComponent<'P, obj>, obj>> with get, set

    and DOMElement<'P> =
        inherit ReactElement
        abstract ``type``: string with get, set
        abstract ref: U2<string, Func<Element, obj>> with get, set

    and ReactHTMLElement =
        inherit DOMElement<HTMLProps<HTMLElement>>
        abstract ref: U2<string, Func<HTMLElement, obj>> with get, set

    and ReactSVGElement =
        inherit DOMElement<SVGProps>
        abstract ref: U2<string, Func<SVGElement, obj>> with get, set

    and Factory<'P> =
        [<Emit("$0($1...)")>] abstract Invoke: ?props: 'P * [<ParamArray>] children: ReactNode[] -> ReactElement

    and ClassicFactory<'P> =
        inherit Factory<'P>
        [<Emit("$0($1...)")>] abstract Invoke: ?props: 'P * [<ParamArray>] children: ReactNode[] -> ClassicElement<'P>

    and DOMFactory<'P> =
        inherit Factory<'P>
        [<Emit("$0($1...)")>] abstract Invoke: ?props: 'P * [<ParamArray>] children: ReactNode[] -> DOMElement<'P>

    and HTMLFactory =
        DOMFactory<HTMLProps<HTMLElement>>

    and SVGFactory =
        DOMFactory<SVGProps>

    and ReactText =
        U2<string, float>

    and ReactChild =
        U2<ReactElement, ReactText>

    and ReactFragment =
        U2<obj, ResizeArray<U3<ReactChild, ResizeArray<obj>, bool>>>

    and ReactNode =
        U3<ReactChild, ReactFragment, bool>

    and ReactInstance =
        U2<Component<obj, obj>, Element>

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
    and [<AbstractClass; Import("Component", "react")>] Component<'P,'S>(initProps: 'P) =
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
    and [<AbstractClass; Import("PureComponent", "react")>] PureComponent<'P, 'S>(props: 'P) =
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
    and [<AbstractClass; Import("PureComponent", "react")>] PureStatelessComponent<'P>(props: 'P) =
        inherit Component<'P, obj>(props)

    and FragmentProps = { key: string }

    and [<Import("Fragment", "react")>] Fragment(props: FragmentProps) =
        interface ReactElement

    and ClassicComponent<'P, 'S> =
        abstract props: 'P with get, set
        abstract state: 'S with get, set
        abstract context: obj with get, set
        abstract refs: obj with get, set
        abstract setState: f: Func<'S, 'P, 'S> * ?callback: Func<unit, obj> -> unit
        abstract setState: state: 'S * ?callback: Func<unit, obj> -> unit
        abstract forceUpdate: ?callBack: Func<unit, obj> -> unit
        abstract render: unit -> ReactElement
        abstract replaceState: nextState: 'S * ?callback: Func<unit, obj> -> unit
        abstract isMounted: unit -> bool
        abstract getInitialState: unit -> 'S

    and ChildContextProvider<'CC> =
        abstract getChildContext: unit -> 'CC

    and StatelessComponent<'P> =
        abstract propTypes: ValidationMap<'P> option with get, set
        abstract contextTypes: ValidationMap<obj> option with get, set
        abstract defaultProps: 'P option with get, set
        abstract displayName: string option with get, set
        [<Emit("$0($1...)")>] abstract Invoke: ?props: 'P * ?context: obj -> ReactElement

    and ComponentClass<'P> =
        abstract propTypes: ValidationMap<'P> option with get, set
        abstract contextTypes: ValidationMap<obj> option with get, set
        abstract childContextTypes: ValidationMap<obj> option with get, set
        abstract defaultProps: 'P option with get, set
        [<Emit("new $0($1...)")>] abstract Create: ?props: 'P * ?context: obj -> Component<'P, obj>

    and ClassicComponentClass<'P> =
        inherit ComponentClass<'P>
        abstract displayName: string option with get, set
        [<Emit("new $0($1...)")>] abstract Create: ?props: 'P * ?context: obj -> ClassicComponent<'P, obj>
        abstract getDefaultProps: unit -> 'P

    and ComponentLifecycle<'P, 'S> =
        abstract componentWillMount: unit -> unit
        abstract componentDidMount: unit -> unit
        abstract componentWillReceiveProps: nextProps: 'P * nextContext: obj -> unit
        abstract shouldComponentUpdate: nextProps: 'P * nextState: 'S * nextContext: obj -> bool
        abstract componentWillUpdate: nextProps: 'P * nextState: 'S * nextContext: obj -> unit
        abstract componentDidUpdate: prevProps: 'P * prevState: 'S * prevContext: obj -> unit
        abstract componentWillUnmount: unit -> unit

    and Mixin<'P, 'S> =
        inherit ComponentLifecycle<'P, 'S>
        abstract mixins: Mixin<'P, 'S> option with get, set
        abstract statics: obj option with get, set
        abstract displayName: string option with get, set
        abstract propTypes: ValidationMap<obj> option with get, set
        abstract contextTypes: ValidationMap<obj> option with get, set
        abstract childContextTypes: ValidationMap<obj> option with get, set
        abstract getDefaultProps: unit -> 'P
        abstract getInitialState: unit -> 'S

    and ComponentSpec<'P, 'S> =
        inherit Mixin<'P, 'S>
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: propertyName: string -> obj with get, set
        abstract render: unit -> ReactElement

    and SyntheticEvent =
        abstract bubbles: bool with get, set
        abstract cancelable: bool with get, set
        abstract currentTarget: EventTarget with get, set
        abstract defaultPrevented: bool with get, set
        abstract eventPhase: float with get, set
        abstract isTrusted: bool with get, set
        abstract nativeEvent: Event with get, set
        abstract target: EventTarget with get, set
        abstract timeStamp: DateTime with get, set
        abstract ``type``: string with get, set
        abstract preventDefault: unit -> unit
        abstract stopPropagation: unit -> unit

    and ClipboardEvent =
        inherit SyntheticEvent
        abstract clipboardData: DataTransfer with get, set

    and CompositionEvent =
        inherit SyntheticEvent
        abstract data: string with get, set

    and DragEvent =
        inherit SyntheticEvent
        abstract dataTransfer: DataTransfer with get, set

    and FocusEvent =
        inherit SyntheticEvent
        abstract relatedTarget: EventTarget with get, set

    and FormEvent =
        inherit SyntheticEvent

    and KeyboardEvent =
        inherit SyntheticEvent
        abstract altKey: bool with get, set
        abstract charCode: float with get, set
        abstract ctrlKey: bool with get, set
        abstract key: string with get, set
        abstract keyCode: float with get, set
        abstract locale: string with get, set
        abstract location: float with get, set
        abstract metaKey: bool with get, set
        abstract repeat: bool with get, set
        abstract shiftKey: bool with get, set
        abstract which: float with get, set
        abstract getModifierState: key: string -> bool

    and MouseEvent =
        inherit SyntheticEvent
        abstract altKey: bool with get, set
        abstract button: float with get, set
        abstract buttons: float with get, set
        abstract clientX: float with get, set
        abstract clientY: float with get, set
        abstract ctrlKey: bool with get, set
        abstract metaKey: bool with get, set
        abstract pageX: float with get, set
        abstract pageY: float with get, set
        abstract relatedTarget: EventTarget with get, set
        abstract screenX: float with get, set
        abstract screenY: float with get, set
        abstract shiftKey: bool with get, set
        abstract getModifierState: key: string -> bool

    and TouchEvent =
        inherit SyntheticEvent
        abstract altKey: bool with get, set
        abstract changedTouches: TouchList with get, set
        abstract ctrlKey: bool with get, set
        abstract metaKey: bool with get, set
        abstract shiftKey: bool with get, set
        abstract targetTouches: TouchList with get, set
        abstract touches: TouchList with get, set
        abstract getModifierState: key: string -> bool

    and UIEvent =
        inherit SyntheticEvent
        abstract detail: float with get, set
        abstract view: AbstractView with get, set

    and WheelEvent =
        inherit SyntheticEvent
        abstract deltaMode: float with get, set
        abstract deltaX: float with get, set
        abstract deltaY: float with get, set
        abstract deltaZ: float with get, set

    and AnimationEvent =
        inherit SyntheticEvent
        abstract animationName: string with get, set
        abstract pseudoElement: string with get, set
        abstract elapsedTime: float with get, set

    and TransitionEvent =
        inherit SyntheticEvent
        abstract propertyName: string with get, set
        abstract pseudoElement: string with get, set
        abstract elapsedTime: float with get, set

    and EventHandler<'E> = Func<'E, unit>

    and ReactEventHandler =
        EventHandler<SyntheticEvent>

    and ClipboardEventHandler =
        EventHandler<ClipboardEvent>

    and CompositionEventHandler =
        EventHandler<CompositionEvent>

    and DragEventHandler =
        EventHandler<DragEvent>

    and FocusEventHandler =
        EventHandler<FocusEvent>

    and FormEventHandler =
        EventHandler<FormEvent>

    and KeyboardEventHandler =
        EventHandler<KeyboardEvent>

    and MouseEventHandler =
        EventHandler<MouseEvent>

    and TouchEventHandler =
        EventHandler<TouchEvent>

    and UIEventHandler =
        EventHandler<UIEvent>

    and WheelEventHandler =
        EventHandler<WheelEvent>

    and AnimationEventHandler =
        EventHandler<AnimationEvent>

    and TransitionEventHandler =
        EventHandler<TransitionEvent>

    and Props<'T> =
        abstract children: ReactNode option with get, set
        abstract key: U2<string, float> option with get, set
        abstract ref: U2<string, Func<'T, obj>> option with get, set

    and HTMLProps<'T> =
        inherit HTMLAttributes
        inherit Props<'T>

    and SVGProps =
        inherit SVGAttributes
        inherit Props<SVGElement>

    and DOMAttributes =
        abstract dangerouslySetInnerHTML: obj option with get, set
        abstract onCopy: ClipboardEventHandler option with get, set
        abstract onCut: ClipboardEventHandler option with get, set
        abstract onPaste: ClipboardEventHandler option with get, set
        abstract onCompositionEnd: CompositionEventHandler option with get, set
        abstract onCompositionStart: CompositionEventHandler option with get, set
        abstract onCompositionUpdate: CompositionEventHandler option with get, set
        abstract onFocus: FocusEventHandler option with get, set
        abstract onBlur: FocusEventHandler option with get, set
        abstract onChange: FormEventHandler option with get, set
        abstract onInput: FormEventHandler option with get, set
        abstract onSubmit: FormEventHandler option with get, set
        abstract onReset: FormEventHandler option with get, set
        abstract onLoad: ReactEventHandler option with get, set
        abstract onError: ReactEventHandler option with get, set
        abstract onKeyDown: KeyboardEventHandler option with get, set
        abstract onKeyPress: KeyboardEventHandler option with get, set
        abstract onKeyUp: KeyboardEventHandler option with get, set
        abstract onAbort: ReactEventHandler option with get, set
        abstract onCanPlay: ReactEventHandler option with get, set
        abstract onCanPlayThrough: ReactEventHandler option with get, set
        abstract onDurationChange: ReactEventHandler option with get, set
        abstract onEmptied: ReactEventHandler option with get, set
        abstract onEncrypted: ReactEventHandler option with get, set
        abstract onEnded: ReactEventHandler option with get, set
        abstract onLoadedData: ReactEventHandler option with get, set
        abstract onLoadedMetadata: ReactEventHandler option with get, set
        abstract onLoadStart: ReactEventHandler option with get, set
        abstract onPause: ReactEventHandler option with get, set
        abstract onPlay: ReactEventHandler option with get, set
        abstract onPlaying: ReactEventHandler option with get, set
        abstract onProgress: ReactEventHandler option with get, set
        abstract onRateChange: ReactEventHandler option with get, set
        abstract onSeeked: ReactEventHandler option with get, set
        abstract onSeeking: ReactEventHandler option with get, set
        abstract onStalled: ReactEventHandler option with get, set
        abstract onSuspend: ReactEventHandler option with get, set
        abstract onTimeUpdate: ReactEventHandler option with get, set
        abstract onVolumeChange: ReactEventHandler option with get, set
        abstract onWaiting: ReactEventHandler option with get, set
        abstract onClick: MouseEventHandler option with get, set
        abstract onContextMenu: MouseEventHandler option with get, set
        abstract onDoubleClick: MouseEventHandler option with get, set
        abstract onDrag: DragEventHandler option with get, set
        abstract onDragEnd: DragEventHandler option with get, set
        abstract onDragEnter: DragEventHandler option with get, set
        abstract onDragExit: DragEventHandler option with get, set
        abstract onDragLeave: DragEventHandler option with get, set
        abstract onDragOver: DragEventHandler option with get, set
        abstract onDragStart: DragEventHandler option with get, set
        abstract onDrop: DragEventHandler option with get, set
        abstract onMouseDown: MouseEventHandler option with get, set
        abstract onMouseEnter: MouseEventHandler option with get, set
        abstract onMouseLeave: MouseEventHandler option with get, set
        abstract onMouseMove: MouseEventHandler option with get, set
        abstract onMouseOut: MouseEventHandler option with get, set
        abstract onMouseOver: MouseEventHandler option with get, set
        abstract onMouseUp: MouseEventHandler option with get, set
        abstract onSelect: ReactEventHandler option with get, set
        abstract onTouchCancel: TouchEventHandler option with get, set
        abstract onTouchEnd: TouchEventHandler option with get, set
        abstract onTouchMove: TouchEventHandler option with get, set
        abstract onTouchStart: TouchEventHandler option with get, set
        abstract onScroll: UIEventHandler option with get, set
        abstract onWheel: WheelEventHandler option with get, set
        abstract onAnimationStart: AnimationEventHandler option with get, set
        abstract onAnimationEnd: AnimationEventHandler option with get, set
        abstract onAnimationIteration: AnimationEventHandler option with get, set
        abstract onTransitionEnd: TransitionEventHandler option with get, set

    and CSSProperties =
        abstract alignContent: obj option with get, set
        abstract alignItems: obj option with get, set
        abstract alignSelf: obj option with get, set
        abstract alignmentAdjust: obj option with get, set
        abstract alignmentBaseline: obj option with get, set
        abstract all: obj option with get, set
        abstract animation: obj option with get, set
        abstract animationDelay: obj option with get, set
        abstract animationDirection: obj option with get, set
        abstract animationDuration: obj option with get, set
        abstract animationFillMode: obj option with get, set
        abstract animationIterationCount: obj option with get, set
        abstract animationName: obj option with get, set
        abstract animationPlayState: obj option with get, set
        abstract animationTimingFunction: obj option with get, set
        abstract appearance: obj option with get, set
        abstract backfaceVisibility: obj option with get, set
        abstract background: obj option with get, set
        abstract backgroundAttachment: obj option with get, set
        abstract backgroundBlendMode: obj option with get, set
        abstract backgroundClip: obj option with get, set
        abstract backgroundColor: obj option with get, set
        abstract backgroundComposite: obj option with get, set
        abstract backgroundImage: obj option with get, set
        abstract backgroundOrigin: obj option with get, set
        abstract backgroundPosition: obj option with get, set
        abstract backgroundPositionX: obj option with get, set
        abstract backgroundPositionY: obj option with get, set
        abstract backgroundRepeat: obj option with get, set
        abstract backgroundSize: obj option with get, set
        abstract baselineShift: obj option with get, set
        abstract behavior: obj option with get, set
        abstract blockSize: obj option with get, set
        abstract border: obj option with get, set
        abstract borderBlockEnd: obj option with get, set
        abstract borderBlockEndColor: obj option with get, set
        abstract borderBlockEndStyle: obj option with get, set
        abstract borderBlockEndWidth: obj option with get, set
        abstract borderBlockStart: obj option with get, set
        abstract borderBlockStartColor: obj option with get, set
        abstract borderBlockStartStyle: obj option with get, set
        abstract borderBlockStartWidth: obj option with get, set
        abstract borderBottom: obj option with get, set
        abstract borderBottomColor: obj option with get, set
        abstract borderBottomLeftRadius: obj option with get, set
        abstract borderBottomRightRadius: obj option with get, set
        abstract borderBottomStyle: obj option with get, set
        abstract borderBottomWidth: obj option with get, set
        abstract borderCollapse: obj option with get, set
        abstract borderColor: obj option with get, set
        abstract borderCornerShape: obj option with get, set
        abstract borderImage: obj option with get, set
        abstract borderImageOutset: obj option with get, set
        abstract borderImageRepeat: obj option with get, set
        abstract borderImageSlice: obj option with get, set
        abstract borderImageSource: obj option with get, set
        abstract borderImageWidth: obj option with get, set
        abstract borderInlineEnd: obj option with get, set
        abstract borderInlineEndColor: obj option with get, set
        abstract borderInlineEndStyle: obj option with get, set
        abstract borderInlineEndWidth: obj option with get, set
        abstract borderInlineStart: obj option with get, set
        abstract borderInlineStartColor: obj option with get, set
        abstract borderInlineStartStyle: obj option with get, set
        abstract borderInlineStartWidth: obj option with get, set
        abstract borderLeft: obj option with get, set
        abstract borderLeftColor: obj option with get, set
        abstract borderLeftStyle: obj option with get, set
        abstract borderLeftWidth: obj option with get, set
        abstract borderRadius: obj option with get, set
        abstract borderRight: obj option with get, set
        abstract borderRightColor: obj option with get, set
        abstract borderRightStyle: obj option with get, set
        abstract borderRightWidth: obj option with get, set
        abstract borderSpacing: obj option with get, set
        abstract borderStyle: obj option with get, set
        abstract borderTop: obj option with get, set
        abstract borderTopColor: obj option with get, set
        abstract borderTopLeftRadius: obj option with get, set
        abstract borderTopRightRadius: obj option with get, set
        abstract borderTopStyle: obj option with get, set
        abstract borderTopWidth: obj option with get, set
        abstract borderWidth: obj option with get, set
        abstract bottom: obj option with get, set
        abstract boxAlign: obj option with get, set
        abstract boxDecorationBreak: obj option with get, set
        abstract boxDirection: obj option with get, set
        abstract boxFlex: obj option with get, set
        abstract boxFlexGroup: obj option with get, set
        abstract boxLineProgression: obj option with get, set
        abstract boxLines: obj option with get, set
        abstract boxOrdinalGroup: obj option with get, set
        abstract boxShadow: obj option with get, set
        abstract boxSizing: obj option with get, set
        abstract breakAfter: obj option with get, set
        abstract breakBefore: obj option with get, set
        abstract breakInside: obj option with get, set
        abstract captionSide: obj option with get, set
        abstract caretColor: obj option with get, set
        abstract clear: obj option with get, set
        abstract clip: obj option with get, set
        abstract clipPath: obj option with get, set
        abstract clipRule: obj option with get, set
        abstract color: obj option with get, set
        abstract colorInterpolation: obj option with get, set
        abstract colorInterpolationFilters: obj option with get, set
        abstract colorProfile: obj option with get, set
        abstract colorRendering: obj option with get, set
        abstract columnCount: obj option with get, set
        abstract columnFill: obj option with get, set
        abstract columnGap: obj option with get, set
        abstract columnRule: obj option with get, set
        abstract columnRuleColor: obj option with get, set
        abstract columnRuleStyle: obj option with get, set
        abstract columnRuleWidth: obj option with get, set
        abstract columnSpan: obj option with get, set
        abstract columnWidth: obj option with get, set
        abstract columns: obj option with get, set
        abstract content: obj option with get, set
        abstract counterIncrement: obj option with get, set
        abstract counterReset: obj option with get, set
        abstract cue: obj option with get, set
        abstract cueAfter: obj option with get, set
        abstract cursor: obj option with get, set
        abstract direction: obj option with get, set
        abstract display: obj option with get, set
        abstract dominantBaseline: obj option with get, set
        abstract emptyCells: obj option with get, set
        abstract enableBackground: obj option with get, set
        abstract fill: obj option with get, set
        abstract fillOpacity: obj option with get, set
        abstract fillRule: obj option with get, set
        abstract filter: obj option with get, set
        abstract flex: obj option with get, set
        abstract flexAlign: obj option with get, set
        abstract flexBasis: obj option with get, set
        abstract flexDirection: obj option with get, set
        abstract flexFlow: obj option with get, set
        abstract flexGrow: obj option with get, set
        abstract flexItemAlign: obj option with get, set
        abstract flexLinePack: obj option with get, set
        abstract flexOrder: obj option with get, set
        abstract flexShrink: obj option with get, set
        abstract flexWrap: obj option with get, set
        abstract float: obj option with get, set
        abstract floodColor: obj option with get, set
        abstract floodOpacity: obj option with get, set
        abstract flowFrom: obj option with get, set
        abstract font: obj option with get, set
        abstract fontFamily: obj option with get, set
        abstract fontFeatureSettings: obj option with get, set
        abstract fontKerning: obj option with get, set
        abstract fontLanguageOverride: obj option with get, set
        abstract fontSize: obj option with get, set
        abstract fontSizeAdjust: obj option with get, set
        abstract fontStretch: obj option with get, set
        abstract fontStyle: obj option with get, set
        abstract fontSynthesis: obj option with get, set
        abstract fontVariant: obj option with get, set
        abstract fontVariantAlternates: obj option with get, set
        abstract fontVariantCaps: obj option with get, set
        abstract fontVariantEastAsian: obj option with get, set
        abstract fontVariantLigatures: obj option with get, set
        abstract fontVariantNumeric: obj option with get, set
        abstract fontVariantPosition: obj option with get, set
        abstract fontWeight: obj option with get, set
        abstract glyphOrientationHorizontal: obj option with get, set
        abstract glyphOrientationVertical: obj option with get, set
        abstract grid: obj option with get, set
        abstract gridArea: obj option with get, set
        abstract gridAutoColumns: obj option with get, set
        abstract gridAutoFlow: obj option with get, set
        abstract gridAutoRows: obj option with get, set
        abstract gridColumn: obj option with get, set
        abstract gridColumnEnd: obj option with get, set
        abstract gridColumnGap: obj option with get, set
        abstract gridColumnStart: obj option with get, set
        abstract gridGap: obj option with get, set
        abstract gridRow: obj option with get, set
        abstract gridRowEnd: obj option with get, set
        abstract gridRowGap: obj option with get, set
        abstract gridRowPosition: obj option with get, set
        abstract gridRowSpan: obj option with get, set
        abstract gridRowStart: obj option with get, set
        abstract gridTemplate: obj option with get, set
        abstract gridTemplateAreas: obj option with get, set
        abstract gridTemplateColumns: obj option with get, set
        abstract gridTemplateRows: obj option with get, set
        abstract hangingPunctuation: obj option with get, set
        abstract height: obj option with get, set
        abstract hyphenateLimitChars: obj option with get, set
        abstract hyphenateLimitLines: obj option with get, set
        abstract hyphenateLimitZone: obj option with get, set
        abstract hyphens: obj option with get, set
        abstract imageOrientation: obj option with get, set
        abstract imageRendering: obj option with get, set
        abstract imageResolution: obj option with get, set
        abstract imeMode: obj option with get, set
        abstract inlineSize: obj option with get, set
        abstract isolation: obj option with get, set
        abstract justifyContent: obj option with get, set
        abstract kerning: obj option with get, set
        abstract layoutGrid: obj option with get, set
        abstract layoutGridChar: obj option with get, set
        abstract layoutGridLine: obj option with get, set
        abstract layoutGridMode: obj option with get, set
        abstract layoutGridType: obj option with get, set
        abstract left: obj option with get, set
        abstract letterSpacing: obj option with get, set
        abstract lightingColor: obj option with get, set
        abstract lineBreak: obj option with get, set
        abstract lineClamp: obj option with get, set
        abstract lineHeight: obj option with get, set
        abstract listStyle: obj option with get, set
        abstract listStyleImage: obj option with get, set
        abstract listStylePosition: obj option with get, set
        abstract listStyleType: obj option with get, set
        abstract margin: obj option with get, set
        abstract marginBlockEnd: obj option with get, set
        abstract marginBlockStart: obj option with get, set
        abstract marginBottom: obj option with get, set
        abstract marginInlineEnd: obj option with get, set
        abstract marginInlineStart: obj option with get, set
        abstract marginLeft: obj option with get, set
        abstract marginRight: obj option with get, set
        abstract marginTop: obj option with get, set
        abstract markerEnd: obj option with get, set
        abstract markerMid: obj option with get, set
        abstract markerStart: obj option with get, set
        abstract marqueeDirection: obj option with get, set
        abstract marqueeStyle: obj option with get, set
        abstract mask: obj option with get, set
        abstract maskBorder: obj option with get, set
        abstract maskBorderRepeat: obj option with get, set
        abstract maskBorderSlice: obj option with get, set
        abstract maskBorderSource: obj option with get, set
        abstract maskBorderWidth: obj option with get, set
        abstract maskClip: obj option with get, set
        abstract maskComposite: obj option with get, set
        abstract maskImage: obj option with get, set
        abstract maskMode: obj option with get, set
        abstract maskOrigin: obj option with get, set
        abstract maskPosition: obj option with get, set
        abstract maskRepeat: obj option with get, set
        abstract maskSize: obj option with get, set
        abstract maskType: obj option with get, set
        abstract maxFontSize: obj option with get, set
        abstract maxHeight: obj option with get, set
        abstract maxWidth: obj option with get, set
        abstract minBlockSize: obj option with get, set
        abstract minHeight: obj option with get, set
        abstract minInlineSize: obj option with get, set
        abstract minWidth: obj option with get, set
        abstract mixBlendMode: obj option with get, set
        abstract objectFit: obj option with get, set
        abstract objectPosition: obj option with get, set
        abstract offsetBlockEnd: obj option with get, set
        abstract offsetBlockStart: obj option with get, set
        abstract offsetInlineEnd: obj option with get, set
        abstract offsetInlineStart: obj option with get, set
        abstract opacity: obj option with get, set
        abstract order: obj option with get, set
        abstract orphans: obj option with get, set
        abstract outline: obj option with get, set
        abstract outlineColor: obj option with get, set
        abstract outlineOffset: obj option with get, set
        abstract outlineStyle: obj option with get, set
        abstract outlineWidth: obj option with get, set
        abstract overflow: obj option with get, set
        abstract overflowStyle: obj option with get, set
        abstract overflowWrap: obj option with get, set
        abstract overflowX: obj option with get, set
        abstract overflowY: obj option with get, set
        abstract padding: obj option with get, set
        abstract paddingBlockEnd: obj option with get, set
        abstract paddingBlockStart: obj option with get, set
        abstract paddingBottom: obj option with get, set
        abstract paddingInlineEnd: obj option with get, set
        abstract paddingInlineStart: obj option with get, set
        abstract paddingLeft: obj option with get, set
        abstract paddingRight: obj option with get, set
        abstract paddingTop: obj option with get, set
        abstract pageBreakAfter: obj option with get, set
        abstract pageBreakBefore: obj option with get, set
        abstract pageBreakInside: obj option with get, set
        abstract pause: obj option with get, set
        abstract pauseAfter: obj option with get, set
        abstract pauseBefore: obj option with get, set
        abstract perspective: obj option with get, set
        abstract perspectiveOrigin: obj option with get, set
        abstract pointerEvents: obj option with get, set
        abstract position: obj option with get, set
        abstract punctuationTrim: obj option with get, set
        abstract quotes: obj option with get, set
        abstract regionFragment: obj option with get, set
        abstract resize: obj option with get, set
        abstract restAfter: obj option with get, set
        abstract restBefore: obj option with get, set
        abstract right: obj option with get, set
        abstract rubyAlign: obj option with get, set
        abstract rubyMerge: obj option with get, set
        abstract rubyPosition: obj option with get, set
        abstract scrollBehavior: obj option with get, set
        abstract scrollSnapCoordinate: obj option with get, set
        abstract scrollSnapDestination: obj option with get, set
        abstract scrollSnapType: obj option with get, set
        abstract shapeImageThreshold: obj option with get, set
        abstract shapeInside: obj option with get, set
        abstract shapeMargin: obj option with get, set
        abstract shapeOutside: obj option with get, set
        abstract shapeRendering: obj option with get, set
        abstract speak: obj option with get, set
        abstract speakAs: obj option with get, set
        abstract stopColor: obj option with get, set
        abstract stopOpacity: obj option with get, set
        abstract stroke: obj option with get, set
        abstract strokeDasharray: obj option with get, set
        abstract strokeDashoffset: obj option with get, set
        abstract strokeLinecap: obj option with get, set
        abstract strokeLinejoin: obj option with get, set
        abstract strokeMiterlimit: obj option with get, set
        abstract strokeOpacity: obj option with get, set
        abstract strokeWidth: obj option with get, set
        abstract tabSize: obj option with get, set
        abstract tableLayout: obj option with get, set
        abstract textAlign: obj option with get, set
        abstract textAlignLast: obj option with get, set
        abstract textAnchor: obj option with get, set
        abstract textCombineUpright: obj option with get, set
        abstract textDecoration: obj option with get, set
        abstract textDecorationColor: obj option with get, set
        abstract textDecorationLine: obj option with get, set
        abstract textDecorationLineThrough: obj option with get, set
        abstract textDecorationNone: obj option with get, set
        abstract textDecorationOverline: obj option with get, set
        abstract textDecorationSkip: obj option with get, set
        abstract textDecorationStyle: obj option with get, set
        abstract textDecorationUnderline: obj option with get, set
        abstract textEmphasis: obj option with get, set
        abstract textEmphasisColor: obj option with get, set
        abstract textEmphasisPosition: obj option with get, set
        abstract textEmphasisStyle: obj option with get, set
        abstract textHeight: obj option with get, set
        abstract textIndent: obj option with get, set
        abstract textJustify: obj option with get, set
        abstract textJustifyTrim: obj option with get, set
        abstract textKashidaSpace: obj option with get, set
        abstract textLineThrough: obj option with get, set
        abstract textLineThroughColor: obj option with get, set
        abstract textLineThroughMode: obj option with get, set
        abstract textLineThroughStyle: obj option with get, set
        abstract textLineThroughWidth: obj option with get, set
        abstract textOrientation: obj option with get, set
        abstract textOverflow: obj option with get, set
        abstract textOverline: obj option with get, set
        abstract textOverlineColor: obj option with get, set
        abstract textOverlineMode: obj option with get, set
        abstract textOverlineStyle: obj option with get, set
        abstract textOverlineWidth: obj option with get, set
        abstract textRendering: obj option with get, set
        abstract textScript: obj option with get, set
        abstract textShadow: obj option with get, set
        abstract textTransform: obj option with get, set
        abstract textUnderlinePosition: obj option with get, set
        abstract textUnderlineStyle: obj option with get, set
        abstract top: obj option with get, set
        abstract touchAction: obj option with get, set
        abstract transform: obj option with get, set
        abstract transformBox: obj option with get, set
        abstract transformOrigin: obj option with get, set
        abstract transformOriginZ: obj option with get, set
        abstract transformStyle: obj option with get, set
        abstract transition: obj option with get, set
        abstract transitionDelay: obj option with get, set
        abstract transitionDuration: obj option with get, set
        abstract transitionProperty: obj option with get, set
        abstract transitionTimingFunction: obj option with get, set
        abstract unicodeBidi: obj option with get, set
        abstract unicodeRange: obj option with get, set
        abstract userFocus: obj option with get, set
        abstract userInput: obj option with get, set
        abstract verticalAlign: obj option with get, set
        abstract visibility: obj option with get, set
        abstract voiceBalance: obj option with get, set
        abstract voiceDuration: obj option with get, set
        abstract voiceFamily: obj option with get, set
        abstract voicePitch: obj option with get, set
        abstract voiceRange: obj option with get, set
        abstract voiceRate: obj option with get, set
        abstract voiceStress: obj option with get, set
        abstract voiceVolume: obj option with get, set
        abstract whiteSpace: obj option with get, set
        abstract whiteSpaceTreatment: obj option with get, set
        abstract widows: obj option with get, set
        abstract width: obj option with get, set
        abstract willChange: obj option with get, set
        abstract wordBreak: obj option with get, set
        abstract wordSpacing: obj option with get, set
        abstract wordWrap: obj option with get, set
        abstract wrapFlow: obj option with get, set
        abstract wrapMargin: obj option with get, set
        abstract wrapOption: obj option with get, set
        abstract writingMode: obj option with get, set
        abstract zIndex: obj option with get, set
        abstract zoom: obj option with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: propertyName: string -> obj with get, set

    and HTMLAttributes =
        inherit DOMAttributes
        abstract defaultChecked: bool option with get, set
        abstract defaultValue: U2<string, ResizeArray<string>> option with get, set
        abstract accept: string option with get, set
        abstract acceptCharset: string option with get, set
        abstract accessKey: string option with get, set
        abstract action: string option with get, set
        abstract allowFullScreen: bool option with get, set
        abstract allowTransparency: bool option with get, set
        abstract alt: string option with get, set
        abstract async: bool option with get, set
        abstract autoComplete: string option with get, set
        abstract autoFocus: bool option with get, set
        abstract autoPlay: bool option with get, set
        abstract capture: bool option with get, set
        abstract cellPadding: U2<float, string> option with get, set
        abstract cellSpacing: U2<float, string> option with get, set
        abstract charSet: string option with get, set
        abstract challenge: string option with get, set
        abstract ``checked``: bool option with get, set
        abstract classID: string option with get, set
        abstract className: string option with get, set
        abstract cols: float option with get, set
        abstract colSpan: float option with get, set
        abstract content: string option with get, set
        abstract contentEditable: bool option with get, set
        abstract contextMenu: string option with get, set
        abstract controls: bool option with get, set
        abstract coords: string option with get, set
        abstract crossOrigin: string option with get, set
        abstract data: string option with get, set
        abstract dateTime: string option with get, set
        abstract ``default``: bool option with get, set
        abstract defer: bool option with get, set
        abstract dir: string option with get, set
        abstract disabled: bool option with get, set
        abstract download: obj option with get, set
        abstract draggable: bool option with get, set
        abstract encType: string option with get, set
        abstract form: string option with get, set
        abstract formAction: string option with get, set
        abstract formEncType: string option with get, set
        abstract formMethod: string option with get, set
        abstract formNoValidate: bool option with get, set
        abstract formTarget: string option with get, set
        abstract frameBorder: U2<float, string> option with get, set
        abstract headers: string option with get, set
        abstract height: U2<float, string> option with get, set
        abstract hidden: bool option with get, set
        abstract high: float option with get, set
        abstract href: string option with get, set
        abstract hrefLang: string option with get, set
        abstract htmlFor: string option with get, set
        abstract httpEquiv: string option with get, set
        abstract icon: string option with get, set
        abstract id: string option with get, set
        abstract inputMode: string option with get, set
        abstract integrity: string option with get, set
        abstract is: string option with get, set
        abstract keyParams: string option with get, set
        abstract keyType: string option with get, set
        abstract kind: string option with get, set
        abstract label: string option with get, set
        abstract lang: string option with get, set
        abstract list: string option with get, set
        abstract loop: bool option with get, set
        abstract low: float option with get, set
        abstract manifest: string option with get, set
        abstract marginHeight: float option with get, set
        abstract marginWidth: float option with get, set
        abstract max: U2<float, string> option with get, set
        abstract maxLength: float option with get, set
        abstract media: string option with get, set
        abstract mediaGroup: string option with get, set
        abstract ``method``: string option with get, set
        abstract min: U2<float, string> option with get, set
        abstract minLength: float option with get, set
        abstract multiple: bool option with get, set
        abstract muted: bool option with get, set
        abstract name: string option with get, set
        abstract noValidate: bool option with get, set
        abstract ``open``: bool option with get, set
        abstract optimum: float option with get, set
        abstract pattern: string option with get, set
        abstract placeholder: string option with get, set
        abstract poster: string option with get, set
        abstract preload: string option with get, set
        abstract radioGroup: string option with get, set
        abstract readOnly: bool option with get, set
        abstract rel: string option with get, set
        abstract required: bool option with get, set
        abstract role: string option with get, set
        abstract rows: float option with get, set
        abstract rowSpan: float option with get, set
        abstract sandbox: string option with get, set
        abstract scope: string option with get, set
        abstract scoped: bool option with get, set
        abstract scrolling: string option with get, set
        abstract seamless: bool option with get, set
        abstract selected: bool option with get, set
        abstract shape: string option with get, set
        abstract size: float option with get, set
        abstract sizes: string option with get, set
        abstract span: float option with get, set
        abstract spellCheck: bool option with get, set
        abstract src: string option with get, set
        abstract srcDoc: string option with get, set
        abstract srcLang: string option with get, set
        abstract srcSet: string option with get, set
        abstract start: float option with get, set
        abstract step: U2<float, string> option with get, set
        abstract style: CSSProperties option with get, set
        abstract summary: string option with get, set
        abstract tabIndex: float option with get, set
        abstract target: string option with get, set
        abstract title: string option with get, set
        abstract ``type``: string option with get, set
        abstract useMap: string option with get, set
        abstract value: U2<string, ResizeArray<string>> option with get, set
        abstract width: U2<float, string> option with get, set
        abstract wmode: string option with get, set
        abstract wrap: string option with get, set
        abstract about: string option with get, set
        abstract datatype: string option with get, set
        abstract inlist: obj option with get, set
        abstract prefix: string option with get, set
        abstract property: string option with get, set
        abstract resource: string option with get, set
        abstract typeof: string option with get, set
        abstract vocab: string option with get, set
        abstract autoCapitalize: string option with get, set
        abstract autoCorrect: string option with get, set
        abstract autoSave: string option with get, set
        abstract color: string option with get, set
        abstract itemProp: string option with get, set
        abstract itemScope: bool option with get, set
        abstract itemType: string option with get, set
        abstract itemID: string option with get, set
        abstract itemRef: string option with get, set
        abstract results: float option with get, set
        abstract security: string option with get, set
        abstract unselectable: bool option with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> obj with get, set

    and SVGAttributes =
        inherit HTMLAttributes
        abstract clipPath: string option with get, set
        abstract cx: U2<float, string> option with get, set
        abstract cy: U2<float, string> option with get, set
        abstract d: string option with get, set
        abstract dx: U2<float, string> option with get, set
        abstract dy: U2<float, string> option with get, set
        abstract fill: string option with get, set
        abstract fillOpacity: U2<float, string> option with get, set
        abstract fontFamily: string option with get, set
        abstract fontSize: U2<float, string> option with get, set
        abstract fx: U2<float, string> option with get, set
        abstract fy: U2<float, string> option with get, set
        abstract gradientTransform: string option with get, set
        abstract gradientUnits: string option with get, set
        abstract markerEnd: string option with get, set
        abstract markerMid: string option with get, set
        abstract markerStart: string option with get, set
        abstract offset: U2<float, string> option with get, set
        abstract opacity: U2<float, string> option with get, set
        abstract patternContentUnits: string option with get, set
        abstract patternUnits: string option with get, set
        abstract points: string option with get, set
        abstract preserveAspectRatio: string option with get, set
        abstract r: U2<float, string> option with get, set
        abstract rx: U2<float, string> option with get, set
        abstract ry: U2<float, string> option with get, set
        abstract spreadMethod: string option with get, set
        abstract stopColor: string option with get, set
        abstract stopOpacity: U2<float, string> option with get, set
        abstract stroke: string option with get, set
        abstract strokeDasharray: string option with get, set
        abstract strokeLinecap: string option with get, set
        abstract strokeMiterlimit: string option with get, set
        abstract strokeOpacity: U2<float, string> option with get, set
        abstract strokeWidth: U2<float, string> option with get, set
        abstract textAnchor: string option with get, set
        abstract transform: string option with get, set
        abstract version: string option with get, set
        abstract viewBox: string option with get, set
        abstract x1: U2<float, string> option with get, set
        abstract x2: U2<float, string> option with get, set
        abstract x: U2<float, string> option with get, set
        abstract xlinkActuate: string option with get, set
        abstract xlinkArcrole: string option with get, set
        abstract xlinkHref: string option with get, set
        abstract xlinkRole: string option with get, set
        abstract xlinkShow: string option with get, set
        abstract xlinkTitle: string option with get, set
        abstract xlinkType: string option with get, set
        abstract xmlBase: string option with get, set
        abstract xmlLang: string option with get, set
        abstract xmlSpace: string option with get, set
        abstract y1: U2<float, string> option with get, set
        abstract y2: U2<float, string> option with get, set
        abstract y: U2<float, string> option with get, set

    and ReactDOM =
        abstract a: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract abbr: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract address: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract area: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract article: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract aside: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract audio: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract b: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract ``base``: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract bdi: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract bdo: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract big: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract blockquote: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract body: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract br: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract button: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract canvas: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract caption: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract cite: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract code: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract col: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract colgroup: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract data: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract datalist: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract dd: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract del: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract details: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract dfn: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract dialog: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract div: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract dl: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract dt: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract em: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract embed: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract fieldset: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract figcaption: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract figure: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract footer: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract form: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract h1: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract h2: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract h3: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract h4: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract h5: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract h6: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract head: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract header: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract hgroup: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract hr: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract html: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract i: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract iframe: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract img: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract input: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract ins: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract kbd: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract keygen: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract label: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract legend: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract li: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract link: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract main: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract map: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract mark: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract menu: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract menuitem: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract meta: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract meter: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract nav: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract noscript: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract ``object``: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract ol: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract optgroup: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract option: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract output: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract p: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract param: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract picture: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract pre: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract progress: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract q: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract rp: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract rt: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract ruby: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract s: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract samp: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract script: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract section: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract select: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract small: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract source: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract span: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract strong: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract style: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract sub: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract summary: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract sup: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract table: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract tbody: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract td: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract textarea: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract tfoot: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract th: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract thead: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract time: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract title: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract tr: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract track: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract u: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract ul: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract var: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract video: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract wbr: ?props: HTMLProps<HTMLElement> * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract svg: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract circle: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract defs: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract ellipse: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract g: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract image: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract line: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract linearGradient: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract mask: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract path: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract pattern: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract polygon: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract polyline: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract radialGradient: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract rect: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract stop: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract text: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>
        abstract tspan: ?props: SVGProps * [<ParamArray>] children: ReactElement[] -> DOMElement<obj>

    and Validator<'T> =
        [<Emit("$0($1...)")>] abstract Invoke: ``object``: 'T * key: string * componentName: string -> Error

    and Requireable<'T> =
        inherit Validator<'T>
        abstract isRequired: Validator<'T> with get, set

    and ValidationMap<'T> =
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> Validator<'T> with get, set

    and ReactPropTypes =
        abstract any: Requireable<obj> with get, set
        abstract array: Requireable<obj> with get, set
        abstract bool: Requireable<obj> with get, set
        abstract func: Requireable<obj> with get, set
        abstract number: Requireable<obj> with get, set
        abstract ``object``: Requireable<obj> with get, set
        abstract string: Requireable<obj> with get, set
        abstract node: Requireable<obj> with get, set
        abstract element: Requireable<obj> with get, set
        abstract instanceOf: expectedClass: obj -> Requireable<obj>
        abstract oneOf: types: ResizeArray<obj> -> Requireable<obj>
        abstract oneOfType: types: ResizeArray<Validator<obj>> -> Requireable<obj>
        abstract arrayOf: ``type``: Validator<obj> -> Requireable<obj>
        abstract objectOf: ``type``: Validator<obj> -> Requireable<obj>
        abstract shape: ``type``: ValidationMap<obj> -> Requireable<obj>

    and ReactChildren =
        abstract map: children: ReactNode * fn: Func<ReactChild, float, 'T> -> ResizeArray<'T>
        abstract forEach: children: ReactNode * fn: Func<ReactChild, float, obj> -> unit
        abstract count: children: ReactNode -> float
        abstract only: children: ReactNode -> ReactElement
        abstract toArray: children: ReactNode -> ResizeArray<ReactChild>

    and AbstractView =
        abstract styleMedia: StyleMedia with get, set
        abstract document: Document with get, set

    and Touch =
        abstract identifier: float with get, set
        abstract target: EventTarget with get, set
        abstract screenX: float with get, set
        abstract screenY: float with get, set
        abstract clientX: float with get, set
        abstract clientY: float with get, set
        abstract pageX: float with get, set
        abstract pageY: float with get, set

    and TouchList =
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: index: float -> Touch with get, set
        abstract length: float with get, set
        abstract item: index: float -> Touch
        abstract identifiedTouch: identifier: float -> Touch

    // type Globals =
    //     member __.DOM with get(): ReactDOM = jsNative and set(v: ReactDOM): unit = jsNative
    //     member __.PropTypes with get(): ReactPropTypes = jsNative and set(v: ReactPropTypes): unit = jsNative
    //     member __.Children with get(): ReactChildren = jsNative and set(v: ReactChildren): unit = jsNative
    //     member __.createClass(spec: ComponentSpec<'P, 'S>): ClassicComponentClass<'P> = jsNative
    //     member __.createFactory(``type``: string): DOMFactory<'P> = jsNative
    //     member __.createFactory(``type``: ClassicComponentClass<'P>): ClassicFactory<'P> = jsNative
    //     member __.createFactory(``type``: U2<ComponentClass<'P>, StatelessComponent<'P>>): Factory<'P> = jsNative
    //     member __.createElement(``type``: string, props: 'P, [<ParamArray>] children: ReactNode[]): DOMElement<'P> = jsNative
    //     member __.createElement(``type``: ClassicComponentClass<'P>, props: 'P, [<ParamArray>] children: ReactNode[]): ClassicElement<'P> = jsNative
    //     member __.createElement(``type``: U2<ComponentClass<'P>, StatelessComponent<'P>>, props: 'P, [<ParamArray>] children: ReactNode[]): ReactElement = jsNative
    //     member __.createElement(``type``: #ComponentClass<'P>, props: 'P, [<ParamArray>] children: ReactNode[]): ReactElement = jsNative
    //     member __.cloneElement(element: DOMElement<'P>, props: 'P, [<ParamArray>] children: ReactNode[]): DOMElement<'P> = jsNative
    //     member __.cloneElement(element: ClassicElement<'P>, props: 'P, [<ParamArray>] children: ReactNode[]): ClassicElement<'P> = jsNative
    //     member __.cloneElement(element: ReactElement, props: 'P, [<ParamArray>] children: ReactNode[]): ReactElement = jsNative
    //     member __.isValidElement(``object``: obj): bool = jsNative

open React

[<Erase>]
type ReactDom =
    /// Render a React element into the DOM in the supplied container.
    /// If the React element was previously rendered into container, this will perform an update on it and only mutate the DOM as necessary to reflect the latest React element.
    /// If the optional callback is provided, it will be executed after the component is rendered or updated.
    [<Import("render", "react-dom")>]
    static member render(element: ReactElement, container: Element, ?callback: unit->unit): unit = jsNative

    /// Same as render(), but is used to hydrate a container whose HTML contents were rendered by ReactDOMServer. React will attempt to attach event listeners to the existing markup.
    [<Import("hydrate", "react-dom")>]
    static member hydrate(element: ReactElement, container: Element, ?callback: unit->unit): unit = jsNative

    /// Remove a mounted React component from the DOM and clean up its event handlers and state. If no component was mounted in the container, calling this function does nothing. Returns true if a component was unmounted and false if there was no component to unmount.
    [<Import("unmountComponentAtNode", "react-dom")>]
    static member unmountComponentAtNode(container: Element): bool = jsNative

    /// Creates a portal. Portals provide a way to render children into a DOM node that exists outside the hierarchy of the DOM component.
    [<Import("createPortal", "react-dom")>]
    static member createPortal(child: ReactElement, container: Element): ReactElement = jsNative

#if !FABLE_REPL_LIB
[<Import("default", "react-dom/server")>]
module ReactDomServer =
    /// Render a React element to its initial HTML. This should only be used on the server. React will return an HTML string. You can use this method to generate HTML on the server and send the markup down on the initial request for faster page loads and to allow search engines to crawl your pages for SEO purposes.
    /// If you call ReactDOM.render() on a node that already has this server-rendered markup, React will preserve it and only attach event handlers, allowing you to have a very performant first-load experience.
    let renderToString(element: ReactElement): string = jsNative

    /// Similar to renderToString, except this doesn't create extra DOM attributes such as data-reactid, that React uses internally. This is useful if you want to use React as a simple static page generator, as stripping away the extra attributes can save lots of bytes.
    let renderToStaticMarkup(element: ReactElement): string = jsNative
#endif