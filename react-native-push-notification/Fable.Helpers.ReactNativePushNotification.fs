[<Fable.Core.Erase>]
/// Contains functions for push notifications.
module Fable.Helpers.ReactNativePushNotification

open Fable.Core
open Fable.Import
open Fable.Import.ReactNativePushNotification

open Fable.Core.JsInterop

type PN = ReactNativePushNotification.Globals

/// Contains properties for push notifications.
module Props =
    [<KeyValueList>]
    type IPushNotificationOptions =
        interface end

    [<KeyValueList>]
    type PushNotificationOptions =
    | OnRegister of (obj -> unit)
    | SenderID of string
    | PopInitialNotification of bool
    | RequestPermissions of bool
    | OnNotification of (obj -> unit)
        interface IPushNotificationOptions


    [<KeyValueList>]
    type ILocalPushNotificationProperties =
        interface end

    [<KeyValueList>]
    type LocalPushNotificationProperties =
    // Android
    | Id of int
    | Ticker of string
    | AutoCancel of bool
    | LargeIcon of string
    | SmallIcon of string
    | BigText of string
    | SubText of string
    | Color of string
    | Vibrate of bool
    | Vibration of float
    | Tag of string
    | Group of string
    | OnGoing of bool
    // Android and iOS
    | Title of string
    | PlaySound of bool
    | SoundName of string
    | Number of string
    | RepeatType of string
    | Actions of string
        interface ILocalPushNotificationProperties
        

open Props

/// Contains functions for push notifications.
module PushNotification =

    /// Configures the push notification system.
    let inline configure (props: IPushNotificationOptions list) =
        PN.PushNotification?configure(props |> unbox) |> ignore

    /// Sends a local push notification.
    let inline localNotification(props: ILocalPushNotificationProperties list, message: string) =
        PN.PushNotification?localNotification(
            JS.Object.assign(
                createObj ["message" ==> message],
                props)) 
        |> ignore        

    /// Schedules a local push notification.
    let inline localNotificationSchedule(props: ILocalPushNotificationProperties list, message: string, date:System.DateTime) =
        PN.PushNotification?localNotificationSchedule(
            JS.Object.assign(
                createObj  ["message" ==> message 
                            "date" ==> date],
                props)) 
        |> ignore