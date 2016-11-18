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
        interface IPushNotificationOptions

open Props

let inline configure (props: IPushNotificationOptions list) f =
    PN.PushNotification?configure(props |> unbox)