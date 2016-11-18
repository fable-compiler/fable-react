[<Fable.Core.Erase>]
module Fable.Helpers.ReactNativePushNotification

open Fable.Core
open Fable.Import
open Fable.Import.ReactNativePushNotification

open Fable.Core.JsInterop

type PN = ReactNativePushNotification.Globals


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
    | Message of string
    | PlaySound of bool
    | SoundName of string
    | Number of string
    | RepeatType of string
    | Actions of string
        interface ILocalPushNotificationProperties
        

open Props

module PushNotification =

    let inline configure (props: IPushNotificationOptions list) =
        PN.PushNotification?configure(props |> unbox) |> ignore


    let inline localNotification(props: ILocalPushNotificationProperties list) =
        PN.PushNotification?localNotification(props |> unbox) |> ignore 