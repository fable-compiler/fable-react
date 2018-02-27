
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
      div [] [ str model.someString ]
      div [] [ ofFloat model.someFloat ]
      div [] [ ofInt model.someInt ]

      div [ Id "someId"; Data ("aa", "bb") ] [ str "data-aa" ]
      input [ Type "checkbox"; DefaultChecked true ]
      div [ HTMLAttr.Custom ("cc", "dd") ] [ str "Custom HTMLAttr" ]
      div [ Style [ Display "block"; CSSProp.Custom ("color", "red") ] ] [ str "Custom CSSProp" ]
    ]
