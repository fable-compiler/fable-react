module Fable.Helpers.ReactNativeSimpleStore.KeyValueStore

open System
open Fable.Import.ReactNative
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

/// Retrieves all keys from the AsyncStorage.
let getAllKeys() : Async<string []> =
    Async.FromContinuations(fun (success,fail,_) ->
        Globals.AsyncStorage.getAllKeys
            (Func<_,_,_>(fun err keys ->
                            if err <> null && err.message <> null then
                                fail (unbox err)
                            else
                                success (unbox keys))) |> ignore)
