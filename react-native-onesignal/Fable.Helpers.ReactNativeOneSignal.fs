[<Fable.Core.Erase>]
/// Contains functions for push notifications via OneSignal.
module Fable.Helpers.ReactNativeOneSignal

open System
open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeOneSignal

open Fable.Core.JsInterop

/// Contains properties for push notifications via OneSignal.
module Props =

    [<KeyValueList>]
    type OneSignalID =
    | UserId of string
    | PushToke of string

    [<KeyValueList>]
    type IOneSignalOptions =
        interface end

    [<KeyValueList>]
    type OneSignalOptions =
    | OnIdsAvailable of (OneSignalID -> unit)
    | OnNotificationOpened of Func<string,obj,bool,unit>
        interface IOneSignalOptions

open Props

/// Contains functions for push notifications via OneSignal.
module OneSignal =

    /// Configures the push notification system.
    let inline configure (props: IOneSignalOptions list) =
        ReactNativeOneSignal.Globals.OneSignal?configure(props |> unbox) |> ignore