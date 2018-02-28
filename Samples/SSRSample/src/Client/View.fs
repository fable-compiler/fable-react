
module Client.View


open Fable.Helpers.React
open Fable.Helpers.React.Props
open Client.Types
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
        input [ Type "checkbox"; Checked true ]
        input [ Type "checkbox"; Checked false ]
        input [ Type "checkbox"; Checked true; DefaultChecked false ]
        input [ Type "checkbox"; DefaultChecked true; Checked false ]
      ]
      div [] [
        span [] [ str "Test value:" ]
        input [ Type "text"; DefaultValue "true" ]
        input [ Type "text"; DefaultValue "false" ]
        input [ Type "text"; Value "true" ]
        input [ Type "text"; Value "false" ]
        input [ Type "text"; Value "true"; DefaultValue "false" ]
        input [ Type "text"; DefaultValue "true"; Value "false" ]
      ]

      div [] [
        span [] [ str "Test textarea:" ]
        textarea [ DefaultValue "true" ] []
        textarea [ DefaultValue "false" ] []
        textarea [ Value "true" ] []
        textarea [ Value "false" ] []
        textarea [ Value "true"; DefaultValue "false" ] []
        textarea [ DefaultValue "true"; Value "false" ] []
      ]
    ]
