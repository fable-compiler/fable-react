module Fable.Helpers.ReactNativeSignaturePad

open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeSignaturePad
open Fable.Core.JsInterop

let signaturePad (props:Fable.Helpers.ReactNative.Props.IViewProperties list) (onError:exn -> unit) (onChange:string -> unit) : React.ReactElement =
    ReactNative.createElement(
        SignaturePad,
        JS.Object.assign(
            createObj [
                    "onError" ==> onError
                    "onChange" ==> onChange],
            props), [])
