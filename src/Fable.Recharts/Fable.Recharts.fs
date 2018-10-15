module Fable.Recharts

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop

module Props =

    type [<StringEnum>] Layout =
        | Horizontal
        | Vertical

    type [<StringEnum>] StackOffset =
        | Expand
        | Wiggle
        | Silhouette
        | Sign
        | [<CompiledName("none")>] NoStackOffset

    type [<StringEnum>] BaseValue =
        | DataMin
        | DataMax
        | Auto

    type [<StringEnum>] InterpolationType =
        | Basis
        | BasisClosed
        | BasisOpen
        | Linear
        | LinearClosed
        | Natural
        | MonotoneX
        | MonotoneY
        | Monotone
        | Step
        | StepBefore
        | StepAfter
        //| Function

    type [<StringEnum>] ShapeType =
        | Line
        | Square
        | Rect
        | Circle
        | Cross
        | Diamond
        | Star
        | Triangle
        | Wye
        | [<CompiledName("none")>] NoLegend

    type [<StringEnum>] LineType =
        | Joint
        | Fitting

    type [<StringEnum>] ScaleType =
        | Auto
        | Linear
        | Pow
        | Sqrt
        | Log
        | Identity
        | Time
        | Band
        | Point
        | Ordinal
        | Quantile
        | Quantize
        | UtcTime
        | Sequential
        | Threshold

    type [<StringEnum>] Easing =
        | Ease
        | [<CompiledName("ease-in")>] EaseIn
        | [<CompiledName("ease-out")>] EaseOut
        | [<CompiledName("ease-in-out")>] EaseInOut
        | Linear

    type [<Pojo>] Point2 =
        { x: float; y: float }

    type [<Pojo>] Point3 =
        { x: float; y: float; z: float }

    type [<Pojo>] LinePoint =
        { x: float
          y: float
          value: float }

    type [<Pojo>] ScatterPoint =
        { cx: float
          cy: float
          r: float
          payload: Point3 }

    type [<Pojo>] Margin =
        { top: float
          bottom: float
          right: float
          left: float }

    type [<Pojo>] ViewBox =
        { x: float
          y: float
          width: float
          height: float }

    type [<RequireQualifiedAccess>] Chart =
        /// If any two categorical charts(LineChart, AreaChart, BarChart, ComposedChart) have the same syncId, these two charts can sync the position tooltip, and the startIndex, endIndex of Brush.
        | SyncId of string
        | Layout of Layout
        | Width of float
        | Height of float
        | Data of System.Array
        | Margin of Margin

        /// BarChart: The gap between two bar categories, which can be a percent value or a fixed value.
        | BarCategoryGap of obj
        /// BarChart: The gap between two bars, which can be a percent value or a fixed value.
        | BarGap of obj
        /// BarChart: The width or height of each bar. If the barSize is not specified, the size of the bar will be calculated by the barCategoryGap, barGap and the quantity of bar groups.
        | BarSize of float
        /// BarChart: The maximum width of all the bars in a horizontal BarChart, or maximum height in a vertical BarChart.
        | MaxBarSize of float
        /// BarChart: The type of offset function used to generate the lower and upper values in the series array. The four types are built-in offsets in d3-shape.
        | StackOffset of StackOffset

        /// AreaChart: The base value of area.
        | BaseValue of BaseValue
        /// AreaChart: Alternative to BaseValue using a float value.
        | [<CompiledName("baseValue")>] BaseValueNumber of float

        /// ComposedChart: If false set, stacked items will be rendered left to right. If true set, stacked items will be rendered right to left. (Render direction affects SVG layering, not x position.)
        | ReverseStackOrder of bool

        /// RadarChart: [Percentage (e.g. "50%") | Number] The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of width.
        | Cx of obj
        /// RadarChart: [Percentage (e.g. "50%") | Number] The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of height.
        | Cy of obj
        /// RadarChart: The angle of first radial direction line.
        | StartAngle of float
        /// RadarChart: The angle of last point in the circle which should be startAngle - 360 or startAngle + 360. We'll calculate the direction of chart by 'startAngle' and 'endAngle'.
        | EndAngle of float
        /// RadarChart: The inner radius of first circle grid. If set a percentage, the final value is obtained by multiplying the percentage of maxRadius which is calculated by the width, height, cx, cy.
        | InnerRadius of obj
        /// RadarChart: The outer radius of last circle grid. If set a percentage, the final value is obtained by multiplying the percentage of maxRadius which is calculated by the width, height, cx, cy.
        | OuterRadius of obj

        // Events
        | OnClick of (React.MouseEvent -> unit)
        | OnMouseDown of (React.MouseEvent -> unit)
        | OnMouseUp of (React.MouseEvent -> unit)
        | OnMouseMove of (React.MouseEvent -> unit)
        | OnMouseOver of (React.MouseEvent -> unit)
        | OnMouseEnter of (React.MouseEvent -> unit)
        | OnMouseLeave of (React.MouseEvent -> unit)

        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Chart = !!(key, value)

    type [<RequireQualifiedAccess>] Treemap =
        | Width of float
        | Height of float
        | Data of System.Array
        /// The key of a group of data which should be unique in a treemap.
        | DataKey of obj
        /// The treemap will try to keep every single rectangle's aspect ratio near the aspectRatio given.
        | AspectRatio of float
        /// If set false, animation of area will be disabled.
        | IsAnimationActive of bool
        /// Specifies when the animation should begin, the unit of this option is ms.
        | AnimationBegin of float
        /// Specifies the duration of animation, the unit of this option is ms.
        | AnimationDuration of float
        | AnimationEasing of Easing
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Treemap = !!(key, value)

    type [<RequireQualifiedAccess>] Responsive =
        /// width / height. If specified, the height will be calculated by width / aspect.
        | Aspect of float
        /// The percentage value of the chart's width or a fixed width.
        | Width of obj
        /// The percentage value of the chart's width or a fixed height.
        | Height of obj
        /// The minimum width of the container.
        | MinWidth of float
        /// The minimum height of the container.
        | MinHeight of float
        /// If specified a positive number, debounced function will be used to handle the resize event.
        | Debounce of float
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Responsive = !!(key, value)

    type [<RequireQualifiedAccess>] Legend =
        | Width of float
        | Height of float
        | Layout of Layout
        /// The alignment of legend items in 'horizontal' direction, which cen be 'left', 'center', 'right'.
        | Align of string
        /// The alignment of legend items in 'vertical' direction, which can be 'top', 'middle', 'bottom'.
        | VerticalAlign of string
        | IconSize of float
        | IconType of ShapeType
        /// The source data of the content to be displayed in the legend, usually calculated internally.
        /// FORMAT [{ value: 'item name', type: 'line', id: 'ID01' }]
        | PayLoad of System.Array
        /// The width of chart container, usually calculated internally.
        | ChartWidth of float
        /// The height of chart container, usually calculated internally.
        | ChartHeight of float
        /// The margin of chart container, usually calculated internally.
        | Margin of Margin
        /// If set to a React element, the option will be used to render the legend. If set to a function, the function will be called to render the legend's content.
        | Content of obj
        /// The style of legend container which is a "position: absolute;" div element. Because the position of legend is quite flexible, so you can change the position by the value of top, left, right, bottom in this option. And the format of wrapperStyle is the same as React inline style.
        | WrapperStyle of obj
        | OnClick of (React.MouseEvent -> unit)
        | OnMouseDown of (React.MouseEvent -> unit)
        | OnMouseUp of (React.MouseEvent -> unit)
        | OnMouseMove of (React.MouseEvent -> unit)
        | OnMouseOver of (React.MouseEvent -> unit)
        | OnMouseEnter of (React.MouseEvent -> unit)
        | OnMouseLeave of (React.MouseEvent -> unit)
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Legend = !!(key, value)

    type [<RequireQualifiedAccess>] Tooltip =
        /// The separator between name and value.
        | Separator of string
        /// The offset size between the position of tooltip and the active position.
        | Offset of float
        /// The style of default tooltip content item which is a li element.
        | ItemStyle of obj
        /// The style of tooltip wrapper which is a dom element.
        | WrapperStyle of obj
        /// The style of default tooltip label which is a p element.
        | LabelStyle of obj
        /// If set false, no cursor will be drawn when tooltip is active. If set a object, the option is the configuration of cursor. If set a React element, the option is the custom react element of drawing cursor.
        | Cursor of obj
        | ViewBox of ViewBox
        /// If set true, the tooltip is displayed. If set false, the tooltip is hidden, usually calculated internally.
        | Active of bool
        /// The coordinate of tooltip position, usually calculated internally.
        | Coordinate of Point2
        /// The source data of the content to be displayed in the tooltip, usually calculated internally.
        /// FORMAT: [{ name: '05-01', value: 12, unit: 'kg' }]
        | Payload of System.Array
        /// The label value which is active now, usually calculated internally.
        | Label of obj
        /// If set a React element, the option is the custom react element of rendering tooltip. If set a function, the function will be called to render tooltip content.
        | Content of obj
        /// The formatter function of value in tooltip.
        | Formatter of obj
        /// The formatter function of label in tooltip.
        | LabelFormatter of obj
        /// Sort function of payload
        /// DEFAULT: () => -1
        | ItemSorter of obj
        /// If set false, animation of area will be disabled.
        | IsAnimationActive of bool
        /// Specifies when the animation should begin, the unit of this option is ms.
        | AnimationBegin of float
        /// Specifies the duration of animation, the unit of this option is ms.
        | AnimationDuration of float
        | AnimationEasing of Easing
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Tooltip = !!(key, value)

    type [<RequireQualifiedAccess>] Cell =
        /// The presentation attribute of a rectangle in bar or a sector in pie.
        | Fill of string
        /// The presentation attribute of a rectangle in bar or a sector in pie.
        | Stroke of string
        static member inline Custom(key: string, value: obj): Cell = !!(key, value)

    type [<RequireQualifiedAccess>] Text =
        /// Scale the text to fit the width or not.
        | ScaleToFit of bool
        /// The rotate angle of Text.
        | Angle of float
        /// The width of Text. When the width is specified to be a number, the text will warp auto by calculating the width of text.
        | Width of float
        /// 'start' | 'middle' | 'end' | 'inherit'
        | TextAnchor of string
        /// 'start' | 'middle' | 'end'
        | VerticalAnchor of string
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Text = !!(key, value)

    type [<RequireQualifiedAccess>] Label =
        | ViewBox of ViewBox
        /// The formatter function of label value which has only one parameter - the value pf label.
        | Formatter of (obj->obj)
        /// The value of label, which can be specified by this props or the children of <Label />
        | Value of obj
        /// The position of label relative to the view box: "top" | "left" | "right" | "bottom" | "inside" | "outside" | "insideLeft" | "insideRight" | "insideTop" | "insideBottom" | "insideTopLeft" | "insideBottomLeft" | "insideTopRight" | "insideBottomRight" | "insideStart" | "insideEnd" | "end" | "center"
        | Position of string
        /// The offset to the specified "position"
        | Offset of float
        /// The value of label, which can be specified by this props or the props "value"
        | Children of obj
        /// If set a React element, the option is the custom react element of rendering label. If set a function, the function will be called to render label content.
        | Content of obj
        /// The unique id of this component, which will be used to generate unique clip path id internally. This props is suggested to be set in SSR.
        | Id of string
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Label = !!(key, value)

    type [<RequireQualifiedAccess>] LabelList =
        /// The key of a group of label values in data.
        | DataKey of obj
        /// The accessor function to get the value of each label.
        | ValueAccessor of obj
        /// If set a React element, the option is the customized react element of rendering each label. If set a function, the function will be called to render each label content.
        | Content of obj
        /// The position of each label relative to the view box: "top" | "left" | "right" | "bottom" | "inside" | "outside" | "insideLeft" | "insideRight" | "insideTop" | "insideBottom" | "insideTopLeft" | "insideBottomLeft" | "insideTopRight" | "insideBottomRight" | "insideStart" | "insideEnd" | "end" | "center"
        | Position of string
        /// The offset to the specified "position"
        | Offset of float
        /// The formatter function of label value which has only one parameter - the value pf label.
        | Formatter of (obj->obj)
        /// The data input to the charts.
        | Data of float
        /// The parameter to calculate the view box of label in radial charts.
        | ClockWise of string
        /// The unique id of this component, which will be used to generate unique clip path id internally. This props is suggested to be set in SSR.
        | Id of string
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): LabelList = !!(key, value)

    type [<RequireQualifiedAccess>] Cartesian =
        /// Area/Line: Use InterpolationType. Customized interpolation function can also be set to type.
        /// Axis: 'number' | 'category' (default 'category')
        | Type of obj
        | Data of System.Array
        /// The key of a group of data which should be unique.
        | DataKey of obj
        | LegendType of ShapeType
        /// If set to false, labels will not be drawn. If true set, labels will be drawn which have the props calculated internally. If object set, labels will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom label element. If set a function, the function will be called to render customized label.
        | Label of obj
        /// If "none", no stroke curve will be drawn.
        | Stroke of string
        | StrokeWidth of string
        /// The layout of line, usually inherited from parent.
        | Layout of Layout
        /// The value which can describe the line, usually calculated internally.
        | BaseLine of obj
        | Unit of string
        | Name of string
        /// The unique id of this component, which will be used to generate unique clip path id internally. This props is suggested to be set in SSR.
        | Id of string
        /// The stack id of bar/area, when two bars have the same value axis and same stackId, then the two bars are stacked in order.
        | StackId of obj

        /// If set false, animation of line will be disabled.
        | IsAnimationActive of bool
        /// Specifies when the animation should begin, the unit of this option is ms.
        | AnimationBegin of float
        /// Specifies the duration of animation, the unit of this option is ms.
        | AnimationDuration of float
        | AnimationEasing of Easing

        /// If false set, dots will not be drawn. If true set, dots will be drawn which have the props calculated internally. If object set, dots will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom dot element.If set a function, the function will be called to render customized dot.
        | Dot of obj
        /// The dot is shown when muser enter a line chart and this chart has tooltip. If false set, no active dot will not be drawn. If true set, active dot will be drawn which have the props calculated internally. If object set, active dot will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom active dot element.If set a function, the function will be called to render customized active dot.
        | ActiveDot of obj
        /// The coordinates of all the points in the line, usually calculated internally.
        /// FORMAT LinePoint: [{x: 12, y: 12, value: 240}]
        /// FORMAT ScatterPoint: [{ cx: 12, cy: 12, r: 4, payload: {x: 12, y: 45, z: 9 }}]
        | Points of System.Array
        /// Whether to connect a graph line across null points.
        | ConnectNulls of bool

        /// Bar: The width or height of each bar. If the barSize is not specified, the size of bar will be caculated by the barCategoryGap, barGap and the quantity of bar groups.
        | BarSize of float
        /// Bar: The maximum width of bar in a horizontal BarChart, or maximum height in a vertical BarChart.
        | MaxBarSize of float
        /// Bar: The minimal height of a bar in a horizontal BarChart, or the minimal width of a bar in a vertical BarChart. By default, 0 values are not shown. To visualize a 0 (or close to zero) point, set the minimal point size to a pixel value like 3. In stacked bar charts, minPointSize might not be respected for tightly packed values. So we strongly recommend not using this props in stacked BarChart.
        | MinPointSize of float
        /// Bar: If false set, background of bars will not be drawn. If true set, background of bars will be drawn which have the props calculated internally. If object set, background of bars will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom background element. If set a function, the function will be called to render customized background.
        | Background of obj
        /// Bar: If set a ReactElement, the shape of bar can be customized. If set a function, the function will be called to render customized shape.
        /// Scatter: ShapeType can be used as well.
        | Shape of obj

        /// Scatter: If false set, line will not be drawn. If true set, line will be drawn which have the props calculated internally. If object set, line will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom line element. If set a function, the function will be called to render Customized line.
        | Line of obj
        /// Scatter: If 'joint' set, line will generated by just jointing all the points. If 'fitting' set, line will be generated by fitting algorithm.
        | LineType of LineType

        // Axis

        /// If set true, the axis do not display in the chart.
        | Hide of bool
        | Width of float
        | Height of float
        | XAxisId of obj
        | YAxisId of obj
        | ZAxisId of obj
        /// DEFAULT: [10, 10]
        | Range of System.Array
        /// If set false, no axis line will be drawn. If set a object, the option is the configuration of axis line.
        | AxisLine of obj
        /// XAxis: 'bottom' , 'top'
        /// YAxis: 'left', 'right'
        | Orientation of string
        /// Allow the ticks of the axis to be decimals or not.
        | AllowDecimals of bool
        /// When domain of the axis is specified and the type of the axis is 'number', if allowDataOverflow is set to be false, the domain will be adjusted when the minimum value of data is smaller than domain[0] or the maximum value of data is greater than domain[1] so that the axis displays all data values. If set to true, graphic elements (line, area, bars) will be clipped to conform to the specified domain.
        | AllowDataOverflow of bool
        /// Allow the axis has duplicated categorys or not when the type of axis is "category".
        | AllowDuplicatedCategory of bool
        /// The minimum gap between two adjacent labels.
        /// DEFAULT: 5
        | MinTickGap of float
        /// The count of axis ticks.
        /// DEFAULT: 5
        | TickCount of float
        /// The lenght of tick line.
        /// DEFAULT: 6
        | TickSize of float
        /// If set false, no axis line will be drawn. If set a object, the option is the configuration of axis line.
        | TickLine of obj
        /// The margin between tick line and tick.
        | TickMargin of float
        /// The formatter function of tick.
        | TickFormatter of obj
        /// Set the values of axis ticks manually.
        | Ticks of System.Array
        /// If set false, no ticks will be drawn. If set a object, the option is the configuration of ticks. If set a React element, the option is the custom react element of drawing ticks.
        | Tick of obj
        /// Specify the domain of axis when the axis is a number axis. The length of domain should be 2, and we will validate the values in domain. And each element in the array can be a number, 'auto', 'dataMin', 'dataMax', a string like 'dataMin - 20', 'dataMax + 100', or a function that accepts a single argument and returns a number. If any element of domain is set to be 'auto', comprehensible scale ticks will be calculated, and the final domain of axis is generated by the ticks.
        /// DEFAULT: [0, 'auto']
        | Domain of System.Array
        /// If set 0, all the ticks will be shown. If set "preserveStart", "preserveEnd" or "preserveStartEnd", the ticks which is to be shown or hidden will be calculated automatically.
        | Interval of obj
        /// Specify the padding of axis.
        /// DEFAULT: { left: 0, right: 0 }
        | Padding of obj
        /// If set true, flips ticks around the axis line, displaying the labels inside the chart instead of outside.
        | Mirror of bool
        /// Reverse the ticks or not.
        | Reversed of bool
        /// If 'auto' set, the scale funtion is descided by the type of chart, and the props type.
        | Scale of ScaleType

        | X of float
        | Y of float
        /// ReferenceArea: A boundary value of the area. If the specified x-axis is a number axis, the type of x must be Number. If the specified x-axis is a category axis, the value of x must be one of the categorys. If one of x1 or x2 is invalidate, the area will cover along x-axis.
        | X1 of obj
        /// ReferenceArea: A boundary value of the area. If the specified x-axis is a number axis, the type of x must be Number. If the specified x-axis is a category axis, the value of x must be one of the categorys. If one of x1 or x2 is invalidate, the area will cover along x-axis.
        | X2 of obj
        /// ReferenceArea: A boundary value of the area. If the specified y-axis is a number axis, the type of y must be Number. If the specified y-axis is a category axis, the value of y must be one of the categorys. If one of y1 or y2 is invalidate, the area will cover along y-axis.
        | Y1 of obj
        /// ReferenceArea: A boundary value of the area. If the specified y-axis is a number axis, the type of y must be Number. If the specified y-axis is a category axis, the value of y must be one of the categorys. If one of y1 or y2 is invalidate, the area will cover along y-axis.
        | Y2 of obj
        | TravellerWidth of float
        | StartIndex of float
        | EndIndex of float
        | ViewBox of ViewBox

        /// If set false, no horizontal grid lines will be drawn.
        | Horizontal of bool
        /// If set false, no vertical grid lines will be drawn.
        | Vertical of bool
        /// The y-coordinates of all horizontal lines.
        | HorizontalPoints of System.Array
        /// The x-coordinates of all vertical lines.
        | VerticalPoints of System.Array

        /// The configuration of the corresponding x-axis, usually calculated internally.
        | XAxis of obj
        /// The configuration of the corresponding y-axis, usually calculated internally.
        | YAxis of obj
        /// If the corresponding axis is a number axis and this option is set true, the value of reference line will be take into account when calculate the domain of corresponding axis, so that the reference line will always show.
        | AlwaysShow of bool
        /// If set true, the line will be rendered in front of bars in BarChart, etc.
        | IsFront of bool

        /// ErrorBar: Only used for ScatterChart with error bars in two directions. Only accepts a value of "x" or "y" and makes the error bars lie in that direction.
        | Direction of string

        // Events
        /// Brush: The handler of changing the active scope of brush.
        | OnChange of (unit -> unit) // TODO: Check args
        | OnClick of (React.MouseEvent -> unit)
        | OnMouseDown of (React.MouseEvent -> unit)
        | OnMouseUp of (React.MouseEvent -> unit)
        | OnMouseOver of (React.MouseEvent -> unit)
        | OnMouseOut of (React.MouseEvent -> unit)
        | OnMouseEnter of (React.MouseEvent -> unit)
        | OnMouseMove of (React.MouseEvent -> unit)
        | OnMouseLeave of (React.MouseEvent -> unit)

        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Cartesian = !!(key, value)

    type [<RequireQualifiedAccess>] Polar =
        /// [Percentage (e.g. "50%") | Number] The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of width.
        | Cx of obj
        /// [Percentage (e.g. "50%") | Number] The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of height.
        | Cy of obj
        /// The inner radius of first circle grid. If set a percentage, the final value is obtained by multiplying the percentage of maxRadius which is calculated by the width, height, cx, cy.
        | InnerRadius of obj
        /// The outer radius of last circle grid. If set a percentage, the final value is obtained by multiplying the percentage of maxRadius which is calculated by the width, height, cx, cy.
        | OuterRadius of obj
        /// Pie: The start angle of first sector.
        | StartAngle of float
        /// Pie: The end angle of last sector, which should be unequal to startAngle.
        | EndAngle of float
        /// Pie/RadialBar: The minimum angle of each unzero data.
        | MinAngle of float
        /// Pie: The angle between two sectors.
        | PaddingAngle of float
        /// Pie: The key of each sector's name.
        | NameKey of string
        /// Pie: The index of active sector in Pie, this option can be changed in mouse event handlers.
        | ActiveInex of System.Array
        /// Pie: The shape of active sector.
        | ActiveShape of obj
        | PolarAngles of System.Array
        | PolarRadius of System.Array
        /// The type of polar grids: 'polygon' | 'circle'
        | GridType of string
        /// The angle of radial direction line to display axis text.
        | Angle of float

        /// Axis: 'number' | 'category' (default 'category')
        | Type of obj
        | Data of System.Array
        /// The key of a group of data which should be unique.
        | DataKey of obj
        | LegendType of ShapeType
        /// If set to false, labels will not be drawn. If true set, labels will be drawn which have the props calculated internally. If object set, labels will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom label element. If set a function, the function will be called to render customized label.
        | Label of obj
        /// If false set, label lines will not be drawn. If true set, label lines will be drawn which have the props calculated internally. If object set, label lines will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom label line element. If set a function, the function will be called to render customized label line.
        | LabelLine of obj

        /// If set false, animation of line will be disabled.
        | IsAnimationActive of bool
        /// Specifies when the animation should begin, the unit of this option is ms.
        | AnimationBegin of float
        /// Specifies the duration of animation, the unit of this option is ms.
        | AnimationDuration of float
        | AnimationEasing of Easing

        /// If false set, dots will not be drawn. If true set, dots will be drawn which have the props calculated internally. If object set, dots will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom dot element.If set a function, the function will be called to render customized dot.
        | Dot of obj
        /// The coordinates of all the points in the line, usually calculated internally.
        | Points of System.Array
        | Background of obj
        | Shape of obj

        /// If set false, no axis line will be drawn. If set a object, the option is the configuration of axis line.
        | AxisLine of obj
        | Orientation of string
        /// Allow the axis has duplicated categorys or not when the type of axis is "category".
        | AllowDuplicatedCategory of bool
        /// The count of axis ticks.
        /// DEFAULT: 5
        | TickCount of float
        /// If set false, no axis line will be drawn. If set a object, the option is the configuration of axis line.
        | TickLine of obj
        /// The formatter function of tick.
        | TickFormatter of obj
        /// Set the values of axis ticks manually.
        | Ticks of System.Array
        /// If set false, no ticks will be drawn. If set a object, the option is the configuration of ticks. If set a React element, the option is the custom react element of drawing ticks.
        | Tick of obj
        /// Specify the domain of axis when the axis is a number axis. The length of domain should be 2, and we will validate the values in domain. And each element in the array can be a number, 'auto', 'dataMin', 'dataMax', a string like 'dataMin - 20', 'dataMax + 100', or a function that accepts a single argument and returns a number. If any element of domain is set to be 'auto', comprehensible scale ticks will be calculated, and the final domain of axis is generated by the ticks.
        /// DEFAULT: [0, 'auto']
        | Domain of System.Array
        /// If 'auto' set, the scale funtion is descided by the type of chart, and the props type.
        | Scale of ScaleType

        // Events
        | OnClick of (React.MouseEvent -> unit)
        | OnMouseDown of (React.MouseEvent -> unit)
        | OnMouseUp of (React.MouseEvent -> unit)
        | OnMouseOver of (React.MouseEvent -> unit)
        | OnMouseOut of (React.MouseEvent -> unit)
        | OnMouseEnter of (React.MouseEvent -> unit)
        | OnMouseMove of (React.MouseEvent -> unit)
        | OnMouseLeave of (React.MouseEvent -> unit)

        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Polar = !!(key, value)

    type [<RequireQualifiedAccess>] Shape =
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Shape = !!(key, value)


open Fable.Helpers.React
open Props

#if FABLE_REPL_LIB
let [<Global>] Recharts = obj()
let inline ofImport (importMember: string) (_importPath: string) (props: 'P) (children: React.ReactElement seq): React.ReactElement =
    createElement(Recharts?(importMember), props, children)
#endif

// Charts
let inline lineChart (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "LineChart" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline barChart (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "BarChart" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline areaChart (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "AreaChart" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline composedChart (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "ComposedChart" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline pieChart (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "PieChart" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline radarChart (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "RadarChart" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline radialBarChart (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "RadialBarChart" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline scatterChart (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "ScatterChart" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline treemap (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Treemap" "recharts" (keyValueList CaseRules.LowerFirst props) children

// General Components

let inline responsiveContainer (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "ResponsiveContainer" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline legend (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Legend" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline tooltip (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Tooltip" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline cell (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Cell" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline text (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Text" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline label (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Label" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline labelList (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "LabelList" "recharts" (keyValueList CaseRules.LowerFirst props) children

// Cartesian Components
let inline area (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Area" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline bar (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Bar" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline line (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Line" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline scatter (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Scatter" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline xaxis (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "XAxis" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline yaxis (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "YAxis" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline zaxis (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "ZAxis" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline brush (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Brush" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline cartesianAxis (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "CartesianAxis" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline cartesianGrid (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "CartesianGrid" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline referenceLine (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "ReferenceLine" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline referenceDot (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "ReferenceDot" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline referenceArea (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "ReferenceArea" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline errorBar (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "ErrorBar" "recharts" (keyValueList CaseRules.LowerFirst props) children


// Polar Components
let inline pie (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Pie" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline radar (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "Radar" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline radialBar (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "RadialBar" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline polarAngleAxis (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "PolarAngleAxis" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline polarGrid (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "PolarGrid" "recharts" (keyValueList CaseRules.LowerFirst props) children

let inline polarRadiusAxis (props: IProp list) (children: React.ReactElement list): React.ReactElement =
    ofImport "PolarRadiusAxis" "recharts" (keyValueList CaseRules.LowerFirst props) children

// Shapes
let inline cross (props: IProp list): React.ReactElement =
    ofImport "Cross" "recharts" (keyValueList CaseRules.LowerFirst props) []

let inline curve (props: IProp list): React.ReactElement =
    ofImport "Curve" "recharts" (keyValueList CaseRules.LowerFirst props) []

let inline dot (props: IProp list): React.ReactElement =
    ofImport "Dot" "recharts" (keyValueList CaseRules.LowerFirst props) []

let inline polygon (props: IProp list): React.ReactElement =
    ofImport "Polygon" "recharts" (keyValueList CaseRules.LowerFirst props) []

let inline rectangle (props: IProp list): React.ReactElement =
    ofImport "Rectangle" "recharts" (keyValueList CaseRules.LowerFirst props) []

let inline sector (props: IProp list): React.ReactElement =
    ofImport "Sector" "recharts" (keyValueList CaseRules.LowerFirst props) []
