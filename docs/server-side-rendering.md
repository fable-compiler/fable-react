# Five steps to enable Server-Side Rendering in your Elmish + DotNet App!

[SSR Sample App of SAFE-stack template is available!](https://github.com/fable-compiler/fable-react/tree/master/Samples/SSRSample)

## Step 1: Reorganize your source files

Separate all your elmish view and types to standalone files, like this:

```F#
pages
|-- Home
    |-- View.fs // contains view function.
    |-- Types.fs // contains msg and model type definitions, also should include init function.
    |-- State.fs // contains update function

```

View.fs and Types.fs will be shared between client and server.

## Step 2. Make sure shared files can be executed on the server side

Some code that works in Fable might throw a run time exception when executed on dotnet, so we should be careful with unsafe type casting and add compiler directives to remove some code if necessary.

Here are some hints about doing this:

### 1. Replace unsafe cast (unbox and `!!`) in your HTML attributes and CSS props with `HTMLAttr.Custom`, `SVGAttr.Custom` and `CSSProp.Custom`

```diff
- div [ !!("class", "container") ] []
+ div [ HTMLAttr.Custom ("class", "container") ]


- div [ Style [ !!("class", "container") ] ] []
+ div [ Style [ CSSProp.Custom("class", "container") ] ] []

- svg [ !!("width", 100) ] []
+ svg [ SVGAttr.Custom("class", "container") ] []
```


### 2. Make sure your browser/js code won't be executed on the server side

One big challenge of sharing code between client and server is that server side has different API environment than client side. In this respect Fable + dotnet's SSR is not much different than nodejs, except in dotnet you should not only prevent browser's API call, but also js.

Thanks for Fable Compiler's `FABLE_COMPILER` directive, we can easly distinguish client environment and server environment and execute different code in each environment:

```#F
#if FABLE_COMPILER
    executeOnClient ()
#else
    executeOnServer ()
#endif
```

We also provice a help function in `Fable.Helpers.Isomorphic` of this, the definition is:

```F#
let inline isomorphicExec clientFn serverFn input =
#if FABLE_COMPILER
    clientFn input
#else
    serverFn input
#endif
```

Full example:

```diff
open Fable.Core
open Fable.Import.JS
open Fable.Helpers.Isomorphic
open Fable.Import.Browser

// example code to make your document's title has marquee effect
-window.setInterval(
-    fun () ->
-        document.title <- document.title.[1..len - 1] + document.title.[0..0],
-    600
-)


+let inline clientFn () =
+    window.setInterval(
+        fun () ->
+            document.title <- document.title.[1..len - 1] + document.title.[0..0],
+        600
+    )
+isomorphicExec clientFn ignore ()
```


### 3. Add a placeholder for components that cannot been rendered on the server side, like js native components.

In `Fable.Helpers.Isomorphic` we also implemented a help function to render a placeholder element for components that cannot been rendered on the server side, this function will also help [React.hydrate](https://reactjs.org/docs/react-dom.html#hydrate) to understand the differences between htmls rendered by client and server, so React won't treat it as a mistake and warn about it.

```diff
open Fable.Core
open Fable.Import.JS
open Fable.Helpers.React
open Fable.Helpers.Isomorphic
open Fable.Import.Browser

type [<Pojo>] JsCompProps = {
  text: string
}


let jsComp (props: JsCompProps) =
  ofImport "default" "./jsComp" props []

-jsComp { text="I'm rendered by a js Component!" }

+let jsCompServer (props: JsCompProps) =
+  div [] [ str "loading" ]
+
+isomorphicView jsComp jsCompServer { text="I'm rendered by a js Component!" }
```

## Step 3. Create your init state on the server side.

On the server side, you could create routes like normal MVC app, just make sure the model passed to server rendering function is exactly match the model on the client side in current route.

Here is an example:

```F#

open Giraffe
open Giraffe.GiraffeViewEngine
open FableJson

let initState: Model = {
    counter = Some 42
    someString = "Some String"
    someFloat = 11.11
    someInt = 22
}

let renderHtml () =
    // This would render the html by model create on the server side.
    // Note in an Elmish app, view function takes two parameters,
    // the first is model, and the second is dispatch,
    // which simple ignored here because React will bind event handlers for you on the client side.
    let htmlStr = Fable.Helpers.ReactServer.renderToString(Client.View.view initState ignore)

    // We also need to pass the model to Elmish and React by print a json string in html to let them know what's the model that used to rendering the html.
    // Note we call ofJson twice here,
    // because Elmish's model can contains some complicate type instead of pojo,
    // the first one will seriallize the state to json string,
    // and the second one will seriallize the json string to a legally js string,
    // so we can deseriallize it by Fable's ofJson and get the correct types.
    let stateJsonStr = toJson (toJson initState)

    html []
        [ head [] []
        body []
            [ div [_id "elmish-app"] [ rawText htmlStr ]
            script []
                [ rawText (sprintf """
                var __INIT_STATE__ = %s
                """ stateJsonStr) ] //
            script [ _src (assetsBaseUrl + "/public/bundle.js") ] []
            ]
        ]
```

## Step 4. Update your elmish app's init function

1. Init your elmish app by state printed in the HTML.
2. Remove init commands that still fetch data which already printed in the HTML.

e.g.

```F#
let init () =
  // Init model by server side state
  let model = ofJson<Model> !!window?__INIT_STATE__
  // let cmd =
  //   Cmd.ofPromise
  //     (fetchAs<int> "/api/init")
  //     []
  //     (Ok >> Init)
  //     (Error >> Init)
  model, Cmd.none
```

## Step 5. Using React.hydrate to render your app

```diff
Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
|> Program.withHMR
#endif
-|> Program.withReact "elmish-app"
+|> Program.withReactHydrate "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
```

Now enjoy! If you find bugs or just need some help, please create an issue and let us know.

## Try the sample app

```sh
git clone https://github.com/fable-compiler/fable-react.git
cd ./fable-react/Samples/SSRSample/
./build.sh # or ./build.cmd in windows
```
