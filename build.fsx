open Octokit
// include Fake libs
#r "./packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem"
#load "paket-files/build/fsharp/FAKE/modules/Octokit/Octokit.fsx"
#load "paket-files/build/fable-compiler/fake-helpers/Fable.FakeHelpers.fs"

open Fake
open Fable.FakeHelpers

#if MONO
// prevent incorrect output encoding (e.g. https://github.com/fsharp/FAKE/issues/1196)
System.Console.OutputEncoding <- System.Text.Encoding.UTF8
#endif

let project = "fable-react"
let gitOwner = "fable-compiler"

let dotnetcliVersion = "2.0.3"
let mutable dotnetExePath = environVarOrDefault "DOTNET" "dotnet"

// Clean and install dotnet SDK
Target "Bootstrap" (fun () ->
    !! "src/**/bin" ++ "src/**/obj" |> CleanDirs
    dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)

Target "PublishPackages" (fun () ->
    [ "src/Fable.React/Fable.React.fsproj"
      "src/Fable.ReactLeaflet/Fable.ReactLeaflet.fsproj"]
    |> publishPackages __SOURCE_DIRECTORY__ dotnetExePath
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
