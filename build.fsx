// include Fake libs
#r "./packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem"
#load "paket-files/build/fsharp/FAKE/modules/Octokit/Octokit.fsx"
#load "paket-files/build/fable-compiler/fake-helpers/Fable.FakeHelpers.fs"

open System.IO
open Fake
open Fable.FakeHelpers
open Octokit

#if MONO
// prevent incorrect output encoding (e.g. https://github.com/fsharp/FAKE/issues/1196)
System.Console.OutputEncoding <- System.Text.Encoding.UTF8
#endif

let project = "fable-react"
let gitOwner = "fable-compiler"

let packages =
    [ "src/Fable.React/Fable.React.fsproj"
      "src/Fable.ReactLeaflet/Fable.ReactLeaflet.fsproj"
      "src/Fable.ReactGoogleMaps/Fable.ReactGoogleMaps.fsproj"
      "src/Fable.Recharts/Fable.Recharts.fsproj"
    ]

let addToPath newPath =
    let path = environVarOrDefault "PATH" ""
    let separator = if isWindows then ";" else ":"
    setEnvironVar "PATH" (newPath + separator + path)

let mutable dotnetExePath = environVarOrDefault "DOTNET" "dotnet"
let installDotnetSdk () =
    let dotnetcliVersion =
        Path.Combine(__SOURCE_DIRECTORY__, "global.json")
        |> findLineAndGetGroupValue "\"version\": \"(.*?)\"" 1

    dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
    if Path.IsPathRooted(dotnetExePath) then
        Path.GetDirectoryName(dotnetExePath) |> addToPath
    run __SOURCE_DIRECTORY__ dotnetExePath "--version"

// Clean and install dotnet SDK
Target "Bootstrap" (fun () ->
    !! "src/**/bin" ++ "src/**/obj" |> CleanDirs
    installDotnetSdk ()
)

Target "PublishPackages" (fun () ->
    publishPackages __SOURCE_DIRECTORY__ dotnetExePath packages
)

Target "GitHubRelease" (fun () ->
    let releasePath = __SOURCE_DIRECTORY__ </> "src/Fable.React/RELEASE_NOTES.md"
    githubRelease releasePath gitOwner project (fun user pw release ->
        createClient user pw
        |> createDraft gitOwner project release.NugetVersion
            (release.SemVer.PreRelease <> None) release.Notes
        |> releaseDraft
        |> Async.RunSynchronously
    )
)

"Bootstrap"
==> "PublishPackages"
==> "GitHubRelease"

RunTargetOrDefault "Bootstrap"
