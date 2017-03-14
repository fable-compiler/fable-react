module Fable.Helpers.ReactNativeImageResizer

open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeImageResizer

open Fable.Core.JsInterop


/// A React Native module that can create scaled versions of local images (also supports the assets library on iOS).
module ImageResizer =

    /// <summary>Creates a scaled version of a local images.</summary>
    /// <param name="path">Path of image file, or a base64 encoded image string prefixed with 'data:image/imagetype' where imagetype is jpeg or png.</param>
    /// <param name="maxWidth">Image max width (ratio is preserved)</param>
    /// <param name="maxHeight">Image max height (ratio is preserved)</param>
    /// <param name="compressFormat">Can be either JPEG, PNG or WEBP (Android only).</param>
    /// <param name="quality">A number between 0 and 100. Used for the JPEG compression.</param>
    let createResizedImage (path: string, maxWidth: int, maxHeight: int, compressFormat: string, quality: int) : JS.Promise<string> =
        ReactNativeImageResizer.Globals.ImageResizer?createResizedImage(path, maxWidth, maxHeight, compressFormat, quality) |> unbox