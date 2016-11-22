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
    | OnNotificationOpened of Func<string,OneSignalNotificationData,bool,unit>
        interface IOneSignalOptions

open Props

/// Contains functions for push notifications via OneSignal.
module OneSignal =

    /// Configures the push notification system.
    let inline configure (props: IOneSignalOptions list) =
        ReactNativeOneSignal.Globals.OneSignal?configure(props |> unbox) |> ignore


    /// Enables In-App alert notifications.
    /// By default this is false and notifications will not be shown when the user is in the app, instead the OneSignalHandleNotificationBlock is fired. 
    /// If activated notifications will be shown as native alert boxes if a notification is received when the user is in your app. 
    /// The OneSignalHandleNotificationBlock is then fired after the alert box is closed.
    let inline enableInAppAlertNotification () =
        ReactNativeOneSignal.Globals.OneSignal?enableInAppAlertNotification(true |> unbox) |> ignore

    /// Disables In-App alert notifications.
    /// By default this is false and notifications will not be shown when the user is in the app, instead the OneSignalHandleNotificationBlock is fired. 
    /// If activated notifications will be shown as native alert boxes if a notification is received when the user is in your app. 
    /// The OneSignalHandleNotificationBlock is then fired after the alert box is closed.
    let inline disableInAppAlertNotification () =
        ReactNativeOneSignal.Globals.OneSignal?enableInAppAlertNotification(false |> unbox) |> ignore

    /// Enables notifications when App is active.
    /// By default this is false and notifications will not be shown when the user is in your app, instead the NotificationOpenedHandler is fired. 
    /// If activated notifications will always show in the notification area and NotificationOpenedHandler will not fire until the user taps on the notification.
    let inline enableNotificationsWhenActive () =
        ReactNativeOneSignal.Globals.OneSignal?enableNotificationsWhenActive(true |> unbox) |> ignore

    /// Disables notifications when App is active.
    /// By default this is false and notifications will not be shown when the user is in your app, instead the NotificationOpenedHandler is fired. 
    /// If activated notifications will always show in the notification area and NotificationOpenedHandler will not fire until the user taps on the notification.
    let inline disableNotificationsWhenActive () =
        ReactNativeOneSignal.Globals.OneSignal?enableNotificationsWhenActive(false |> unbox) |> ignore

    /// Enables sound.
    /// You can call this from your UI from a button press for example to give your user's options for your notifications. 
    /// By default OneSignal plays the system's default notification sound when the device's notification system volume is turned on. 
    /// Disabling sounds means that the device will only vibrate unless the device is set to a total silent mode.
    let inline enableSound () =
        ReactNativeOneSignal.Globals.OneSignal?enableSound(true |> unbox) |> ignore

    /// Disables sound.
    /// You can call this from your UI from a button press for example to give your user's options for your notifications. 
    /// By default OneSignal plays the system's default notification sound when the device's notification system volume is turned on. 
    /// Disabling sounds means that the device will only vibrate unless the device is set to a total silent mode.
    let inline disableSound () =
        ReactNativeOneSignal.Globals.OneSignal?enableSound(false |> unbox) |> ignore
        
    /// Enables vibration.
    /// You can call this from your UI from a button press for example to give your user's options for your notifications. 
    /// By default OneSignal always vibrates the device when a notification is displayed unless the device is in a total silent mode. 
    /// Disabling vinrations means that the device will only vibrate lightly when the device is in it's vibrate only mode.
    let inline enableVibrate () =
        ReactNativeOneSignal.Globals.OneSignal?enableVibrate(true |> unbox) |> ignore
        
    /// Disables vibration.
    /// You can call this from your UI from a button press for example to give your user's options for your notifications. 
    /// By default OneSignal always vibrates the device when a notification is displayed unless the device is in a total silent mode. 
    /// Disabling vinrations means that the device will only vibrate lightly when the device is in it's vibrate only mode.
    let inline disableVibrate () =
        ReactNativeOneSignal.Globals.OneSignal?enableVibrate(false |> unbox) |> ignore
        
    /// Enables subscriptions.
    let inline enableSubscriptions () =
        ReactNativeOneSignal.Globals.OneSignal?setSubscription(true |> unbox) |> ignore

    /// Disables subscriptions.
    let inline disableSubscriptions () =
        ReactNativeOneSignal.Globals.OneSignal?setSubscription(false |> unbox) |> ignore

    /// Prompts the user for location permissions. (Android Only) 
    /// This allows for geotagging so you can send notifications to users based on location. 
    /// Note: Make sure you also have the required location permission in your AndroidManifest.xml.
    let inline promptLocation () =
        ReactNativeOneSignal.Globals.OneSignal?promptLocation() |> ignore

    /// Removes all OneSignal notifications from the Notification Shade. (Android Only)
    let inline clearOneSignalNotifications () =
        ReactNativeOneSignal.Globals.OneSignal?clearOneSignalNotifications() |> ignore

    /// Cancels a single OneSignal notification based on its Android notification integer id. (Android Only)
    /// You can get the notification Id when invoking OneSignal.onNotificationOpened while receiving a notification.
    let inline cancelNotification (id:string) =
        ReactNativeOneSignal.Globals.OneSignal?cancelNotification(id |> unbox) |> ignore


    /// Post Peer-to-Peer-Notfication.
    /// Allows you to send notifications from user to user or schedule ones in the future to be delivered to the current device.
    let inline postP2PNotification(message, data, userId: string) : unit =
        ReactNativeOneSignal.Globals.OneSignal?postNotification(message |> unbox, data |> unbox, userId |> unbox) |> ignore