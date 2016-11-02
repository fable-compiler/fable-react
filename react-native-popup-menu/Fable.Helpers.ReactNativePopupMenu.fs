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

    [<KeyValueList>]
    type IMenuTriggerProperties =
        interface end

    [<KeyValueList>]
    type MenuTriggerProperties =
        | Text of string
        interface IMenuTriggerProperties
        
    [<KeyValueList>]
    type IMenuOptionsProperties =
        interface end

    [<KeyValueList>]
    type MenuOptionsProperties =
        inherit IMenuOptionsProperties

    [<KeyValueList>]
    type IMenuOptionProperties =
        interface end

    [<KeyValueList>]
    type MenuOptionProperties =
        | Value of int
        | Text of string
        interface IMenuOptionProperties
open Props

/// Creates a MenuContext element
let inline menuContext (props:IMenuContextProperties list) (onBackdropPress: unit -> unit) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      BPM.MenuContext,
        JS.Object.assign(
            createObj ["onBackdropPress" ==> onBackdropPress],
            props)
        |> unbox,
        unbox(List.toArray children)) |> unbox

/// Creates a Menu element
let inline menu (props:IMenuProperties list) (onSelect: obj -> unit) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      BPM.Menu,
        JS.Object.assign(
            createObj ["onSelect" ==> onSelect],
            props)
        |> unbox,
        unbox(List.toArray children)) |> unbox
        

/// Creates a MenuTrigger element
let inline menuTrigger (props:IMenuTriggerProperties list) (onPress: unit -> unit) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      BPM.MenuTrigger,
        JS.Object.assign(
            createObj ["onPress" ==> onPress],
            props)
        |> unbox,
        unbox(List.toArray children)) |> unbox

/// Creates a MenuOptions element
let inline menuOptions (props:IMenuOptionsProperties list) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      BPM.MenuOptions,
        props |> unbox,
        unbox(List.toArray children)) |> unbox


/// Creates a MenuOption element
let inline menuOption (props:IMenuOptionProperties list) : React.ReactElement<obj> = 
    React.createElement(
      BPM.MenuOption,
        props |> unbox,
        unbox [||]) |> unbox
        