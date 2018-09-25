# Fable.ReactGoogleMaps

Fable bindings and helpers for [react-google-map](https://github.com/tomchentw/react-google-maps)

## Installation

    npm install --save react-google-maps # or
    yarn add react-google-maps

    paket add Fable.ReactGoogleMap --project [yourproject]

## Usage

In your css add the following:

    .maploadercontainer,
    .mapcontainer {
        height: calc(100vh - 18rem);
        width: 100%;
    }

and in your F# code you can create the map like this:

    let defaultCenter:Position = { lat = 40.6892494 ; lng = -74.0445004 }

    let myMap =
        googleMap [ 
            MapProperties.ApiKey googleMapApiKey
            MapProperties.MapContainer "mapContainer"
            MapProperties.DefaultZoom 9
            MapProperties.DefaultCenter defaultCenter
            MapProperties.Center defaultCenter ]