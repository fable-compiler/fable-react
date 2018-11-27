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

    type TransitionProps =
        | In of bool
        | Appear of bool
        | Enter of bool
        | Exit of bool
        | MountOnEnter of bool
        | UnmountOnExit of bool
        | Timeout of U2<int, Timeout>
        | AddEndListener of (Browser.HTMLElement -> (unit -> unit) -> unit)
        | OnEnter of (Browser.HTMLElement -> bool -> unit)
        | OnEntering of (Browser.HTMLElement -> bool -> unit)
        | OnEntered of (Browser.HTMLElement -> bool -> unit)
        | OnExit of (Browser.HTMLElement -> unit)
        | OnExiting of (Browser.HTMLElement -> unit)
        | OnExited of (Browser.HTMLElement -> unit)
        | Children of U2<React.ReactNode, (TransitionStatus -> React.ReactNode)>
        | Ref of (obj -> obj)
        | Key of string
        static member Custom(key: string, value: obj): TransitionProps =
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

    type CSSTransitionProps =
        | In of bool
        | Appear of bool
        | Enter of bool
        | Exit of bool
        | MountOnEnter of bool
        | UnmountOnExit of bool
        | Timeout of U2<int, Timeout>
        | AddEndListener of (Browser.HTMLElement -> (unit -> unit) -> unit)
        | OnEnter of (Browser.HTMLElement -> bool -> unit)
        | OnEntering of (Browser.HTMLElement -> bool -> unit)
        | OnEntered of (Browser.HTMLElement -> bool -> unit)
        | OnExit of (Browser.HTMLElement -> unit)
        | OnExiting of (Browser.HTMLElement -> unit)
        | OnExited of (Browser.HTMLElement -> unit)
        | Children of U2<React.ReactNode, TransitionStatus -> React.ReactNode>
        | ClassNames of U2<string, CSSTransitionClassNames>
        | Ref of (obj -> obj)
        | Key of string
        static member Custom(key: string, value: obj): CSSTransitionProps =
            unbox(key, value)

    type TransitionGroupProps =
        | Component of React.ReactType
        | ChildFactory of (React.ReactElement -> React.ReactElement)
        | Ref of (obj -> obj)
        | Key of string
        static member Custom(key: string, value: obj): TransitionGroupProps =
            unbox(key, value)

    let private asNode (el: React.ReactElement): React.ReactNode =
        !^(!^el: React.ReactChild)

    let transition (props: TransitionProps list) (child: React.ReactElement): React.ReactElement =
        let props = (TransitionProps.Children !^(asNode child))::props
        ofImport "Transition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    let transitionWithRender (props: TransitionProps list) (render: TransitionStatus -> React.ReactNode): React.ReactElement =
        let props = (TransitionProps.Children !^render)::props
        ofImport "Transition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    let cssTransition (props: CSSTransitionProps list) (child: React.ReactElement): React.ReactElement =
        let props = (CSSTransitionProps.Children !^(asNode child))::props
        ofImport "CSSTransition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    let cssTransitionWithRender (props: CSSTransitionProps list) (render: TransitionStatus -> React.ReactNode): React.ReactElement =
        let props = (CSSTransitionProps.Children !^render)::props
        ofImport "CSSTransition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    let transitionGroup (props: TransitionGroupProps list) (children: React.ReactElement list): React.ReactElement =
        ofImport "TransitionGroup" "react-transition-group" (keyValueList CaseRules.LowerFirst props) children
