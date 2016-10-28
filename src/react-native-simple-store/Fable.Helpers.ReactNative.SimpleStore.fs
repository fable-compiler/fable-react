[<Fable.Core.Erase>]
module internal Fable.Helpers.ReactNativeSimpleStore

open System
open Fable.Import.ReactNative
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.PowerPack
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
module DB =
    [<Literal>]
    let private modelsKey = "models/"
    type Table<'a> = 'a[]

    /// Removes all rows from the model.
    let inline clear<'a>() =
       let key = modelsKey + typeof<'a>.FullName
       promise {
            let s:string = [||] |> Serialize.toJson
            let! _ = Globals.AsyncStorage.setItem(key,s)
            ()
       }

    /// Creates a new model.
    let inline private getModel<'a> (key) : Promise<Table<'a>> = promise {
        let! v = Globals.AsyncStorage.getItem (key)
        match v with
        | null -> return [||]
        | _ -> return Serialize.ofJson v
    }

    /// Adds a row to a model
    let inline add<'a>(data:'a) =
        let key = modelsKey + typeof<'a>.FullName
        promise {
            let! model = getModel<'a> key

            let newModel : string = Array.append [|unbox data|] model |> Serialize.toJson
            let! _ = Globals.AsyncStorage.setItem(key,newModel)
            ()
        }

    /// Updates a row in a model
    let inline update<'a>(index, data:'a) =
        let key = modelsKey + typeof<'a>.FullName
        promise {
            let! model = getModel<'a> key
            model.[index] <- unbox data
            let newModel : string = Serialize.toJson model
            let! _ = Globals.AsyncStorage.setItem(key,newModel)
            ()
        }

    /// Deletes a row from a model
    let inline delete<'a>(index) =
        let key = modelsKey + typeof<'a>.FullName
        async {
            let! model = getModel<'a> key
            let model : 'a[] = model |> Array.mapi (fun i x -> i,x) |> Array.filter (fun (i,_) -> i <> index) |> Array.map snd
            let newModel : string =  toJson model
            let! _ = Globals.AsyncStorage.setItem(key,newModel) |> Async.AwaitPromise
            ()
        }

    /// Updates multiple rows in a model
    let inline updateMultiple<'a>(values) =
        let key = modelsKey + typeof<'a>.FullName
        async {
            let! model = getModel<'a> key
            for index, data:'a in values do
                model.[index] <- unbox data

            let newModel : string =  toJson model
            let! _ = Globals.AsyncStorage.setItem(key,newModel) |> Async.AwaitPromise
            ()
        }

    ///  Update data by an update function.
    let inline updateWithFunction<'a>(updateF: 'a[] -> 'a[]) =
        let key = modelsKey + typeof<'a>.FullName
        async {
            let! model = getModel<'a> key

            let updated = updateF model

            let newModel : string = toJson updated
            let! _ = Globals.AsyncStorage.setItem(key,newModel) |> Async.AwaitPromise
            ()
        }

    ///  Update data by an update function.
    let inline updateWithFunctionAndKey<'a>(updateF: 'a[] -> 'a[],key) =
        let key = modelsKey + typeof<'a>.FullName + "/" + key
        async {
            let! model = getModel<'a> key

            let updated = updateF model

            let newModel : string = toJson updated
            let! _ = Globals.AsyncStorage.setItem(key,newModel) |> Async.AwaitPromise
            ()
        }

    /// Adds multiple rows to a model
    let inline addMultiple<'a>(data:'a []) =
        let key = modelsKey + typeof<'a>.FullName
        promise {
            let! model = getModel<'a> key

            let newModel : string = Array.append data model |> Serialize.toJson
            let! _ = Globals.AsyncStorage.setItem(key,newModel)
            ()
        }

    /// Replaces all rows of a model
    let inline replaceWithKey<'a>(key,data:'a []) =
        let modelKey = modelsKey + typeof<'a>.FullName + "/" + key
        async {
            let newModel : string = data |> toJson
            let! _ = Globals.AsyncStorage.setItem(modelKey,newModel) |> Async.AwaitPromise
            ()
        }

    /// Replaces all rows of a model
    let inline replace<'a>(data:'a []) =
        let key = modelsKey + typeof<'a>.FullName
        promise {
            let newModel : string = data |> Serialize.toJson
            let! _ = Globals.AsyncStorage.setItem(key,newModel)
            ()
        }

    /// Gets a row from the model
    let inline get<'a>(index:int) =
        let key = modelsKey + typeof<'a>.FullName
        promise {
            let! model = getModel<'a> key
            return model.[index]
        }

    /// Gets all rows from the model
    let inline getAll<'a>() =
        let key = modelsKey + typeof<'a>.FullName
        getModel<'a> key


    /// Gets all rows from the model
    let inline getAllWithKey<'a>(key) =
        let key = modelsKey + typeof<'a>.FullName + "/" + key
        getModel<'a> key

    /// Gets the row count from the model
    let inline count<'a>() =
        let key = modelsKey + typeof<'a>.FullName
        promise {
            let! model = getModel<'a> key
            return model.Length
        }
