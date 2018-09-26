// ts2fable 0.6.1
module rec Google

open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

    [<Global("window.google.maps")>]
    let maps: Maps.IExports = jsNative

    module Maps =
//        let [<Import("adsense","module/google/maps")>] adsense: Adsense.IExports = jsNative
//        let [<Import("Data","module/google/maps")>] data: Data.IExports = jsNative
//        let [<Import("drawing","module/google/maps")>] drawing: Drawing.IExports = jsNative
//        let [<Import("geometry","module/google/maps")>] geometry: Geometry.IExports = jsNative
//        let [<Import("places","module/google/maps")>] places: Places.IExports = jsNative
//        let [<Import("visualization","module/google/maps")>] visualization: Visualization.IExports = jsNative

        type [<AllowNullLiteral>] IExports =
            abstract Map: MapStatic
            abstract Data: DataStatic
            abstract Marker: MarkerStatic
            abstract InfoWindow: InfoWindowStatic
            abstract Polyline: PolylineStatic
            abstract Polygon: PolygonStatic
            abstract Rectangle: RectangleStatic
            abstract Circle: CircleStatic
            abstract GroundOverlay: GroundOverlayStatic
            abstract OverlayView: OverlayViewStatic
            abstract MapCanvasProjection: MapCanvasProjectionStatic
            abstract Geocoder: GeocoderStatic
            abstract DirectionsRenderer: DirectionsRendererStatic
            abstract DirectionsService: DirectionsServiceStatic
            abstract ElevationService: ElevationServiceStatic
            abstract MaxZoomService: MaxZoomServiceStatic
            abstract DistanceMatrixService: DistanceMatrixServiceStatic
            abstract SaveWidget: SaveWidgetStatic
            abstract MapTypeRegistry: MapTypeRegistryStatic
            abstract ImageMapType: ImageMapTypeStatic
            abstract StyledMapType: StyledMapTypeStatic
            abstract BicyclingLayer: BicyclingLayerStatic
            abstract FusionTablesLayer: FusionTablesLayerStatic
            abstract KmlLayer: KmlLayerStatic
            abstract TrafficLayer: TrafficLayerStatic
            abstract TransitLayer: TransitLayerStatic
            abstract StreetViewPanorama: StreetViewPanoramaStatic
            abstract StreetViewService: StreetViewServiceStatic
            abstract StreetViewCoverageLayer: StreetViewCoverageLayerStatic
            abstract ``event``: eventStatic
            abstract LatLng: LatLngStatic
            abstract LatLngBounds: LatLngBoundsStatic
            abstract Point: PointStatic
            abstract Size: SizeStatic
            abstract MVCObject: MVCObjectStatic
            abstract MVCArray: MVCArrayStatic

        type [<AllowNullLiteral>] Map =
            inherit MVCObject
            abstract fitBounds: bounds: U2<LatLngBounds, LatLngBoundsLiteral> * ?padding: U2<float, Padding> -> unit
            abstract getBounds: unit -> LatLngBounds option
            abstract getCenter: unit -> LatLng
            abstract getDiv: unit -> Element
            abstract getHeading: unit -> float
            abstract getMapTypeId: unit -> U2<MapTypeId, string>
            abstract getProjection: unit -> Projection
            abstract getStreetView: unit -> StreetViewPanorama
            abstract getTilt: unit -> float
            abstract getZoom: unit -> float
            abstract panBy: x: float * y: float -> unit
            abstract panTo: latLng: U2<LatLng, LatLngLiteral> -> unit
            abstract panToBounds: latLngBounds: U2<LatLngBounds, LatLngBoundsLiteral> * ?padding: U2<float, Padding> -> unit
            abstract setCenter: latlng: U2<LatLng, LatLngLiteral> -> unit
            abstract setHeading: heading: float -> unit
            abstract setMapTypeId: mapTypeId: U2<MapTypeId, string> -> unit
            abstract setOptions: options: MapOptions -> unit
            abstract setStreetView: panorama: StreetViewPanorama -> unit
            abstract setTilt: tilt: float -> unit
            abstract setZoom: zoom: float -> unit
            abstract controls: ResizeArray<MVCArray<Node>> with get, set
            abstract data: Data with get, set
            abstract mapTypes: MapTypeRegistry with get, set
            abstract overlayMapTypes: MVCArray<MapType> with get, set
            abstract setClickableIcons: clickable: bool -> unit

        type [<AllowNullLiteral>] MapStatic =
            [<Emit "new $0($1...)">] abstract Create: mapDiv: Element option * ?opts: MapOptions -> Map

        type [<AllowNullLiteral>] Padding =
            abstract bottom: float with get, set
            abstract left: float with get, set
            abstract right: float with get, set
            abstract top: float with get, set

        type [<AllowNullLiteral>] MapOptions =
            /// Color used for the background of the Map div. This color will be visible
            /// when tiles have not yet loaded as the user pans. This option can only be
            /// set when the map is initialized.
            abstract backgroundColor: string option with get, set
            /// The initial Map center. Required. 
            abstract center: U2<LatLng, LatLngLiteral> option with get, set
            /// When false, map icons are not clickable. A map icon represents a point of
            /// interest, also known as a POI. By default map icons are clickable.
            abstract clickableIcons: bool option with get, set
            /// Enables/disables all default UI. May be overridden individually. 
            abstract disableDefaultUI: bool option with get, set
            /// Enables/disables zoom and center on double click. Enabled by default. 
            abstract disableDoubleClickZoom: bool option with get, set
            /// If false, prevents the map from being dragged. Dragging is enabled by
            /// default.
            abstract draggable: bool option with get, set
            /// The name or url of the cursor to display when mousing over a draggable
            /// map. This property uses the css cursor attribute to change the icon. As
            /// with the css property, you must specify at least one fallback cursor that
            /// is not a URL. For example: draggableCursor:
            /// 'url(http://www.example.com/icon.png), auto;'.
            abstract draggableCursor: string option with get, set
            /// The name or url of the cursor to display when the map is being dragged.
            /// This property uses the css cursor attribute to change the icon. As with
            /// the css property, you must specify at least one fallback cursor that is
            /// not a URL. For example: draggingCursor:
            /// 'url(http://www.example.com/icon.png), auto;'.
            abstract draggingCursor: string option with get, set
            /// The enabled/disabled state of the Fullscreen control. 
            abstract fullscreenControl: bool option with get, set
            /// The display options for the Fullscreen control. 
            abstract fullscreenControlOptions: FullscreenControlOptions option with get, set
            /// This setting controls how gestures on the map are handled.
            abstract gestureHandling: GestureHandlingOptions option with get, set
            /// The heading for aerial imagery in degrees measured clockwise from
            /// cardinal direction North. Headings are snapped to the nearest available
            /// angle for which imagery is available.
            abstract heading: float option with get, set
            /// If false, prevents the map from being controlled by the keyboard.
            /// Keyboard shortcuts are enabled by default.
            abstract keyboardShortcuts: bool option with get, set
            /// The initial enabled/disabled state of the Map type control. 
            abstract mapTypeControl: bool option with get, set
            /// The initial display options for the Map type control. 
            abstract mapTypeControlOptions: MapTypeControlOptions option with get, set
            /// The initial Map mapTypeId. Defaults to ROADMAP. 
            abstract mapTypeId: MapTypeId option with get, set
            /// The maximum zoom level which will be displayed on the map. If omitted, or
            /// set to null, the maximum zoom from the current map type is used instead.
            /// Valid values: Integers between zero, and up to the supported maximum zoom
            /// level.
            abstract maxZoom: float option with get, set
            /// The minimum zoom level which will be displayed on the map. If omitted, or
            /// set to null, the minimum zoom from the current map type is used instead.
            /// Valid values: Integers between zero, and up to the supported maximum zoom
            /// level.
            abstract minZoom: float option with get, set
            /// If true, do not clear the contents of the Map div. 
            abstract noClear: bool option with get, set
            abstract overviewMapControl: bool option with get, set
            abstract overviewMapControlOptions: OverviewMapControlOptions option with get, set
            /// The enabled/disabled state of the Pan control.
            /// Note: The Pan control is not available in the new set of controls
            /// introduced in v3.22 of the Google Maps JavaScript API. While using v3.22
            /// and v3.23, you can choose to use the earlier set of controls rather than
            /// the new controls, thus making the Pan control available as part of the
            /// old control set. See {@link
            /// https://developers.google.com/maps/articles/v322-controls-diff|What's New
            /// in the v3.22 Map Controls}.
            abstract panControl: bool option with get, set
            /// The display options for the Pan control.
            /// Note: The Pan control is not available in the new set of controls
            /// introduced in v3.22 of the Google Maps JavaScript API. While using v3.22
            /// and v3.23, you can choose to use the earlier set of controls rather than
            /// the new controls, thus making the Pan control available as part of the
            /// old control set. See {@link
            /// https://developers.google.com/maps/articles/v322-controls-diff|What's New
            /// in the v3.22 Map Controls}.
            abstract panControlOptions: PanControlOptions option with get, set
            /// The enabled/disabled state of the Rotate control. 
            abstract rotateControl: bool option with get, set
            /// The display options for the Rotate control. 
            abstract rotateControlOptions: RotateControlOptions option with get, set
            /// The initial enabled/disabled state of the Scale control. 
            abstract scaleControl: bool option with get, set
            /// The initial display options for the Scale control. 
            abstract scaleControlOptions: ScaleControlOptions option with get, set
            /// If false, disables scrollwheel zooming on the map. The scrollwheel is
            /// enabled by default.
            abstract scrollwheel: bool option with get, set
            /// The enabled/disabled state of the sign in control. This option only
            /// applies if signed_in=true has been passed as a URL parameter in the
            /// bootstrap request. You may want to use this option to hide the map's sign
            /// in control if you have provided another way for your users to sign in,
            /// such as the Google Sign-In button. This option does not affect the
            /// visibility of the Google avatar shown when the user is already signed in.
            abstract signInControl: bool option with get, set
            /// A StreetViewPanorama to display when the Street View pegman is dropped on
            /// the map. If no panorama is specified, a default StreetViewPanorama will
            /// be displayed in the map's div when the pegman is dropped.
            abstract streetView: StreetViewPanorama option with get, set
            /// The initial enabled/disabled state of the Street View Pegman control.
            /// This control is part of the default UI, and should be set to false when
            /// displaying a map type on which the Street View road overlay should not
            /// appear (e.g. a non-Earth map type).
            abstract streetViewControl: bool option with get, set
            /// The initial display options for the Street View Pegman control. 
            abstract streetViewControlOptions: StreetViewControlOptions option with get, set
            /// Styles to apply to each of the default map types. Note that for
            /// satellite/hybrid and terrain modes, these styles will only apply to
            /// labels and geometry.
            abstract styles: ResizeArray<MapTypeStyle> option with get, set
            /// Controls the automatic switching behavior for the angle of incidence of
            /// the map. The only allowed values are 0 and 45. The value 0 causes the map
            /// to always use a 0° overhead view regardless of the zoom level and
            /// viewport. The value 45 causes the tilt angle to automatically switch to
            /// 45 whenever 45° imagery is available for the current zoom level and
            /// viewport, and switch back to 0 whenever 45° imagery is not available
            /// (this is the default behavior). 45° imagery is only available for
            /// satellite and hybrid map types, within some locations, and at some zoom
            /// levels. Note: getTilt returns the current tilt angle, not the value
            /// specified by this option. Because getTilt and this option refer to
            /// different things, do not bind() the tilt property; doing so may yield
            /// unpredictable effects.
            abstract tilt: float option with get, set
            /// The initial Map zoom level. Required. Valid values: Integers between
            /// zero, and up to the supported maximum zoom level.
            abstract zoom: float option with get, set
            /// The enabled/disabled state of the Zoom control. 
            abstract zoomControl: bool option with get, set
            /// The display options for the Zoom control. 
            abstract zoomControlOptions: ZoomControlOptions option with get, set

        type MapTypeId =
            obj

        /// Options for the rendering of the map type control. 
        type [<AllowNullLiteral>] MapTypeControlOptions =
            /// IDs of map types to show in the control. 
            abstract mapTypeIds: ResizeArray<U2<MapTypeId, string>> option with get, set
            /// Position id. Used to specify the position of the control on the map.
            /// The default position is TOP_RIGHT.
            abstract position: ControlPosition option with get, set
            /// Style id. Used to select what style of map type control to display. 
            abstract style: MapTypeControlStyle option with get, set

        type MapTypeControlStyle =
            obj

        type [<AllowNullLiteral>] OverviewMapControlOptions =
            abstract opened: bool option with get, set

        type [<StringEnum>] [<RequireQualifiedAccess>] GestureHandlingOptions =
            | Cooperative
            | Greedy
            | None
            | Auto

        /// Options for the rendering of the pan control. 
        type [<AllowNullLiteral>] PanControlOptions =
            /// Position id. Used to specify the position of the control on the map.
            /// The default position is TOP_LEFT.
            abstract position: ControlPosition option with get, set

        /// Options for the rendering of the rotate control. 
        type [<AllowNullLiteral>] RotateControlOptions =
            /// Position id. Used to specify the position of the control on the map.
            /// The default position is TOP_LEFT.
            abstract position: ControlPosition option with get, set

        /// Options for the rendering of the scale control. 
        type [<AllowNullLiteral>] ScaleControlOptions =
            /// Style id. Used to select what style of scale control to display. 
            abstract style: ScaleControlStyle option with get, set

        type ScaleControlStyle =
            obj

        /// Options for the rendering of the Street View pegman control on the map. 
        type [<AllowNullLiteral>] StreetViewControlOptions =
            /// Position id. Used to specify the position of the control on the map. The
            /// default position is embedded within the navigation (zoom and pan)
            /// controls. If this position is empty or the same as that specified in the
            /// zoomControlOptions or panControlOptions, the Street View control will be
            /// displayed as part of the navigation controls. Otherwise, it will be
            /// displayed separately.
            abstract position: ControlPosition option with get, set

        /// Options for the rendering of the zoom control. 
        type [<AllowNullLiteral>] ZoomControlOptions =
            /// Position id. Used to specify the position of the control on the map.
            /// The default position is TOP_LEFT.
            abstract position: ControlPosition option with get, set
            abstract style: ZoomControlStyle option with get, set

        type ZoomControlStyle =
            obj

        type ControlPosition =
            obj

        type [<StringEnum>] [<RequireQualifiedAccess>] DrawingMode =
            | [<CompiledName "Point">] Point
            | [<CompiledName "LineString">] LineString
            | [<CompiledName "Polygon">] Polygon

        type [<AllowNullLiteral>] Data =
            inherit MVCObject
            abstract add: feature: U2<Data.Feature, Data.FeatureOptions> -> Data.Feature
            abstract addGeoJson: geoJson: Object * ?options: Data.GeoJsonOptions -> ResizeArray<Data.Feature>
            abstract contains: feature: Data.Feature -> bool
            abstract forEach: callback: (Data.Feature -> unit) -> unit
            abstract getControlPosition: unit -> ControlPosition
            abstract getControls: unit -> ResizeArray<DrawingMode>
            abstract getDrawingMode: unit -> DrawingMode option
            abstract getFeatureById: id: U2<float, string> -> Data.Feature
            abstract getMap: unit -> Map
            abstract getStyle: unit -> U2<Data.StylingFunction, Data.StyleOptions>
            abstract loadGeoJson: url: string * ?options: Data.GeoJsonOptions * ?callback: (ResizeArray<Data.Feature> -> unit) -> unit
            abstract overrideStyle: feature: Data.Feature * style: Data.StyleOptions -> unit
            abstract remove: feature: Data.Feature -> unit
            abstract revertStyle: ?feature: Data.Feature -> unit
            abstract setControlPosition: controlPosition: ControlPosition -> unit
            abstract setControls: controls: ResizeArray<DrawingMode> option -> unit
            abstract setDrawingMode: drawingMode: DrawingMode option -> unit
            abstract setMap: map: Map option -> unit
            abstract setStyle: style: U2<Data.StylingFunction, Data.StyleOptions> -> unit
            abstract toGeoJson: callback: (Object -> unit) -> unit

        type [<AllowNullLiteral>] DataStatic =
            [<Emit "new $0($1...)">] abstract Create: ?options: Data.DataOptions -> Data

        module Data =

            type [<AllowNullLiteral>] IExports =
                abstract Feature: FeatureStatic
                abstract Geometry: GeometryStatic
                abstract Point: PointStatic
                abstract MultiPoint: MultiPointStatic
                abstract LineString: LineStringStatic
                abstract MultiLineString: MultiLineStringStatic
                abstract LinearRing: LinearRingStatic
                abstract Polygon: PolygonStatic
                abstract MultiPolygon: MultiPolygonStatic
                abstract GeometryCollection: GeometryCollectionStatic

            type [<AllowNullLiteral>] DataOptions =
                abstract controlPosition: ControlPosition option with get, set
                abstract controls: ResizeArray<DrawingMode> option with get, set
                abstract drawingMode: DrawingMode option with get, set
                abstract featureFactory: (Data.Geometry -> Data.Feature) option with get, set
                abstract map: Map option with get, set
                abstract style: U2<Data.StylingFunction, Data.StyleOptions> option with get, set

            type [<AllowNullLiteral>] GeoJsonOptions =
                abstract idPropertyName: string option with get, set

            type [<AllowNullLiteral>] StyleOptions =
                abstract clickable: bool option with get, set
                abstract cursor: string option with get, set
                abstract draggable: bool option with get, set
                abstract editable: bool option with get, set
                abstract fillColor: string option with get, set
                abstract fillOpacity: float option with get, set
                abstract icon: U3<string, Icon, Symbol> option with get, set
                abstract shape: MarkerShape option with get, set
                abstract strokeColor: string option with get, set
                abstract strokeOpacity: float option with get, set
                abstract strokeWeight: float option with get, set
                abstract title: string option with get, set
                abstract visible: bool option with get, set
                abstract zIndex: float option with get, set

            type [<AllowNullLiteral>] StylingFunction =
                [<Emit "$0($1...)">] abstract Invoke: feature: Data.Feature -> Data.StyleOptions

            type [<AllowNullLiteral>] Feature =
                abstract forEachProperty: callback: (obj option -> string -> unit) -> unit
                abstract getGeometry: unit -> Data.Geometry
                abstract getId: unit -> U2<float, string>
                abstract getProperty: name: string -> obj option
                abstract removeProperty: name: string -> unit
                abstract setGeometry: newGeometry: U3<Data.Geometry, LatLng, LatLngLiteral> -> unit
                abstract setProperty: name: string * newValue: obj option -> unit
                abstract toGeoJson: callback: (Object -> unit) -> unit

            type [<AllowNullLiteral>] FeatureStatic =
                [<Emit "new $0($1...)">] abstract Create: ?options: Data.FeatureOptions -> Feature

            type [<AllowNullLiteral>] FeatureOptions =
                abstract geometry: U3<Data.Geometry, LatLng, LatLngLiteral> option with get, set
                abstract id: U2<float, string> option with get, set
                abstract properties: Object option with get, set

            type [<AllowNullLiteral>] Geometry =
                abstract getType: unit -> string
                abstract forEachLatLng: callback: (LatLng -> unit) -> unit

            type [<AllowNullLiteral>] GeometryStatic =
                [<Emit "new $0($1...)">] abstract Create: unit -> Geometry

            type [<AllowNullLiteral>] Point =
                inherit Data.Geometry
                abstract get: unit -> LatLng

            type [<AllowNullLiteral>] PointStatic =
                [<Emit "new $0($1...)">] abstract Create: latLng: U2<LatLng, LatLngLiteral> -> Point

            type [<AllowNullLiteral>] MultiPoint =
                inherit Data.Geometry
                abstract getArray: unit -> ResizeArray<LatLng>
                abstract getAt: n: float -> LatLng
                abstract getLength: unit -> float

            type [<AllowNullLiteral>] MultiPointStatic =
                [<Emit "new $0($1...)">] abstract Create: elements: ResizeArray<U2<LatLng, LatLngLiteral>> -> MultiPoint

            type [<AllowNullLiteral>] LineString =
                inherit Data.Geometry
                abstract getArray: unit -> ResizeArray<LatLng>
                abstract getAt: n: float -> LatLng
                abstract getLength: unit -> float

            type [<AllowNullLiteral>] LineStringStatic =
                [<Emit "new $0($1...)">] abstract Create: elements: ResizeArray<U2<LatLng, LatLngLiteral>> -> LineString

            type [<AllowNullLiteral>] MultiLineString =
                inherit Data.Geometry
                abstract getArray: unit -> ResizeArray<Data.LineString>
                abstract getAt: n: float -> Data.LineString
                abstract getLength: unit -> float

            type [<AllowNullLiteral>] MultiLineStringStatic =
                [<Emit "new $0($1...)">] abstract Create: elements: ResizeArray<U2<Data.LineString, ResizeArray<U2<LatLng, LatLngLiteral>>>> -> MultiLineString

            type [<AllowNullLiteral>] LinearRing =
                inherit Data.Geometry
                abstract getArray: unit -> ResizeArray<LatLng>
                abstract getAt: n: float -> LatLng
                abstract getLength: unit -> float

            type [<AllowNullLiteral>] LinearRingStatic =
                [<Emit "new $0($1...)">] abstract Create: elements: ResizeArray<U2<LatLng, LatLngLiteral>> -> LinearRing

            type [<AllowNullLiteral>] Polygon =
                inherit Data.Geometry
                abstract getArray: unit -> ResizeArray<Data.LinearRing>
                abstract getAt: n: float -> Data.LinearRing
                abstract getLength: unit -> float

            type [<AllowNullLiteral>] PolygonStatic =
                [<Emit "new $0($1...)">] abstract Create: elements: ResizeArray<U2<Data.LinearRing, ResizeArray<U2<LatLng, LatLngLiteral>>>> -> Polygon

            type [<AllowNullLiteral>] MultiPolygon =
                inherit Data.Geometry
                abstract getArray: unit -> ResizeArray<Data.Polygon>
                abstract getAt: n: float -> Data.Polygon
                abstract getLength: unit -> float

            type [<AllowNullLiteral>] MultiPolygonStatic =
                [<Emit "new $0($1...)">] abstract Create: elements: ResizeArray<U2<Data.Polygon, ResizeArray<U2<LinearRing, ResizeArray<U2<LatLng, LatLngLiteral>>>>>> -> MultiPolygon

            type [<AllowNullLiteral>] GeometryCollection =
                inherit Data.Geometry
                abstract getArray: unit -> ResizeArray<Data.Geometry>
                abstract getAt: n: float -> Data.Geometry
                abstract getLength: unit -> float

            type [<AllowNullLiteral>] GeometryCollectionStatic =
                [<Emit "new $0($1...)">] abstract Create: elements: ResizeArray<U3<ResizeArray<Data.Geometry>, ResizeArray<LatLng>, LatLngLiteral>> -> GeometryCollection

            type [<AllowNullLiteral>] MouseEvent =
                inherit Google.Maps.MouseEvent
                abstract feature: Data.Feature with get, set

            type [<AllowNullLiteral>] AddFeatureEvent =
                abstract feature: Data.Feature with get, set

            type [<AllowNullLiteral>] RemoveFeatureEvent =
                abstract feature: Data.Feature with get, set

            type [<AllowNullLiteral>] SetGeometryEvent =
                abstract feature: Data.Feature with get, set
                abstract newGeometry: Data.Geometry with get, set
                abstract oldGeometry: Data.Geometry with get, set

            type [<AllowNullLiteral>] SetPropertyEvent =
                abstract feature: Data.Feature with get, set
                abstract name: string with get, set
                abstract newValue: obj option with get, set
                abstract oldValue: obj option with get, set

            type [<AllowNullLiteral>] RemovePropertyEvent =
                abstract feature: Data.Feature with get, set
                abstract name: string with get, set
                abstract oldValue: obj option with get, set

        type [<AllowNullLiteral>] Marker =
            inherit MVCObject
            abstract MAX_ZINDEX: float with get, set
            abstract getAnimation: unit -> Animation
            abstract getAttribution: unit -> Attribution
            abstract getClickable: unit -> bool
            abstract getCursor: unit -> string
            abstract getDraggable: unit -> bool
            abstract getIcon: unit -> U3<string, Icon, Symbol>
            abstract getLabel: unit -> MarkerLabel
            abstract getMap: unit -> U2<Map, StreetViewPanorama>
            abstract getOpacity: unit -> float
            abstract getPlace: unit -> Place
            abstract getPosition: unit -> LatLng
            abstract getShape: unit -> MarkerShape
            abstract getTitle: unit -> string
            abstract getVisible: unit -> bool
            abstract getZIndex: unit -> float
            abstract setAnimation: animation: Animation option -> unit
            abstract setAttribution: attribution: Attribution -> unit
            abstract setClickable: flag: bool -> unit
            abstract setCursor: cursor: string -> unit
            abstract setDraggable: flag: bool -> unit
            abstract setIcon: icon: U3<string, Icon, Symbol> -> unit
            abstract setLabel: label: U2<string, MarkerLabel> -> unit
            abstract setMap: map: U2<Map, StreetViewPanorama> option -> unit
            abstract setOpacity: opacity: float -> unit
            abstract setOptions: options: MarkerOptions -> unit
            abstract setPlace: place: Place -> unit
            abstract setPosition: latlng: U2<LatLng, LatLngLiteral> -> unit
            abstract setShape: shape: MarkerShape -> unit
            abstract setTitle: title: string -> unit
            abstract setVisible: visible: bool -> unit
            abstract setZIndex: zIndex: float -> unit

        type [<AllowNullLiteral>] MarkerStatic =
            [<Emit "new $0($1...)">] abstract Create: ?opts: MarkerOptions -> Marker

        type [<AllowNullLiteral>] MarkerOptions =
            /// The offset from the marker's position to the tip of an InfoWindow
            /// that has been opened with the marker as anchor.
            abstract anchorPoint: Point option with get, set
            /// Which animation to play when marker is added to a map. 
            abstract animation: Animation option with get, set
            /// If true, the marker receives mouse and touch events.
            abstract clickable: bool option with get, set
            /// Mouse cursor to show on hover. 
            abstract cursor: string option with get, set
            /// If true, the marker can be dragged.
            abstract draggable: bool option with get, set
            /// Icon for the foreground.
            /// If a string is provided, it is treated as though it were an Icon with the
            /// string as url.
            abstract icon: U3<string, Icon, Symbol> option with get, set
            /// Adds a label to the marker. The label can either be a string, or a
            /// MarkerLabel object. Only the first character of the string will be
            /// displayed.
            abstract label: U2<string, MarkerLabel> option with get, set
            /// Map on which to display Marker.
            abstract map: U2<Map, StreetViewPanorama> option with get, set
            /// The marker's opacity between 0.0 and 1.0. 
            abstract opacity: float option with get, set
            /// Optimization renders many markers as a single static element.
            /// Optimized rendering is enabled by default.
            /// Disable optimized rendering for animated GIFs or PNGs, or when each
            /// marker must be rendered as a separate DOM element (advanced usage
            /// only).
            abstract optimized: bool option with get, set
            /// Place information, used to identify and describe the place
            /// associated with this Marker. In this context, 'place' means a
            /// business, point of interest or geographic location. To allow a user
            /// to save this place, open an info window anchored on this marker.
            /// The info window will contain information about the place and an
            /// option for the user to save it. Only one of position or place can
            /// be specified.
            abstract place: Place option with get, set
            /// Marker position. Required.
            abstract position: U2<LatLng, LatLngLiteral> with get, set
            /// Image map region definition used for drag/click. 
            abstract shape: MarkerShape option with get, set
            /// Rollover text. 
            abstract title: string option with get, set
            /// If true, the marker is visible. 
            abstract visible: bool option with get, set
            /// All markers are displayed on the map in order of their zIndex,
            /// with higher values displaying in front of markers with lower values.
            /// By default, markers are displayed according to their vertical position on
            /// screen, with lower markers appearing in front of markers further up the
            /// screen.
            abstract zIndex: float option with get, set

        type [<AllowNullLiteral>] Icon =
            /// The position at which to anchor an image in correspondence to the
            /// location of the marker on the map. By default, the anchor is
            /// located along the center point of the bottom of the image.
            abstract anchor: Point option with get, set
            /// The origin of the label relative to the top-left corner of the icon
            /// image, if a label is supplied by the marker. By default, the origin
            /// is located in the center point of the image.
            abstract labelOrigin: Point option with get, set
            /// The position of the image within a sprite, if any. By default, the
            /// origin is located at the top left corner of the image (0, 0).
            abstract origin: Point option with get, set
            /// The size of the entire image after scaling, if any. Use this
            /// property to stretch/ shrink an image or a sprite.
            abstract scaledSize: Size option with get, set
            /// The display size of the sprite or image. When using sprites, you
            /// must specify the sprite size. If the size is not provided, it will
            /// be set when the image loads.
            abstract size: Size option with get, set
            /// The URL of the image or sprite sheet. 
            abstract url: string option with get, set

        type [<AllowNullLiteral>] MarkerLabel =
            /// The color of the label text. Default color is black. 
            abstract color: string option with get, set
            /// The font family of the label text (equivalent to the CSS font-family
            /// property).
            abstract fontFamily: string option with get, set
            /// The font size of the label text (equivalent to the CSS font-size
            /// property). Default size is 14px.
            abstract fontSize: string option with get, set
            /// The font weight of the label text (equivalent to the CSS font-weight
            /// property).
            abstract fontWeight: string option with get, set
            /// The text to be displayed in the label. Only the first character of this
            /// string will be shown.
            abstract text: string option with get, set

        type [<AllowNullLiteral>] MarkerShape =
            abstract coords: ResizeArray<float> option with get, set
            abstract ``type``: string option with get, set

        type [<AllowNullLiteral>] Symbol =
            /// The position of the symbol relative to the marker or polyline.
            /// The coordinates of the symbol's path are translated left and up by the
            /// anchor's x and y coordinates respectively. By default, a symbol is
            /// anchored at (0, 0). The position is expressed in the same coordinate
            /// system as the symbol's path.
            abstract anchor: Point option with get, set
            /// The symbol's fill color.
            /// All CSS3 colors are supported except for extended named colors. For
            /// symbol markers, this defaults to 'black'. For symbols on polylines, this
            /// defaults to the stroke color of the corresponding polyline.
            abstract fillColor: string option with get, set
            /// The symbol's fill opacity.
            abstract fillOpacity: float option with get, set
            /// The symbol's path, which is a built-in symbol path, or a custom path
            /// expressed using SVG path notation. Required.
            abstract path: U2<SymbolPath, string> option with get, set
            /// The angle by which to rotate the symbol, expressed clockwise in degrees.
            /// Defaults to 0.
            /// A symbol in an IconSequence where fixedRotation is false is rotated
            /// relative to the angle of the edge on which it lies.
            abstract rotation: float option with get, set
            /// The amount by which the symbol is scaled in size.
            /// For symbol markers, this defaults to 1; after scaling, the symbol may be
            /// of any size. For symbols on a polyline, this defaults to the stroke
            /// weight of the polyline; after scaling, the symbol must lie inside a
            /// square 22 pixels in size centered at the symbol's anchor.
            abstract scale: float option with get, set
            /// The symbol's stroke color. All CSS3 colors are supported except for
            /// extended named colors. For symbol markers, this defaults to 'black'. For
            /// symbols on a polyline, this defaults to the stroke color of the polyline.
            abstract strokeColor: string option with get, set
            /// The symbol's stroke opacity. For symbol markers, this defaults to 1.
            /// For symbols on a polyline, this defaults to the stroke opacity of the
            /// polyline.
            abstract strokeOpacity: float option with get, set
            /// The symbol's stroke weight. Defaults to the scale of the symbol.v
            abstract strokeWeight: float option with get, set

        type SymbolPath =
            obj

        type Animation =
            obj

        /// An overlay that looks like a bubble and is often connected to a marker.
        /// This class extends MVCObject.
        type [<AllowNullLiteral>] InfoWindow =
            inherit MVCObject
            /// Closes this InfoWindow by removing it from the DOM structure. 
            abstract close: unit -> unit
            abstract getContent: unit -> U2<string, Element>
            abstract getPosition: unit -> LatLng
            abstract getZIndex: unit -> float
            /// Opens this InfoWindow on the given map. Optionally, an InfoWindow can be
            /// associated with an anchor. In the core API, the only anchor is the Marker
            /// class. However, an anchor can be any MVCObject that exposes a LatLng
            /// position property and optionally a Point anchorPoint property for
            /// calculating the pixelOffset (see InfoWindowOptions). The anchorPoint is
            /// the offset from the anchor's position to the tip of the InfoWindow.
            abstract ``open``: ?map: U2<Map, StreetViewPanorama> * ?anchor: MVCObject -> unit
            abstract setContent: content: U2<string, Node> -> unit
            abstract setOptions: options: InfoWindowOptions -> unit
            abstract setPosition: position: U2<LatLng, LatLngLiteral> -> unit
            abstract setZIndex: zIndex: float -> unit

        /// An overlay that looks like a bubble and is often connected to a marker.
        /// This class extends MVCObject.
        type [<AllowNullLiteral>] InfoWindowStatic =
            /// Creates an info window with the given options. An InfoWindow can be
            /// placed on a map at a particular position or above a marker,
            /// depending on what is specified in the options. Unless auto-pan is
            /// disabled, an InfoWindow will pan the map to make itself visible
            /// when it is opened. After constructing an InfoWindow, you must call
            /// open to display it on the map. The user can click the close button
            /// on the InfoWindow to remove it from the map, or the developer can
            /// call close() for the same effect.
            [<Emit "new $0($1...)">] abstract Create: ?opts: InfoWindowOptions -> InfoWindow

        type [<AllowNullLiteral>] InfoWindowOptions =
            /// Content to display in the InfoWindow. This can be an HTML element, a
            /// plain-text string, or a string containing HTML. The InfoWindow will be
            /// sized according to the content. To set an explicit size for the content,
            /// set content to be a HTML element with that size.
            abstract content: U2<string, Node> option with get, set
            /// Disable auto-pan on open. By default, the info window will pan the map so
            /// that it is fully visible when it opens.
            abstract disableAutoPan: bool option with get, set
            /// Maximum width of the infowindow, regardless of content's width.
            /// This value is only considered if it is set before a call to open.
            /// To change the maximum width when changing content, call close,
            /// setOptions, and then open.
            abstract maxWidth: float option with get, set
            /// The offset, in pixels, of the tip of the info window from the point on
            /// the map at whose geographical coordinates the info window is anchored. If
            /// an InfoWindow is opened with an anchor, the pixelOffset will be
            /// calculated from the anchor's anchorPoint property.
            abstract pixelOffset: Size option with get, set
            /// The LatLng at which to display this InfoWindow. If the InfoWindow is
            /// opened with an anchor, the anchor's position will be used instead.
            abstract position: U2<LatLng, LatLngLiteral> option with get, set
            /// All InfoWindows are displayed on the map in order of their zIndex,
            /// with higher values displaying in front of InfoWindows with lower values.
            /// By default, InfoWindows are displayed according to their latitude,
            /// with InfoWindows of lower latitudes appearing in front of InfoWindows at
            /// higher latitudes. InfoWindows are always displayed in front of markers.
            abstract zIndex: float option with get, set

        type [<AllowNullLiteral>] Polyline =
            inherit MVCObject
            abstract getDraggable: unit -> bool
            abstract getEditable: unit -> bool
            abstract getMap: unit -> Map
            abstract getPath: unit -> MVCArray<LatLng>
            abstract getVisible: unit -> bool
            abstract setDraggable: draggable: bool -> unit
            abstract setEditable: editable: bool -> unit
            abstract setMap: map: Map option -> unit
            abstract setOptions: options: PolylineOptions -> unit
            abstract setPath: path: U3<MVCArray<LatLng>, ResizeArray<LatLng>, ResizeArray<LatLngLiteral>> -> unit
            abstract setVisible: visible: bool -> unit

        type [<AllowNullLiteral>] PolylineStatic =
            [<Emit "new $0($1...)">] abstract Create: ?opts: PolylineOptions -> Polyline

        type [<AllowNullLiteral>] PolylineOptions =
            /// Indicates whether this Polyline handles mouse events. Defaults to true.
            abstract clickable: bool option with get, set
            /// If set to true, the user can drag this shape over the map.
            /// The geodesic property defines the mode of dragging. Defaults to false.
            abstract draggable: bool option with get, set
            /// If set to true, the user can edit this shape by dragging the control
            /// points shown at the vertices and on each segment. Defaults to false.
            abstract editable: bool option with get, set
            /// When true, edges of the polygon are interpreted as geodesic and will
            /// follow the curvature of the Earth. When false, edges of the polygon are
            /// rendered as straight lines in screen space. Note that the shape of a
            /// geodesic polygon may appear to change when dragged, as the dimensions are
            /// maintained relative to the surface of the earth. Defaults to false.
            abstract geodesic: bool option with get, set
            /// The icons to be rendered along the polyline. 
            abstract icons: ResizeArray<IconSequence> option with get, set
            /// Map on which to display Polyline. 
            abstract map: Map option with get, set
            /// The ordered sequence of coordinates of the Polyline.
            /// This path may be specified using either a simple array of LatLngs, or an
            /// MVCArray of LatLngs. Note that if you pass a simple array, it will be
            /// converted to an MVCArray Inserting or removing LatLngs in the MVCArray
            /// will automatically update the polyline on the map.
            abstract path: U3<MVCArray<LatLng>, ResizeArray<LatLng>, ResizeArray<LatLngLiteral>> option with get, set
            /// The stroke color. All CSS3 colors are supported except for extended
            /// named colors.
            abstract strokeColor: string option with get, set
            /// The stroke opacity between 0.0 and 1.0. 
            abstract strokeOpacity: float option with get, set
            /// The stroke width in pixels. 
            abstract strokeWeight: float option with get, set
            /// Whether this polyline is visible on the map. Defaults to true. 
            abstract visible: bool option with get, set
            /// The zIndex compared to other polys. 
            abstract zIndex: float option with get, set

        type [<AllowNullLiteral>] IconSequence =
            abstract fixedRotation: bool option with get, set
            abstract icon: Symbol option with get, set
            abstract offset: string option with get, set
            abstract repeat: string option with get, set

        type [<AllowNullLiteral>] Polygon =
            inherit MVCObject
            abstract getDraggable: unit -> bool
            abstract getEditable: unit -> bool
            abstract getMap: unit -> Map
            /// Retrieves the first path. 
            abstract getPath: unit -> MVCArray<LatLng>
            /// Retrieves the paths for this polygon. 
            abstract getPaths: unit -> MVCArray<MVCArray<LatLng>>
            abstract getVisible: unit -> bool
            abstract setDraggable: draggable: bool -> unit
            abstract setEditable: editable: bool -> unit
            abstract setMap: map: Map option -> unit
            abstract setOptions: options: PolygonOptions -> unit
            abstract setPath: path: U3<MVCArray<LatLng>, ResizeArray<LatLng>, ResizeArray<LatLngLiteral>> -> unit
            abstract setPaths: paths: U6<MVCArray<MVCArray<LatLng>>, MVCArray<LatLng>, ResizeArray<ResizeArray<LatLng>>, ResizeArray<ResizeArray<LatLngLiteral>>, ResizeArray<LatLng>, ResizeArray<LatLngLiteral>> -> unit
            abstract setVisible: visible: bool -> unit

        type [<AllowNullLiteral>] PolygonStatic =
            [<Emit "new $0($1...)">] abstract Create: ?opts: PolygonOptions -> Polygon

        type [<AllowNullLiteral>] PolygonOptions =
            /// Indicates whether this Polygon handles mouse events. Defaults to true.
            abstract clickable: bool option with get, set
            /// If set to true, the user can drag this shape over the map.
            /// The geodesic property defines the mode of dragging. Defaults to false.
            abstract draggable: bool option with get, set
            /// If set to true, the user can edit this shape by dragging the control
            /// points shown at the vertices and on each segment. Defaults to false.
            abstract editable: bool option with get, set
            /// The fill color. All CSS3 colors are supported except for extended named
            /// colors.
            abstract fillColor: string option with get, set
            /// The fill opacity between 0.0 and 1.0 
            abstract fillOpacity: float option with get, set
            /// When true, edges of the polygon are interpreted as geodesic and will
            /// follow the curvature of the Earth. When false, edges of the polygon are
            /// rendered as straight lines in screen space. Note that the shape of a
            /// geodesic polygon may appear to change when dragged, as the dimensions are
            /// maintained relative to the surface of the earth. Defaults to false.
            abstract geodesic: bool option with get, set
            /// Map on which to display Polygon. 
            abstract map: Map option with get, set
            /// The ordered sequence of coordinates that designates a closed loop. Unlike
            /// polylines, a polygon may consist of one or more paths. As a result, the
            /// paths property may specify one or more arrays of LatLng coordinates.
            /// Paths are closed automatically; do not repeat the first vertex of the
            /// path as the last vertex. Simple polygons may be defined using a single
            /// array of LatLngs. More complex polygons may specify an array of arrays.
            /// Any simple arrays are converted into MVCArrays. Inserting or removing
            /// LatLngs from the MVCArray will automatically update the polygon on the
            /// map.
            abstract paths: U6<MVCArray<MVCArray<LatLng>>, MVCArray<LatLng>, ResizeArray<ResizeArray<LatLng>>, ResizeArray<ResizeArray<LatLngLiteral>>, ResizeArray<LatLng>, ResizeArray<LatLngLiteral>> option with get, set
            /// The stroke color.
            /// All CSS3 colors are supported except for extended named colors.
            abstract strokeColor: string option with get, set
            /// The stroke opacity between 0.0 and 1.0 
            abstract strokeOpacity: float option with get, set
            /// The stroke position. Defaults to CENTER.
            /// This property is not supported on Internet Explorer 8 and earlier.
            abstract strokePosition: StrokePosition option with get, set
            /// The stroke width in pixels. 
            abstract strokeWeight: float option with get, set
            /// Whether this polygon is visible on the map. Defaults to true. 
            abstract visible: bool option with get, set
            /// The zIndex compared to other polys. 
            abstract zIndex: float option with get, set

        type [<AllowNullLiteral>] PolyMouseEvent =
            inherit MouseEvent
            abstract edge: float option with get, set
            abstract path: float option with get, set
            abstract vertex: float option with get, set

        type [<AllowNullLiteral>] Rectangle =
            inherit MVCObject
            abstract getBounds: unit -> LatLngBounds
            abstract getDraggable: unit -> bool
            abstract getEditable: unit -> bool
            abstract getMap: unit -> Map
            abstract getVisible: unit -> bool
            abstract setBounds: bounds: U2<LatLngBounds, LatLngBoundsLiteral> -> unit
            abstract setDraggable: draggable: bool -> unit
            abstract setEditable: editable: bool -> unit
            abstract setMap: map: Map option -> unit
            abstract setOptions: options: RectangleOptions -> unit
            abstract setVisible: visible: bool -> unit

        type [<AllowNullLiteral>] RectangleStatic =
            [<Emit "new $0($1...)">] abstract Create: ?opts: RectangleOptions -> Rectangle

        type [<AllowNullLiteral>] RectangleOptions =
            abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> option with get, set
            abstract clickable: bool option with get, set
            abstract draggable: bool option with get, set
            abstract editable: bool option with get, set
            abstract fillColor: string option with get, set
            abstract fillOpacity: float option with get, set
            abstract map: Map option with get, set
            abstract strokeColor: string option with get, set
            abstract strokeOpacity: float option with get, set
            abstract strokePosition: StrokePosition option with get, set
            abstract strokeWeight: float option with get, set
            abstract visible: bool option with get, set
            abstract zIndex: float option with get, set

        /// A circle on the Earth's surface; also known as a "spherical cap". 
        type [<AllowNullLiteral>] Circle =
            inherit MVCObject
            /// Gets the LatLngBounds of this Circle. 
            abstract getBounds: unit -> LatLngBounds
            /// Returns the center of this circle. 
            abstract getCenter: unit -> LatLng
            /// Returns whether this circle can be dragged by the user. 
            abstract getDraggable: unit -> bool
            /// Returns whether this circle can be edited by the user. 
            abstract getEditable: unit -> bool
            /// Returns the map on which this circle is displayed. 
            abstract getMap: unit -> Map
            /// Returns the radius of this circle (in meters). 
            abstract getRadius: unit -> float
            /// Returns whether this circle is visible on the map. 
            abstract getVisible: unit -> bool
            /// Sets the center of this circle. 
            abstract setCenter: center: U2<LatLng, LatLngLiteral> -> unit
            /// If set to true, the user can drag this circle over the map. 
            abstract setDraggable: draggable: bool -> unit
            /// If set to true, the user can edit this circle by dragging the control
            /// points shown at the center and around the circumference of the circle.
            abstract setEditable: editable: bool -> unit
            /// Renders the circle on the specified map. If map is set to null, the
            /// circle will be removed.
            abstract setMap: map: Map option -> unit
            abstract setOptions: options: CircleOptions -> unit
            /// Sets the radius of this circle (in meters). 
            abstract setRadius: radius: float -> unit
            /// Hides this circle if set to false. 
            abstract setVisible: visible: bool -> unit

        /// A circle on the Earth's surface; also known as a "spherical cap". 
        type [<AllowNullLiteral>] CircleStatic =
            /// Create a circle using the passed CircleOptions, which specify the
            /// center, radius, and style.
            [<Emit "new $0($1...)">] abstract Create: ?opts: CircleOptions -> Circle

        type [<AllowNullLiteral>] CircleOptions =
            /// The center 
            abstract center: U2<LatLng, LatLngLiteral> option with get, set
            /// Indicates whether this Circle handles mouse events. Defaults to true. 
            abstract clickable: bool option with get, set
            /// If set to true, the user can drag this circle over the map. Defaults to
            /// false.
            abstract draggable: bool option with get, set
            /// If set to true, the user can edit this circle by dragging the control
            /// points shown at the center and around the circumference of the circle.
            /// Defaults to false.
            abstract editable: bool option with get, set
            /// The fill color. All CSS3 colors are supported except for extended named
            /// colors.
            abstract fillColor: string option with get, set
            /// The fill opacity between 0.0 and 1.0 
            abstract fillOpacity: float option with get, set
            /// Map on which to display Circle. 
            abstract map: Map option with get, set
            /// The radius in meters on the Earth's surface 
            abstract radius: float option with get, set
            /// The stroke color. All CSS3 colors are supported except for extended
            /// named colors.
            abstract strokeColor: string option with get, set
            /// The stroke opacity between 0.0 and 1.0 
            abstract strokeOpacity: float option with get, set
            /// The stroke position. Defaults to CENTER. This property is not supported
            /// on Internet Explorer 8 and earlier.
            abstract strokePosition: StrokePosition option with get, set
            /// The stroke width in pixels. 
            abstract strokeWeight: float option with get, set
            /// Whether this circle is visible on the map. Defaults to true. 
            abstract visible: bool option with get, set
            /// The zIndex compared to other polys. 
            abstract zIndex: float option with get, set

        type [<AllowNullLiteral>] CircleLiteral =
            inherit CircleOptions
            /// The center of the Circle. 
            abstract center: U2<LatLng, LatLngLiteral> option with get, set
            /// The radius in meters on the Earth's surface. 
            abstract radius: float option with get, set

        type StrokePosition =
            obj

        type [<AllowNullLiteral>] GroundOverlay =
            inherit MVCObject
            abstract getBounds: unit -> LatLngBounds
            abstract getMap: unit -> Map
            abstract getOpacity: unit -> float
            abstract getUrl: unit -> string
            abstract setMap: map: Map option -> unit
            abstract setOpacity: opacity: float -> unit

        type [<AllowNullLiteral>] GroundOverlayStatic =
            [<Emit "new $0($1...)">] abstract Create: url: string * bounds: U2<LatLngBounds, LatLngBoundsLiteral> * ?opts: GroundOverlayOptions -> GroundOverlay

        type [<AllowNullLiteral>] GroundOverlayOptions =
            abstract clickable: bool option with get, set
            abstract map: Map option with get, set
            abstract opacity: float option with get, set

        type [<AllowNullLiteral>] OverlayView =
            inherit MVCObject
            abstract draw: unit -> unit
            abstract getMap: unit -> U2<Map, StreetViewPanorama>
            abstract getPanes: unit -> MapPanes
            abstract getProjection: unit -> MapCanvasProjection
            abstract onAdd: unit -> unit
            abstract onRemove: unit -> unit
            abstract setMap: map: U2<Map, StreetViewPanorama> option -> unit

        type [<AllowNullLiteral>] OverlayViewStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> OverlayView

        type [<AllowNullLiteral>] MapPanes =
            abstract floatPane: Element with get, set
            abstract floatShadow: Element with get, set
            abstract mapPane: Element with get, set
            abstract markerLayer: Element with get, set
            abstract overlayImage: Element with get, set
            abstract overlayLayer: Element with get, set
            abstract overlayMouseTarget: Element with get, set
            abstract overlayShadow: Element with get, set

        type [<AllowNullLiteral>] MapCanvasProjection =
            inherit MVCObject
            abstract fromContainerPixelToLatLng: pixel: Point * ?nowrap: bool -> LatLng
            abstract fromDivPixelToLatLng: pixel: Point * ?nowrap: bool -> LatLng
            abstract fromLatLngToContainerPixel: latLng: LatLng -> Point
            abstract fromLatLngToDivPixel: latLng: LatLng -> Point
            abstract getWorldWidth: unit -> float

        type [<AllowNullLiteral>] MapCanvasProjectionStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> MapCanvasProjection

        type [<AllowNullLiteral>] Geocoder =
            abstract geocode: request: GeocoderRequest * callback: (ResizeArray<GeocoderResult> -> GeocoderStatus -> unit) -> unit

        type [<AllowNullLiteral>] GeocoderStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Geocoder

        type [<AllowNullLiteral>] GeocoderRequest =
            abstract address: string option with get, set
            abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> option with get, set
            abstract componentRestrictions: GeocoderComponentRestrictions option with get, set
            abstract location: U2<LatLng, LatLngLiteral> option with get, set
            abstract placeId: string option with get, set
            abstract region: string option with get, set

        type [<AllowNullLiteral>] GeocoderComponentRestrictions =
            abstract administrativeArea: string option with get, set
            abstract country: U2<string, ResizeArray<string>> option with get, set
            abstract locality: string option with get, set
            abstract postalCode: string option with get, set
            abstract route: string option with get, set

        type GeocoderStatus =
            obj

        type [<AllowNullLiteral>] GeocoderResult =
            abstract address_components: ResizeArray<GeocoderAddressComponent> with get, set
            abstract formatted_address: string with get, set
            abstract geometry: GeocoderGeometry with get, set
            abstract partial_match: bool with get, set
            abstract place_id: string with get, set
            abstract postcode_localities: ResizeArray<string> with get, set
            abstract types: ResizeArray<string> with get, set

        type [<AllowNullLiteral>] GeocoderAddressComponent =
            abstract long_name: string with get, set
            abstract short_name: string with get, set
            abstract types: ResizeArray<string> with get, set

        type [<AllowNullLiteral>] GeocoderGeometry =
            abstract bounds: LatLngBounds with get, set
            abstract location: LatLng with get, set
            abstract location_type: GeocoderLocationType with get, set
            abstract viewport: LatLngBounds with get, set

        type GeocoderLocationType =
            obj

        type [<AllowNullLiteral>] DirectionsRenderer =
            inherit MVCObject
            abstract getDirections: unit -> DirectionsResult
            abstract getMap: unit -> Map
            abstract getPanel: unit -> Element
            abstract getRouteIndex: unit -> float
            abstract setDirections: directions: DirectionsResult -> unit
            abstract setMap: map: Map option -> unit
            abstract setOptions: options: DirectionsRendererOptions -> unit
            abstract setPanel: panel: Element -> unit
            abstract setRouteIndex: routeIndex: float -> unit

        type [<AllowNullLiteral>] DirectionsRendererStatic =
            [<Emit "new $0($1...)">] abstract Create: ?opts: DirectionsRendererOptions -> DirectionsRenderer

        type [<AllowNullLiteral>] DirectionsRendererOptions =
            abstract directions: DirectionsResult option with get, set
            abstract draggable: bool option with get, set
            abstract hideRouteList: bool option with get, set
            abstract infoWindow: InfoWindow option with get, set
            abstract map: Map option with get, set
            abstract markerOptions: MarkerOptions option with get, set
            abstract panel: Element option with get, set
            abstract polylineOptions: PolylineOptions option with get, set
            abstract preserveViewport: bool option with get, set
            abstract routeIndex: float option with get, set
            abstract suppressBicyclingLayer: bool option with get, set
            abstract suppressInfoWindows: bool option with get, set
            abstract suppressMarkers: bool option with get, set
            abstract suppressPolylines: bool option with get, set

        type [<AllowNullLiteral>] DirectionsService =
            abstract route: request: DirectionsRequest * callback: (DirectionsResult -> DirectionsStatus -> unit) -> unit

        type [<AllowNullLiteral>] DirectionsServiceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> DirectionsService

        /// A directions query to be sent to the DirectionsService. 
        type [<AllowNullLiteral>] DirectionsRequest =
            /// If true, instructs the Directions service to avoid ferries where
            /// possible. Optional.
            abstract avoidFerries: bool option with get, set
            /// If true, instructs the Directions service to avoid highways where
            /// possible. Optional.
            abstract avoidHighways: bool option with get, set
            /// If true, instructs the Directions service to avoid toll roads where
            /// possible. Optional.
            abstract avoidTolls: bool option with get, set
            /// Location of destination. This can be specified as either a string to be
            /// geocoded, or a LatLng, or a Place. Required.
            abstract destination: U4<string, LatLng, LatLngLiteral, Place> option with get, set
            /// Deprecated. Use drivingOptions field instead 
            abstract durationInTraffic: bool option with get, set
            /// Settings that apply only to requests where travelMode is DRIVING. This
            /// object will have no effect for other travel modes.
            abstract drivingOptions: DrivingOptions option with get, set
            /// If set to true, the DirectionService will attempt to re-order the
            /// supplied intermediate waypoints to minimize overall cost of the route. If
            /// waypoints are optimized, inspect DirectionsRoute.waypoint_order in the
            /// response to determine the new ordering.
            abstract optimizeWaypoints: bool option with get, set
            /// Location of origin. This can be specified as either a string to be
            /// geocoded, or a LatLng, or a Place. Required.
            abstract origin: U4<string, LatLng, LatLngLiteral, Place> option with get, set
            /// Whether or not route alternatives should be provided. Optional. 
            abstract provideRouteAlternatives: bool option with get, set
            /// Region code used as a bias for geocoding requests. Optional. 
            abstract region: string option with get, set
            /// Settings that apply only to requests where travelMode is TRANSIT. This
            /// object will have no effect for other travel modes.
            abstract transitOptions: TransitOptions option with get, set
            /// Type of routing requested. Required. 
            abstract travelMode: TravelMode option with get, set
            /// Preferred unit system to use when displaying distance. Defaults to the
            /// unit system used in the country of origin.
            abstract unitSystem: UnitSystem option with get, set
            /// Array of intermediate waypoints. Directions will be calculated from the
            /// origin to the destination by way of each waypoint in this array. The
            /// maximum allowed waypoints is 8, plus the origin, and destination. Premium
            /// Plan customers are allowed 23 waypoints, plus the origin, and
            /// destination. Waypoints are not supported for transit directions.
            /// Optional.
            abstract waypoints: ResizeArray<DirectionsWaypoint> option with get, set

        type TravelMode =
            obj

        type UnitSystem =
            obj

        type [<AllowNullLiteral>] TransitOptions =
            abstract arrivalTime: DateTime option with get, set
            abstract departureTime: DateTime option with get, set
            abstract modes: ResizeArray<TransitMode> option with get, set
            abstract routingPreference: TransitRoutePreference option with get, set

        type TransitMode =
            obj

        type TransitRoutePreference =
            obj

        type [<AllowNullLiteral>] TransitFare =
            interface end

        type [<AllowNullLiteral>] DrivingOptions =
            abstract departureTime: DateTime with get, set
            abstract trafficModel: TrafficModel option with get, set

        type TrafficModel =
            obj

        /// A DirectionsWaypoint represents a location between origin and destination
        /// through which the trip should be routed.
        type [<AllowNullLiteral>] DirectionsWaypoint =
            /// Waypoint location. Can be an address string, a LatLng, or a Place.
            /// Optional.
            abstract location: U3<LatLng, LatLngLiteral, string> with get, set
            /// If true, indicates that this waypoint is a stop between the origin and
            /// destination. This has the effect of splitting the route into two legs. If
            /// false, indicates that the route should be biased to go through this
            /// waypoint, but not split into two legs. This is useful if you want to
            /// create a route in response to the user dragging waypoints on a map. This
            /// value is true by default. Optional.
            abstract stopover: bool with get, set

        type DirectionsStatus =
            obj

        type [<AllowNullLiteral>] DirectionsResult =
            abstract geocoded_waypoints: ResizeArray<DirectionsGeocodedWaypoint> with get, set
            abstract routes: ResizeArray<DirectionsRoute> with get, set

        /// A single geocoded waypoint.
        type [<AllowNullLiteral>] DirectionsGeocodedWaypoint =
            abstract partial_match: bool with get, set
            abstract place_id: string with get, set
            abstract types: ResizeArray<string> with get, set

        /// A single route containing a set of legs in a DirectionsResult.
        /// Note that though this object is "JSON-like," it is not strictly JSON,
        /// as it directly and indirectly includes LatLng objects.
        type [<AllowNullLiteral>] DirectionsRoute =
            /// The bounds for this route. 
            abstract bounds: LatLngBounds with get, set
            /// Copyrights text to be displayed for this route. 
            abstract copyrights: string with get, set
            /// The total fare for the whole transit trip. Only applicable to transit
            /// requests.
            abstract fare: TransitFare with get, set
            /// An array of DirectionsLegs, each of which contains information about the
            /// steps of which it is composed. There will be one leg for each stopover
            /// waypoint or destination specified. So a route with no stopover waypoints
            /// will contain one DirectionsLeg and a route with one stopover waypoint
            /// will contain two.
            abstract legs: ResizeArray<DirectionsLeg> with get, set
            /// An array of LatLngs representing the entire course of this route. The
            /// path is simplified in order to make it suitable in contexts where a small
            /// number of vertices is required (such as Static Maps API URLs).
            abstract overview_path: ResizeArray<LatLng> with get, set
            /// An encoded polyline representation of the route in overview_path.
            /// This polyline is an approximate (smoothed) path of the resulting
            /// directions.
            abstract overview_polyline: string with get, set
            /// Warnings to be displayed when showing these directions. 
            abstract warnings: ResizeArray<string> with get, set
            /// If optimizeWaypoints was set to true, this field will contain the
            /// re-ordered permutation of the input waypoints. For example, if the input
            /// was: Origin: Los Angeles Waypoints: Dallas, Bangor, Phoenix Destination:
            /// New York and the optimized output was ordered as follows: Origin: Los
            /// Angeles Waypoints: Phoenix, Dallas, Bangor Destination: New York then
            /// this field will be an Array containing the values [2, 0, 1]. Note that
            /// the numbering of waypoints is zero-based. If any of the input waypoints
            /// has stopover set to false, this field will be empty, since route
            /// optimization is not available for such queries.
            abstract waypoint_order: ResizeArray<float> with get, set

        type [<AllowNullLiteral>] DirectionsLeg =
            abstract arrival_time: Time with get, set
            abstract departure_time: Time with get, set
            abstract distance: Distance with get, set
            abstract duration: Duration with get, set
            abstract duration_in_traffic: Duration with get, set
            abstract end_address: string with get, set
            abstract end_location: LatLng with get, set
            abstract start_address: string with get, set
            abstract start_location: LatLng with get, set
            abstract steps: ResizeArray<DirectionsStep> with get, set
            abstract via_waypoints: ResizeArray<LatLng> with get, set

        type [<AllowNullLiteral>] DirectionsStep =
            abstract distance: Distance with get, set
            abstract duration: Duration with get, set
            abstract end_location: LatLng with get, set
            abstract instructions: string with get, set
            abstract path: ResizeArray<LatLng> with get, set
            abstract start_location: LatLng with get, set
            abstract steps: DirectionsStep with get, set
            abstract transit: TransitDetails with get, set
            abstract travel_mode: TravelMode with get, set

        type [<AllowNullLiteral>] Distance =
            abstract text: string with get, set
            abstract value: float with get, set

        type [<AllowNullLiteral>] Duration =
            abstract text: string with get, set
            abstract value: float with get, set

        type [<AllowNullLiteral>] Time =
            abstract text: string with get, set
            abstract time_zone: string with get, set
            abstract value: DateTime with get, set

        type [<AllowNullLiteral>] TransitDetails =
            abstract arrival_stop: TransitStop with get, set
            abstract arrival_time: Time with get, set
            abstract departure_stop: TransitStop with get, set
            abstract departure_time: Time with get, set
            abstract headsign: string with get, set
            abstract headway: float with get, set
            abstract line: TransitLine with get, set
            abstract num_stops: float with get, set

        type [<AllowNullLiteral>] TransitStop =
            abstract location: LatLng with get, set
            abstract name: string with get, set

        type [<AllowNullLiteral>] TransitLine =
            abstract agencies: ResizeArray<TransitAgency> with get, set
            abstract color: string with get, set
            abstract icon: string with get, set
            abstract name: string with get, set
            abstract short_name: string with get, set
            abstract text_color: string with get, set
            abstract url: string with get, set
            abstract vehicle: TransitVehicle with get, set

        type [<AllowNullLiteral>] TransitAgency =
            abstract name: string with get, set
            abstract phone: string with get, set
            abstract url: string with get, set

        type [<AllowNullLiteral>] TransitVehicle =
            abstract icon: string with get, set
            abstract local_icon: string with get, set
            abstract name: string with get, set
            abstract ``type``: VehicleType with get, set

        type VehicleType =
            obj

        type [<AllowNullLiteral>] ElevationService =
            abstract getElevationAlongPath: request: PathElevationRequest * callback: (ResizeArray<ElevationResult> -> ElevationStatus -> unit) -> unit
            abstract getElevationForLocations: request: LocationElevationRequest * callback: (ResizeArray<ElevationResult> -> ElevationStatus -> unit) -> unit

        type [<AllowNullLiteral>] ElevationServiceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> ElevationService

        type [<AllowNullLiteral>] LocationElevationRequest =
            abstract locations: ResizeArray<LatLng> with get, set

        type [<AllowNullLiteral>] PathElevationRequest =
            abstract path: ResizeArray<LatLng> option with get, set
            abstract samples: float option with get, set

        type [<AllowNullLiteral>] ElevationResult =
            abstract elevation: float with get, set
            abstract location: LatLng with get, set
            abstract resolution: float with get, set

        type ElevationStatus =
            obj

        type [<AllowNullLiteral>] MaxZoomService =
            abstract getMaxZoomAtLatLng: latlng: U2<LatLng, LatLngLiteral> * callback: (MaxZoomResult -> unit) -> unit

        type [<AllowNullLiteral>] MaxZoomServiceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> MaxZoomService

        type [<AllowNullLiteral>] MaxZoomResult =
            abstract status: MaxZoomStatus with get, set
            abstract zoom: float with get, set

        type MaxZoomStatus =
            obj

        type [<AllowNullLiteral>] DistanceMatrixService =
            abstract getDistanceMatrix: request: DistanceMatrixRequest * callback: (DistanceMatrixResponse -> DistanceMatrixStatus -> unit) -> unit

        type [<AllowNullLiteral>] DistanceMatrixServiceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> DistanceMatrixService

        type [<AllowNullLiteral>] DistanceMatrixRequest =
            abstract avoidFerries: bool option with get, set
            abstract avoidHighways: bool option with get, set
            abstract avoidTolls: bool option with get, set
            abstract destinations: U4<ResizeArray<string>, ResizeArray<LatLng>, ResizeArray<LatLngLiteral>, ResizeArray<Place>> option with get, set
            abstract drivingOptions: DrivingOptions option with get, set
            abstract durationInTraffic: bool option with get, set
            abstract origins: U4<ResizeArray<string>, ResizeArray<LatLng>, ResizeArray<LatLngLiteral>, ResizeArray<Place>> option with get, set
            abstract region: string option with get, set
            abstract transitOptions: TransitOptions option with get, set
            abstract travelMode: TravelMode option with get, set
            abstract unitSystem: UnitSystem option with get, set

        type [<AllowNullLiteral>] DistanceMatrixResponse =
            abstract destinationAddresses: ResizeArray<string> with get, set
            abstract originAddresses: ResizeArray<string> with get, set
            abstract rows: ResizeArray<DistanceMatrixResponseRow> with get, set

        type [<AllowNullLiteral>] DistanceMatrixResponseRow =
            abstract elements: ResizeArray<DistanceMatrixResponseElement> with get, set

        type [<AllowNullLiteral>] DistanceMatrixResponseElement =
            abstract distance: Distance with get, set
            abstract duration: Duration with get, set
            abstract duration_in_traffic: Duration with get, set
            abstract fare: TransitFare with get, set
            abstract status: DistanceMatrixElementStatus with get, set

        type DistanceMatrixStatus =
            obj

        type DistanceMatrixElementStatus =
            obj

        type [<AllowNullLiteral>] Attribution =
            abstract iosDeepLinkId: string option with get, set
            abstract source: string option with get, set
            abstract webUrl: string option with get, set

        type [<AllowNullLiteral>] Place =
            abstract location: U2<LatLng, LatLngLiteral> option with get, set
            abstract placeId: string option with get, set
            abstract query: string option with get, set

        type [<AllowNullLiteral>] SaveWidget =
            abstract getAttribution: unit -> Attribution
            abstract getPlace: unit -> Place
            abstract setAttribution: attribution: Attribution -> unit
            abstract setOptions: opts: SaveWidgetOptions -> unit
            abstract setPlace: place: Place -> unit

        type [<AllowNullLiteral>] SaveWidgetStatic =
            [<Emit "new $0($1...)">] abstract Create: container: Node * ?opts: SaveWidgetOptions -> SaveWidget

        type [<AllowNullLiteral>] SaveWidgetOptions =
            abstract attribution: Attribution option with get, set
            abstract place: Place option with get, set

        type [<AllowNullLiteral>] MapType =
            abstract getTile: tileCoord: Point * zoom: float * ownerDocument: Document -> Element
            abstract releaseTile: tile: Element -> unit
            abstract alt: string option with get, set
            abstract maxZoom: float option with get, set
            abstract minZoom: float option with get, set
            abstract name: string option with get, set
            abstract projection: Projection option with get, set
            abstract radius: float option with get, set
            abstract tileSize: Size option with get, set

        type [<AllowNullLiteral>] MapTypeRegistry =
            inherit MVCObject
            abstract set: id: string * mapType: MapType -> unit

        type [<AllowNullLiteral>] MapTypeRegistryStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> MapTypeRegistry

        type [<AllowNullLiteral>] Projection =
            abstract fromLatLngToPoint: latLng: LatLng * ?point: Point -> Point
            abstract fromPointToLatLng: pixel: Point * ?noWrap: bool -> LatLng

        type [<AllowNullLiteral>] ImageMapType =
            inherit MVCObject
            inherit MapType
            abstract getOpacity: unit -> float
            abstract getTile: tileCoord: Point * zoom: float * ownerDocument: Document -> Element
            abstract releaseTile: tile: Element -> unit
            abstract setOpacity: opacity: float -> unit

        type [<AllowNullLiteral>] ImageMapTypeStatic =
            [<Emit "new $0($1...)">] abstract Create: opts: ImageMapTypeOptions -> ImageMapType

        type [<AllowNullLiteral>] ImageMapTypeOptions =
            abstract alt: string option with get, set
            abstract getTileUrl: tileCoord: Point * zoom: float -> string
            abstract maxZoom: float option with get, set
            abstract minZoom: float option with get, set
            abstract name: string option with get, set
            abstract opacity: float option with get, set
            abstract tileSize: Size option with get, set

        type [<AllowNullLiteral>] StyledMapType =
            inherit MVCObject
            inherit MapType
            abstract getTile: tileCoord: Point * zoom: float * ownerDocument: Document -> Element
            abstract releaseTile: tile: Element -> unit

        type [<AllowNullLiteral>] StyledMapTypeStatic =
            [<Emit "new $0($1...)">] abstract Create: styles: ResizeArray<MapTypeStyle> * ?options: StyledMapTypeOptions -> StyledMapType

        type [<AllowNullLiteral>] StyledMapTypeOptions =
            abstract alt: string option with get, set
            abstract maxZoom: float option with get, set
            abstract minZoom: float option with get, set
            abstract name: string option with get, set

        type [<AllowNullLiteral>] MapTypeStyle =
            abstract elementType: MapTypeStyleElementType option with get, set
            abstract featureType: MapTypeStyleFeatureType option with get, set
            abstract stylers: ResizeArray<MapTypeStyler> option with get, set

        type [<StringEnum>] [<RequireQualifiedAccess>] MapTypeStyleFeatureType =
            | All
            | Administrative
            | [<CompiledName "administrative.country">] Administrative_country
            | [<CompiledName "administrative.land_parcel">] Administrative_land_parcel
            | [<CompiledName "administrative.locality">] Administrative_locality
            | [<CompiledName "administrative.neighborhood">] Administrative_neighborhood
            | [<CompiledName "administrative.province">] Administrative_province
            | Landscape
            | [<CompiledName "landscape.man_made">] Landscape_man_made
            | [<CompiledName "landscape.natural">] Landscape_natural
            | [<CompiledName "landscape.natural.landcover">] Landscape_natural_landcover
            | [<CompiledName "landscape.natural.terrain">] Landscape_natural_terrain
            | Poi
            | [<CompiledName "poi.attraction">] Poi_attraction
            | [<CompiledName "poi.business">] Poi_business
            | [<CompiledName "poi.government">] Poi_government
            | [<CompiledName "poi.medical">] Poi_medical
            | [<CompiledName "poi.park">] Poi_park
            | [<CompiledName "poi.place_of_worship">] Poi_place_of_worship
            | [<CompiledName "poi.school">] Poi_school
            | [<CompiledName "poi.sports_complex">] Poi_sports_complex
            | Road
            | [<CompiledName "road.arterial">] Road_arterial
            | [<CompiledName "road.highway">] Road_highway
            | [<CompiledName "road.highway.controlled_access">] Road_highway_controlled_access
            | [<CompiledName "road.local">] Road_local
            | Transit
            | [<CompiledName "transit.line">] Transit_line
            | [<CompiledName "transit.station">] Transit_station
            | [<CompiledName "transit.station.airport">] Transit_station_airport
            | [<CompiledName "transit.station.bus">] Transit_station_bus
            | [<CompiledName "transit.station.rail">] Transit_station_rail
            | Water

        type [<StringEnum>] [<RequireQualifiedAccess>] MapTypeStyleElementType =
            | All
            | Geometry
            | [<CompiledName "geometry.fill">] Geometry_fill
            | [<CompiledName "geometry.stroke">] Geometry_stroke
            | Labels
            | [<CompiledName "labels.icon">] Labels_icon
            | [<CompiledName "labels.text">] Labels_text
            | [<CompiledName "labels.text.fill">] Labels_text_fill
            | [<CompiledName "labels.text.stroke">] Labels_text_stroke

        type [<AllowNullLiteral>] MapTypeStyler =
            abstract color: string option with get, set
            abstract gamma: float option with get, set
            abstract hue: string option with get, set
            abstract invert_lightness: bool option with get, set
            abstract lightness: float option with get, set
            abstract saturation: float option with get, set
            abstract visibility: string option with get, set
            abstract weight: float option with get, set

        type [<AllowNullLiteral>] BicyclingLayer =
            inherit MVCObject
            abstract getMap: unit -> Map
            abstract setMap: map: Map option -> unit

        type [<AllowNullLiteral>] BicyclingLayerStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> BicyclingLayer

        type [<AllowNullLiteral>] FusionTablesLayer =
            inherit MVCObject
            abstract getMap: unit -> Map
            abstract setMap: map: Map option -> unit
            abstract setOptions: options: FusionTablesLayerOptions -> unit

        type [<AllowNullLiteral>] FusionTablesLayerStatic =
            [<Emit "new $0($1...)">] abstract Create: options: FusionTablesLayerOptions -> FusionTablesLayer

        type [<AllowNullLiteral>] FusionTablesLayerOptions =
            abstract clickable: bool option with get, set
            abstract heatmap: FusionTablesHeatmap option with get, set
            abstract map: Map option with get, set
            abstract query: FusionTablesQuery option with get, set
            abstract styles: ResizeArray<FusionTablesStyle> option with get, set
            abstract suppressInfoWindows: bool option with get, set

        type [<AllowNullLiteral>] FusionTablesQuery =
            abstract from: string option with get, set
            abstract limit: float option with get, set
            abstract offset: float option with get, set
            abstract orderBy: string option with get, set
            abstract select: string option with get, set
            abstract where: string option with get, set

        type [<AllowNullLiteral>] FusionTablesStyle =
            abstract markerOptions: FusionTablesMarkerOptions option with get, set
            abstract polygonOptions: FusionTablesPolygonOptions option with get, set
            abstract polylineOptions: FusionTablesPolylineOptions option with get, set
            abstract where: string option with get, set

        type [<AllowNullLiteral>] FusionTablesHeatmap =
            abstract enabled: bool with get, set

        type [<AllowNullLiteral>] FusionTablesMarkerOptions =
            abstract iconName: string with get, set

        type [<AllowNullLiteral>] FusionTablesPolygonOptions =
            abstract fillColor: string option with get, set
            abstract fillOpacity: float option with get, set
            abstract strokeColor: string option with get, set
            abstract strokeOpacity: float option with get, set
            abstract strokeWeight: float option with get, set

        type [<AllowNullLiteral>] FusionTablesPolylineOptions =
            abstract strokeColor: string option with get, set
            abstract strokeOpacity: float option with get, set
            abstract strokeWeight: float option with get, set

        type [<AllowNullLiteral>] FusionTablesMouseEvent =
            abstract infoWindowHtml: string option with get, set
            abstract latLng: LatLng option with get, set
            abstract pixelOffset: Size option with get, set
            abstract row: Object option with get, set

        type [<AllowNullLiteral>] FusionTablesCell =
            abstract columnName: string option with get, set
            abstract value: string option with get, set

        type [<AllowNullLiteral>] KmlLayer =
            inherit MVCObject
            abstract getDefaultViewport: unit -> LatLngBounds
            abstract getMap: unit -> Map
            abstract getMetadata: unit -> KmlLayerMetadata
            abstract getStatus: unit -> KmlLayerStatus
            abstract getUrl: unit -> string
            abstract getZIndex: unit -> float
            abstract setMap: map: Map option -> unit
            abstract setUrl: url: string -> unit
            abstract setZIndex: zIndex: float -> unit
            abstract setOptions: options: KmlLayerOptions -> unit

        type [<AllowNullLiteral>] KmlLayerStatic =
            [<Emit "new $0($1...)">] abstract Create: ?opts: KmlLayerOptions -> KmlLayer

        type [<AllowNullLiteral>] KmlLayerOptions =
            abstract clickable: bool option with get, set
            abstract map: Map option with get, set
            abstract preserveViewport: bool option with get, set
            abstract screenOverlays: bool option with get, set
            abstract suppressInfoWindows: bool option with get, set
            abstract url: string option with get, set
            abstract zIndex: float option with get, set

        type [<AllowNullLiteral>] KmlLayerMetadata =
            abstract author: KmlAuthor with get, set
            abstract description: string with get, set
            abstract hasScreenOverlays: bool with get, set
            abstract name: string with get, set
            abstract snippet: string with get, set

        type KmlLayerStatus =
            obj

        type [<AllowNullLiteral>] KmlMouseEvent =
            abstract featureData: KmlFeatureData with get, set
            abstract latLng: LatLng with get, set
            abstract pixelOffset: Size with get, set

        type [<AllowNullLiteral>] KmlFeatureData =
            abstract author: KmlAuthor with get, set
            abstract description: string with get, set
            abstract id: string with get, set
            abstract infoWindowHtml: string with get, set
            abstract name: string with get, set
            abstract snippet: string with get, set

        type [<AllowNullLiteral>] KmlAuthor =
            abstract email: string with get, set
            abstract name: string with get, set
            abstract uri: string with get, set

        type [<AllowNullLiteral>] TrafficLayer =
            inherit MVCObject
            abstract getMap: unit -> Map
            abstract setMap: map: Map option -> unit
            abstract setOptions: options: TrafficLayerOptions -> unit

        type [<AllowNullLiteral>] TrafficLayerStatic =
            [<Emit "new $0($1...)">] abstract Create: ?opts: TrafficLayerOptions -> TrafficLayer

        type [<AllowNullLiteral>] TrafficLayerOptions =
            abstract autoRefresh: bool option with get, set
            abstract map: Map option with get, set

        type [<AllowNullLiteral>] TransitLayer =
            inherit MVCObject
            abstract getMap: unit -> unit
            abstract setMap: map: Map option -> unit

        type [<AllowNullLiteral>] TransitLayerStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> TransitLayer

        type [<AllowNullLiteral>] StreetViewPanorama =
            inherit MVCObject
            abstract controls: ResizeArray<MVCArray<Node>> with get, set
            abstract getLinks: unit -> ResizeArray<StreetViewLink>
            abstract getLocation: unit -> StreetViewLocation
            abstract getMotionTracking: unit -> bool
            abstract getPano: unit -> string
            abstract getPhotographerPov: unit -> StreetViewPov
            abstract getPosition: unit -> LatLng
            abstract getPov: unit -> StreetViewPov
            abstract getStatus: unit -> StreetViewStatus
            abstract getVisible: unit -> bool
            abstract getZoom: unit -> float
            abstract registerPanoProvider: provider: (string -> StreetViewPanoramaData) -> unit
            abstract setLinks: links: Array<StreetViewLink> -> unit
            abstract setMotionTracking: motionTracking: bool -> unit
            abstract setOptions: options: StreetViewPanoramaOptions -> unit
            abstract setPano: pano: string -> unit
            abstract setPosition: latLng: U2<LatLng, LatLngLiteral> -> unit
            abstract setPov: pov: StreetViewPov -> unit
            abstract setVisible: flag: bool -> unit
            abstract setZoom: zoom: float -> unit

        type [<AllowNullLiteral>] StreetViewPanoramaStatic =
            [<Emit "new $0($1...)">] abstract Create: container: Element * ?opts: StreetViewPanoramaOptions -> StreetViewPanorama

        /// Options for the rendering of the fullscreen control. 
        type [<AllowNullLiteral>] FullscreenControlOptions =
            /// Position id. Used to specify the position of the control on the map.
            /// The default position is RIGHT_TOP.
            abstract position: ControlPosition option with get, set

        type [<AllowNullLiteral>] StreetViewPanoramaOptions =
            abstract addressControl: bool option with get, set
            abstract addressControlOptions: StreetViewAddressControlOptions option with get, set
            abstract clickToGo: bool option with get, set
            abstract disableDefaultUI: bool option with get, set
            abstract disableDoubleClickZoom: bool option with get, set
            abstract enableCloseButton: bool option with get, set
            abstract fullscreenControl: bool option with get, set
            abstract fullscreenControlOptions: FullscreenControlOptions option with get, set
            abstract imageDateControl: bool option with get, set
            abstract linksControl: bool option with get, set
            abstract motionTracking: bool option with get, set
            abstract motionTrackingControl: bool option with get, set
            abstract motionTrackingControlOptions: MotionTrackingControlOptions option with get, set
            abstract mode: U3<string, string, string> option with get, set
            abstract panControl: bool option with get, set
            abstract panControlOptions: PanControlOptions option with get, set
            abstract pano: string option with get, set
            abstract panoProvider: (string -> StreetViewPanoramaData) option with get, set
            abstract position: U2<LatLng, LatLngLiteral> option with get, set
            abstract pov: StreetViewPov option with get, set
            abstract scrollwheel: bool option with get, set
            abstract visible: bool option with get, set
            abstract zoom: float option with get, set
            abstract zoomControl: bool option with get, set
            abstract zoomControlOptions: ZoomControlOptions option with get, set

        type [<AllowNullLiteral>] StreetViewAddressControlOptions =
            abstract position: ControlPosition option with get, set

        type [<AllowNullLiteral>] StreetViewLink =
            abstract description: string option with get, set
            abstract heading: float option with get, set
            abstract pano: string option with get, set

        type [<AllowNullLiteral>] StreetViewPov =
            abstract heading: float option with get, set
            abstract pitch: float option with get, set

        type [<AllowNullLiteral>] StreetViewPanoramaData =
            abstract copyright: string option with get, set
            abstract imageDate: string option with get, set
            abstract links: ResizeArray<StreetViewLink> option with get, set
            abstract location: StreetViewLocation option with get, set
            abstract tiles: StreetViewTileData option with get, set

        type [<AllowNullLiteral>] StreetViewLocation =
            abstract description: string option with get, set
            abstract latLng: LatLng option with get, set
            abstract pano: string option with get, set
            abstract shortDescription: string option with get, set

        type [<AllowNullLiteral>] StreetViewTileData =
            abstract getTileUrl: pano: string * tileZoom: float * tileX: float * tileY: float -> string
            abstract centerHeading: float option with get, set
            abstract tileSize: Size option with get, set
            abstract worldSize: Size option with get, set

        type StreetViewPreference =
            obj

        type StreetViewSource =
            obj

        type [<AllowNullLiteral>] StreetViewLocationRequest =
            abstract location: U2<LatLng, LatLngLiteral> with get, set
            abstract preference: StreetViewPreference option with get, set
            abstract radius: float option with get, set
            abstract source: StreetViewSource option with get, set

        type [<AllowNullLiteral>] StreetViewPanoRequest =
            abstract pano: string with get, set

        type [<AllowNullLiteral>] StreetViewService =
            abstract getPanorama: request: U2<StreetViewLocationRequest, StreetViewPanoRequest> * cb: (StreetViewPanoramaData -> StreetViewStatus -> unit) -> unit
            abstract getPanoramaById: pano: string * callback: (StreetViewPanoramaData -> StreetViewStatus -> unit) -> unit
            abstract getPanoramaByLocation: latlng: U2<LatLng, LatLngLiteral> * radius: float * callback: (StreetViewPanoramaData -> StreetViewStatus -> unit) -> unit

        type [<AllowNullLiteral>] StreetViewServiceStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> StreetViewService

        type StreetViewStatus =
            obj

        type [<AllowNullLiteral>] StreetViewCoverageLayer =
            inherit MVCObject
            abstract getMap: unit -> Map
            abstract setMap: map: Map option -> unit

        type [<AllowNullLiteral>] StreetViewCoverageLayerStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> StreetViewCoverageLayer

        type [<AllowNullLiteral>] MotionTrackingControlOptions =
            abstract position: ControlPosition option with get, set

        type [<AllowNullLiteral>] MapsEventListener =
            /// Removes the listener.  Equivalent to calling
            /// google.maps.event.removeListener(listener).
            abstract remove: unit -> unit

        type [<AllowNullLiteral>] ``event`` =
            interface end

        type [<AllowNullLiteral>] eventStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> ``event``
            /// Cross browser event handler registration. This listener is removed by
            /// calling removeListener(handle) for the handle that is returned by this
            /// function.
            abstract addDomListener: instance: Object * eventName: string * handler: (obj -> unit) * ?capture: bool -> MapsEventListener
            /// Wrapper around addDomListener that removes the listener after the first
            /// event.
            abstract addDomListenerOnce: instance: Object * eventName: string * handler: (obj -> unit) * ?capture: bool -> MapsEventListener
            /// Adds the given listener function to the given event name for the given
            /// object instance. Returns an identifier for this listener that can be used
            /// with removeListener().
            abstract addListener: instance: Object * eventName: string * handler: (obj -> unit) -> MapsEventListener
            /// Like addListener, but the handler removes itself after handling the first
            /// event.
            abstract addListenerOnce: instance: Object * eventName: string * handler: (obj -> unit) -> MapsEventListener
            /// Removes all listeners for all events for the given instance.
            abstract clearInstanceListeners: instance: Object -> unit
            /// Removes all listeners for the given event for the given instance.
            abstract clearListeners: instance: Object * eventName: string -> unit
            /// Removes the given listener, which should have been returned by
            /// addListener above. Equivalent to calling listener.remove().
            abstract removeListener: listener: MapsEventListener -> unit
            /// Triggers the given event. All arguments after eventName are passed as
            /// arguments to the listeners.
            abstract trigger: instance: obj option * eventName: string * [<ParamArray>] args: ResizeArray<obj option> -> unit

        /// This object is returned from various mouse events on the map and overlays,
        /// and contains all the fields shown below.
        type [<AllowNullLiteral>] MouseEvent =
            /// Prevents this event from propagating further. 
            abstract stop: unit -> unit
            /// The latitude/longitude that was below the cursor when the event
            /// occurred.
            abstract latLng: LatLng with get, set

        /// This object is sent in an event when a user clicks on an icon on the map.
        /// The place ID of this place is stored in the placeId member.
        /// To prevent the default info window from showing up, call the stop() method
        /// on this event to prevent it being propagated. Learn more about place IDs in
        /// the Places API developer guide.
        type [<AllowNullLiteral>] IconMouseEvent =
            inherit MouseEvent
            /// The place ID of the place that was clicked.
            /// This place ID can be used to query more information about the feature
            /// that was clicked.
            abstract placeId: string with get, set

        /// A LatLng is a point in geographical coordinates: latitude and longitude.
        /// 
        /// * Latitude ranges between -90 and 90 degrees, inclusive. Values above or
        ///    below this range will be clamped to the range [-90, 90]. This means
        ///    that if the value specified is less than -90, it will be set to -90.
        ///    And if the value is greater than 90, it will be set to 90.
        /// * Longitude ranges between -180 and 180 degrees, inclusive. Values above
        ///    or below this range will be wrapped so that they fall within the
        ///    range. For example, a value of -190 will be converted to 170. A value
        ///    of 190 will be converted to -170. This reflects the fact that
        ///    longitudes wrap around the globe.
        /// 
        /// Although the default map projection associates longitude with the
        /// x-coordinate of the map, and latitude with the y-coordinate, the
        /// latitude coordinate is always written first, followed by the longitude.
        /// Notice that you cannot modify the coordinates of a LatLng. If you want
        /// to compute another point, you have to create a new one.
        type [<AllowNullLiteral>] LatLng =
            /// Comparison function. 
            abstract equals: other: LatLng -> bool
            /// Returns the latitude in degrees. 
            abstract lat: unit -> float
            /// Returns the longitude in degrees. 
            abstract lng: unit -> float
            /// Converts to string representation. 
            abstract toString: unit -> string
            /// Returns a string of the form "lat,lng". We round the lat/lng values to 6
            /// decimal places by default.
            abstract toUrlValue: ?precision: float -> string
            /// Converts to JSON representation. This function is intended to be used
            /// via JSON.stringify.
            abstract toJSON: unit -> LatLngLiteral

        /// A LatLng is a point in geographical coordinates: latitude and longitude.
        /// 
        /// * Latitude ranges between -90 and 90 degrees, inclusive. Values above or
        ///    below this range will be clamped to the range [-90, 90]. This means
        ///    that if the value specified is less than -90, it will be set to -90.
        ///    And if the value is greater than 90, it will be set to 90.
        /// * Longitude ranges between -180 and 180 degrees, inclusive. Values above
        ///    or below this range will be wrapped so that they fall within the
        ///    range. For example, a value of -190 will be converted to 170. A value
        ///    of 190 will be converted to -170. This reflects the fact that
        ///    longitudes wrap around the globe.
        /// 
        /// Although the default map projection associates longitude with the
        /// x-coordinate of the map, and latitude with the y-coordinate, the
        /// latitude coordinate is always written first, followed by the longitude.
        /// Notice that you cannot modify the coordinates of a LatLng. If you want
        /// to compute another point, you have to create a new one.
        type [<AllowNullLiteral>] LatLngStatic =
            /// <summary>Creates a LatLng object representing a geographic point.
            /// Note the ordering of latitude and longitude.</summary>
            /// <param name="lat">Latitude is specified in degrees within the range [-90, 90].</param>
            /// <param name="lng">Longitude is specified in degrees within the range [-180,
            /// 180].</param>
            /// <param name="noWrap">Set noWrap to true to enable values outside of this range.</param>
            [<Emit "new $0($1...)">] abstract Create: lat: float * lng: float * ?noWrap: bool -> LatLng

        type [<AllowNullLiteral>] LatLngLiteral =
            abstract lat: float with get, set
            abstract lng: float with get, set

        type [<AllowNullLiteral>] LatLngBoundsLiteral =
            abstract east: float with get, set
            abstract north: float with get, set
            abstract south: float with get, set
            abstract west: float with get, set

        /// A LatLngBounds instance represents a rectangle in geographical coordinates,
        /// including one that crosses the 180 degrees longitudinal meridian.
        type [<AllowNullLiteral>] LatLngBounds =
            /// Returns true if the given lat/lng is in this bounds. 
            abstract contains: latLng: U2<LatLng, LatLngLiteral> -> bool
            /// Returns true if this bounds approximately equals the given bounds. 
            abstract equals: other: U2<LatLngBounds, LatLngBoundsLiteral> -> bool
            /// Extends this bounds to contain the given point. 
            abstract extend: point: U2<LatLng, LatLngLiteral> -> LatLngBounds
            /// Computes the center of this LatLngBounds 
            abstract getCenter: unit -> LatLng
            /// Returns the north-east corner of this bounds. 
            abstract getNorthEast: unit -> LatLng
            /// Returns the south-west corner of this bounds. 
            abstract getSouthWest: unit -> LatLng
            /// Returns true if this bounds shares any points with the other bounds. 
            abstract intersects: other: U2<LatLngBounds, LatLngBoundsLiteral> -> bool
            /// Returns if the bounds are empty. 
            abstract isEmpty: unit -> bool
            /// Converts to JSON representation. This function is intended to be used
            /// via JSON.stringify.
            abstract toJSON: unit -> LatLngBoundsLiteral
            /// Converts the given map bounds to a lat/lng span. 
            abstract toSpan: unit -> LatLng
            /// Converts to string. 
            abstract toString: unit -> string
            /// Returns a string of the form "lat_lo,lng_lo,lat_hi,lng_hi" for this
            /// bounds, where "lo" corresponds to the southwest corner of the bounding
            /// box, while "hi" corresponds to the northeast corner of that box.
            abstract toUrlValue: ?precision: float -> string
            /// Extends this bounds to contain the union of this and the given bounds.
            abstract union: other: U2<LatLngBounds, LatLngBoundsLiteral> -> LatLngBounds

        /// A LatLngBounds instance represents a rectangle in geographical coordinates,
        /// including one that crosses the 180 degrees longitudinal meridian.
        type [<AllowNullLiteral>] LatLngBoundsStatic =
            /// Constructs a rectangle from the points at its south-west and north-east
            /// corners.
            [<Emit "new $0($1...)">] abstract Create: ?sw: U2<LatLng, LatLngLiteral> * ?ne: U2<LatLng, LatLngLiteral> -> LatLngBounds

        type [<AllowNullLiteral>] Point =
            /// The X coordinate 
            abstract x: float with get, set
            /// The Y coordinate 
            abstract y: float with get, set
            /// Compares two Points 
            abstract equals: other: Point -> bool
            /// Returns a string representation of this Point. 
            abstract toString: unit -> string

        type [<AllowNullLiteral>] PointStatic =
            /// A point on a two-dimensional plane. 
            [<Emit "new $0($1...)">] abstract Create: x: float * y: float -> Point

        type [<AllowNullLiteral>] Size =
            abstract height: float with get, set
            abstract width: float with get, set
            abstract equals: other: Size -> bool
            abstract toString: unit -> string

        type [<AllowNullLiteral>] SizeStatic =
            [<Emit "new $0($1...)">] abstract Create: width: float * height: float * ?widthUnit: string * ?heightUnit: string -> Size

        /// Base class implementing KVO. 
        type [<AllowNullLiteral>] MVCObject =
            /// Adds the given listener function to the given event name. Returns an
            /// identifier for this listener that can be used with
            /// google.maps.event.removeListener.
            abstract addListener: eventName: string * handler: (ResizeArray<obj option> -> unit) -> MapsEventListener
            /// Binds a View to a Model. 
            abstract bindTo: key: string * target: MVCObject * ?targetKey: string * ?noNotify: bool -> unit
            abstract changed: key: string -> unit
            /// Gets a value. 
            abstract get: key: string -> obj option
            /// Notify all observers of a change on this property. This notifies both
            /// objects that are bound to the object's property as well as the object
            /// that it is bound to.
            abstract notify: key: string -> unit
            /// Sets a value. 
            abstract set: key: string * value: obj option -> unit
            /// Sets a collection of key-value pairs. 
            abstract setValues: values: obj option -> unit
            /// Removes a binding. Unbinding will set the unbound property to the current
            /// value. The object will not be notified, as the value has not changed.
            abstract unbind: key: string -> unit
            /// Removes all bindings. 
            abstract unbindAll: unit -> unit

        /// Base class implementing KVO. 
        type [<AllowNullLiteral>] MVCObjectStatic =
            /// The MVCObject constructor is guaranteed to be an empty function, and so
            /// you may inherit from MVCObject by simply writing MySubclass.prototype =
            /// new google.maps.MVCObject();. Unless otherwise noted, this is not true of
            /// other classes in the API, and inheriting from other classes in the API is
            /// not supported.
            [<Emit "new $0($1...)">] abstract Create: unit -> MVCObject

        /// This class extends MVCObject. 
        type [<AllowNullLiteral>] MVCArray<'T> =
            inherit MVCObject
            /// Removes all elements from the array. 
            abstract clear: unit -> unit
            /// Iterate over each element, calling the provided callback.
            /// The callback is called for each element like: callback(element, index).
            abstract forEach: callback: ('T -> float -> unit) -> unit
            /// Returns a reference to the underlying Array.
            /// Warning: if the Array is mutated, no events will be fired by this object.
            abstract getArray: unit -> ResizeArray<'T>
            /// Returns the element at the specified index. 
            abstract getAt: i: float -> 'T
            /// Returns the number of elements in this array. 
            abstract getLength: unit -> float
            /// Inserts an element at the specified index. 
            abstract insertAt: i: float * elem: 'T -> unit
            /// Removes the last element of the array and returns that element. 
            abstract pop: unit -> 'T
            /// Adds one element to the end of the array and returns the new length of
            /// the array.
            abstract push: elem: 'T -> float
            /// Removes an element from the specified index. 
            abstract removeAt: i: float -> 'T
            /// Sets an element at the specified index. 
            abstract setAt: i: float * elem: 'T -> unit

        /// This class extends MVCObject. 
        type [<AllowNullLiteral>] MVCArrayStatic =
            /// A mutable MVC Array. 
            [<Emit "new $0($1...)">] abstract Create: ?array: ResizeArray<'T> -> MVCArray<'T>

        module Geometry =

            type [<AllowNullLiteral>] IExports =
                abstract encoding: encodingStatic
                abstract spherical: sphericalStatic
                abstract poly: polyStatic

            type [<AllowNullLiteral>] encoding =
                interface end

            type [<AllowNullLiteral>] encodingStatic =
                [<Emit "new $0($1...)">] abstract Create: unit -> encoding
                abstract decodePath: encodedPath: string -> ResizeArray<LatLng>
                abstract encodePath: path: U2<ResizeArray<LatLng>, MVCArray<LatLng>> -> string

            /// Utility functions for computing geodesic angles, distances and areas.
            /// The default radius is Earth's radius of 6378137 meters.
            type [<AllowNullLiteral>] spherical =
                interface end

            /// Utility functions for computing geodesic angles, distances and areas.
            /// The default radius is Earth's radius of 6378137 meters.
            type [<AllowNullLiteral>] sphericalStatic =
                [<Emit "new $0($1...)">] abstract Create: unit -> spherical
                /// Returns the area of a closed path.
                /// The computed area uses the same units as the radius.
                /// The radius defaults to the Earth's radius in meters,
                /// in which case the area is in square meters.
                abstract computeArea: path: U2<ResizeArray<LatLng>, MVCArray<LatLng>> * ?radius: float -> float
                /// Returns the distance, in meters, between two LatLngs.
                /// You can optionally specify a custom radius.
                /// The radius defaults to the radius of the Earth.
                abstract computeDistanceBetween: from: LatLng * ``to``: LatLng * ?radius: float -> float
                /// Returns the heading from one LatLng to another LatLng.
                /// Headings are expressed in degrees clockwise from North within the range
                /// [-180,180).
                abstract computeHeading: from: LatLng * ``to``: LatLng -> float
                /// Returns the length of the given path.
                abstract computeLength: path: U2<ResizeArray<LatLng>, MVCArray<LatLng>> * ?radius: float -> float
                /// Returns the LatLng resulting from moving a distance from an origin in
                /// the specified heading (expressed in degrees clockwise from north).
                abstract computeOffset: from: LatLng * distance: float * heading: float * ?radius: float -> LatLng
                /// Returns the location of origin when provided with a LatLng destination,
                /// meters travelled and original heading. Headings are expressed in
                /// degrees clockwise from North. This function returns null when no
                /// solution is available.
                abstract computeOffsetOrigin: ``to``: LatLng * distance: float * heading: float * ?radius: float -> LatLng
                /// Returns the signed area of a closed path. The signed area may be used
                /// to determine the orientation of the path. The computed area uses the
                /// same units as the radius. The radius defaults to the Earth's radius in
                /// meters, in which case the area is in square meters.
                abstract computeSignedArea: loop: U2<ResizeArray<LatLng>, MVCArray<LatLng>> * ?radius: float -> float
                /// Returns the LatLng which lies the given fraction of the way between the
                /// origin LatLng and the destination LatLng.
                abstract interpolate: from: LatLng * ``to``: LatLng * fraction: float -> LatLng

            type [<AllowNullLiteral>] poly =
                interface end

            type [<AllowNullLiteral>] polyStatic =
                [<Emit "new $0($1...)">] abstract Create: unit -> poly
                abstract containsLocation: point: LatLng * polygon: Polygon -> bool
                abstract isLocationOnEdge: point: LatLng * poly: U2<Polygon, Polyline> * ?tolerance: float -> bool

        module Adsense =

            type [<AllowNullLiteral>] IExports =
                abstract AdUnit: AdUnitStatic

            type [<AllowNullLiteral>] AdUnit =
                inherit MVCObject
                abstract getBackgroundColor: unit -> string
                abstract getBorderColor: unit -> string
                abstract getChannelNumber: unit -> string
                abstract getContainer: unit -> Element
                abstract getFormat: unit -> AdFormat
                abstract getMap: unit -> Map
                abstract getPosition: unit -> ControlPosition
                abstract getPublisherId: unit -> string
                abstract getTextColor: unit -> string
                abstract getTitleColor: unit -> string
                abstract getUrlColor: unit -> string
                abstract setBackgroundColor: backgroundColor: string -> unit
                abstract setBorderColor: borderColor: string -> unit
                abstract setChannelNumber: channelNumber: string -> unit
                abstract setFormat: format: AdFormat -> unit
                abstract setMap: map: Map option -> unit
                abstract setPosition: position: ControlPosition -> unit
                abstract setTextColor: textColor: string -> unit
                abstract setTitleColor: titleColor: string -> unit
                abstract setUrlColor: urlColor: string -> unit

            type [<AllowNullLiteral>] AdUnitStatic =
                [<Emit "new $0($1...)">] abstract Create: container: Element * opts: AdUnitOptions -> AdUnit

            type [<AllowNullLiteral>] AdUnitOptions =
                abstract backgroundColor: string option with get, set
                abstract borderColor: string option with get, set
                abstract channelNumber: string option with get, set
                abstract format: AdFormat option with get, set
                abstract map: Map option with get, set
                abstract position: ControlPosition option with get, set
                abstract publisherId: string option with get, set
                abstract textColor: string option with get, set
                abstract titleColor: string option with get, set
                abstract urlColor: string option with get, set

            type AdFormat =
                obj

        module Places =

            type [<AllowNullLiteral>] IExports =
                abstract Autocomplete: AutocompleteStatic
                abstract AutocompleteService: AutocompleteServiceStatic
                abstract AutocompleteSessionToken: AutocompleteSessionTokenStatic
                abstract PlacesService: PlacesServiceStatic
                abstract SearchBox: SearchBoxStatic

            type [<AllowNullLiteral>] Autocomplete =
                inherit MVCObject
                abstract getBounds: unit -> LatLngBounds
                abstract getPlace: unit -> PlaceResult
                abstract setBounds: bounds: U2<LatLngBounds, LatLngBoundsLiteral> -> unit
                abstract setComponentRestrictions: restrictions: ComponentRestrictions -> unit
                abstract setTypes: types: ResizeArray<string> -> unit

            type [<AllowNullLiteral>] AutocompleteStatic =
                [<Emit "new $0($1...)">] abstract Create: inputField: HTMLInputElement * ?opts: AutocompleteOptions -> Autocomplete

            type [<AllowNullLiteral>] AutocompleteOptions =
                abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> option with get, set
                abstract componentRestrictions: ComponentRestrictions option with get, set
                abstract placeIdOnly: bool option with get, set
                abstract strictBounds: bool option with get, set
                abstract types: ResizeArray<string> option with get, set
                abstract ``type``: string option with get, set

            type [<AllowNullLiteral>] AutocompletePrediction =
                abstract description: string with get, set
                abstract matched_substrings: ResizeArray<PredictionSubstring> with get, set
                abstract place_id: string with get, set
                abstract reference: string with get, set
                abstract structured_formatting: AutocompleteStructuredFormatting with get, set
                abstract terms: ResizeArray<PredictionTerm> with get, set
                abstract types: ResizeArray<string> with get, set

            type [<AllowNullLiteral>] AutocompleteStructuredFormatting =
                abstract main_text: string with get, set
                abstract main_text_matched_substrings: ResizeArray<PredictionSubstring> with get, set
                abstract secondary_text: string with get, set

            type [<AllowNullLiteral>] OpeningHours =
                abstract open_now: bool with get, set
                abstract periods: ResizeArray<OpeningPeriod> with get, set
                abstract weekday_text: ResizeArray<string> with get, set

            type [<AllowNullLiteral>] OpeningPeriod =
                abstract ``open``: OpeningHoursTime with get, set
                abstract close: OpeningHoursTime option with get, set

            type [<AllowNullLiteral>] OpeningHoursTime =
                abstract day: float with get, set
                abstract hours: float with get, set
                abstract minutes: float with get, set
                abstract nextDate: float with get, set
                abstract time: string with get, set

            type [<AllowNullLiteral>] PredictionTerm =
                abstract offset: float with get, set
                abstract value: string with get, set

            type [<AllowNullLiteral>] PredictionSubstring =
                abstract length: float with get, set
                abstract offset: float with get, set

            type [<AllowNullLiteral>] AutocompleteService =
                abstract getPlacePredictions: request: AutocompletionRequest * callback: (ResizeArray<AutocompletePrediction> -> PlacesServiceStatus -> unit) -> unit
                abstract getQueryPredictions: request: QueryAutocompletionRequest * callback: (ResizeArray<QueryAutocompletePrediction> -> PlacesServiceStatus -> unit) -> unit

            type [<AllowNullLiteral>] AutocompleteServiceStatic =
                [<Emit "new $0($1...)">] abstract Create: unit -> AutocompleteService

            type [<AllowNullLiteral>] AutocompleteSessionToken =
                interface end

            type [<AllowNullLiteral>] AutocompleteSessionTokenStatic =
                [<Emit "new $0($1...)">] abstract Create: unit -> AutocompleteSessionToken

            type [<AllowNullLiteral>] AutocompletionRequest =
                abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> option with get, set
                abstract componentRestrictions: ComponentRestrictions option with get, set
                abstract input: string with get, set
                abstract location: LatLng option with get, set
                abstract offset: float option with get, set
                abstract radius: float option with get, set
                abstract sessionToken: AutocompleteSessionToken option with get, set
                abstract types: ResizeArray<string> option with get, set

            type [<AllowNullLiteral>] ComponentRestrictions =
                abstract country: U2<string, ResizeArray<string>> with get, set

            type LocationBias =
                U7<LatLng, LatLngLiteral, LatLngBounds, LatLngBoundsLiteral, Circle, CircleLiteral, string>

            [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
            module LocationBias =
                let ofLatLng v: LocationBias = v |> U7.Case1
                let isLatLng (v: LocationBias) = match v with U7.Case1 _ -> true | _ -> false
                let asLatLng (v: LocationBias) = match v with U7.Case1 o -> Some o | _ -> None
                let ofLatLngLiteral v: LocationBias = v |> U7.Case2
                let isLatLngLiteral (v: LocationBias) = match v with U7.Case2 _ -> true | _ -> false
                let asLatLngLiteral (v: LocationBias) = match v with U7.Case2 o -> Some o | _ -> None
                let ofLatLngBounds v: LocationBias = v |> U7.Case3
                let isLatLngBounds (v: LocationBias) = match v with U7.Case3 _ -> true | _ -> false
                let asLatLngBounds (v: LocationBias) = match v with U7.Case3 o -> Some o | _ -> None
                let ofLatLngBoundsLiteral v: LocationBias = v |> U7.Case4
                let isLatLngBoundsLiteral (v: LocationBias) = match v with U7.Case4 _ -> true | _ -> false
                let asLatLngBoundsLiteral (v: LocationBias) = match v with U7.Case4 o -> Some o | _ -> None
                let ofCircle v: LocationBias = v |> U7.Case5
                let isCircle (v: LocationBias) = match v with U7.Case5 _ -> true | _ -> false
                let asCircle (v: LocationBias) = match v with U7.Case5 o -> Some o | _ -> None
                let ofCircleLiteral v: LocationBias = v |> U7.Case6
                let isCircleLiteral (v: LocationBias) = match v with U7.Case6 _ -> true | _ -> false
                let asCircleLiteral (v: LocationBias) = match v with U7.Case6 o -> Some o | _ -> None
                let ofString v: LocationBias = v |> U7.Case7
                let isString (v: LocationBias) = match v with U7.Case7 _ -> true | _ -> false
                let asString (v: LocationBias) = match v with U7.Case7 o -> Some o | _ -> None

            type [<AllowNullLiteral>] PlaceAspectRating =
                abstract rating: float with get, set
                abstract ``type``: string with get, set

            type [<AllowNullLiteral>] PlaceDetailsRequest =
                abstract placeId: string with get, set
                abstract fields: ResizeArray<string> option with get, set
                abstract sessionToken: AutocompleteSessionToken option with get, set

            type [<AllowNullLiteral>] PlaceGeometry =
                abstract location: LatLng with get, set
                abstract viewport: LatLngBounds with get, set

            type [<AllowNullLiteral>] PlacePhoto =
                abstract height: float with get, set
                abstract html_attributions: ResizeArray<string> with get, set
                abstract width: float with get, set
                abstract getUrl: opts: PhotoOptions -> string

            type [<AllowNullLiteral>] PhotoOptions =
                abstract maxHeight: float option with get, set
                abstract maxWidth: float option with get, set

            type [<AllowNullLiteral>] PlaceResult =
                abstract address_components: ResizeArray<GeocoderAddressComponent> with get, set
                abstract adr_address: string with get, set
                abstract formatted_address: string with get, set
                abstract formatted_phone_number: string with get, set
                abstract geometry: PlaceGeometry with get, set
                abstract html_attributions: ResizeArray<string> with get, set
                abstract icon: string with get, set
                abstract id: string with get, set
                abstract international_phone_number: string with get, set
                abstract name: string with get, set
                abstract opening_hours: OpeningHours with get, set
                abstract permanently_closed: bool with get, set
                abstract photos: ResizeArray<PlacePhoto> with get, set
                abstract place_id: string with get, set
                abstract price_level: float with get, set
                abstract rating: float with get, set
                abstract reviews: ResizeArray<PlaceReview> with get, set
                abstract types: ResizeArray<string> with get, set
                abstract url: string with get, set
                abstract utc_offset: float with get, set
                abstract vicinity: string with get, set
                abstract website: string with get, set

            type [<AllowNullLiteral>] PlaceReview =
                abstract aspects: ResizeArray<PlaceAspectRating> with get, set
                abstract author_name: string with get, set
                abstract author_url: string with get, set
                abstract language: string with get, set
                abstract text: string with get, set

            type [<AllowNullLiteral>] PlaceSearchPagination =
                abstract nextPage: unit -> unit
                abstract hasNextPage: bool with get, set

            type [<AllowNullLiteral>] PlaceSearchRequest =
                abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> option with get, set
                abstract keyword: string option with get, set
                abstract location: U2<LatLng, LatLngLiteral> option with get, set
                abstract maxPriceLevel: float option with get, set
                abstract minPriceLevel: float option with get, set
                abstract name: string option with get, set
                abstract openNow: bool option with get, set
                abstract radius: float option with get, set
                abstract rankBy: RankBy option with get, set
                abstract types: ResizeArray<string> option with get, set
                abstract ``type``: string option with get, set

            type [<AllowNullLiteral>] PlacesService =
                abstract findPlaceFromPhoneNumber: request: FindPlaceFromPhoneNumberRequest * callback: (ResizeArray<PlaceResult> -> PlacesServiceStatus -> unit) -> unit
                abstract findPlaceFromQuery: request: FindPlaceFromQueryRequest * callback: (ResizeArray<PlaceResult> -> PlacesServiceStatus -> unit) -> unit
                abstract getDetails: request: PlaceDetailsRequest * callback: (PlaceResult -> PlacesServiceStatus -> unit) -> unit
                abstract nearbySearch: request: PlaceSearchRequest * callback: (ResizeArray<PlaceResult> -> PlacesServiceStatus -> PlaceSearchPagination -> unit) -> unit
                abstract radarSearch: request: RadarSearchRequest * callback: (ResizeArray<PlaceResult> -> PlacesServiceStatus -> unit) -> unit
                abstract textSearch: request: TextSearchRequest * callback: (ResizeArray<PlaceResult> -> PlacesServiceStatus -> PlaceSearchPagination -> unit) -> unit

            type [<AllowNullLiteral>] PlacesServiceStatic =
                [<Emit "new $0($1...)">] abstract Create: attrContainer: U2<HTMLDivElement, Map> -> PlacesService

            type PlacesServiceStatus =
                obj

            type [<AllowNullLiteral>] QueryAutocompletePrediction =
                abstract description: string with get, set
                abstract matched_substrings: ResizeArray<PredictionSubstring> with get, set
                abstract place_id: string with get, set
                abstract terms: ResizeArray<PredictionTerm> with get, set

            type [<AllowNullLiteral>] QueryAutocompletionRequest =
                abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> option with get, set
                abstract input: string option with get, set
                abstract location: LatLng option with get, set
                abstract offset: float option with get, set
                abstract radius: float option with get, set

            type [<AllowNullLiteral>] RadarSearchRequest =
                abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> option with get, set
                abstract keyword: string option with get, set
                abstract location: U2<LatLng, LatLngLiteral> option with get, set
                abstract name: string option with get, set
                abstract radius: float option with get, set
                abstract types: ResizeArray<string> option with get, set
                abstract ``type``: string option with get, set

            type RankBy =
                obj

            type [<AllowNullLiteral>] SearchBox =
                inherit MVCObject
                abstract getBounds: unit -> LatLngBounds
                abstract getPlaces: unit -> ResizeArray<PlaceResult>
                abstract setBounds: bounds: U2<LatLngBounds, LatLngBoundsLiteral> -> unit

            type [<AllowNullLiteral>] SearchBoxStatic =
                [<Emit "new $0($1...)">] abstract Create: inputField: HTMLInputElement * ?opts: SearchBoxOptions -> SearchBox

            type [<AllowNullLiteral>] SearchBoxOptions =
                abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> with get, set

            type [<AllowNullLiteral>] TextSearchRequest =
                abstract bounds: U2<LatLngBounds, LatLngBoundsLiteral> option with get, set
                abstract location: U2<LatLng, LatLngLiteral> option with get, set
                abstract query: string with get, set
                abstract radius: float option with get, set
                abstract types: ResizeArray<string> option with get, set
                abstract ``type``: string option with get, set

            type [<AllowNullLiteral>] FindPlaceFromQueryRequest =
                abstract fields: ResizeArray<string> with get, set
                abstract locationBias: LocationBias option with get, set
                abstract query: string with get, set

            type [<AllowNullLiteral>] FindPlaceFromPhoneNumberRequest =
                abstract fields: ResizeArray<string> with get, set
                abstract locationBias: LocationBias option with get, set
                abstract query: string with get, set

        module Drawing =

            type [<AllowNullLiteral>] IExports =
                abstract DrawingManager: DrawingManagerStatic

            type [<AllowNullLiteral>] DrawingManager =
                inherit MVCObject
                abstract getDrawingMode: unit -> OverlayType
                abstract getMap: unit -> Map
                abstract setDrawingMode: drawingMode: OverlayType option -> unit
                abstract setMap: map: Map option -> unit
                abstract setOptions: options: DrawingManagerOptions -> unit

            type [<AllowNullLiteral>] DrawingManagerStatic =
                [<Emit "new $0($1...)">] abstract Create: ?options: DrawingManagerOptions -> DrawingManager

            /// Options for the drawing manager. 
            type [<AllowNullLiteral>] DrawingManagerOptions =
                /// Options to apply to any new circles created with this DrawingManager.
                /// The center and radius properties are ignored, and the map property of a
                /// new circle is always set to the DrawingManager's map.
                abstract circleOptions: CircleOptions option with get, set
                /// The enabled/disabled state of the drawing control. Defaults to true.
                abstract drawingControl: bool option with get, set
                /// The display options for the drawing control. 
                abstract drawingControlOptions: DrawingControlOptions option with get, set
                /// The DrawingManager's drawing mode, which defines the type of overlay to
                /// be added on the map. Accepted values are 'marker', 'polygon',
                /// 'polyline', 'rectangle', 'circle', or null. A drawing mode of null
                /// means that the user can interact with the map as normal, and clicks do
                /// not draw anything.
                abstract drawingMode: OverlayType option with get, set
                /// The Map to which the DrawingManager is attached, which is the Map on
                /// which the overlays created will be placed.
                abstract map: Map option with get, set
                /// Options to apply to any new markers created with this DrawingManager.
                /// The position property is ignored, and the map property of a new marker
                /// is always set to the DrawingManager's map.
                abstract markerOptions: MarkerOptions option with get, set
                /// Options to apply to any new polygons created with this DrawingManager.
                /// The paths property is ignored, and the map property of a new polygon is
                /// always set to the DrawingManager's map.
                abstract polygonOptions: PolygonOptions option with get, set
                /// Options to apply to any new polylines created with this DrawingManager.
                /// The path property is ignored, and the map property of a new polyline is
                /// always set to the DrawingManager's map.
                abstract polylineOptions: PolylineOptions option with get, set
                /// Options to apply to any new rectangles created with this
                /// DrawingManager. The bounds property is ignored, and the map property of
                /// a new rectangle is always set to the DrawingManager's map.
                abstract rectangleOptions: RectangleOptions option with get, set

            type [<AllowNullLiteral>] DrawingControlOptions =
                abstract drawingModes: ResizeArray<OverlayType> option with get, set
                abstract position: ControlPosition option with get, set

            /// The properties of an overlaycomplete event on a DrawingManager.. 
            type [<AllowNullLiteral>] OverlayCompleteEvent =
                /// The completed overlay. 
                abstract overlay: U5<Marker, Polygon, Polyline, Rectangle, Circle> with get, set
                /// The completed overlay's type. 
                abstract ``type``: OverlayType with get, set

            type OverlayType =
                obj

        module Visualization =

            type [<AllowNullLiteral>] IExports =
                abstract MapsEngineLayer: MapsEngineLayerStatic
                abstract HeatmapLayer: HeatmapLayerStatic
                abstract MouseEvent: MouseEventStatic
                abstract MapsEventListener: MapsEventListenerStatic

            type [<AllowNullLiteral>] MapsEngineLayer =
                inherit MVCObject
                abstract getLayerId: unit -> string
                abstract getLayerKey: unit -> string
                abstract getMap: unit -> Map
                abstract getMapId: unit -> string
                abstract getOpacity: unit -> float
                abstract getProperties: unit -> MapsEngineLayerProperties
                abstract getStatus: unit -> MapsEngineStatus
                abstract getZIndex: unit -> float
                abstract setLayerId: layerId: string -> unit
                abstract setLayerKey: layerKey: string -> unit
                abstract setMap: map: Map option -> unit
                abstract setMapId: mapId: string -> unit
                abstract setOpacity: opacity: float -> unit
                abstract setOptions: options: MapsEngineLayerOptions -> unit
                abstract setZIndex: zIndex: float -> unit

            type [<AllowNullLiteral>] MapsEngineLayerStatic =
                [<Emit "new $0($1...)">] abstract Create: options: MapsEngineLayerOptions -> MapsEngineLayer

            type [<AllowNullLiteral>] MapsEngineLayerOptions =
                abstract accessToken: string option with get, set
                abstract clickable: bool option with get, set
                abstract fitBounds: bool option with get, set
                abstract layerId: string option with get, set
                abstract layerKey: string option with get, set
                abstract map: Map option with get, set
                abstract mapId: string option with get, set
                abstract opacity: float option with get, set
                abstract suppressInfoWindows: bool option with get, set
                abstract zIndex: float option with get, set

            type [<AllowNullLiteral>] MapsEngineLayerProperties =
                abstract name: string with get, set

            type [<AllowNullLiteral>] MapsEngineMouseEvent =
                abstract featureId: string option with get, set
                abstract infoWindowHtml: string option with get, set
                abstract latLng: LatLng option with get, set
                abstract pixelOffset: Size option with get, set

            type MapsEngineStatus =
                obj

            type [<AllowNullLiteral>] HeatmapLayer =
                inherit MVCObject
                abstract getData: unit -> MVCArray<'T>
                abstract getMap: unit -> Map
                abstract setData: data: U3<MVCArray<U2<LatLng, WeightedLocation>>, ResizeArray<LatLng>, ResizeArray<WeightedLocation>> -> unit
                abstract setMap: map: Map option -> unit

            type [<AllowNullLiteral>] HeatmapLayerStatic =
                [<Emit "new $0($1...)">] abstract Create: ?opts: HeatmapLayerOptions -> HeatmapLayer

            type [<AllowNullLiteral>] HeatmapLayerOptions =
                abstract data: obj option with get, set
                abstract dissipating: bool option with get, set
                abstract gradient: ResizeArray<string> option with get, set
                abstract map: Map option with get, set
                abstract maxIntensity: float option with get, set
                abstract opacity: float option with get, set
                abstract radius: float option with get, set

            type [<AllowNullLiteral>] WeightedLocation =
                abstract location: LatLng with get, set
                abstract weight: float with get, set

            type [<AllowNullLiteral>] MouseEvent =
                abstract stop: unit -> unit

            type [<AllowNullLiteral>] MouseEventStatic =
                [<Emit "new $0($1...)">] abstract Create: unit -> MouseEvent

            type [<AllowNullLiteral>] MapsEventListener =
                interface end

            type [<AllowNullLiteral>] MapsEventListenerStatic =
                [<Emit "new $0($1...)">] abstract Create: unit -> MapsEventListener