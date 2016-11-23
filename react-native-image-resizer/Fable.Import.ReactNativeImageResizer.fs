namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

module ReactNativeImageResizer =



    type ImagePicker =
        abstract member createResizedImage: ImagePickerOptions * (ImagePickerResult -> unit) -> unit

    type Globals =
        [<Import("default", from="react-native-image-resizer")>]
        static member ImageResizer with get(): ImageResizer = failwith "JS only" and set(v: ImageResizer): unit = failwith "JS only"