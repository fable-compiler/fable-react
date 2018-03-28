// ts2fable 0.5.2
module rec ReactLeaflet

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.React
open Fable.Helpers.React

[<RequireQualifiedAccess>]
type GridLayerProps =
    | TileSize of U2<float, Leaflet.Point>
    | Opacity of float
    | UpdateWhenIdle of bool
    | UpdateWhenZooming of bool
    | UpdateInterval of float
    | Attribution of string
    | ZIndex of float
    | Bounds of Leaflet.LatLngBoundsExpression
    | MinZoom of float
    | MaxZoom of float
    | NoWrap of bool
    | Pane of string
    | ClassName of string
    | KeepBuffer of float
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): GridLayerProps = unbox(key, value)

[<RequireQualifiedAccess>]
type TileLayerProps =
    | TileSize of U2<float, Leaflet.Point>
    | Opacity of float
    | UpdateWhenIdle of bool
    | UpdateWhenZooming of bool
    | UpdateInterval of float
    | Attribution of string
    | ZIndex of float
    | Bounds of Leaflet.LatLngBoundsExpression
    | NoWrap of bool
    | Pane of string
    | ClassName of string
    | KeepBuffer of float
    | MinZoom of float
    | MaxZoom of float
    | MaxNativeZoom of float
    | MinNativeZoom of float
    | Subdomains of U2<string, ResizeArray<string>>
    | ErrorTileUrl of string
    | ZoomOffset of float
    | Tms of bool
    | ZoomReverse of bool
    | DetectRetina of bool
    | CrossOrigin of bool
    | Url of string
    | OnLoading of (Leaflet.LeafletEvent -> unit)
    | OnLoad of (Leaflet.LeafletEvent -> unit)
    | OnTileLoadstart of (Leaflet.TileEvent -> unit)
    | OnTileLoad of (Leaflet.TileEvent -> unit)
    | OnTileUnload of (Leaflet.TileEvent -> unit)
    | OnTileError of (Leaflet.TileEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): TileLayerProps = unbox(key, value)

[<RequireQualifiedAccess>]
type WMSTileLayerProps =
    | TileSize of U2<float, Leaflet.Point>
    | Opacity of float
    | UpdateWhenIdle of bool
    | UpdateWhenZooming of bool
    | UpdateInterval of float
    | Attribution of string
    | ZIndex of float
    | Bounds of Leaflet.LatLngBoundsExpression
    | NoWrap of bool
    | Pane of string
    | ClassName of string
    | KeepBuffer of float
    | MinZoom of float
    | MaxZoom of float
    | MaxNativeZoom of float
    | MinNativeZoom of float
    | Subdomains of U2<string, ResizeArray<string>>
    | ErrorTileUrl of string
    | ZoomOffset of float
    | Tms of bool
    | ZoomReverse of bool
    | DetectRetina of bool
    | CrossOrigin of bool
    | Url of string
    | Layers of string
    | Styles of string
    | Format of string
    | Transparent of bool
    | Version of string
    | Crs of Leaflet.CRS
    | Uppercase of bool
    | OnLoading of (Leaflet.LeafletEvent -> unit)
    | OnLoad of (Leaflet.LeafletEvent -> unit)
    | OnTileLoadstart of (Leaflet.TileEvent -> unit)
    | OnTileLoad of (Leaflet.TileEvent -> unit)
    | OnTileUnload of (Leaflet.TileEvent -> unit)
    | OnTileError of (Leaflet.TileEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): WMSTileLayerProps = unbox(key, value)

[<RequireQualifiedAccess>]
type ImageOverlayProps =
    | Pane of string
    | Opacity of float
    | Alt of string
    | Interactive of bool
    | Attribution of string
    | CrossOrigin of bool
    | Url of string
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): ImageOverlayProps = unbox(key, value)

[<StringEnum>]
[<RequireQualifiedAccess>]
type LineCapShape =
    | Butt
    | Round
    | Square
    | Inherit

[<StringEnum>]
[<RequireQualifiedAccess>]
type LineJoinShape =
    | Miter
    | Round
    | Bevel
    | Inherit

[<StringEnum>]
[<RequireQualifiedAccess>]
type FillRule =
    | Nonzero
    | Evenodd
    | Inherit

[<RequireQualifiedAccess>]
type PathProps =
    | Pane of string
    | Attribution of string
    | Interactive of bool
    | Stroke of bool
    | Color of string
    | Weight of float
    | Opacity of float
    | LineCap of LineCapShape
    | LineJoin of LineJoinShape
    | DashArray of string
    | DashOffset of string
    | Fill of bool
    | FillColor of string
    | FillOpacity of float
    | FillRule of FillRule
    | Renderer of Leaflet.Renderer
    | ClassName of string
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseDown of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnAdd of (Leaflet.LeafletEvent -> unit)
    | OnRemove of (Leaflet.LeafletEvent -> unit)
    | OnPopupOpen of (Leaflet.PopupEvent -> unit)
    | OnPopupClose of (Leaflet.PopupEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): PathProps = unbox(key, value)

[<RequireQualifiedAccess>]
type PolylineProps =
    | Pane of string
    | Attribution of string
    | Interactive of bool
    | Stroke of bool
    | Color of string
    | Weight of float
    | Opacity of float
    | LineCap of LineCapShape
    | LineJoin of LineJoinShape
    | DashArray of string
    | DashOffset of string
    | Fill of bool
    | FillColor of string
    | FillOpacity of float
    | FillRule of FillRule
    | Renderer of Leaflet.Renderer
    | ClassName of string
    | SmoothFactor of float
    | NoClip of bool
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseDown of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnAdd of (Leaflet.LeafletEvent -> unit)
    | OnRemove of (Leaflet.LeafletEvent -> unit)
    | OnPopupOpen of (Leaflet.PopupEvent -> unit)
    | OnPopupClose of (Leaflet.PopupEvent -> unit)
    | Positions of U3<Leaflet.LatLngExpression [], Leaflet.LatLngExpression [][], Leaflet.LatLngExpression [][][]>
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): PolylineProps = unbox(key, value)

[<RequireQualifiedAccess>]
type PolygonProps =
    | SmoothFactor of float
    | NoClip of bool
    | Pane of string
    | Attribution of string
    | Interactive of bool
    | Stroke of bool
    | Color of string
    | Weight of float
    | Opacity of float
    | LineCap of LineCapShape
    | LineJoin of LineJoinShape
    | DashArray of string
    | DashOffset of string
    | Fill of bool
    | FillColor of string
    | FillOpacity of float
    | FillRule of FillRule
    | Renderer of Leaflet.Renderer
    | ClassName of string
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseDown of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnAdd of (Leaflet.LeafletEvent -> unit)
    | OnRemove of (Leaflet.LeafletEvent -> unit)
    | OnPopupOpen of (Leaflet.PopupEvent -> unit)
    | OnPopupClose of (Leaflet.PopupEvent -> unit)
    | Positions of U3<Leaflet.LatLngExpression [], Leaflet.LatLngExpression [][], Leaflet.LatLngExpression [][][]>
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): PolygonProps = unbox(key, value)

[<RequireQualifiedAccess>]
type CircleMarkerProps =
    | Pane of string
    | Attribution of string
    | Interactive of bool
    | Stroke of bool
    | Color of string
    | Weight of float
    | Opacity of float
    | LineCap of LineCapShape
    | LineJoin of LineJoinShape
    | DashArray of string
    | DashOffset of string
    | Fill of bool
    | FillColor of string
    | FillOpacity of float
    | FillRule of FillRule
    | Renderer of Leaflet.Renderer
    | ClassName of string
    | Radius of float
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseDown of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnAdd of (Leaflet.LeafletEvent -> unit)
    | OnRemove of (Leaflet.LeafletEvent -> unit)
    | OnPopupOpen of (Leaflet.PopupEvent -> unit)
    | OnPopupClose of (Leaflet.PopupEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): CircleMarkerProps = unbox(key, value)

[<RequireQualifiedAccess>]
type CircleProps =
    | Pane of string
    | Attribution of string
    | Interactive of bool
    | Stroke of bool
    | Color of string
    | Weight of float
    | Opacity of float
    | LineCap of LineCapShape
    | LineJoin of LineJoinShape
    | DashArray of string
    | DashOffset of string
    | Fill of bool
    | FillColor of string
    | FillOpacity of float
    | FillRule of FillRule
    | Renderer of Leaflet.Renderer
    | ClassName of string
    | Radius of float
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseDown of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnAdd of (Leaflet.LeafletEvent -> unit)
    | OnRemove of (Leaflet.LeafletEvent -> unit)
    | OnPopupOpen of (Leaflet.PopupEvent -> unit)
    | OnPopupClose of (Leaflet.PopupEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): CircleProps = unbox(key, value)

[<RequireQualifiedAccess>]
type GeoJSONProps =
    | Pane of string
    | Attribution of string
    | Data of Geojson.GeoJsonObject
    /// A Function defining how GeoJSON points spawn Leaflet layers.
    /// It is internally called when data is added, passing the GeoJSON point
    /// feature and its LatLng.
    ///
    /// The default is to spawn a default Marker:
    ///
    /// ```
    /// function(geoJsonPoint, latlng) {
    ///      return L.marker(latlng);
    /// }
    /// ```
    | PointToLayer of ((Geojson.Feature<Geojson.Point, obj> * Leaflet.LatLng) -> Leaflet.Layer)

    /// A Function defining the Path options for styling GeoJSON lines and polygons,
    /// called internally when data is added.
    ///
    /// The default value is to not override any defaults:
    ///
    /// ```
    /// function (geoJsonFeature) {
    ///      return {}
    /// }
    /// ```
    | Style of Leaflet.StyleFunction<obj>
    /// A Function that will be called once for each created Feature, after it
    /// has been created and styled. Useful for attaching events and popups to features.
    ///
    /// The default is to do nothing with the newly created layers:
    ///
    /// ```
    /// function (feature, layer) {}
    /// ```
    | OnEachFeature of ((Geojson.Feature<Geojson.GeometryObject, obj> * Leaflet.Layer) -> unit)
    /// A Function that will be used to decide whether to show a feature or not.
    ///
    /// The default is to show all features:
    ///
    /// ```
    /// function (geoJsonFeature) {
    ///      return true;
    /// }
    /// ```
    | Filter of (Geojson.Feature<Geojson.GeometryObject, obj> -> bool)
    /// A Function that will be used for converting GeoJSON coordinates to LatLngs.
    /// The default is the coordsToLatLng static method.
    | CoordsToLatLng of (U2<float * float, float * float * float> -> Leaflet.LatLng)
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnLayerAdd of (Leaflet.LayerEvent -> unit)
    | OnLayerRemove of (Leaflet.LayerEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): GeoJSONProps = unbox(key, value)

[<RequireQualifiedAccess>]
type MapProps =
    | PreferCanvas of bool
    | AttributionControl of bool
    | ZoomControl of bool
    | ClosePopupOnClick of bool
    | ZoomSnap of float
    | ZoomDelta of float
    | TrackResize of bool
    | BoxZoom of bool
    | DoubleClickZoom of Leaflet.Zoom
    | Dragging of bool
    | Crs of Leaflet.CRS
    | Layers of ResizeArray<Leaflet.Layer>
    | Renderer of Leaflet.Renderer
    | FadeAnimation of bool
    | MarkerZoomAnimation of bool
    | Transform3DLimit of float
    | ZoomAnimation of bool
    | ZoomAnimationThreshold of float
    | Inertia of bool
    | InertiaDeceleration of float
    | InertiaMaxSpeed of float
    | EaseLinearity of float
    | WorldCopyJump of bool
    | MaxBoundsViscosity of float
    | Keyboard of bool
    | KeyboardPanDelta of float
    | ScrollWheelZoom of Leaflet.Zoom
    | WheelDebounceTime of float
    | WheelPxPerZoomLevel of float
    | Tap of bool
    | TapTolerance of float
    | TouchZoom of Leaflet.Zoom
    | BounceAtZoomLimits of bool
    | Animate of bool
    | Bounds of Leaflet.LatLngBoundsExpression
    | BoundsOptions of Leaflet.FitBoundsOptions
    | Center of Leaflet.LatLngExpression
    | ClassName of string
    | Id of string
    | MaxBounds of Leaflet.LatLngBoundsExpression
    | MinZoom of float
    | UseFlyTo of bool
    | Zoom of float
    | Watch of bool
    | SetView of bool
    | MaxZoom of float
    | Timeout of float
    | MaximumAge of float
    | EnableHighAccuracy of bool
    | Duration of float
    | NoMoveStart of bool
    | PaddingTopLeft of Leaflet.PointExpression
    | PaddingBottomRight of Leaflet.PointExpression
    | Padding of Leaflet.PointExpression
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseDown of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseUp of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseMove of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnFocus of (Leaflet.LeafletEvent -> unit)
    | OnBlur of (Leaflet.LeafletEvent -> unit)
    | OnPreClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnLoad of (Leaflet.LeafletEvent -> unit)
    | OnUnload of (Leaflet.LeafletEvent -> unit)
    | OnViewReset of (Leaflet.LeafletEvent -> unit)
    | OnMove of (Leaflet.LeafletEvent -> unit)
    | OnMoveStart of (Leaflet.LeafletEvent -> unit)
    | OnMoveEnd of (Leaflet.LeafletEvent -> unit)
    | OnDragStart of (Leaflet.LeafletEvent -> unit)
    | OnDrag of (Leaflet.LeafletEvent -> unit)
    | OnDragEnd of (Leaflet.DragEndEvent -> unit)
    | OnZoomStart of (Leaflet.LeafletEvent -> unit)
    | OnZoomEnd of (Leaflet.LeafletEvent -> unit)
    | OnZoomLevelsChange of (Leaflet.LeafletEvent -> unit)
    | OnResize of (Leaflet.ResizeEvent -> unit)
    | OnAutopaSstart of (Leaflet.LeafletEvent -> unit)
    | OnLayerAdd of (Leaflet.LayerEvent -> unit)
    | OnLayerRemove of (Leaflet.LayerEvent -> unit)
    | OnBaseLayerChange of (Leaflet.LayersControlEvent -> unit)
    | OnOverLayerAdd of (Leaflet.LayersControlEvent -> unit)
    | OnOverLayerRemove of (Leaflet.LayersControlEvent -> unit)
    | OnLocationFound of (Leaflet.LocationEvent -> unit)
    | OnLocationError of (Leaflet.ErrorEvent -> unit)
    | OnPopupOpen of (Leaflet.PopupEvent -> unit)
    | OnPopupClose of (Leaflet.PopupEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom (key: string, value: obj): MapProps = unbox(key, value)
    static member Style (css: Fable.Helpers.React.Props.CSSProp list) : MapProps = unbox ("style", keyValueList CaseRules.LowerFirst css)

[<StringEnum>]
[<RequireQualifiedAccess>]
type ControlPosition =
    | Topleft
    | Topright
    | Bottomleft
    | Bottomright

[<RequireQualifiedAccess>]
type MapControlProps =
    | Position of ControlPosition
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): MapControlProps = unbox(key, value)

[<RequireQualifiedAccess>]
type ZoomProps =
    | Position of ControlPosition
    | ZoomInText of string
    | ZoomInTitle of string
    | ZoomOutText of string
    | ZoomOutTitle of string
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): ZoomProps = unbox(key, value)

[<RequireQualifiedAccess>]
type PopupProps =
    | Offset of Leaflet.PointExpression
    | ZoomAnimation of bool
    | ClassName of string
    | Pane of string
    | MaxWidth of float
    | MinWidth of float
    | MaxHeight of float
    | AutoPan of bool
    | AutoPanPaddingTopLeft of Leaflet.PointExpression
    | AutoPanPaddingBottomRight of Leaflet.PointExpression
    | AutoPanPadding of Leaflet.PointExpression
    | KeepInView of bool
    | CloseButton of bool
    | AutoClose of bool
    | CloseOnClick of bool
    | OnClose of (Leaflet.Popup -> unit)
    | OnOpen of (Leaflet.Popup -> unit)
    | Position of Leaflet.LatLngBoundsExpression
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): PopupProps = unbox(key, value)

[<StringEnum>]
[<RequireQualifiedAccess>]
type Direction =
    | Right
    | Left
    | Top
    | Bottom
    | Center
    | Auto

[<RequireQualifiedAccess>]
type TooltipProps =
    | ZoomAnimation of bool
    | ClassName of string
    | Pane of string
    | Offset of Leaflet.PointExpression
    | Direction of Direction
    | Permanent of bool
    | Sticky of bool
    | Interactive of bool
    | Opacity of float
    | OnClose of (Leaflet.Tooltip -> unit)
    | OnOpen of (Leaflet.Tooltip -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): TooltipProps = unbox(key, value)

[<RequireQualifiedAccess>]
type MarkerProps =
    | Pane of string
    | Attribution of string
    | Interactive of bool
    | Icon of U2<Leaflet.Icon<obj>, Leaflet.DivIcon>
    | Clickable of bool
    | Draggable of bool
    | Keyboard of bool
    | Title of string
    | Alt of string
    | ZIndexOffset of float
    | Opacity of float
    | RiseOnHover of bool
    | RiseOffset of float
    | Position of Leaflet.LatLngExpression
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseDown of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnDragStart of (Leaflet.LeafletEvent -> unit)
    | OnDrag of (Leaflet.LeafletEvent -> unit)
    | OnDragEnd of (Leaflet.DragEndEvent -> unit)
    | OnMove of (Leaflet.LeafletEvent -> unit)
    | OnAdd of (Leaflet.LeafletEvent -> unit)
    | OnRemove of (Leaflet.LeafletEvent -> unit)
    | OnPopupOpen of (Leaflet.PopupEvent -> unit)
    | OnPopupClose of (Leaflet.PopupEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): MarkerProps = unbox(key, value)

[<RequireQualifiedAccess>]
type RectangleProps =
    | Bounds of Leaflet.LatLngBoundsExpression
    | Pane of string
    | Attribution of string
    | Interactive of bool
    | Stroke of bool
    | Color of string
    | Weight of float
    | Opacity of float
    | LineCap of LineCapShape
    | LineJoin of LineJoinShape
    | DashArray of string
    | DashOffset of string
    | Fill of bool
    | FillColor of string
    | FillOpacity of float
    | FillRule of FillRule
    | Renderer of Leaflet.Renderer
    | ClassName of string
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseDown of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnAdd of (Leaflet.LeafletEvent -> unit)
    | OnRemove of (Leaflet.LeafletEvent -> unit)
    | OnPopupOpen of (Leaflet.PopupEvent -> unit)
    | OnPopupClose of (Leaflet.PopupEvent -> unit)
    | PopupContainer of Leaflet.FeatureGroup<obj>
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): RectangleProps = unbox(key, value)

[<RequireQualifiedAccess>]
type AttributionControlProps =
    | Prefix of U2<string, bool>
    | Position of ControlPosition
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): AttributionControlProps = unbox(key, value)

[<RequireQualifiedAccess>]
type LayersControlProps =
    | BaseLayers of Leaflet.Control.LayersObject
    | Overlays of Leaflet.Control.LayersObject
    | OnBaseLayerChange of (Leaflet.LayersControlEvent -> unit)
    | OnOverLayerAdd of (Leaflet.LayersControlEvent -> unit)
    | OnOverLayerRmove of (Leaflet.LayersControlEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): LayersControlProps = unbox(key, value)

[<RequireQualifiedAccess>]
type ScaleControlProps =
    | MaxWidth of float
    | Metric of bool
    | Imperial of bool
    | UpdateWhenIdle of bool
    | Position of ControlPosition
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): ScaleControlProps = unbox(key, value)

[<RequireQualifiedAccess>]
type ZoomControlProps =
    | ZoomInText of string
    | ZoomInTitle of string
    | ZoomOutText of string
    | ZoomOutTitle of string
    | Position of ControlPosition
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): ZoomControlProps = unbox(key, value)

[<RequireQualifiedAccess>]
type PaneProps =
    | Name of string
    | Map of Leaflet.Map
    | ClassName of string
    | Pane of string
    | Ref of (obj -> unit)
    | Key of string
    static member Style (css: Fable.Helpers.React.Props.CSSProp list) : MapProps = unbox ("style", keyValueList CaseRules.LowerFirst css)
    static member Custom(key: string, value: obj): PaneProps = unbox(key, value)

[<RequireQualifiedAccess>]
type MapLayerProps =
    | Pane of string
    | Attribution of string
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): MapLayerProps = unbox(key, value)

[<RequireQualifiedAccess>]
type LayerGroupProps =
    | Pane of string
    | Attribution of string
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): LayerGroupProps = unbox(key, value)

[<RequireQualifiedAccess>]
type FeatureGroupProps =
    | Pane of string
    | Attribution of string
    | Interactive of bool
    | Stroke of bool
    | Color of string
    | Weight of float
    | Opacity of float
    | LineCap of LineCapShape
    | LineJoin of LineJoinShape
    | DashArray of string
    | DashOffset of string
    | Fill of bool
    | FillColor of string
    | FillOpacity of float
    | FillRule of FillRule
    | Renderer of Leaflet.Renderer
    | ClassName of string
    | OnClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnDblClick of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOver of (Leaflet.LeafletMouseEvent -> unit)
    | OnMouseOut of (Leaflet.LeafletMouseEvent -> unit)
    | OnContextMenu of (Leaflet.LeafletMouseEvent -> unit)
    | OnLayerAdd of (Leaflet.LayerEvent -> unit)
    | OnLayerRemove of (Leaflet.LayerEvent -> unit)
    | Ref of (obj -> unit)
    | Key of string
    static member Custom(key: string, value: obj): FeatureGroupProps = unbox(key, value)

let inline mapComponent (props: MapProps list) (children : ReactElement list) : ReactElement =
    ofImport "MapComponent" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline map (props: MapProps list) (children : ReactElement list) : ReactElement =
    ofImport "Map" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline pane (props: PaneProps list) (children : ReactElement list) : ReactElement =
    ofImport "Pane" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline mapLayer (props: MapLayerProps list) (children : ReactElement list) : ReactElement =
    ofImport "MapLayer" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline gridLayer (props: GridLayerProps list) (children : ReactElement list) : ReactElement =
    ofImport "GridLayer" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline tileLayer (props: TileLayerProps list) (children : ReactElement list) : ReactElement =
    ofImport "TileLayer" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline wMSTileLayer (props: WMSTileLayerProps list) (children : ReactElement list) : ReactElement =
    ofImport "WMSTileLayer" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline imageOverlay (props: ImageOverlayProps list) (children : ReactElement list) : ReactElement =
    ofImport "ImageOverlay" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline layerGroup (props: LayerGroupProps list) (children : ReactElement list) : ReactElement =
    ofImport "LayerGroup" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline marker (props: MarkerProps list) (children : ReactElement list) : ReactElement =
    ofImport "Marker" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline path (props: PathProps list) (children : ReactElement list) : ReactElement =
    ofImport "Path" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline circle (props: CircleProps list) (children : ReactElement list) : ReactElement =
    ofImport "Circle" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline circleMarker (props: CircleMarkerProps list) (children : ReactElement list) : ReactElement =
    ofImport "CircleMarker" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline featureGroup (props: FeatureGroupProps list) (children : ReactElement list) : ReactElement =
    ofImport "FeatureGroup" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline geoJSON (props: GeoJSONProps list) (children : ReactElement list) : ReactElement =
    ofImport "GeoJSON" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline polyline (props: PolylineProps list) (children : ReactElement list) : ReactElement =
    ofImport "Polyline" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline polygon (props: PolygonProps list) (children : ReactElement list) : ReactElement =
    ofImport "Polygon" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline rectangle (props: RectangleProps list) (children : ReactElement list) : ReactElement =
    ofImport "Rectangle" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline popup (props: PopupProps list) (children : ReactElement list) : ReactElement =
    ofImport "Popup" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline tooltip (props: TooltipProps list) (children : ReactElement list) : ReactElement =
    ofImport "Tooltip" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline mapControl (props: MapControlProps list) (children : ReactElement list) : ReactElement =
    ofImport "MapControl" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline attributionControl (props: AttributionControlProps list) (children : ReactElement list) : ReactElement =
    ofImport "AttributionControl" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline layersControl (props: LayersControlProps list) (children : ReactElement list) : ReactElement =
    ofImport "LayersControl" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline scaleControl (props: ScaleControlProps list) (children : ReactElement list) : ReactElement =
    ofImport "ScaleControl" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children

let inline zoomControl (props: ZoomControlProps list) (children : ReactElement list) : ReactElement =
    ofImport "ZoomControl" "react-leaflet" (keyValueList CaseRules.LowerFirst props) children
