module Fable.Helpers.ReactNativeBarcodeScanner

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeBarcodeScanner
module RN = Fable.Helpers.ReactNative
type BCS = ReactNativeBarcodeScanner.Globals

module Props =

    [<RequireQualifiedAccess>]
    type BarcodeScannerStyle =
        | Flex of int

    type IBarcodeScannerProperties =
        interface end

    [<RequireQualifiedAccess>]
    type BarcodeScannerProperties =
    | TorchMode of TorchMode
    | CameraType of CameraType
    | Style of BarcodeScannerStyle list
        interface IBarcodeScannerProperties


open Props

type Barcode =
    abstract data: string with get, set
    abstract ``type``: string with get, set


/// Creates a BarcodeScanner element
let inline barcodeScanner (props:IBarcodeScannerProperties list) (onBarcodeRead: Barcode -> unit) : React.ReactElement =
    RN.createElementWithObjProps(
      BCS.BarcodeScanner,
        !!JS.Object.assign(
            createObj ["onBarCodeRead" ==> onBarcodeRead],
            keyValueList CaseRules.LowerFirst props), [])
