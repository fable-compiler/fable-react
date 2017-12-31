module Fable.Recharts

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop

module Props =
    [<StringEnum>]
    type Layout =
        | Horizontal
        | Vertical

    [<StringEnum>]
    type StackOffset =
        | Expand
        | Wiggle
        | Silhouette
        | Sign
        | [<CompiledName("none")>] NoStackOffset

    [<StringEnum>]
    type Interpolation =
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

    [<StringEnum>]
    type Legend =
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

    [<StringEnum>]
    type Easing =
        | Ease
        | [<CompiledName("ease-in")>] EaseIn
        | [<CompiledName("ease-out")>] EaseOut
        | [<CompiledName("ease-in-out")>] EaseInOut
        | Linear

    type [<Pojo>] CoordinatePoint =
        { x: float
          y: float
          value: float }

    type [<Pojo>] Margin =
        { top: float
          bottom: float
          right: float
          left: float }

    type ChartProp =
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

        // Events
        | OnClick of (React.MouseEvent -> unit)
        | OnMouseEnter of (React.MouseEvent -> unit)
        | OnMouseMove of (React.MouseEvent -> unit)
        | OnMouseLeave of (React.MouseEvent -> unit)
        static member Custom(key: string, value: obj): ChartProp = !!(key, value)

    type CartesianProp =
        /// The interpolation type of line. And customized interpolation function can be set to type. It's the same as type in Area.
        | Type of Interpolation
        /// The key of a group of data which should be unique in a LineChart.
        | DataKey of obj
        // The id of x-axis which is corresponding to the data.
        | XAxisId of obj
        // The id of y-axis which is corresponding to the data.
        | YAxisId of obj
        | LegendType of Legend
        /// If false set, labels will not be drawn. If true set, labels will be drawn which have the props calculated internally. If object set, labels will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom label element. If set a function, the function will be called to render customized label.
        | Label of obj
        /// The layout of line, usually inherited from parent.
        | Layout of Layout
        | Unit of string
        /// The name of data. This option will be used in tooltip and legend to represent a line. If no value was set to this option, the value of dataKey will be used alternatively.
        | Name of string
        /// If set false, animation of line will be disabled.
        | IsAnimationActive of bool
        /// Specifies when the animation should begin, the unit of this option is ms.
        | AnimationBegin of float
        /// Specifies the duration of animation, the unit of this option is ms.
        | AnimationDuration of float
        | AnimationEasing of Easing

        /// Line: If false set, dots will not be drawn. If true set, dots will be drawn which have the props calculated internally. If object set, dots will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom dot element.If set a function, the function will be called to render customized dot.
        | Dot of obj
        /// Line: The dot is shown when muser enter a line chart and this chart has tooltip. If false set, no active dot will not be drawn. If true set, active dot will be drawn which have the props calculated internally. If object set, active dot will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom active dot element.If set a function, the function will be called to render customized active dot.
        | ActiveDot of obj
        /// Line: The coordinates of all the points in the line, usually calculated internally.
        | Points of CoordinatePoint[]
        /// Line: Whether to connect a graph line across null points.
        | ConnectNulls of bool

        /// Bar: The width or height of each bar. If the barSize is not specified, the size of bar will be caculated by the barCategoryGap, barGap and the quantity of bar groups.
        | BarSize of float
        /// Bar: The maximum width of bar in a horizontal BarChart, or maximum height in a vertical BarChart.
        | MaxBarSize of float
        /// Bar: The minimal height of a bar in a horizontal BarChart, or the minimal width of a bar in a vertical BarChart. By default, 0 values are not shown. To visualize a 0 (or close to zero) point, set the minimal point size to a pixel value like 3. In stacked bar charts, minPointSize might not be respected for tightly packed values. So we strongly recommend not using this props in stacked BarChart.
        | MinPointSize of float
        /// Bar: If set a ReactElement, the shape of bar can be customized. If set a function, the function will be called to render customized shape.
        | Shape of React.ReactElement
        /// Bar: The stack id of bar, when two bars have the same value axis and same stackId, then the two bars are stacked in order.
        | StackId of obj

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
        static member Custom(key: string, value: obj): ChartProp = !!(key, value)

type RechartComponent =
    interface end

module Imports =
    // Charts
    let lineChartEl: obj = import "LineChart" "recharts"
    let barChartEl: obj = import "BarChart" "recharts"

    // General Components
    let tooltipEl: obj = import "Tooltip" "recharts"
    let legendEl: obj = import "Legend" "recharts"

    // Cartesian Components
    let lineEl: obj = import "Line" "recharts"
    let barEl: obj = import "Bar" "recharts"
    let cartesianGridEl: obj = import "CartesianGrid" "recharts"
    let xaxisEl: obj = import "XAxis" "recharts"
    let yaxisEl: obj = import "YAxis" "recharts"

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Props
open Imports

let inline lineChart (props: ChartProp list) (children: RechartComponent list): React.ReactElement =
    createElement(lineChartEl, keyValueList CaseRules.LowerFirst props, children)

let inline barChart (props: ChartProp list) (children: RechartComponent list): React.ReactElement =
    createElement(barChartEl, keyValueList CaseRules.LowerFirst props, children)

// TODO: Tooltip props
let inline tooltip (props: obj list): RechartComponent =
    createElement(tooltipEl, keyValueList CaseRules.LowerFirst props, [])

// TODO: Legend props
let inline legend (props: obj list): RechartComponent =
    createElement(legendEl, keyValueList CaseRules.LowerFirst props, [])

let inline bar (props: IProp list): RechartComponent =
    createElement(barEl, keyValueList CaseRules.LowerFirst props, [])

let inline line (props: IProp list): RechartComponent =
    createElement(lineEl, keyValueList CaseRules.LowerFirst props, [])

let inline cartesianGrid (props: IProp list): RechartComponent =
    createElement(cartesianGridEl, keyValueList CaseRules.LowerFirst props, [])

let inline xaxis (props: IProp list): RechartComponent =
    createElement(xaxisEl, keyValueList CaseRules.LowerFirst props, [])

let inline yaxis (props: IProp list): RechartComponent =
    createElement(yaxisEl, keyValueList CaseRules.LowerFirst props, [])

