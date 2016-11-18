namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

module ReactNativePushNotification =

    type PushNotification =
        abstract member configure: PushNotificationOptions -> unit

    and PushNotificationOptions =
        abstract onRegister: obj -> unit   

    type Globals =
        [<Import("PushNotification", from="react-native-push-notification")>]
        static member PushNotification with get(): PushNotification = failwith "JS only" and set(v: PushNotification): unit = failwith "JS only"