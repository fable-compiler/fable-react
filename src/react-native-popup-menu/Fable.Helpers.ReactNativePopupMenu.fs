module Fable.Helpers.ReactNativePopupMenu

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
let menuContext (props:IMenuContextProperties list) (onBackdropPress: unit -> unit) (children: React.ReactElement list): React.ReactElement =
    createElement(
        BPM.MenuContext,
        JS.Object.assign(
            createObj ["onBackdropPress" ==> onBackdropPress],
            props),
        children)

/// Creates a Menu element
let menu (props:IMenuProperties list) (onSelect: obj -> unit) (children: React.ReactElement list): React.ReactElement =
    createElement(
        BPM.Menu,
        JS.Object.assign(
            createObj ["onSelect" ==> onSelect],
            props),
        children)


/// Creates a MenuTrigger element
let menuTrigger (props:IMenuTriggerProperties list) (onPress: unit -> unit) (children: React.ReactElement list): React.ReactElement =
    createElement(
        BPM.MenuTrigger,
        JS.Object.assign(
            createObj ["onPress" ==> onPress],
            props),
        children)

/// Creates a MenuOptions element
let menuOptions (props:IMenuOptionsProperties list) (children: React.ReactElement list): React.ReactElement =
    createElement(BPM.MenuOptions, props, children)

/// Creates a MenuOption element
let menuOption (props:IMenuOptionProperties list) : React.ReactElement =
    createElement(BPM.MenuOption, props, [])
