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

open Newtonsoft.Json

open Shared

let clientPath = Path.Combine("..","Client") |> Path.GetFullPath
let port = 8085us

let initState: Model = {
  counter = Some 42
  someString = "Some String"
  someFloat = 11.11
  someInt = 22
}

let getInitCounter () : Task<Model> = task { return initState }

let htmlTemplate =
  html []
    [ head [] []
      body []
        [ div [_id "elmish-app"] [ rawText (Fable.Helpers.ReactServer.renderToString(Client.View.view initState ignore)) ]
          script []
            [ rawText (sprintf """
            var __INIT_STATE__ = %s
            """ (toJson initState)) ]
          script [ _src "http://localhost:8080/public/bundle.js" ] []
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
    // Configure JsonSerializer to use Fable.JsonConverter
    let fableJsonSettings = JsonSerializerSettings()
    fableJsonSettings.Converters.Add(Fable.JsonConverter())

    services.AddSingleton<IJsonSerializer>(
        NewtonsoftJsonSerializer(fableJsonSettings)) |> ignore

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
