[<Fable.Core.Erase>]
/// Contains functions for push notifications via OneSignal.
module Fable.Helpers.ReactNativeOneSignal

open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeOneSignal

open Fable.Core.JsInterop

type PN = ReactNativeOneSignal.Globals

/// Contains properties for push notifications via OneSignal.
module Props =
    [<KeyValueList>]
    type IOneSignalOptions =
        interface end
        

open Props

/// Contains functions for push notifications via OneSignal.
module OneSignal =

    let x = 1