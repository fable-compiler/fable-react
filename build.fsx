#r "nuget: Fable.PublishUtils, 2.4.0"

open PublishUtils

let args =
    fsi.CommandLineArgs
    |> Array.skip 1
    |> List.ofArray

match args with
| IgnoreCase "publish"::_ ->
    pushFableNuget "src/Fable.React.Types/Fable.React.Types.fsproj" [] doNothing
    pushFableNuget "src/Fable.ReactDom.Types/Fable.ReactDom.Types.fsproj" [] doNothing
    pushFableNuget "src/Fable.React/Fable.React.fsproj" [] doNothing
| _ -> ()
