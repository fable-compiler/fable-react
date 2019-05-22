# How to use react error boundaries in fable

When react renders the view and encounters an error it will by default just crash the complete application.
If your html page only contains a single react element your page will be essentially a white page from this point and the user needs to reload the website.

The problem is that a simple `try-catch` in the view will not be enough to handle errors in the render-pipeline. 
In order to catch these errors you need to overwrite `componentDidCatch`, this process is documented [here](https://reactjs.org/docs/error-boundaries.html)

While render-errors are rare when using fable it can happen, especially when embedding 3rd-party-components.
Because of this we provide a general purpose ReactErrorBoundary component which can be added and used from your application (including elmish-architecture)


## ReactErrorBoundaries.fs

Just copy the following code to your project:

```fsharp
module ReactErrorBoundary

open Fable.Core
open Fable.Import
open Fable.Helpers.React

type [<AllowNullLiteral>] InfoComponentObject =
    abstract componentStack: string with get

type ErrorBoundaryProps =
    { Inner : React.ReactElement
      ErrorComponent : React.ReactElement
      OnError : exn * InfoComponentObject -> unit }

type ErrorBoundaryState =
    { HasErrors : bool }

// See https://github.com/MangelMaxime/Fulma/blob/master/docs/src/Widgets/Showcase.fs
// See https://reactjs.org/docs/error-boundaries.html
type ErrorBoundary(props) =
    inherit React.Component<ErrorBoundaryProps, ErrorBoundaryState>(props)
    do base.setInitState({ HasErrors = false })

    override x.componentDidCatch(error, info) =
        let info = info :?> InfoComponentObject
        x.props.OnError(error, info)
        x.setState({ HasErrors = true })

    override x.render() =
        if (x.state.HasErrors) then
            x.props.ErrorComponent
        else
            x.props.Inner

let renderCatchSimple errorElement element =
    ofType<ErrorBoundary,_,_> { Inner = element; ErrorComponent = errorElement; OnError = fun _ -> () } [ ]

let renderCatchFn onError errorElement element =
    ofType<ErrorBoundary,_,_> { Inner = element; ErrorComponent = errorElement; OnError = onError } [ ]
```

## Usage

Usage from an elmish application could look similar to this:

Consider you have a `SubComponent` which might run into rendering issues and an `ErrorComponent` you want to show if a rendering issue occurs:

```fsharp
let view model dispatch =
    SubComponent.view model dispatch
    |> ReactErrorBoundary.renderCatchFn
        (fun (error, info) ->
            //dispatch (MyMessage ...)
            logger.Error("SubComponent failed to render" + info.componentStack, error))
        (ErrorComponent.view model dispatch)
```

If you don't need the `OnError` event:

```fsharp
let view model dispatch =
    SubComponent.view model dispatch
    |> ReactErrorBoundary.renderCatchSimple
        (ErrorComponent.view model dispatch)
```
