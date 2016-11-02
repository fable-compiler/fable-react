[<Fable.Core.Erase>]
module Fable.Helpers.ReactNativePopupMenu

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Import.ReactNativePopupMenu
type BCS = ReactNativePopupMenu.Globals

module Props =

    [<KeyValueList; RequireQualifiedAccess>]
    type MenuContextStyle =
        | Flex of int

    [<KeyValueList>]
    type IMenuContextProperties =
        interface end

    [<KeyValueList; RequireQualifiedAccess>]
    type MenuContextProperties =
    | Style of MenuContextStyle list
        interface IMenuContextProperties


open Props

/// Creates a MenuContext element
let inline menuContext (props:IMenuContextProperties list) (onBackdropPress: unit -> unit) : React.ReactElement<obj> = 
    React.createElement(
      BCS.MenuContext,
        JS.Object.assign(
            createObj ["onBackdropPress" ==> onBackdropPress],
            props)
        |> unbox,
        unbox [||]) |> unbox
