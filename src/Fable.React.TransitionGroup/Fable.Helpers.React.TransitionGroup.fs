namespace Fable.Helpers.React

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React

module TransitionGroup =
    type Timeout = {
        enter: int option
        exit: int option
    }

    type [<StringEnum>] TransitionStatus =
        | [<CompiledName("entering")>] Entering
        | [<CompiledName("entered")>] Entered
        | [<CompiledName("exiting")>] Exiting
        | [<CompiledName("exited")>] Exited
        | [<CompiledName("unmounted")>] Unmounted

    [<RequireQualifiedAccess>]
    type TransitionProp =
        /// Show the element; triggers the `enter` or `exit` states
        | In of bool
        /// Normally a element is not transitioned if it is shown when the `transition` element mounts.
        /// If you want to transition on the first mount set appear to true,
        /// and the element will transition in as soon as the `transition` mounts.
        | Appear of bool
        /// Enable or disable enter transitions.
        | Enter of bool
        /// Enable or disable exit transitions.
        | Exit of bool
        /// By default the child element is mounted immediately along with the parent `transition` element.
        /// If you want to "lazy mount" the element on the first `In true` you can set `MountOnEnter`.
        /// After the first enter transition the element will stay mounted, even on `exited`, unless you also specify `UnmountOnExit`.
        | MountOnEnter of bool
        /// By default the child element stays mounted after it reaches the `exited` state.
        /// Set `UnmountOnExit` if you'd prefer to unmount the element after it finishes exiting.
        | UnmountOnExit of bool
        /// The duration of the transition, in milliseconds. Required unless `AddEndListener` is provided
        | Timeout of U2<int, Timeout>
        /// Add a custom transition end trigger.
        /// Called with the transitioning DOM node and a done callback.
        /// Allows for more fine grained transition end logic.
        /// Note: Timeouts are still used as a fallback if provided.
        | AddEndListener of (Browser.HTMLElement -> (unit -> unit) -> unit)
        /// A transition callback fired immediately after the `enter` or `appear` class is applied.
        | OnEnter of (Browser.HTMLElement -> bool -> unit)
        /// A transition callback fired immediately after the `enter-active` or `appear-active` class is applied.
        | OnEntering of (Browser.HTMLElement -> bool -> unit)
        /// A transition callback fired immediately after the `enter` or `appear` classes are removed and the done class is added to the DOM node.
        | OnEntered of (Browser.HTMLElement -> bool -> unit)
        /// A transition callback fired immediately after the `exit` class is applied.
        | OnExit of (Browser.HTMLElement -> unit)
        /// A transition callback fired immediately after the `exit-active` is applied.
        | OnExiting of (Browser.HTMLElement -> unit)
        /// A transition callback fired immediately after the `exit` classes are removed and the exit-done class is added to the DOM node.
        | OnExited of (Browser.HTMLElement -> unit)
        /// A function child can be used instead of a React element.
        /// This function is called with the current transition status
        /// (`entering`, `entered`, `exiting`, `exited`, `unmounted`),
        /// which can be used to apply context specific props to a element.
        | Children of U2<React.ReactElement, TransitionStatus -> React.ReactElement>
        | [<CompiledName "className">] Class of string
        | Ref of (obj -> obj)
        | Key of string
        static member Custom(key: string, value: obj): TransitionProp =
            unbox(key, value)

    type CSSTransitionClassNames = {
        appear: string option
        appearActive: string option
        enter: string option
        enterActive: string option
        enterDone: string option
        exit: string option
        exitActive: string option
        exitDone: string option
    }

    [<RequireQualifiedAccess>]
    type CSSTransitionProp =
        /// Show the element; triggers the `enter` or `exit` states
        | In of bool
        /// Normally a element is not transitioned if it is shown when the `transition` element mounts.
        /// If you want to transition on the first mount set appear to true,
        /// and the element will transition in as soon as the `transition` mounts.
        | Appear of bool
        /// Enable or disable enter transitions.
        | Enter of bool
        /// Enable or disable exit transitions.
        | Exit of bool
        /// By default the child element is mounted immediately along with the parent `transition` element.
        /// If you want to "lazy mount" the element on the first `In true` you can set `MountOnEnter`.
        /// After the first enter transition the element will stay mounted, even on `exited`, unless you also specify `UnmountOnExit`.
        | MountOnEnter of bool
        /// By default the child element stays mounted after it reaches the `exited` state.
        /// Set `UnmountOnExit` if you'd prefer to unmount the element after it finishes exiting.
        | UnmountOnExit of bool
        /// The duration of the transition, in milliseconds. Required unless `AddEndListener` is provided
        | Timeout of U2<int, Timeout>
        /// Add a custom transition end trigger.
        /// Called with the transitioning DOM node and a done callback.
        /// Allows for more fine grained transition end logic.
        /// Note: Timeouts are still used as a fallback if provided.
        | AddEndListener of (Browser.HTMLElement -> (unit -> unit) -> unit)
        /// A transition callback fired immediately after the `enter` or `appear` class is applied.
        | OnEnter of (Browser.HTMLElement -> bool -> unit)
        /// A transition callback fired immediately after the `enter-active` or `appear-active` class is applied.
        | OnEntering of (Browser.HTMLElement -> bool -> unit)
        /// A transition callback fired immediately after the `enter` or `appear` classes are removed and the done class is added to the DOM node.
        | OnEntered of (Browser.HTMLElement -> bool -> unit)
        /// A transition callback fired immediately after the `exit` class is applied.
        | OnExit of (Browser.HTMLElement -> unit)
        /// A transition callback fired immediately after the `exit-active` is applied.
        | OnExiting of (Browser.HTMLElement -> unit)
        /// A transition callback fired immediately after the `exit` classes are removed and the exit-done class is added to the DOM node.
        | OnExited of (Browser.HTMLElement -> unit)
        /// A function child can be used instead of a React element.
        /// This function is called with the current transition status
        /// (`entering`, `entered`, `exiting`, `exited`, `unmounted`),
        /// which can be used to apply context specific props to a element.
        | Children of U2<React.ReactElement, TransitionStatus -> React.ReactElement>
        /// The animation ClassNames applied to the element as it enters or exits.
        /// A single name can be provided and it will be suffixed for each stage: e.g.
        ///
        /// `classNames="fade"` applies `fade-enter`, `fade-enter-active`,
        /// `fade-exit`, `fade-exit-active`, `fade-appear`, and `fade-appear-active`.
        /// Each individual classNames can also be specified independently.
        | ClassNames of U2<string, CSSTransitionClassNames>
        | [<CompiledName "className">] Class of string
        | Ref of (obj -> obj)
        | Key of string
        static member Custom(key: string, value: obj): CSSTransitionProp =
            unbox(key, value)

    [<RequireQualifiedAccess>]
    type TransitionGroupProp =
        /// `transitionGroup` renders a <div> by default.
        /// You can change this behavior by providing a component prop.
        /// If you use React v16+ and would like to avoid a wrapping <div> element you can pass in `Component null`.
        /// This is useful if the wrapping div borks your css styles.
        | Component of React.ReactType
        /// You may need to apply reactive updates to a child as it is exiting.
        /// This is generally done by using cloneElement however in the case of an
        /// exiting child the element has already been removed and not accessible to the consumer.
        | ChildFactory of (React.ReactElement -> React.ReactElement)
        | [<CompiledName "className">] Class of string
        | Ref of (obj -> obj)
        | Key of string
        static member Custom(key: string, value: obj): TransitionGroupProp =
            unbox(key, value)

    /// The transition element lets you describe a transition from one element
    /// state to another _over time_ with a simple declarative API. Most commonly
    /// It's used to animate the mounting and unmounting of Component, but can also
    /// be used to describe in-place transition states as well.
    ///
    /// By default the `transition` element does not alter the behavior of the
    /// element it renders, it only tracks Enter and Exit states for the elements.
    /// It's up to you to give meaning and effect to those states. For example we can
    /// add styles to a element when it enters or exits.
    let transition (props: TransitionProp list) (child: React.ReactElement): React.ReactElement =
        let props = (TransitionProp.Children !^child)::props
        ofImport "Transition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    /// The transition element lets you describe a transition from one component
    /// state to another _over time_ with a simple declarative API. Most commonly
    /// It's used to animate the mounting and unmounting of Component, but can also
    /// be used to describe in-place transition states as well.
    ///
    /// By default the `transition` element does not alter the behavior of the
    /// element it renders, it only tracks Enter and Exit states for the elements.
    /// It's up to you to give meaning and effect to those states. For example we can
    /// add styles to a element when it enters or exits.
    let transitionWithRender (props: TransitionProp list) (render: TransitionStatus -> React.ReactElement): React.ReactElement =
        let props = (TransitionProp.Children !^render)::props
        ofImport "Transition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    /// A transition element using CSS transitions and animations.
    /// See `transition` for more information.
    let cssTransition (props: CSSTransitionProp list) (child: React.ReactElement): React.ReactElement =
        let props = (CSSTransitionProp.Children !^child)::props
        ofImport "CSSTransition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    /// A transition element using CSS transitions and animations.
    /// See `transitionWithRender` for more information.
    let cssTransitionWithRender (props: CSSTransitionProp list) (render: TransitionStatus -> React.ReactElement): React.ReactElement =
        let props = (CSSTransitionProp.Children !^render)::props
        ofImport "CSSTransition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    /// The `transitionGroup` element manages a set of `transition` elements
    /// in a list. Like with the `transition` element, `transitionGroup`, is a
    /// state machine for managing the mounting and unmounting of elements over
    /// time.
    let transitionGroup (props: TransitionGroupProp list) (children: React.ReactElement list): React.ReactElement =
        ofImport "TransitionGroup" "react-transition-group" (keyValueList CaseRules.LowerFirst props) children
