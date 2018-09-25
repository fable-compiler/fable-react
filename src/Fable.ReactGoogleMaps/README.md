# Fable.ReactGoogleMaps

Fable bindings and helpers for [react-google-map](https://github.com/tomchentw/react-google-maps)

## Installation

```
npm install --save react-google-maps # or
yarn add react-google-maps

paket add Fable.ReactGoogleMap --project [yourproject]
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
let defaultCenter:Position = { lat = 40.6892494 ; lng = -74.0445004 }

let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        MapProperties.MapLoadingContainer "maploadercontainer"
        MapProperties.MapContainer "mapcontainer"
        MapProperties.DefaultZoom 9
        MapProperties.DefaultCenter defaultCenter
        MapProperties.Center defaultCenter ]
```

## Markers

If you want to show markers on the map then you can create them like this:

```fs
let markers =
    locations
    |> Array.map (fun location ->
        marker [
            MarkerProperties.Key location.ID
            MarkerProperties.Position (Coordinates.newPos location.X location.Y)
            MarkerProperties.Icon (sprintf "Images/markers/%s.png" location.Color)
            MarkerProperties.Title location.Title] []))


let myMap =
    googleMap [ 
        MapProperties.ApiKey googleMapApiKey
        // ..
        MapProperties.Markers (unbox markers) ]
```

## MarkerClusterer

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
        MapProperties.Markers clustered ]
```
