#load "node_modules/fable-publish-utils/PublishUtils.fs"
open PublishUtils

match args with
| IgnoreCase "publish"::_ ->
    pushNuget "src/Fable.React.Types/Fable.React.Types.fsproj" doNothing
    pushNuget "src/Fable.React/Fable.React.fsproj" doNothing
| _ -> ()
