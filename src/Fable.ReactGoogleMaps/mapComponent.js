import { withScriptjs, withGoogleMap, GoogleMap, TrafficLayer } from "react-google-maps";
const { SearchBox } = require("react-google-maps/lib/components/places/SearchBox");
import React from 'react';

const TrafficMapComponent = withScriptjs(withGoogleMap((props) => {
  var childs = [ props.markers ];
  if(props.showSearchBox) {
    var inputBox =
        React.createElement("input",
            { type:"text",
            placeholder : props.searchBoxText,
            style : {
                boxSizing: `border-box`,
                border: `1px solid transparent`,
                width: `240px`,
                height: `30px`,
                marginTop: `10px`,
                padding: `0 12px`,
                borderRadius: `3px`,
                boxShadow: `0 1px 6px rgba(0, 0, 0, 0.3)`,
                fontSize: `14px`,
                outline: `none`,
                textOverflow: `ellipses`}
            });

    var searchBox =
        React.createElement(SearchBox,
            { ref : props.onSearchBoxMounted,
              key: "googlemaps-searchBox",
              bounds : props.bounds,
              controlPosition : google.maps.ControlPosition.TOP_LEFT,
              onPlacesChanged : props.onPlacesChanged },
              inputBox
        );

    childs = [ searchBox, ...childs ];
  };

  if(props.showTrafficLayer) {
      var traffic = React.createElement(TrafficLayer, { key: "googlemaps-traffic-layer" });
      childs = [ traffic, ...childs ]
  };

  return (
    React.createElement(
        GoogleMap,
        { defaultZoom : props.defaultZoom,
          key: "googlemaps-map",
          onZoomChanged : props.onZoomChanged,
          onIdle : props.onIdle,
          defaultCenter : props.defaultCenter,
          onClick: props.onClick,
          center : props.center,
          options: props.options,
          ref : props.onMapMounted },
        childs))
}));

export class GoogleMapComponent extends React.PureComponent {

    constructor(props) {
        super(props);
        this.searchBoxRef = {};
        this.state = {
            isMarkerShown: false,
        };
        this.delayedShowMarker = this.delayedShowMarker.bind(this);
    }

    componentDidMount() {
      this.delayedShowMarker()
    }

    delayedShowMarker() {
      setTimeout(() => {
        this.setState({ isMarkerShown: true })
      }, 3000)
    }

    render() {
      var loading = React.createElement("div", { className : this.props.mapLoadingContainer, style : { width: `100%` }}, "Loading");
      var container = React.createElement("div", { className : this.props.mapContainer});
      var mapElement = React.createElement("div", { style : { height: `100%` }});
      return (
        React.createElement(
          TrafficMapComponent,
          { key:"map",
            isMarkerShown: this.state.isMarkerShown,
            defaultZoom: this.props.defaultZoom,
            onZoomChanged: this.props.onZoomChanged,
            defaultCenter: this.props.defaultCenter,
            searchBoxText: this.props.searchBoxText,
            showSearchBox: this.props.showSearchBox,
            showTrafficLayer: this.props.showTrafficLayer,
            center: this.props.center, 
            options: this.props.options,
            onPlacesChanged: () => {
                this.props.onPlacesChanged(this.searchBoxRef.getPlaces())
            },
            onIdle: this.props.onIdle,
            onMapMounted: this.props.onMapMounted,
            onSearchBoxMounted: ref => {
                this.searchBoxRef = ref;
            },
            markers: this.props.markers,
            onMarkerClick: () => {
                this.setState({ isMarkerShown: false })
                this.delayedShowMarker()
            }, 
            onClick: this.props.onClick,
            googleMapURL: "https://maps.googleapis.com/maps/api/js?key=" + this.props.apiKey + "&v=3.exp&libraries=geometry,drawing,places",
            loadingElement: loading,
            containerElement: container,
            mapElement: mapElement
          }))
    }
  }
