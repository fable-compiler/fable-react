[<Fable.Core.Erase>]
module Fable.Helpers.ReactNativeBarcodeScanner

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeBarcodeScanner
type BCS = ReactNativeBarcodeScanner.Globals

module Props =
    [<KeyValueList>]
    type IBarcodeScannerProperties =
        interface end

    [<KeyValueList>]
    type BarcodeScannerProperties =
    | OnBarCodeRead of (obj -> unit)
    | TorchMode of TorchMode
    | CameraType of CameraType
        interface IBarcodeScannerProperties

open Props


let inline barcodeScanner (props:IBarcodeScannerProperties list) : React.ReactElement<obj> = 
    React.createElement(
      BCS.BarcodeScanner,
      props |> unbox,
      unbox [||]) |> unbox
