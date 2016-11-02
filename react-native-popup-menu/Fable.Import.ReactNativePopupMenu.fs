namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

module ReactNativePopupMenu =

    type MenuContextProperties =
        inherit React.Props<MenuContextStatic>
        
    and MenuContextStatic =
        inherit React.ComponentClass<MenuContextProperties>

    and MenuContext =
        MenuContextStatic

    type Globals =
        [<Import("MenuContext", "react-native--popup-menu")>] static member MenuContext with get(): MenuContextStatic = failwith "JS only" and set(v: MenuContextStatic): unit = failwith "JS only"

