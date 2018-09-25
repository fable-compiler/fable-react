module Fable.Helpers.ReactGoogleMaps

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop

module Coordinates =

    /// GoogleMaps Position
    /// see https://developers.google.com/maps/documentation/javascript/reference/coordinates
    type IPosition =
        abstract member lat: unit -> float
        abstract member lng: unit -> float

    let newPos lat lng =
        { new IPosition 
            with 
                member __.lat() = lat
                member __.lng() = lng }

    type [<Pojo>] Bounds = {
        NE : IPosition
        SW : IPosition
    }


module Places =

    type [<Pojo>] Geometry = {
        location: Coordinates.IPosition
    }

    type [<Pojo>] Place = {
        geometry: Geometry
    }


module R = Fable.Helpers.React

type RCom = React.ComponentClass<obj>

type MapRef(mapRef) =

    /// Get the current bounds of the Map
    member __.GetBounds() : Coordinates.Bounds =
        let bounds = mapRef?getBounds()
        let ne = bounds?getNorthEast()
        let sw = bounds?getSouthWest()

        { NE = Coordinates.newPos (ne?lat() |> unbox) (ne?lng() |> unbox)
          SW = Coordinates.newPos (sw?lat() |> unbox) (sw?lng() |> unbox) }

    member __.GetZoom() : int =
        mapRef?getZoom() |> unbox

    member __.GetCenter() : Coordinates.IPosition =
        mapRef?getCenter() |> unbox

module Props =

    type IInfoWindowProperties =
        interface end

    [<RequireQualifiedAccess>]
    type InfoWindowProperties =
    | OnCloseClick of (unit -> unit)
        interface IInfoWindowProperties

    type ISearchBoxProperties =
        interface end

    [<RequireQualifiedAccess>]
    type SearchBoxProperties =
    | Ref of (obj -> unit)
    | OnPlacesChanged of (unit -> unit)
        interface ISearchBoxProperties

    type IMarkerProperties =
        interface end

    [<RequireQualifiedAccess>]
    type MarkerProperties =
    | Key of obj
    | Title of string
    | Icon of string
    | OnClick of (unit -> unit)
    | Position of Coordinates.IPosition
        interface IMarkerProperties

    type IMarkerClustererProperties =
        interface end

    [<RequireQualifiedAccess>]
    type MarkerClustererProperties =
    | Key of obj
    | AverageCenter of bool
    | MaxZoom of int
    | EnableRetinaIcons of bool
    | GridSize of float
        interface IMarkerClustererProperties

    type IMapProperties =
        interface end
        

        
    // https://developers.google.com/maps/documentation/javascript/events#EventArguments
    type GoogleMapsMouseEvent =
        { latLng: Coordinates.IPosition }

    [<RequireQualifiedAccess>]
    type MapProperties =
    | SetRef of (obj -> unit)
    | ApiKey of string
    | DefaultZoom of int
    | SearchBoxText of string
    | ShowSearchBox of bool
    | ShowTrafficLayer of bool
    | DefaultCenter of Coordinates.IPosition
    | Center of Coordinates.IPosition
    | OnCenterChanged of (unit -> unit)
    | OnPlacesChanged of (Places.Place [] -> unit)
    | OnZoomChanged of (unit -> unit)
    | OnIdle of (unit -> unit)
    | OnClick of (GoogleMapsMouseEvent -> unit)
    | Markers of React.ReactElement list
    | MapLoadingContainer of string
    | MapContainer of string
    | Options of obj
        interface IMapProperties
let InfoWindow: RCom = import "InfoWindow" "react-google-maps"

/// A wrapper around google.maps.InfoWindow
let infoWindow (props:Props.IInfoWindowProperties list) child : React.ReactElement =
    R.from InfoWindow (keyValueList CaseRules.LowerFirst props) [child]

let SearchBox: RCom = import "SearchBox" "react-google-maps"

/// A wrapper around google.maps.places.SearchBox on the map
let searchBox (props:Props.ISearchBoxProperties list) children : React.ReactElement =
    R.from SearchBox (keyValueList CaseRules.LowerFirst props) children


let Marker: RCom = import "Marker" "react-google-maps"

/// A wrapper around google.maps.Marker
let marker (props:Props.IMarkerProperties list) children : React.ReactElement =
    R.from Marker (keyValueList CaseRules.LowerFirst props) children

let MarkerClusterer: RCom = import "MarkerClusterer" "react-google-maps/lib/components/addons/MarkerClusterer.js"

/// A wrapper around MarkerClusterer - https://github.com/mahnunchik/markerclustererplus/blob/master/docs/reference.html
let markerClusterer (props:Props.IMarkerClustererProperties list) (markers:React.ReactElement list) : React.ReactElement =
    R.from MarkerClusterer (keyValueList CaseRules.LowerFirst props) markers

let GoogleMapComponent: RCom = import "GoogleMapComponent" "./mapComponent.js"


/// A wrapper around google.maps.Map
let googleMap (props:Props.IMapProperties list) : React.ReactElement =

    R.from GoogleMapComponent (keyValueList CaseRules.LowerFirst props) []


let getPosition (options: obj) : Fable.Import.JS.Promise<Fable.Import.Browser.Position> = importMember "./location.js"
