[<Fable.Core.Erase>]
module Fable.Helpers.ReactNativeImageResizer

open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeImageResizer

open Fable.Core.JsInterop


/// A React Native module that can create scaled versions of local images (also supports the assets library on iOS).
module ImageResizer =

    /// Creates a scaled version of a local images.
    let inline createResizedImage (path, maxWidth, maxHeight, compressFormat, quality, rotation, outputPath) : Async<string> =
        ReactNativeImageResizer.Globals.ImageResizer?createResizedImage(path, maxWidth, maxHeight, compressFormat, quality, rotation, outputPath) |> unbox
        |> Async.AwaitPromise