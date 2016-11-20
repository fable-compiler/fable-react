namespace Fable.Import
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

[<Erase>]
module React =
    type ReactElement =
        interface end

    type ComponentClass<'P> =
        interface end

    [<AbstractClass; Import("Component", "react")>]
    type Component<[<Pojo>]'P, [<Pojo>]'S>(props: 'P) =
        [<Emit("$0.props")>]
        member __.props: 'P = jsNative
        [<Emit("$0.props.children")>]
        member __.children: ReactElement array = jsNative
        [<Emit("$0.state")>]
        member __.state: 'S = jsNative
        [<Emit("$0.setState($1)")>]
        member __.setState(value: 'S): unit = jsNative
        [<Emit("this.state = $1")>]
        /// This method can only be called in the constructor
        member __.setInitState(value: 'S): unit = jsNative
        interface ReactElement

    type SyntheticEvent =
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

    and AbstractView =
        abstract styleMedia: StyleMedia with get, set
        abstract document: Document with get, set

module ReactDom =
    open React


    [<Import("render", "react-dom")>]
    let render(element: ReactElement, container: Element): unit = jsNative
