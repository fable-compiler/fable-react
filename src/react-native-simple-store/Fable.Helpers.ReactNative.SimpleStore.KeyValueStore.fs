module Fable.Helpers.ReactNativeSimpleStore.KeyValueStore

open System
open Fable.Import.ReactNative
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.PowerPack

/// Retrieves all keys from the AsyncStorage.
let getAllKeys() : JS.Promise<string []> =
    Promise.create(fun success fail ->
        Globals.AsyncStorage.getAllKeys
            (Func<_,_,_>(fun err keys ->
                if err <> null && err.message <> null then
                    fail (unbox err)
                else
                    success (unbox keys))) |> ignore)
