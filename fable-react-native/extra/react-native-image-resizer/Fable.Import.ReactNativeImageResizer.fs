namespace Fable.Import

open System
open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser

[<Erase>]
module ReactNativeImageResizer =

    type ImageResizer =
        abstract member createResizedImage: string -> int -> int -> string -> float -> float -> string -> Promise<obj>

    type Globals =
        [<Import("default", from="react-native-image-resizer")>]
        static member ImageResizer with get(): ImageResizer = failwith "JS only" and set(v: ImageResizer): unit = failwith "JS only"