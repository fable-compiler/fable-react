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


    /// Enables In-App Alert Notifications.
    /// By default this is false and notifications will not be shown when the user is in the app, instead the OneSignalHandleNotificationBlock is fired. 
    /// If set to true notifications will be shown as native alert boxes if a notification is received when the user is in your app. 
    /// The OneSignalHandleNotificationBlock is then fired after the alert box is closed.
    let inline enableInAppAlertNotification () =
        ReactNativeOneSignal.Globals.OneSignal?enableInAppAlertNotification(true) |> ignore

    /// Disables In-App Alert Notifications.
    /// By default this is false and notifications will not be shown when the user is in the app, instead the OneSignalHandleNotificationBlock is fired. 
    /// If set to true notifications will be shown as native alert boxes if a notification is received when the user is in your app. 
    /// The OneSignalHandleNotificationBlock is then fired after the alert box is closed.
    let inline disableInAppAlertNotification () =
        ReactNativeOneSignal.Globals.OneSignal?enableInAppAlertNotification(false) |> ignore        