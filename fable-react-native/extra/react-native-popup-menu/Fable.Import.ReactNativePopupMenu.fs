namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

[<Erase>]
module ReactNativePopupMenu =

    type MenuContextProperties =
        inherit React.Props<MenuContextStatic>

    and MenuContextStatic =
        inherit React.ComponentClass<MenuContextProperties>

    and MenuContext =
        MenuContextStatic

    and MenuProperties =
        inherit React.Props<MenuStatic>

    and MenuStatic =
        inherit React.ComponentClass<MenuProperties>

    and Menu =
        MenuStatic

    and MenuTriggerProperties =
        inherit React.Props<MenuTriggerStatic>

    and MenuTriggerStatic =
        inherit React.ComponentClass<MenuTriggerProperties>

    and MenuTrigger =
        MenuTriggerStatic

    and MenuOptionsProperties =
        inherit React.Props<MenuOptionsStatic>

    and MenuOptionsStatic =
        inherit React.ComponentClass<MenuOptionsProperties>

    and MenuOptions =
        MenuOptionsStatic

    and MenuOptionProperties =
        inherit React.Props<MenuOptionStatic>

    and MenuOptionStatic =
        inherit React.ComponentClass<MenuOptionProperties>

    and MenuOption =
        MenuOptionStatic

    type Globals =
        [<Import("MenuContext", "react-native-popup-menu")>] static member MenuContext with get(): MenuContextStatic = failwith "JS only" and set(v: MenuContextStatic): unit = failwith "JS only"
        [<Import("default", "react-native-popup-menu")>] static member Menu with get(): MenuStatic = failwith "JS only" and set(v: MenuStatic): unit = failwith "JS only"
        [<Import("MenuTrigger", "react-native-popup-menu")>] static member MenuTrigger with get(): MenuTriggerStatic = failwith "JS only" and set(v: MenuTriggerStatic): unit = failwith "JS only"
        [<Import("MenuOptions", "react-native-popup-menu")>] static member MenuOptions with get(): MenuOptionsStatic = failwith "JS only" and set(v: MenuOptionsStatic): unit = failwith "JS only"

        [<Import("MenuOption", "react-native-popup-menu")>] static member MenuOption with get(): MenuOptionStatic = failwith "JS only" and set(v: MenuOptionStatic): unit = failwith "JS only"


