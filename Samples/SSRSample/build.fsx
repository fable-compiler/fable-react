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
let yarnTool = platformTool "yarn" "yarn.cmd"

let dotnetcliVersion = DotNetCli.GetDotNetSDKVersionFromGlobalJson()
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

Target "InstallDotNetCore" (fun _ ->
  dotnetCli <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)

Target "InstallClient" (fun _ ->
  printfn "Node version:"
  run nodeTool "--version" __SOURCE_DIRECTORY__
  printfn "Yarn version:"
  run yarnTool "--version" __SOURCE_DIRECTORY__
  run yarnTool "install" __SOURCE_DIRECTORY__
  run dotnetCli "restore" clientPath
)

Target "RestoreServer" (fun () ->
  run dotnetCli "restore" serverPath
)

Target "Build" (fun () ->
  run dotnetCli "build" serverPath
  run dotnetCli "fable webpack -- -p" clientPath
)

Target "BuildBench" (fun () ->
  run dotnetCli "build --configuration Release" serverPath
  run dotnetCli "build --configuration Release" benchmarkPath
  run dotnetCli "fable npm-run buildClientLib" clientPath
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
    run dotnetCli "fable webpack-dev-server" clientPath
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
  ==> "InstallDotNetCore"
  ==> "InstallClient"
  ==> "Build"

"InstallClient"
  ==> "RestoreServer"
  ==> "Run"


"BuildBench"
  ==> "Bench"

RunTargetOrDefault "Build"
