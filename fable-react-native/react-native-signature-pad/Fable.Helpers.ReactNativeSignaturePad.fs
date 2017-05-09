module Fable.Helpers.ReactNativeSignaturePad

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
module R = Fable.Helpers.React

let SignaturePad: React.ComponentClass<obj> = importDefault "react-native-signature-pad"

/// Opens a signature pad with callbacks for onError and onChange
let inline signaturePad (props:Fable.Helpers.ReactNative.Props.IStyle list) (onError:exn -> unit) (onChange:string -> unit) : React.ReactElement =
    R.from
        SignaturePad
        (createObj
            [ "style" ==> keyValueList CaseRules.LowerFirst props
              "onError" ==> onError
              "onChange" ==> fun (o:obj) -> onChange(!!o?base64DataUrl) ])
        []