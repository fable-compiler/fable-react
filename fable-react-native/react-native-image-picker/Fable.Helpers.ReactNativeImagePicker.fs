module Fable.Helpers.ReactNativeImagePicker

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.ReactNativeImagePicker
type IP = ReactNativeImagePicker.Globals

module Props =
    type IImagePickerOptions =
        interface end

    type ImagePickerOptions =
    | Title of string
    | CancelButtonTitle of string
    | TakePhotoButtonTitle of string
    | ChooseFromLibraryButtonTitle of string
    | CameraType of CameraType
    | MediaType of MediaType
    | MaxWidth of int
    | MaxHeight of int
    | Quality of float
    | VideoQuality of VideoQuality
    | DurationLimit of int
    | Rotation of int
    | AllowsEditing of bool
    | NoData of bool
    | StorageOptions of StorageOptions
        interface IImagePickerOptions

open Props

let inline showImagePicker (props: IImagePickerOptions list) f =
    IP.ImagePicker.showImagePicker(!!(keyValueList CaseRules.LowerFirst props), f)

let showImagePickerAsync (props: IImagePickerOptions list) =
    Fable.PowerPack.Promise.create(fun onSuccess onError ->
        showImagePicker
            !!(keyValueList CaseRules.LowerFirst props)
            (fun result ->
                if not result.didCancel then
                    if System.String.IsNullOrEmpty result.error then
                        onSuccess (Some result.uri)
                    else
                        onError (System.Exception result.error)
                else onSuccess None)
    )

let inline launchCamera (props: IImagePickerOptions list) f =
    IP.ImagePicker.launchCamera(!!(keyValueList CaseRules.LowerFirst props), f)


let inline launchImageLibrary (props: IImagePickerOptions list) f =
    IP.ImagePicker.launchImageLibrary(!!(keyValueList CaseRules.LowerFirst props), f)