// include Fake libs
#r "./packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem"

open System
open System.IO
open System.Text.RegularExpressions
open Fake
open Fake.NpmHelper
open Fake.ReleaseNotesHelper
open Fake.Git
open Fake.YarnHelper

module Util =

    let visitFile (visitor: string->string) (fileName : string) =
        File.ReadAllLines(fileName)
        |> Array.map (visitor)
        |> fun lines -> File.WriteAllLines(fileName, lines)

    let replaceLines (replacer: string->Match->string option) (reg: Regex) (fileName: string) =
        fileName |> visitFile (fun line ->
            let m = reg.Match(line)
            if not m.Success
            then line
            else
                match replacer line m with
                | None -> line
                | Some newLine -> newLine)

let mutable dotnetExePath = "dotnet"

let runDotnet dir =
    DotNetCli.RunCommand (fun p -> { p with ToolPath = dotnetExePath
                                            WorkingDir = dir
                                            TimeOut =  TimeSpan.FromHours 12. } )
                                            // Extra timeout allow us to run watch mode
                                            // Otherwise, the process is stopped every 30 minutes by default

Target "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    |> Seq.iter(CleanDir)
)

Target "Restore" (fun _ ->
    !! "src/**/*.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "restore")
)

Target "Build" (fun _ ->
    !! "src/**/*.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "build")
)

// --------------------------------------------------------------------------------------
// Build a NuGet package
let needsPublishing (versionRegex: Regex) (releaseNotes: ReleaseNotes) projFile =
    printfn "Project: %s" projFile
    if releaseNotes.NugetVersion.ToUpper().EndsWith("NEXT")
    then
        printfn "Version in Release Notes ends with NEXT, don't publish yet."
        false
    else
        File.ReadLines(projFile)
        |> Seq.tryPick (fun line ->
            let m = versionRegex.Match(line)
            if m.Success then Some m else None)
        |> function
            | None -> failwith "Couldn't find version in project file"
            | Some m ->
                let sameVersion = m.Groups.[1].Value = releaseNotes.NugetVersion
                if sameVersion then
                    printfn "Already version %s, no need to publish." releaseNotes.NugetVersion
                not sameVersion

let toPackageReleaseNotes (notes: string list) =
    "* " + String.Join("\n * ", notes)
    |> (fun txt -> txt.Replace("\"", "\\\""))

let pushNuget (releaseNotes: ReleaseNotes) (projFile: string) =
    let versionRegex = Regex("<Version>(.*?)</Version>", RegexOptions.IgnoreCase)

    if needsPublishing versionRegex releaseNotes projFile then
        let projDir = Path.GetDirectoryName(projFile)
        let nugetKey =
            match environVarOrNone "NUGET_KEY" with
            | Some nugetKey -> nugetKey
            | None -> failwith "The Nuget API key must be set in a NUGET_KEY environmental variable"
        runDotnet projDir (sprintf "pack -c Release /p:Version=%s /p:PackageReleaseNotes=\"%s\"" releaseNotes.NugetVersion (toPackageReleaseNotes releaseNotes.Notes))
        Directory.GetFiles(projDir </> "bin" </> "Release", "*.nupkg")
        |> Array.find (fun nupkg -> nupkg.Contains(releaseNotes.NugetVersion))
        |> (fun nupkg ->
            (Path.GetFullPath nupkg, nugetKey)
            ||> sprintf "nuget push %s -s nuget.org -k %s"
            |> DotNetCli.RunCommand id)
        // After successful publishing, update the project file
        (versionRegex, projFile)
        ||> Util.replaceLines (fun line _ ->
                                    versionRegex.Replace(line, "<Version>"+releaseNotes.NugetVersion+"</Version>") |> Some)

Target "PublishNugets" (fun _ ->
    !! "src/Fable.React/Fable.React.fsproj"
    ++ "src/Fable.ReactLeaflet/Fable.ReactLeaflet.fsproj"
    |> Seq.iter(fun s ->
        let projFile = s
        let projDir = IO.Path.GetDirectoryName(projFile)
        let release = projDir </> "RELEASE_NOTES.md" |> ReleaseNotesHelper.LoadReleaseNotes
        pushNuget release projFile
    )
)

// Build order
"Clean"
    ==> "Restore"
    ==> "Build"
    ==> "PublishNugets"

// start build
RunTargetOrDefault "Build"
