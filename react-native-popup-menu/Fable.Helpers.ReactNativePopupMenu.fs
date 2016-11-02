[<Fable.Core.Erase>]
module internal Fable.Helpers.ReactNativePopupMenu

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Import.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Helpers.ReactNative
open Fable.Import.ReactNativePopupMenu
type BPM = ReactNativePopupMenu.Globals

module Props =

    [<KeyValueList>]
    type IMenuContextProperties =
        inherit IViewProperties

    [<KeyValueList>]
    type MenuContextProperties =
        | Style of IStyle list
        interface IMenuContextProperties

    [<KeyValueList>]
    type IMenuProperties =
        interface end

    [<KeyValueList>]
    type MenuProperties =
        | Opened of bool
        interface IMenuProperties


open Props

/// Creates a MenuContext element
let inline menuContext (props:IMenuContextProperties list) (onBackdropPress: unit -> unit) children : React.ReactElement<obj> = 
    React.createElement(
      BPM.MenuContext,
        JS.Object.assign(
            createObj ["onBackdropPress" ==> onBackdropPress],
            props)
        |> unbox,
        unbox children) |> unbox

/// Creates a Menu element
let inline menu (props:IMenuProperties list) (onSelect: obj -> unit) children : React.ReactElement<obj> = 
    React.createElement(
      BPM.Menu,
        JS.Object.assign(
            createObj ["onSelect" ==> onSelect],
            props)
        |> unbox,
        unbox children) |> unbox
        
