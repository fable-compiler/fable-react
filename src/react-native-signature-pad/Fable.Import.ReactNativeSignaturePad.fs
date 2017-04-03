namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

[<Erase>]
module ReactNativeSignaturePad =

    type SignaturePadStatic =
        inherit React.ComponentClass<ReactNative.ViewProperties>


    and SignaturePad =
        SignaturePadStatic
        

    type Globals =
        [<Import("SignaturePad", "react-native-signture-pad")>] static member SignaturePad with get(): SignaturePadStatic = jsNative and set(v: SignaturePadStatic): unit = jsNative