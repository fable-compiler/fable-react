
module Client.View


open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.Isomorphic
open Fable.Helpers.React.Props
open Client.Types
open Shared

type [<Pojo>] JsCompProps = {
  text: string
}

#if FABLE_COMPILER
let JsComp: React.ComponentClass<JsCompProps> = importDefault "./jsComp"
#else
let JsComp = Unchecked.defaultof<React.ComponentClass<JsCompProps>>
#endif

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

let jsComp (props: JsCompProps) =
  ofImport "default" "./jsComp" props []

let jsCompServer (props: JsCompProps) =
  div [] [ str "loading" ]

type [<Pojo>] MyProp = {
  text: string
}
type [<Pojo>] MyState = {
  text: string
}

type MyReactComp(initProps: MyProp) as self =
  inherit React.Component<MyProp, MyState>(initProps) with
  do self.setInitState { text="my state" }

  override x.render() =
    div []
      [ span [] [ str (sprintf "prop: %s state: %s" x.props.text x.state.text) ]
        span [] [ ofArray x.children ] ]



type [<Pojo>] FnCompProps = {
  text: string
}

let fnComp (props: FnCompProps) =
  div []
      [ span [] [ str (sprintf "prop: %s" props.text) ] ]

type [<Pojo>] FnCompWithChildrenProps = {
  children: React.ReactElement array
  text: string
}

let fnCompWithChildren (props: FnCompWithChildrenProps) =
  div []
      [ span [] [ str (sprintf "prop: %s" props.text) ]
        span [] [ ofArray props.children ] ]

let view (model: Model) (dispatch) =
  div []
    [ h1 [] [ str "SAFE Template" ]
      p  [] [ str "The initial counter is fetched from server" ]
      p  [] [ str "Press buttons to manipulate counter:" ]
      button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
      div [] [ str (show model.counter) ]
      button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
      safeComponents
      div [] [
        span [] [ str "Test str:" ]
        span [] [ str model.someString ]
      ]
      div [] [
        span [] [ str "Test ofFloat:" ]
        span [] [ ofFloat model.someFloat ]
      ]
      div [] [
        span [] [ str "Test ofInt:" ]
        span [] [ ofInt model.someInt ]
      ]
      div [] [
        span [] [ str "Test html attr:" ]
        span [ Id "someId"; Data ("aa", "bb"); HTMLAttr.Custom ("cc", "dd") ] [ str "data-aa" ]
      ]
      div [] [
        span [] [ str "Test CSS prop:" ]
        div [ Style [ Display "block"; CSSProp.Custom ("color", "red") ] ] [ str "Custom CSSProp" ]
      ]
      div [] [
        span [] [ str "Test checkbox:" ]
        input [ Type "checkbox"; DefaultChecked true ]
        input [ Type "checkbox"; DefaultChecked false ]
        input [ Type "checkbox"; Checked true; OnChange ignore ]
        input [ Type "checkbox"; Checked false; OnChange ignore ]
      ]
      div [] [
        span [] [ str "Test value:" ]
        input [ Type "text"; DefaultValue "true" ]
        input [ Type "text"; DefaultValue "false" ]
        input [ Type "text"; Value "true"; OnChange ignore ]
        input [ Type "text"; Value "false"; OnChange ignore ]
      ]

      div [] [
        span [] [ str "Test textarea:" ]
        textarea [ DefaultValue "true" ] []
        textarea [ DefaultValue "false" ] []
        textarea [ Value "true"; OnChange ignore] []
        textarea [ Value "false"; OnChange ignore] []
      ]

      div [] [
        span [] [ str "Test React.Fragment:" ]
        fragment []
          [ span [] [ str "child 1" ]
            span [] [ str "child 2" ]
            span [] [ str "child 3" ]
            span [] [ str "child 4" ]
          ]
      ]

      div [] [
        span [] [ str "Test escape:" ]
        fragment []
          [ span
              [ Data ("value", "<div>\"\'&</div>");
                Style [ Display "<div>\"\'&</div>"]
              ]
              [ str "<div>\"\'&</div>" ]
          ]
      ]

      div [] [
        span [] [ str "Test js component:" ]
        hybridView jsComp jsCompServer { text="I'm rendered by a js Component!" }
      ]

      div [] [
        span [] [ str "Test ofType:" ]
        ofType<MyReactComp, _, _> { text="my prop" } [ span [] [ str "I'm rendered by children!"] ]
      ]

      div [] [
        span [] [ str "Test ofFunction:" ]
        ofFunction fnComp { text = "I'm rendered by Function Component!"} []
        ofFunction fnCompWithChildren { text = "I'm rendered by Function Component!"; children=[||]} [ span [] [ str "I'm rendered by children!"] ]
      ]

    ]
