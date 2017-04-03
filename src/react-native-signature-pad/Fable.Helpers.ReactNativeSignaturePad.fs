module Fable.Helpers.ReactNativeSignaturePad

open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeSignaturePad

let signaturePad (props:IViewProperties list) (onError:exn -> unit) (onChange:string -> unit) : React.ReactElement =
    createElement(
        RN.SignaturePad,
        JS.Object.assign(
            createObj [
                    "onError" ==> onError
                    "onChange" ==> onChange],
            props), [])
