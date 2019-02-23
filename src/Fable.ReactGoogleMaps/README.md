# Fable.ReactGoogleMaps

Fable bindings and helpers for [react-google-map](https://github.com/tomchentw/react-google-maps)

## Installation

```
npm install --save react-google-maps # or
yarn add react-google-maps
yarn add @babel/plugin-proposal-class-properties

paket add Fable.ReactGoogleMaps --project [yourproject]
```

## Usage

In your css add the following:

```css
.maploadercontainer,
.mapcontainer {
    height: calc(100vh - 18rem);
    width: 100%;
}
```

and in your F# code you can create the map like this:

```fs
open Fable.Core.JsInterop
open Fable.Helpers.ReactGoogleMaps
open Fable.Helpers.ReactGoogleMaps.Props

let defaultCenter:Fable.Import.GoogleMaps.LatLngLiteral = Fable.Helpers.GoogleMaps.Literal.createLatLng 40.6892494 -74.0445004

let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        MapProperties.MapLoadingContainer "maploadercontainer"
        MapProperties.MapContainer "mapcontainer"
        MapProperties.DefaultZoom 9
        MapProperties.DefaultCenter !^ defaultCenter
        MapProperties.Center !^ defaultCenter ]
```

### Traffic Layer

Google Maps allows you to activate the traffic layer. The map component has a simple property for that:


```fs
let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        // ..
        MapProperties.ShowTrafficLayer true ]
```

### SearchBox

If you want to show a searchbox in Google Maps then use the following properties:


```fs
let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        // ..
        MapProperties.SearchBoxText "Search"
        MapProperties.ShowSearchBox true ]
```

### Markers

If you want to show markers on the map then you can create them like this:

```fs
let markers =
    locations
    |> Array.map (fun location ->
        marker [
            MarkerProperties.Key location.ID
            MarkerProperties.Position !^ (Fable.Helpers.GoogleMaps.Literal.createLatLng location.X location.Y)
            MarkerProperties.Icon (sprintf "Images/markers/%s.png" location.Color)
            MarkerProperties.Title location.Title] [])


let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        // ..
        MapProperties.Markers markers ]
```

If your markers are changing over time, then it's important to set the key property to some stable ID. This allows React to keep track of which markers actually changed and reduces flickering.

### MarkerClusterer

The map component allows you to use a [MarkerClusterer](https://tomchentw.github.io/react-google-maps/#markerclusterer):

```fs
let clustered =
    markers
    |> markerClusterer [
        MarkerClustererProperties.AverageCenter true
        MarkerClustererProperties.MaxZoom 15
        MarkerClustererProperties.EnableRetinaIcons true
        MarkerClustererProperties.GridSize 60.]

let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        // ..
        MapProperties.Clusterer clustered ]
```


### Getting properties from the map

It's possible to retrieve properties like current center or current bounds from the GoogleMaps component. You need to use a MapRef like the following:

```fs

let mutable mapRef = MapRef null
let onMapMounted (ref:obj) =
    mapRef <- MapRef ref

// ...


let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        // ..
        MapProperties.OnMapMounted onMapMounted ]

// ...

let bounds = mapRef.GetBounds()

```

### Set bounds of map to fit all the markers

```fs
// ...
let markerPositions: Position list = // ...


let mutable mapRef = MapRef null
let onMapMounted (ref:obj) =
    mapRef <- MapRef ref
    mapRef.FitBounds(getBoundsFromLatLngs markerPositions)

let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        // ..    
        MapProperties.Markers markers
        MapProperties.OnMapMounted onMapMounted ]

```
