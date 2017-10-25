module Fable.Helpers.ReactLeaflet

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.React
open Fable.Helpers.React.Props

    [<AutoOpen>]
    module Props =
        type IReactLeafletMapProp =
            inherit IProp

    let inline rtEl<[<Pojo>]'P when 'P :> IProp> (a:ComponentClass<'P>) (b:IProp list) c = React.from a (keyValueList CaseRules.LowerFirst b |> unbox) c

    // Minimal import from Leaflet

    type LatLngTuple = float * float

    type [<AllowNullLiteral>] Event =
        abstract ``type``: string with get, set
        abstract target: obj with get, set

    type EventHandler = Event -> unit

    type EventProps =
        | OnClick of EventHandler
        interface IReactLeafletMapProp

    type MapProps =
        | Center of obj //LatLngTuple
        | Zoom of int
        | MinZoom of int
        | MaxZoom of int
        interface IReactLeafletMapProp

    let Map = importMember<ComponentClass<IProp>> "react-leaflet"
    let inline map b c = rtEl Map b c

    type TileLayerProps =
        | Url of string
        | Attribution of string
        interface IReactLeafletMapProp

    let TileLayer = importMember<ComponentClass<IProp>> "react-leaflet"
    let inline tileLayer b c = rtEl TileLayer b c

    type MarkerProps =
        | ZIndexOffset of int
        | Draggable of bool
        | Opacity of float
        | Position of obj //LatLngTuple
        | Children of string
        interface IReactLeafletMapProp

    let Marker = importMember<ComponentClass<IProp>> "react-leaflet"
    let inline marker b c = rtEl Marker b c

    type PolylineProps =
        | Positions of obj //LatLngTuple []
        interface IReactLeafletMapProp

    let Polyline = importMember<ComponentClass<IProp>> "react-leaflet"
    let inline polyline b c = rtEl Polyline b c

    type PolygonProps =
        | Positions of obj //LatLngTuple []
        interface IReactLeafletMapProp

    let Polygon = importMember<ComponentClass<IProp>> "react-leaflet"
    let inline polygon b c = rtEl Polygon b c

    type TooltipProps =
        | OnClose of EventHandler
        | OnOpen of EventHandler
        | Pane of string
        interface IReactLeafletMapProp

    let Tooltip = importMember<ComponentClass<IProp>> "react-leaflet"
    let inline tooltip b c = rtEl Polygon b c

    type PathProps =
        | Stroke of bool
        | Color of string
        | Weight of int
        | Opacity of float
        | LineCap of string
        | LineJoin of string
        | DashArray of string
        | DashOffset of string
        | Fill of bool
        | FillColor of string
        | FillOpacity of float
        | FillRule of string
        | BubblingMouseEvents of obj
        | Renderer of obj
        // Interactive Layer
        | Interactive of bool
        // Layer
        | Pane of string
        | Attribution of string
        interface IReactLeafletMapProp

    let Path = importMember<ComponentClass<IProp>> "react-leaflet"
    let inline path b c = rtEl Path b c

    type LayerGroupProps =
        | AddLayer of EventHandler
        | RemoveLayer of EventHandler
        interface IReactLeafletMapProp

    let LayerGroup = importMember<ComponentClass<IProp>> "react-leaflet"
    let inline layerGroup b c = rtEl LayerGroup b c
