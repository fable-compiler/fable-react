module Fable.Helpers.React.TransitionGroup

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

type Timeout = {
    enter: int option
    exit: int option
}

type TransitionStatus =
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
    | Children of U2<React.ReactNode, TransitionStatus -> React.ReactNode>
    interface IProp

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
    | ClassNames of U2<string, CSSTransitionClassNames>
    interface IProp

type TransitionGroupProps =
    | Component of React.ReactType
    | ChildFactory of (React.ReactElement -> React.ReactElement)
    interface IProp

let private asNode (el: React.ReactElement): React.ReactNode =
    !^(!^el: React.ReactChild)

let transition (props: IProp list) (child: React.ReactElement): React.ReactElement =
    let props = (Children !^(asNode child) :> IProp)::props
    ofImport "Transition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

let transitionWithRender (props: IProp list) (render: TransitionStatus -> React.ReactNode): React.ReactElement =
    let props = (Children !^render :> IProp)::props
    ofImport "Transition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

let cssTransition (props: IProp list) (child: React.ReactElement): React.ReactElement =
    let props = (Children !^(asNode child) :> IProp)::props
    ofImport "CSSTransition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

let cssTransitionWithRender (props: IProp list) (render: TransitionStatus -> React.ReactNode): React.ReactElement =
    let props = (Children !^render :> IProp)::props
    ofImport "CSSTransition" "react-transition-group" (keyValueList CaseRules.LowerFirst props) []

let transitionGroup (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "TransitionGroup" "react-transition-group" (keyValueList CaseRules.LowerFirst props) children
