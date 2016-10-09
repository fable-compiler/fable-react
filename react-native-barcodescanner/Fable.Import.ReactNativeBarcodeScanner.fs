namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

module ReactNativeBarcodeScanner =

    [<StringEnum>]
    type TorchMode =
    | On
    | Off

    [<StringEnum>]
    type CameraType =
    | Front
    | Back


    // and BarcodeScannerResult =
    //     abstract data: string with get, set
    //     abstract type: string with get, set

    and BarcodeScannerProperties =
        inherit React.Props<BarcodeScannerStatic>
        
    and BarcodeScannerStatic =
        inherit React.ComponentClass<BarcodeScannerProperties>
        
        abstract OnBarCodeRead: (obj -> unit) with get, set

    and BarcodeScanner =
        BarcodeScannerStatic

    type Globals =
        [<Import("BarcodeScanner", "react-native-barcodescanner")>] static member BarcodeScanner with get(): BarcodeScannerStatic = failwith "JS only" and set(v: BarcodeScannerStatic): unit = failwith "JS only"

