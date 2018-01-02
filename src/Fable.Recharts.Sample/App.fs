module App

open Fable.Recharts
open Fable.Recharts.Props
module R = Fable.Helpers.React
module P = R.Props
open Data

let margin t r b l =
    Chart.Margin { top = t; bottom = b; right = r; left = l }

let lineChartSample() =
    lineChart
        [ margin 5. 20. 5. 0.
          Chart.Width 600.
          Chart.Height 300.
          Chart.Data data ]
        [ line
            [ Cartesian.Type Monotone
              Cartesian.DataKey "uv"
              P.Stroke "#8884d8"
              P.StrokeWidth 2. ]
            []
          cartesianGrid
            [ P.Stroke "#ccc"
              P.StrokeDasharray "5 5" ]
            []
          xaxis [Cartesian.DataKey "name"] []
          yaxis [] []
          tooltip [] []
        ]

let barChartSample() =
    barChart
        [ margin 5. 20. 5. 0.
          Chart.Width 600.
          Chart.Height 300.
          Chart.Data data ]
        [ xaxis [Cartesian.DataKey "name"] []
          yaxis [] []
          tooltip [] []
          legend [] []
          cartesianGrid [P.StrokeDasharray "3 3"] []
          bar [Cartesian.DataKey "pv"; Cartesian.StackId "a"; P.Fill "#8884d8"] []
          bar [Cartesian.DataKey "uv"; Cartesian.StackId "a"; P.Fill "#82ca9d"] []
        ]

let areaChartSample() =
    areaChart
        [ margin 10. 30. 0. 0.
          Chart.Width 730.
          Chart.Height 250.
          Chart.Data data ]
        [
          R.defs []
            [ R.linearGradient
                [ P.Id "colorUv"; P.X1 0.; P.Y1 0.; P.X2 0.; P.Y2 1.]
                [ R.stop [ P.Offset "5%"; P.StopColor "#8884d8"; P.StopOpacity 0.8 ] []
                  R.stop [ P.Offset "95%"; P.StopColor "#8884d8"; P.StopOpacity 0 ] [] ]
              R.linearGradient
                [ P.Id "colorPv"; P.X1 0.; P.Y1 0.; P.X2 0.; P.Y2 1.]
                [ R.stop [ P.Offset "5%"; P.StopColor "#82ca9d"; P.StopOpacity 0.8 ] []
                  R.stop [ P.Offset "95%"; P.StopColor "#82ca9d"; P.StopOpacity 0 ] [] ] ]
          xaxis [ Cartesian.DataKey "name" ] []
          yaxis [] []
          cartesianGrid [P.StrokeDasharray "3 3"] []
          tooltip [] []
          area
            [ Cartesian.Type Monotone
              Cartesian.DataKey "uv"
              Cartesian.Stroke "#8884d8"
              P.Fill "url(#colorUv)"
              P.FillOpacity 1 ] []
          area
            [ Cartesian.Type Monotone
              Cartesian.DataKey "pv"
              Cartesian.Stroke "#82ca9d"
              P.Fill "url(#colorPv)"
              P.FillOpacity 1 ] []
        ]

let renderApp() =
    R.mountById "container1" <| lineChartSample()
    R.mountById "container2" <| barChartSample()
    R.mountById "container3" <| areaChartSample()

renderApp()
