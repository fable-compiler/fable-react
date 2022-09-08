module Server.Main

open System
open System.IO
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection

open Giraffe
open Giraffe.GiraffeViewEngine
open Giraffe.Serialization.Json

open Thoth.Json.Net
open Thoth.Json.Giraffe

open Shared.Types


let clientPath = Path.Combine(__SOURCE_DIRECTORY__,"..","Client") |> Path.GetFullPath
let port = 8085us
let assetsBaseUrl = "http://localhost:8080"

let initState: Model = {
  counter = Some 42
  someString = "Some String"
  someFloat = 11.11
  someInt = 22
}
let getInitCounter () : Task<Model> = task { return initState }

let htmlTemplate =
  let clientHtml = Fable.ReactServer.renderToString(Shared.View.view initState ignore)
  
  let stateJson = // Serialize twice to output json as js string in html
    Encode.Auto.toString(0, initState)
    |> Encode.string |> Encode.toString 0
  html []
    [ head []
        [ link
            [ _rel "stylesheet"
              _href "https://cdnjs.cloudflare.com/ajax/libs/bulma/0.6.2/css/bulma.min.css"
            ]
          link
            [ _rel "stylesheet"
              _href (assetsBaseUrl + "/index.css")
            ]
        ]
      body []
        [ div [_id "elmish-app"] [ rawText clientHtml ]
          script []
            [ rawText (sprintf """
            var __INIT_STATE__ = %s
            """ stateJson) ]
          script [ _src (assetsBaseUrl + "/public/bundle.js") ] []
        ]
    ]


let webApp : HttpHandler =
  choose [

    route "/" >=> htmlView htmlTemplate
    route "/api/init" >=>
      fun next ctx ->
        task {
          let! counter = getInitCounter()
          return! Successful.OK counter next ctx
        }
  ]

let configureApp  (app : IApplicationBuilder) =
  app.UseStaticFiles()
     .UseGiraffe webApp


let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore
    services.AddSingleton<IJsonSerializer, ThothSerializer>() |> ignore

[<EntryPoint>]
let main argv =
  WebHost
    .CreateDefaultBuilder()
    .UseWebRoot(clientPath)
    .UseContentRoot(clientPath)
    .Configure(Action<IApplicationBuilder> configureApp)
    .ConfigureServices(configureServices)
    .UseUrls("http://0.0.0.0:" + port.ToString() + "/")
    .Build()
    .Run()
  0
