module Fable.Helpers.ReactNativePopupMenu

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Import.ReactNative
open Fable.Helpers.ReactNative.Props
open Fable.Helpers.ReactNative
open Fable.Import.ReactNativePopupMenu
module R = Fable.Helpers.React
type BPM = ReactNativePopupMenu.Globals

module Props =

    type IMenuContextProperties =
        inherit IViewProperties

    type MenuContextProperties =
        | Style of IStyle list
        interface IMenuContextProperties

    type IMenuProperties =
        interface end

    type MenuProperties =
        | Opened of bool
        interface IMenuProperties

    type IMenuTriggerProperties =
        interface end

    type MenuTriggerProperties =
        | Text of string
        interface IMenuTriggerProperties

    type IMenuOptionsProperties =
        interface end

    type MenuOptionsProperties =
        inherit IMenuOptionsProperties

    type IMenuOptionProperties =
        interface end

    type MenuOptionProperties =
        | Value of int
        | Text of string
        interface IMenuOptionProperties
open Props

/// Creates a MenuContext element
let inline menuContext (props:IMenuContextProperties list) (onBackdropPress: unit -> unit) (children: React.ReactElement list): React.ReactElement =
    R.from
        BPM.MenuContext
        !!(JS.Object.assign(
            createObj ["onBackdropPress" ==> onBackdropPress],
            keyValueList CaseRules.LowerFirst props))
        children

/// Creates a Menu element
let inline menu (props:IMenuProperties list) (onSelect: obj -> unit) (children: React.ReactElement list): React.ReactElement =
    R.from
        BPM.Menu
        !!(JS.Object.assign(
            createObj ["onSelect" ==> onSelect],
            keyValueList CaseRules.LowerFirst props))
        children


/// Creates a MenuTrigger element
let inline menuTrigger (props:IMenuTriggerProperties list) (onPress: unit -> unit) (children: React.ReactElement list): React.ReactElement =
    R.from
        BPM.MenuTrigger
        !!(JS.Object.assign(
            createObj ["onPress" ==> onPress],
            keyValueList CaseRules.LowerFirst props))
        children

/// Creates a MenuOptions element
let inline menuOptions (props:IMenuOptionsProperties list) (children: React.ReactElement list): React.ReactElement =
    R.from BPM.MenuOptions !!(keyValueList CaseRules.LowerFirst props) children

/// Creates a MenuOption element
let inline menuOption (props:IMenuOptionProperties list) : React.ReactElement =
    R.from BPM.MenuOption !!(keyValueList CaseRules.LowerFirst props) []
