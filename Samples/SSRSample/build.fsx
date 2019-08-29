#r @"packages/build/FAKE/tools/FakeLib.dll"

open System

open Fake

let serverPath = "./src/Server" |> FullName
let benchmarkPath = "./benchmark" |> FullName
let clientPath = "./src/Client" |> FullName
let deployDir = "./deploy" |> FullName

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

// We'll have problems with npm dependencies if we reference files outside the package.json dir
// so copy Fable.React files here first
Target "CopyFableReact" (fun _ ->
    FileUtils.cp_r "../../src/" "src/Fable.React/"
)

Target "InstallClient" (fun _ ->
  printfn "Node version:"
  run nodeTool "--version" __SOURCE_DIRECTORY__
  printfn "Npm version:"
  run npmTool "--version" __SOURCE_DIRECTORY__
  run npmTool "install" __SOURCE_DIRECTORY__
)

Target "Build" (fun () ->
  run dotnetCli "build" serverPath
  run npmTool "run build" __SOURCE_DIRECTORY__
)

Target "BuildBench" (fun () ->
  run dotnetCli "build --configuration Release" serverPath
  run dotnetCli "build --configuration Release" benchmarkPath
  run npmTool "run build-lib" __SOURCE_DIRECTORY__
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
    run npmTool "start" __SOURCE_DIRECTORY__
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
  ==> "CopyFableReact"
  ==> "InstallClient"
  ==> "Build"

"InstallClient"
  ==> "Run"

"InstallClient"
  ==> "BuildBench"
  ==> "Bench"

RunTargetOrDefault "Build"
