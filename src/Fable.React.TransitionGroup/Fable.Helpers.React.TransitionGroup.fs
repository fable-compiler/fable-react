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
        | Children of U2<React.ReactElement, (TransitionStatus -> React.ReactElement)>
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
        | Children of U2<React.ReactElement, TransitionStatus -> React.ReactElement>
        | ClassNames of U2<string, CSSTransitionClassNames>
        | [<CompiledName "className">] Class of string
        | Ref of (obj -> obj)
        | Key of string
        static member Custom(key: string, value: obj): CSSTransitionProp =
            unbox(key, value)

    [<RequireQualifiedAccess>]
    type TransitionGroupProp =
        | Component of React.ReactType
        | ChildFactory of (React.ReactElement -> React.ReactElement)
        | [<CompiledName "className">] Class of string
        | Ref of (obj -> obj)
        | Key of string
        static member Custom(key: string, value: obj): TransitionGroupProp =
            unbox(key, value)

    let transition (props: TransitionProp list) (child: React.ReactElement): React.ReactElement =
        let props = (TransitionProp.Children !^child)::props
        ofImport "Transition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    let transitionWithRender (props: TransitionProp list) (render: TransitionStatus -> React.ReactElement): React.ReactElement =
        let props = (TransitionProp.Children !^render)::props
        ofImport "Transition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    let cssTransition (props: CSSTransitionProp list) (child: React.ReactElement): React.ReactElement =
        let props = (CSSTransitionProp.Children !^child)::props
        ofImport "CSSTransition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    let cssTransitionWithRender (props: CSSTransitionProp list) (render: TransitionStatus -> React.ReactElement): React.ReactElement =
        let props = (CSSTransitionProp.Children !^render)::props
        ofImport "CSSTransition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

    let transitionGroup (props: TransitionGroupProp list) (children: React.ReactElement list): React.ReactElement =
        ofImport "TransitionGroup" "react-transition-group" (keyValueList CaseRules.LowerFirst props) children
