module Client.Bench

open Fable.Core
open Fable.Core.JsInterop
open Fable.PowerPack.Fetch
open Client.Types
open Client.View
open Fable.Import.React
open Fable.Import.Browser
open Shared

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
  let mutable len = 10000
  console.log(renderToString (view initState ignore))
  console.time("render")
  while len > 0 do
    renderToString (view initState ignore) |> ignore
    len <- len - 1
  console.timeEnd("render")

jsRenderBench ()
