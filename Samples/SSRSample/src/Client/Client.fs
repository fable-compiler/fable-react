module Client.Main

open Elmish
open Elmish.React

open Fable.Core
open Fable.Core.JsInterop
open Fable.PowerPack.Fetch
open Client.Types
open Client.View
open Fable.Import.React
open Fable.Import.Browser
open Shared

Client.Bench.jsRenderBench()


// let div = document.getElementById("elmish-app")
// div.innerHTML <- ""
// console.log("root", div)


let init () =
  // Init model by server side state
  let model = ofJson<Model> !!window?__INIT_STATE__
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


#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReactHydrate "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
