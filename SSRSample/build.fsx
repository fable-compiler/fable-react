#r @"packages/build/FAKE/tools/FakeLib.dll"

open System

open Fake

let serverPath = "./src/Server" |> FullName
let benchmarkPath = "./benchmark" |> FullName
let clientPath = "./src/Client" |> FullName
let deployDir = "./deploy" |> FullName
let packageJsonDir = "../../" |> FullName

let platformTool tool winTool =
  let tool = if isUnix then tool else winTool
  tool
  |> ProcessHelper.tryFindFileOnPath
  |> function Some t -> t | _ -> failwithf "%s not found" tool

let nodeTool = platformTool "node" "node.exe"
let npmTool = platformTool "npm" "npm.cmd"

let mutable dotnetCli = "dotnet"

let runWithEnv cmd args workingDir (env: (string * string) list) =
  let result =
    ExecProcess (fun info ->
      info.FileName <- cmd
      for (key, value) in env do
        info.Environment.Add(key, value)
      info.WorkingDirectory <- workingDir
      info.Arguments <- args) TimeSpan.MaxValue
  if result <> 0 then failwithf "'%s %s' failedwith" cmd args

let run cmd args workingDir =
  runWithEnv cmd args workingDir []

Target "Clean" (fun _ ->
  CleanDirs [deployDir]
)

Target "InstallClient" (fun _ ->
  printfn "Node version:"
  run nodeTool "--version" packageJsonDir
  printfn "Npm version:"
  run npmTool "--version" packageJsonDir
  run npmTool "install" packageJsonDir
)

Target "Build" (fun () ->
  run dotnetCli "build" serverPath
  run npmTool "run ssrsample-build" packageJsonDir
)

Target "BuildBench" (fun () ->
  run dotnetCli "build --configuration Release" serverPath
  run dotnetCli "build --configuration Release" benchmarkPath
  run npmTool "run ssrsample-build-lib" packageJsonDir
)

Target "Bench" (fun () ->
  run dotnetCli "./bin/Release/netcoreapp2.0/dotnet.dll" benchmarkPath
  runWithEnv nodeTool "./node.js" benchmarkPath ["NODE_ENV", "production"]
)

Target "Run" (fun () ->
  let server = async {
    run dotnetCli "watch run" serverPath
  }
  let client = async {
    run npmTool "run ssrsample-start" packageJsonDir
  }
  let browser = async {
    Threading.Thread.Sleep 10000
    Diagnostics.Process.Start "http://localhost:8085" |> ignore
  }

  [ server; client; browser]
  |> Async.Parallel
  |> Async.RunSynchronously
  |> ignore
)


"Clean"
  ==> "InstallClient"
  ==> "Build"

"InstallClient"
  ==> "Run"

"InstallClient"
  ==> "BuildBench"
  ==> "Bench"

RunTargetOrDefault "Run"
