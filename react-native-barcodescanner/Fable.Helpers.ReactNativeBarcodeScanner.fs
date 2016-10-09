[<Fable.Core.Erase>]
module Fable.Helpers.ReactNativeBarcodeScanner

open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeBarcodeScanner
open Fable.Core.JsInterop
type BCS = ReactNativeBarcodeScanner.Globals

module Props =
    [<KeyValueList>]
    type IBarcodeScannerProperties =
        interface end

    [<KeyValueList>]
    type BarcodeScannerProperties =
    | TorchMode of TorchMode
    | CameraType of CameraType
        interface IBarcodeScannerProperties

open Props


let inline barcodeScanner (props:IBarcodeScannerProperties list) (onBarCodeRead : obj -> unit) : React.ReactElement<obj> = 
    React.createElement(
      BCS.BarcodeScanner,
      JS.Object.assign(
            createObj ["onBarCodeRead" ==> onBarCodeRead],
            props)
        |> unbox,
      unbox([||])) |> unbox
