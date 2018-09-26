module Fable.Helpers.ReactGoogleMaps

open Fable.Core
open Fable.Import
open Fable.Core.JsInterop

module Coordinates =

    /// GoogleMaps Position
    /// see https://developers.google.com/maps/documentation/javascript/reference/coordinates
    type LatLng =
        abstract member lat: unit -> float
        abstract member lng: unit -> float

    let newLatLng (lat: float, lng: float) : LatLng =
        let pos = obj()
        pos?lat <- lat
        pos?lng <- lng
        pos |> unbox


    // https://developers.google.com/maps/documentation/javascript/reference/coordinates#LatLngBounds
    
    type LatLngBounds =
        abstract member extend : LatLngBounds -> LatLngBounds
        abstract member extend : LatLng -> LatLngBounds
        abstract member getSouthWest : unit -> LatLng
        abstract member getNorthEast : unit -> LatLng


    let newLatLngBounds (sw: LatLng, ne: LatLng) : LatLng =
        let bounds = obj()
        bounds?sw <- sw
        bounds?ne <- ne
        bounds |> unbox

        
    [<Emit("new window.google.maps.LatLngBounds()")>]
    let newEmptyLatLngBounds () : LatLngBounds = jsNative

    let emptyLatLngBounds () : LatLng =
        let bounds = obj()
        bounds |> unbox

module Places =

    type [<Pojo>] Geometry = {
        location: Coordinates.LatLng
    }

    type [<Pojo>] Place = {
        geometry: Geometry
    }


module R = Fable.Helpers.React

type RCom = React.ComponentClass<obj>

type MapRef(mapRef) =

    /// Get the current bounds of the Map
    member __.GetBounds() : Coordinates.LatLngBounds option =
        if isNull mapRef then
            None
        else
            Some(mapRef?getBounds() |> unbox)

    member __.GetZoom() : int option =
        if isNull mapRef then
            None
        else
            Some(mapRef?getZoom() |> unbox)


    member __.GetCenter() : Coordinates.LatLng option =
        if isNull mapRef then
            None
        else
            Some(mapRef?getCenter() |> unbox)

    member __.FitBounds(bounds: Coordinates.LatLngBounds, ?padding: float) : unit =
        if not(isNull mapRef) then
            mapRef?fitBounds(bounds, padding) |> ignore

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
    | Position of Coordinates.LatLng
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
        { latLng: Coordinates.LatLng }

    [<RequireQualifiedAccess>]
    type MapProperties =
    | OnMapMounted of (obj -> unit)
    | ApiKey of string
    | DefaultZoom of int
    | SearchBoxText of string
    | ShowSearchBox of bool
    | ShowTrafficLayer of bool
    | DefaultCenter of Coordinates.LatLng
    | Center of Coordinates.LatLng
    | OnCenterChanged of (unit -> unit)
    | OnPlacesChanged of (Places.Place [] -> unit)
    | OnZoomChanged of (unit -> unit)
    | OnIdle of (unit -> unit)
    | OnClick of (GoogleMapsMouseEvent -> unit)
    | Markers of React.ReactElement seq
    | [<CompiledName("Markers")>] Clusterer of React.ReactElement
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
