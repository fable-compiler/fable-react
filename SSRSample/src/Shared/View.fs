
module Shared.View


open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Fable.React.Isomorphic
open Shared.Types
open Shared


let show = function
| Some x -> string x
| None -> "Loading..."

let safeComponents =
  let intersperse sep ls =
    List.foldBack (fun x -> function
      | [] -> [x]
      | xs -> x::sep::xs) ls []

  let components =
    [
      "Giraffe", "https://github.com/giraffe-fsharp/Giraffe"
      "Fable", "http://fable.io"
      "Elmish", "https://fable-elmish.github.io/"
    ]
    |> List.map (fun (desc,link) -> a [ Href link ] [ str desc ] )
    |> intersperse (str ", ")
    |> span [ ]

  p [ ]
    [ strong [] [ str "SAFE Template" ]
      str " powered by: "
      components ]

type JsCompProps = {
  text: string
}

let jsComp (props: JsCompProps) =
  ofImport "default" "./jsComp" props []

let jsCompServer (props: JsCompProps) =
  div [] [ str "loading" ]


type MyProp = {
  text: string
}
type MyState = {
  text: string
}

type MyReactComp(initProps: MyProp) =
  inherit Component<MyProp, MyState>(initProps) with

  do base.setInitState({ text="my state" })

  override x.render() =
    div [ ClassName "class-comp children-comp" ]
      [ div [] [ str (sprintf "prop: %s state: %s" x.props.text x.state.text) ]
        div [] [ ofArray x.children ] ]



type FnCompProps = {
  text: string
}

let fnComp (props: FnCompProps) =
  div [ ClassName "fn-comp" ]
      [ span [] [ str (sprintf "prop: %s" props.text) ] ]

type FnCompWithChildrenProps = {
  children: ReactElement array
  text: string
}

let fnCompWithChildren (props: FnCompWithChildrenProps) =
  div [ ClassName "fn-comp children-comp" ]
      [ div [] [ str (sprintf "prop: %s" props.text) ]
        div [] [ ofArray props.children ] ]

let view (model: Model) (dispatch) =
  div []
    [ h1 [ ClassName "title is-1 has-text-centered"] [ str "Server-Side Rendering Sample" ]
      div [ ClassName "intro" ]
        [ p  [] [ str "The initial state is rendered in html from server." ]
          div [ ClassName "counter-app" ]
            [ p  [] [ str "Press buttons to manipulate counter:" ]
              div [ ClassName "counter" ]
                [ button [ ClassName "button is-small"; OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
                  span [ ClassName "tag is-info" ] [ str (show model.counter) ]
                  button [ ClassName "button is-small"; OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
                ]
            ]
          safeComponents
        ]
      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test str:" ]
        span [] [ str model.someString ]
      ]
      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test ofFloat:" ]
        span [] [ ofFloat model.someFloat ]
      ]
      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test ofInt:" ]
        span [] [ ofInt model.someInt ]
      ]
      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test html attr:" ]
        span [ Id "someId"; Data ("aa", "bb"); HTMLAttr.Custom ("cc", "dd") ] [ str "data-aa" ]
      ]
      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test CSS prop:" ]
        div [ Style [ Display DisplayOptions.Block
                      CSSProp.Color "red" ] ] [ str "Custom CSSProp" ]
      ]
      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test checkbox:" ]
        input [ ClassName "checkbox"; Type "checkbox"; DefaultChecked true ]
        input [ ClassName "checkbox"; Type "checkbox"; DefaultChecked false ]
        input [ ClassName "checkbox"; Type "checkbox"; Checked true; OnChange ignore ]
        input [ ClassName "checkbox"; Type "checkbox"; Checked false; OnChange ignore ]
      ]
      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test value:" ]
        input [ ClassName "input"; Type "text"; DefaultValue "true" ]
        input [ ClassName "input"; Type "text"; DefaultValue "false" ]
        input [ ClassName "input"; Type "text"; Value "true"; OnChange ignore ]
        input [ ClassName "input"; Type "text"; Value "false"; OnChange ignore ]
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test textarea:" ]
        textarea [ ClassName "textarea"; DefaultValue "true" ] []
        textarea [ ClassName "textarea"; DefaultValue "false" ] []
        textarea [ ClassName "textarea"; Value "true"; OnChange ignore] []
        textarea [ ClassName "textarea"; Value "false"; OnChange ignore] []
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test React.Fragment:" ]
        fragment []
          [ span [] [ str "child 1" ]
            span [] [ str "child 2" ]
            span [] [ str "child 3" ]
            span [] [ str "child 4" ]
          ]
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test escape:" ]
        fragment []
          [ span
              [ Data ("value", "<div>\"\'&</div>");
                // Style [ Display "<div>\"\'&</div>"]
              ]
              [ str "<div>\"\'&</div>" ]
          ]
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test js component:" ]
        isomorphicView jsComp jsCompServer { text="I'm rendered by a js Component!" }
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test ofType:" ]
        ofType<MyReactComp, _, _> { text="my prop" } [ span [] [ str " I'm rendered by children!"] ]
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test null:" ]
        null
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test ofFunction:" ]
        ofFunction fnComp { text = "I'm rendered by Function Component!"} []
        ofFunction fnCompWithChildren { text = " I'm rendered by Function Component! "; children=[||]} [ span [] [ str " I'm rendered by children!"] ]
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test void elements:" ]
        hr [ Style [ BorderColor "green" ] ]
        br []
      ]

      div [ ClassName "test-case" ] [
        span [ ClassName "label" ] [ str "Test add slug to attributes:" ]
        div
          [ HTMLAttr.Custom ("contentEditable", "true")
            HTMLAttr.Custom ("placeholder", "I'm editable!")
            Style [ CSSProp.Custom ("-webkit-transform", "translateX(30px)"); CSSProp.Custom ("-webkit-transform-origin", "0 0") ] ]
          [ ]
      ]
    ]
