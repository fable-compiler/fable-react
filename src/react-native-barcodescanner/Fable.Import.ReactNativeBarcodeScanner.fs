namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

[<Erase>]
module ReactNativeBarcodeScanner =

    [<StringEnum>]
    type TorchMode =
    | On
    | Off

    [<StringEnum>]
    type CameraType =
    | Front
    | Back
    and BarcodeScannerProperties =
        inherit React.Props<BarcodeScannerStatic>

    and BarcodeScannerStatic =
        inherit React.ComponentClass<BarcodeScannerProperties>

    and BarcodeScanner =
        BarcodeScannerStatic

    type Globals =
        [<Import("default", "react-native-barcodescanner")>] static member BarcodeScanner with get(): BarcodeScannerStatic = failwith "JS only" and set(v: BarcodeScannerStatic): unit = failwith "JS only"

