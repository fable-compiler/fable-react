module Client.Main

open Elmish
open Elmish.React

open Fable.Core
open Fable.Core.JsInterop
open Thoth.Json
open Shared.Types
open Shared.View
open Browser

// let div = document.getElementById("elmish-app")
// div.innerHTML <- ""
// console.log("root", div)

let init () =
  // Init model by server side state
  let model =
    match Decode.Auto.fromString<Model> window?__INIT_STATE__ with
    | Ok model -> model
    | Error er ->
        JS.console.error("Cannot decode init state", er, window?__INIT_STATE__)
        Model.Empty
  // let cmd =
  //   Cmd.ofPromise
  //     (fetchAs<int> "/api/init")
  //     []
  //     (Ok >> Init)
  //     (Error >> Init)
  model, Cmd.none

let update msg (model : Model) =
  let model' =
    match model.counter,  msg with
    | Some x, Increment -> { model with counter=Some (x + 1) }
    | Some x, Decrement -> { model with counter=Some (x - 1) }
    | None, Init (Ok x) -> x
    | _ -> model
  model', Cmd.none


Program.mkProgram init update view
|> Program.withReactHydrate "elmish-app"
|> Program.run
