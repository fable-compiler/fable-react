
open System
open System.IO
open System.Threading
open System.Threading.Tasks
open System.Diagnostics
open Shared
open Fable.Helpers.ReactServer
open FSharp.Core
let initState: Model = {
  counter = Some 42
  someString = "Some String"
  someFloat = 11.11
  someInt = 22
}

let coreCount = Environment.ProcessorCount
let workerTimes = 5000
let totalTimes = workerTimes * coreCount
let mutable totalms = 0L

let reset () =
  totalms <- 0L

let render times () =
  reset ()
  let tid = Thread.CurrentThread.ManagedThreadId
  printfn "Thread %i started" tid
  let watch = Stopwatch()
  watch.Start()
  for i = 1 to times do
    renderToString(Client.View.view initState ignore) |> ignore
  watch.Stop()
  totalms <- totalms + watch.ElapsedMilliseconds
  printfn "Thread %i render %d times used %dms" tid times watch.ElapsedMilliseconds
  int watch.ElapsedMilliseconds

let singleTest () =
  let times = workerTimes * 2
  let time = render times ()
  printfn "[Single thread] %dms    %.3freq/s" time ((float times) / (float time) * 1000.)

let tasksTest () =
  Tasks.Parallel.For(0, coreCount, (fun _ -> render workerTimes () |> ignore)) |> ignore
  Process.GetCurrentProcess().WorkingSet64

let log label memory =
  let totalms = totalms / (int64 coreCount)
  printfn "[%d %s] Total: %dms    Memory footprint: %.3fMB   Requests/sec: %.3f" coreCount label totalms ((float memory) / 1024. / 1024.) ((float totalTimes) / (float totalms) * 1000.)

[<EntryPoint>]
let main _ =
  reset ()
  singleTest ()
  reset ()
  tasksTest() |> log "tasks"
  0
