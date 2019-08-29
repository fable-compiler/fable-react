module Client.Bench

open Fable.Core
open Fable.Core.JsInterop
open Shared.Types
open Shared.View
open Fable.React
open Browser

let initState: Model = {
  counter = Some 42
  someString = "Some String"
  someFloat = 11.11
  someInt = 22
}

[<Emit("typeof process.platform !== 'undefined'")>]
let isNode: bool = jsNative

let jsRenderBench () =
  if not isNode then () else

  let renderToString: ReactElement -> string = importMember "react-dom/server"
  let mutable times = 10000
  let label = sprintf "render %d times in nodejs" times
  console.time(label)
  while times > 0 do
    renderToString (view initState ignore) |> ignore
    times <- times - 1
  console.timeEnd(label)

jsRenderBench ()
