module HelloWorld

open Fable.React
open Fable.React.Props
open Browser

let helloWord = h1 [] [str "Hello World!"]

let MyButton text =
    button [] [str text]

let init() =
    ReactDom.render(
        fragment [] [
            helloWord
            MyButton "Hello"
            MyButton "World"
        ],
        document.getElementsByClassName("hello-world").[0])

init()













// let MyButton text =
//     let count = Hooks.useState(0)
//     let text = sprintf "%s %i" text count.current
//     button [OnClick (fun _ -> count.update(fun c -> c + 1))] [str text]
