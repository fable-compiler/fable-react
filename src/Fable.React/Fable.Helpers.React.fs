module Fable.Helpers.React

open FSharp.Reflection
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

module rec Props =
    type IProp =
        interface end

    type IHTMLProp =
        inherit IProp

    type IFragmentProp =
        inherit IProp

    type FragmentProp =
        | Key of string
        interface IFragmentProp

    type Prop =
        | Key of string
        | Ref of (Browser.Element->unit)
        interface IHTMLProp

    type DangerousHtml = {
        __html: string
    }

    type DOMAttr =
        | DangerouslySetInnerHTML of DangerousHtml
        | OnCut of (React.ClipboardEvent -> unit)
        | OnPaste of (React.ClipboardEvent -> unit)
        | OnCompositionEnd of (React.CompositionEvent -> unit)
        | OnCompositionStart of (React.CompositionEvent -> unit)
        | OnCopy of (React.ClipboardEvent -> unit)
        | OnCompositionUpdate of (React.CompositionEvent -> unit)
        | OnFocus of (React.FocusEvent -> unit)
        | OnBlur of (React.FocusEvent -> unit)
        | OnChange of (React.FormEvent -> unit)
        | OnInput of (React.FormEvent -> unit)
        | OnSubmit of (React.FormEvent -> unit)
        | OnReset of (React.FormEvent -> unit)
        | OnLoad of (React.SyntheticEvent -> unit)
        | OnError of (React.SyntheticEvent -> unit)
        | OnKeyDown of (React.KeyboardEvent -> unit)
        | OnKeyPress of (React.KeyboardEvent -> unit)
        | OnKeyUp of (React.KeyboardEvent -> unit)
        | OnAbort of (React.SyntheticEvent -> unit)
        | OnCanPlay of (React.SyntheticEvent -> unit)
        | OnCanPlayThrough of (React.SyntheticEvent -> unit)
        | OnDurationChange of (React.SyntheticEvent -> unit)
        | OnEmptied of (React.SyntheticEvent -> unit)
        | OnEncrypted of (React.SyntheticEvent -> unit)
        | OnEnded of (React.SyntheticEvent -> unit)
        | OnLoadedData of (React.SyntheticEvent -> unit)
        | OnLoadedMetadata of (React.SyntheticEvent -> unit)
        | OnLoadStart of (React.SyntheticEvent -> unit)
        | OnPause of (React.SyntheticEvent -> unit)
        | OnPlay of (React.SyntheticEvent -> unit)
        | OnPlaying of (React.SyntheticEvent -> unit)
        | OnProgress of (React.SyntheticEvent -> unit)
        | OnRateChange of (React.SyntheticEvent -> unit)
        | OnSeeked of (React.SyntheticEvent -> unit)
        | OnSeeking of (React.SyntheticEvent -> unit)
        | OnStalled of (React.SyntheticEvent -> unit)
        | OnSuspend of (React.SyntheticEvent -> unit)
        | OnTimeUpdate of (React.SyntheticEvent -> unit)
        | OnVolumeChange of (React.SyntheticEvent -> unit)
        | OnWaiting of (React.SyntheticEvent -> unit)
        | OnClick of (React.MouseEvent -> unit)
        | OnContextMenu of (React.MouseEvent -> unit)
        | OnDoubleClick of (React.MouseEvent -> unit)
        | OnDrag of (React.DragEvent -> unit)
        | OnDragEnd of (React.DragEvent -> unit)
        | OnDragEnter of (React.DragEvent -> unit)
        | OnDragExit of (React.DragEvent -> unit)
        | OnDragLeave of (React.DragEvent -> unit)
        | OnDragOver of (React.DragEvent -> unit)
        | OnDragStart of (React.DragEvent -> unit)
        | OnDrop of (React.DragEvent -> unit)
        | OnMouseDown of (React.MouseEvent -> unit)
        | OnMouseEnter of (React.MouseEvent -> unit)
        | OnMouseLeave of (React.MouseEvent -> unit)
        | OnMouseMove of (React.MouseEvent -> unit)
        | OnMouseOut of (React.MouseEvent -> unit)
        | OnMouseOver of (React.MouseEvent -> unit)
        | OnMouseUp of (React.MouseEvent -> unit)
        | OnSelect of (React.SyntheticEvent -> unit)
        | OnTouchCancel of (React.TouchEvent -> unit)
        | OnTouchEnd of (React.TouchEvent -> unit)
        | OnTouchMove of (React.TouchEvent -> unit)
        | OnTouchStart of (React.TouchEvent -> unit)
        | OnScroll of (React.UIEvent -> unit)
        | OnWheel of (React.WheelEvent -> unit)
        | OnAnimationStart of (React.AnimationEvent -> unit)
        | OnAnimationEnd of (React.AnimationEvent -> unit)
        | OnAnimationIteration of (React.AnimationEvent -> unit)
        | OnTransitionEnd of (React.TransitionEvent -> unit)
        interface IHTMLProp

    type SVGAttr =
        | ClipPath of string
        | Cx of obj
        | Cy of obj
        | D of string
        | Dx of obj
        | Dy of obj
        | Fill of string
        | FillOpacity of obj
        | FontFamily of string
        | FontSize of obj
        | Fx of obj
        | Fy of obj
        | GradientTransform of string
        | GradientUnits of string
        | Height of obj
        | MarkerEnd of string
        | MarkerMid of string
        | MarkerStart of string
        | Offset of obj
        | Opacity of obj
        | PatternContentUnits of string
        | PatternUnits of string
        | Points of string
        | PreserveAspectRatio of string
        | R of obj
        | Rx of obj
        | Ry of obj
        | SpreadMethod of string
        | StopColor of string
        | StopOpacity of obj
        | Stroke of string
        | StrokeDasharray of string
        | StrokeLinecap of string
        | StrokeMiterlimit of string
        | StrokeOpacity of obj
        | StrokeWidth of obj
        | TextAnchor of string
        | Transform of string
        | Version of string
        | ViewBox of string
        | Width of obj
        | X1 of obj
        | X2 of obj
        | X of obj
        | XlinkActuate of string
        | XlinkArcrole of string
        | XlinkHref of string
        | XlinkRole of string
        | XlinkShow of string
        | XlinkTitle of string
        | XlinkType of string
        | XmlBase of string
        | XmlLang of string
        | XmlSpace of string
        | Y1 of obj
        | Y2 of obj
        | Y of obj
        /// If you are searching for a way to provide a value not supported by this DSL then use something like: CSSProp.Custom ("align-content", "center")
        | [<Erase>] Custom of string * obj
        interface IProp

    type HTMLAttr =
        | DefaultChecked of bool
        | DefaultValue of obj
        | Accept of string
        | AcceptCharset of string
        | AccessKey of string
        | Action of string
        | AllowFullScreen of bool
        | AllowTransparency of bool
        | Alt of string
        | [<CompiledName("aria-haspopup")>] AriaHasPopup of bool
        | [<CompiledName("aria-expanded")>] AriaExpanded of bool
        | Async of bool
        | AutoComplete of string
        | AutoFocus of bool
        | AutoPlay of bool
        | Capture of bool
        | CellPadding of obj
        | CellSpacing of obj
        | CharSet of string
        | Challenge of string
        | Checked of bool
        | ClassID of string
        | ClassName of string
        /// Alias of ClassName
        | [<CompiledName("className")>] Class of string
        | Cols of int
        | ColSpan of int
        | Content of string
        | ContentEditable of bool
        | ContextMenu of string
        | Controls of bool
        | Coords of string
        | CrossOrigin of string
        // | Data of string
        | [<CompiledName("data-toggle")>] DataToggle of string
        | DateTime of string
        | Default of bool
        | Defer of bool
        | Dir of string
        | Disabled of bool
        | Download of obj
        | Draggable of bool
        | EncType of string
        | Form of string
        | FormAction of string
        | FormEncType of string
        | FormMethod of string
        | FormNoValidate of bool
        | FormTarget of string
        | FrameBorder of obj
        | Headers of string
        | Height of obj
        | Hidden of bool
        | High of float
        | Href of string
        | HrefLang of string
        | HtmlFor of string
        | HttpEquiv of string
        | Icon of string
        | Id of string
        | InputMode of string
        | Integrity of string
        | Is of string
        | KeyParams of string
        | KeyType of string
        | Kind of string
        | Label of string
        | Lang of string
        | List of string
        | Loop of bool
        | Low of float
        | Manifest of string
        | MarginHeight of float
        | MarginWidth of float
        | Max of obj
        | MaxLength of float
        | Media of string
        | MediaGroup of string
        | Method of string
        | Min of obj
        | MinLength of float
        | Multiple of bool
        | Muted of bool
        | Name of string
        | NoValidate of bool
        | Open of bool
        | Optimum of float
        | Pattern of string
        | Placeholder of string
        | Poster of string
        | Preload of string
        | RadioGroup of string
        | ReadOnly of bool
        | Rel of string
        | Required of bool
        | Role of string
        | Rows of int
        | RowSpan of int
        | Sandbox of string
        | Scope of string
        | Scoped of bool
        | Scrolling of string
        | Seamless of bool
        | Selected of bool
        | Shape of string
        | Size of float
        | Sizes of string
        | Span of float
        | SpellCheck of bool
        | Src of string
        | SrcDoc of string
        | SrcLang of string
        | SrcSet of string
        | Start of float
        | Step of obj
        | Summary of string
        | TabIndex of int
        | Target of string
        | Title of string
        | Type of string
        | UseMap of string
        | Value of obj
        /// Compiles to same prop as `Value`. Intended for `select` elements
        /// with `Multiple` prop set to `true`.
        | [<CompiledName("value")>] ValueMultiple of string[]
        | Width of obj
        | Wmode of string
        | Wrap of string
        | About of string
        | Datatype of string
        | Inlist of obj
        | Prefix of string
        | Property of string
        | Resource of string
        | Typeof of string
        | Vocab of string
        | AutoCapitalize of string
        | AutoCorrect of string
        | AutoSave of string
        // | Color of string // Conflicts with CSSProp, shouldn't be used in HTML5
        | ItemProp of string
        | ItemScope of bool
        | ItemType of string
        | ItemID of string
        | ItemRef of string
        | Results of float
        | Security of string
        | Unselectable of bool
        | [<Erase>] Custom of string * obj
#if !FABLE_COMPILER
        | Style of CSSProp list
        | Data of string * obj
#endif
        interface IHTMLProp

    type CSSProp =
        | AlignContent of obj
        | AlignItems of obj
        | AlignSelf of obj
        | AlignmentAdjust of obj
        | AlignmentBaseline of obj
        | All of obj
        | Animation of obj
        | AnimationDelay of obj
        | AnimationDirection of obj
        | AnimationDuration of obj
        | AnimationFillMode of obj
        | AnimationIterationCount of obj
        | AnimationName of obj
        | AnimationPlayState of obj
        | AnimationTimingFunction of obj
        | Appearance of obj
        | BackfaceVisibility of obj
        | Background of obj
        | BackgroundAttachment of obj
        | BackgroundBlendMode of obj
        | BackgroundClip of obj
        | BackgroundColor of obj
        | BackgroundComposite of obj
        | BackgroundImage of obj
        | BackgroundOrigin of obj
        | BackgroundPosition of obj
        | BackgroundPositionX of obj
        | BackgroundPositionY of obj
        | BackgroundRepeat of obj
        | BackgroundSize of obj
        | BaselineShift of obj
        | Behavior of obj
        | BlockSize of obj
        | Border of obj
        | BorderBlockEnd of obj
        | BorderBlockEndColor of obj
        | BorderBlockEndStyle of obj
        | BorderBlockEndWidth of obj
        | BorderBlockStart of obj
        | BorderBlockStartColor of obj
        | BorderBlockStartStyle of obj
        | BorderBlockStartWidth of obj
        | BorderBottom of obj
        | BorderBottomColor of obj
        | BorderBottomLeftRadius of obj
        | BorderBottomRightRadius of obj
        | BorderBottomStyle of obj
        | BorderBottomWidth of obj
        | BorderCollapse of obj
        | BorderColor of obj
        | BorderCornerShape of obj
        | BorderImage of obj
        | BorderImageOutset of obj
        | BorderImageRepeat of obj
        | BorderImageSlice of obj
        | BorderImageSource of obj
        | BorderImageWidth of obj
        | BorderInlineEnd of obj
        | BorderInlineEndColor of obj
        | BorderInlineEndStyle of obj
        | BorderInlineEndWidth of obj
        | BorderInlineStart of obj
        | BorderInlineStartColor of obj
        | BorderInlineStartStyle of obj
        | BorderInlineStartWidth of obj
        | BorderLeft of obj
        | BorderLeftColor of obj
        | BorderLeftStyle of obj
        | BorderLeftWidth of obj
        | BorderRadius of obj
        | BorderRight of obj
        | BorderRightColor of obj
        | BorderRightStyle of obj
        | BorderRightWidth of obj
        | BorderSpacing of obj
        | BorderStyle of obj
        | BorderTop of obj
        | BorderTopColor of obj
        | BorderTopLeftRadius of obj
        | BorderTopRightRadius of obj
        | BorderTopStyle of obj
        | BorderTopWidth of obj
        | BorderWidth of obj
        | Bottom of obj
        | BoxAlign of obj
        | BoxDecorationBreak of obj
        | BoxDirection of obj
        | BoxFlex of obj
        | BoxFlexGroup of obj
        | BoxLineProgression of obj
        | BoxLines of obj
        | BoxOrdinalGroup of obj
        | BoxShadow of obj
        | BoxSizing of obj
        | BreakAfter of obj
        | BreakBefore of obj
        | BreakInside of obj
        | CaptionSide of obj
        | CaretColor of obj
        | Clear of obj
        | Clip of obj
        | ClipPath of obj
        | ClipRule of obj
        | Color of obj
        | ColorInterpolation of obj
        | ColorInterpolationFilters of obj
        | ColorProfile of obj
        | ColorRendering of obj
        | ColumnCount of obj
        | ColumnFill of obj
        | ColumnGap of obj
        | ColumnRule of obj
        | ColumnRuleColor of obj
        | ColumnRuleStyle of obj
        | ColumnRuleWidth of obj
        | ColumnSpan of obj
        | ColumnWidth of obj
        | Columns of obj
        | Content of obj
        | CounterIncrement of obj
        | CounterReset of obj
        | Cue of obj
        | CueAfter of obj
        | Cursor of obj
        | Direction of obj
        | Display of obj
        | DominantBaseline of obj
        | EmptyCells of obj
        | EnableBackground of obj
        | Fill of obj
        | FillOpacity of obj
        | FillRule of obj
        | Filter of obj
        | Flex of obj
        | FlexAlign of obj
        | FlexBasis of obj
        | FlexDirection of obj
        | FlexFlow of obj
        | FlexGrow of obj
        | FlexItemAlign of obj
        | FlexLinePack of obj
        | FlexOrder of obj
        | FlexShrink of obj
        | FlexWrap of obj
        | Float of obj
        | FloodColor of obj
        | FloodOpacity of obj
        | FlowFrom of obj
        | Font of obj
        | FontFamily of obj
        | FontFeatureSettings of obj
        | FontKerning of obj
        | FontLanguageOverride of obj
        | FontSize of obj
        | FontSizeAdjust of obj
        | FontStretch of obj
        | FontStyle of obj
        | FontSynthesis of obj
        | FontVariant of obj
        | FontVariantAlternates of obj
        | FontVariantCaps of obj
        | FontVariantEastAsian of obj
        | FontVariantLigatures of obj
        | FontVariantNumeric of obj
        | FontVariantPosition of obj
        | FontWeight of obj
        | GlyphOrientationHorizontal of obj
        | GlyphOrientationVertical of obj
        | Grid of obj
        | GridArea of obj
        | GridAutoColumns of obj
        | GridAutoFlow of obj
        | GridAutoRows of obj
        | GridColumn of obj
        | GridColumnEnd of obj
        | GridColumnGap of obj
        | GridColumnStart of obj
        | GridGap of obj
        | GridRow of obj
        | GridRowEnd of obj
        | GridRowGap of obj
        | GridRowPosition of obj
        | GridRowSpan of obj
        | GridRowStart of obj
        | GridTemplate of obj
        | GridTemplateAreas of obj
        | GridTemplateColumns of obj
        | GridTemplateRows of obj
        | HangingPunctuation of obj
        | Height of obj
        | HyphenateLimitChars of obj
        | HyphenateLimitLines of obj
        | HyphenateLimitZone of obj
        | Hyphens of obj
        | ImageOrientation of obj
        | ImageRendering of obj
        | ImageResolution of obj
        | ImeMode of obj
        | InlineSize of obj
        | Isolation of obj
        | JustifyContent of obj
        | Kerning of obj
        | LayoutGrid of obj
        | LayoutGridChar of obj
        | LayoutGridLine of obj
        | LayoutGridMode of obj
        | LayoutGridType of obj
        | Left of obj
        | LetterSpacing of obj
        | LightingColor of obj
        | LineBreak of obj
        | LineClamp of obj
        | LineHeight of obj
        | ListStyle of obj
        | ListStyleImage of obj
        | ListStylePosition of obj
        | ListStyleType of obj
        | Margin of obj
        | MarginBlockEnd of obj
        | MarginBlockStart of obj
        | MarginBottom of obj
        | MarginInlineEnd of obj
        | MarginInlineStart of obj
        | MarginLeft of obj
        | MarginRight of obj
        | MarginTop of obj
        | MarkerEnd of obj
        | MarkerMid of obj
        | MarkerStart of obj
        | MarqueeDirection of obj
        | MarqueeStyle of obj
        | Mask of obj
        | MaskBorder of obj
        | MaskBorderRepeat of obj
        | MaskBorderSlice of obj
        | MaskBorderSource of obj
        | MaskBorderWidth of obj
        | MaskClip of obj
        | MaskComposite of obj
        | MaskImage of obj
        | MaskMode of obj
        | MaskOrigin of obj
        | MaskPosition of obj
        | MaskRepeat of obj
        | MaskSize of obj
        | MaskType of obj
        | MaxFontSize of obj
        | MaxHeight of obj
        | MaxWidth of obj
        | MinBlockSize of obj
        | MinHeight of obj
        | MinInlineSize of obj
        | MinWidth of obj
        | MixBlendMode of obj
        | ObjectFit of obj
        | ObjectPosition of obj
        | OffsetBlockEnd of obj
        | OffsetBlockStart of obj
        | OffsetInlineEnd of obj
        | OffsetInlineStart of obj
        | Opacity of obj
        | Order of obj
        | Orphans of obj
        | Outline of obj
        | OutlineColor of obj
        | OutlineOffset of obj
        | OutlineStyle of obj
        | OutlineWidth of obj
        | Overflow of obj
        | OverflowStyle of obj
        | OverflowWrap of obj
        | OverflowX of obj
        | OverflowY of obj
        | Padding of obj
        | PaddingBlockEnd of obj
        | PaddingBlockStart of obj
        | PaddingBottom of obj
        | PaddingInlineEnd of obj
        | PaddingInlineStart of obj
        | PaddingLeft of obj
        | PaddingRight of obj
        | PaddingTop of obj
        | PageBreakAfter of obj
        | PageBreakBefore of obj
        | PageBreakInside of obj
        | Pause of obj
        | PauseAfter of obj
        | PauseBefore of obj
        | Perspective of obj
        | PerspectiveOrigin of obj
        | PointerEvents of obj
        | Position of obj
        | PunctuationTrim of obj
        | Quotes of obj
        | RegionFragment of obj
        | Resize of obj
        | RestAfter of obj
        | RestBefore of obj
        | Right of obj
        | RubyAlign of obj
        | RubyMerge of obj
        | RubyPosition of obj
        | ScrollBehavior of obj
        | ScrollSnapCoordinate of obj
        | ScrollSnapDestination of obj
        | ScrollSnapType of obj
        | ShapeImageThreshold of obj
        | ShapeInside of obj
        | ShapeMargin of obj
        | ShapeOutside of obj
        | ShapeRendering of obj
        | Speak of obj
        | SpeakAs of obj
        | StopColor of obj
        | StopOpacity of obj
        | Stroke of obj
        | StrokeDasharray of obj
        | StrokeDashoffset of obj
        | StrokeLinecap of obj
        | StrokeLinejoin of obj
        | StrokeMiterlimit of obj
        | StrokeOpacity of obj
        | StrokeWidth of obj
        | TabSize of obj
        | TableLayout of obj
        | TextAlign of obj
        | TextAlignLast of obj
        | TextAnchor of obj
        | TextCombineUpright of obj
        | TextDecoration of obj
        | TextDecorationColor of obj
        | TextDecorationLine of obj
        | TextDecorationLineThrough of obj
        | TextDecorationNone of obj
        | TextDecorationOverline of obj
        | TextDecorationSkip of obj
        | TextDecorationStyle of obj
        | TextDecorationUnderline of obj
        | TextEmphasis of obj
        | TextEmphasisColor of obj
        | TextEmphasisPosition of obj
        | TextEmphasisStyle of obj
        | TextHeight of obj
        | TextIndent of obj
        | TextJustify of obj
        | TextJustifyTrim of obj
        | TextKashidaSpace of obj
        | TextLineThrough of obj
        | TextLineThroughColor of obj
        | TextLineThroughMode of obj
        | TextLineThroughStyle of obj
        | TextLineThroughWidth of obj
        | TextOrientation of obj
        | TextOverflow of obj
        | TextOverline of obj
        | TextOverlineColor of obj
        | TextOverlineMode of obj
        | TextOverlineStyle of obj
        | TextOverlineWidth of obj
        | TextRendering of obj
        | TextScript of obj
        | TextShadow of obj
        | TextTransform of obj
        | TextUnderlinePosition of obj
        | TextUnderlineStyle of obj
        | Top of obj
        | TouchAction of obj
        | Transform of obj
        | TransformBox of obj
        | TransformOrigin of obj
        | TransformOriginZ of obj
        | TransformStyle of obj
        | Transition of obj
        | TransitionDelay of obj
        | TransitionDuration of obj
        | TransitionProperty of obj
        | TransitionTimingFunction of obj
        | UnicodeBidi of obj
        | UnicodeRange of obj
        | UserFocus of obj
        | UserInput of obj
        | VerticalAlign of obj
        | Visibility of obj
        | VoiceBalance of obj
        | VoiceDuration of obj
        | VoiceFamily of obj
        | VoicePitch of obj
        | VoiceRange of obj
        | VoiceRate of obj
        | VoiceStress of obj
        | VoiceVolume of obj
        | WhiteSpace of obj
        | WhiteSpaceTreatment of obj
        | Widows of obj
        | Width of obj
        | WillChange of obj
        | WordBreak of obj
        | WordSpacing of obj
        | WordWrap of obj
        | WrapFlow of obj
        | WrapMargin of obj
        | WrapOption of obj
        | WritingMode of obj
        | ZIndex of obj
        | Zoom of obj
        /// If you are searching for a way to provide a value not supported by this DSL then use something like: CSSProp.Custom ("align-content", "center")
        | [<Erase>] Custom of string * obj

#if FABLE_COMPILER
    let inline Style (css: CSSProp list): HTMLAttr =
        !!("style", keyValueList CaseRules.LowerFirst css)

    let inline Data (key: string, value: obj): HTMLAttr =
        !!("data-" + key, value)
#endif

open Props
open Fable.Import.React

[<Erase>]
type HTMLNode =
| Text of string
| RawText of string
| Node of string * IProp seq * ReactElement seq
| List of ReactElement seq
| Empty
with interface ReactElement

[<Import("createElement", from="react")>]
let createElement(comp: obj, props: obj, [<ParamList>] children: obj) =
    HTMLNode.Empty :> ReactElement

[<StringEnum>]
type ServerElementType =
| Tag
| Fragment
| Component

let [<Literal>] private ChildrenName = "children"

module ServerRenderingInternal =

#if FABLE_COMPILER
    let inline createServerElement (tag: obj, props: obj, children: ReactElement seq, elementType: ServerElementType) =
        createElement(tag, props, children)
    let inline createServerElementByFn (f, props, children) =
        createElement(f, props, children)
#else
    let createServerElement (tag: obj, props: obj, children: ReactElement seq, elementType: ServerElementType) =
        match elementType with
        | ServerElementType.Tag ->
            HTMLNode.Node (string tag, props :?> IProp seq, children) :> ReactElement
        | ServerElementType.Fragment ->
            HTMLNode.List children :> ReactElement
        | ServerElementType.Component ->
            let tag = tag :?> System.Type
            let comp = System.Activator.CreateInstance(tag, props)
#if NETSTANDARD1_6
            let tag = tag.GetTypeInfo()
#endif
            let childrenProp = tag.GetProperty(ChildrenName)
            childrenProp.SetValue(comp, children |> Seq.toArray)
            let render = tag.GetMethod("render")
            render.Invoke(comp, null) :?> ReactElement

    let createServerElementByFn = fun (f, props, children) ->
#if NETSTANDARD1_6
        let propsType' = props.GetType()
        let propsType = propsType'.GetTypeInfo()
#else
        let propsType = props.GetType()
#endif
        let props =
            if propsType.GetProperty (ChildrenName) |> isNull then
                props
            else
                let values = ResizeArray<obj> ()
                let properties = propsType.GetProperties()
                for p in properties do
                    if p.Name = ChildrenName then
                        values.Add (children |> Seq.toArray)
                    else
                        values.Add (FSharpValue.GetRecordField(props, p))
#if NETSTANDARD1_6
                let propsType = propsType'
#endif
                FSharpValue.MakeRecord(propsType, values.ToArray()) :?> 'P
        f props

#endif

open ServerRenderingInternal

/// OBSOLETE: Use `ReactElementType.create`
[<System.Obsolete("Use ReactElementType.create")>]
let inline from<'P> (com: ComponentClass<'P>) (props: 'P) (children: ReactElement seq): ReactElement =
    createElement(com, props, children)

/// Instantiate a component from a type inheriting React.Component
/// Example: `ofType<MyComponent,_,_> { myProps = 5 } []`
let inline ofType<'T,'P,'S when 'T :> Component<'P,'S>> (props: 'P) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
    createElement(jsConstructor<'T>, props, children)
#else
    createServerElement(typeof<'T>, props, children, ServerElementType.Component)
#endif


/// OBSOLETE: Use `ofType`
[<System.Obsolete("Use ofType")>]
let inline com<'T,'P,'S when 'T :> Component<'P,'S>> (props: 'P) (children: ReactElement seq): ReactElement =
    ofType<'T, 'P, 'S> props children

/// Instantiate a stateless component from a function
/// Example:
/// ```
/// let Hello (p: MyProps) = div [] [ofString ("Hello " + p.name)]
/// ofFunction Hello { name = "Maxime" } []
/// ```
let inline ofFunction<'P> (f: 'P -> ReactElement) (props: 'P) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
    createElement(f, props, children)
#else
    createServerElementByFn(f, props, children)
#endif

/// OBSOLETE: Use `ofFunction`
[<System.Obsolete("Use ofFunction")>]
let inline fn<'P> (f: 'P -> ReactElement) (props: 'P) (children: ReactElement seq): ReactElement =
    ofFunction f props children

/// Instantiate an imported React component. The first two arguments must be string literals, "default" can be used for the first one.
/// Example: `ofImport "Map" "leaflet" { x = 10; y = 50 } []`
let inline ofImport<'P> (importMember: string) (importPath: string) (props: 'P) (children: ReactElement seq): ReactElement =
    createElement(import importMember importPath, props, children)

type ReactElementType<'props> = interface end

type ReactComponentType<'props> =
    inherit ReactElementType<'props>
    abstract displayName: string option with get, set

[<Erase>]
type ReactElementTypeWrapper<'P> =
    | Comp of obj
    | Fn of ('P -> ReactElement)
    | HtmlTag of string
    interface ReactElementType<'P>

[<RequireQualifiedAccess>]
module ReactElementType =
    let inline ofComponent<'comp, 'props, 'state when 'comp :> Component<'props, 'state>> =
        #if FABLE_COMPILER
        unbox<ReactComponentType<'props>> jsConstructor<'comp>
        #else
        Comp (typeof<'comp>) :> ReactElementType<'props>
        #endif

    let inline ofFunction<'props> (f: 'props -> ReactElement) =
        #if FABLE_COMPILER
        unbox<ReactComponentType<'props>> f
        #else
        Fn f :> ReactElementType<'props>
        #endif

    let inline ofHtmlElement<'props> (name: string): ReactElementType<'props> =
        #if FABLE_COMPILER
        unbox name
        #else
        HtmlTag name :> ReactElementType<'props>
        #endif

    /// Create a ReactElement to be rendered from an element type, props and children
    let inline create<'props> (comp: ReactElementType<'props>) (props: 'props) (children: ReactElement seq): ReactElement =
        #if FABLE_COMPILER
        createElement(comp, props, children)
        #else
        match (comp :?> ReactElementTypeWrapper<'props>) with
        | Comp obj -> createServerElement(obj, props, children, ServerElementType.Component)
        | Fn f -> createServerElementByFn(f, props, children)
        | HtmlTag obj -> createServerElement(obj, props, children, ServerElementType.Tag)
        #endif

    #if FABLE_COMPILER
    [<Import("memo", from="react")>]
    let private reactMemo<'props> (render: 'props -> ReactElement, areEqual: 'props -> 'props -> bool) : ReactComponentType<'props> =
        jsNative
    #endif

    /// React.memo is a higher order component. It’s similar to React.PureComponent but for function components instead of classes.
    /// If your function component renders the same result given the same props, you can wrap it in a call to React.memo.
    /// React will skip rendering the component, and reuse the last rendered result.
    /// By default it will only shallowly compare complex objects in the props object. If you want control over the comparison, you can use `memoWith`.
    let memo<'props> (render: 'props -> ReactElement) =
        #if FABLE_COMPILER
        reactMemo(render, unbox null)
        #else
        ofFunction render
        #endif

    /// React.memo is a higher order component. It’s similar to React.PureComponent but for function components instead of classes.
    /// If your function renders the same result given the "same" props (according to `areEqual`), you can wrap it in a call to React.memo.
    /// React will skip rendering the component, and reuse the last rendered result.
    /// By default it will only shallowly compare complex objects in the props object. If you want control over the comparison, you can use `memoWith`.
    /// This version allow you to control the comparison used instead of the default shallow one by provide a custom comparison function.
    let memoWith<'props> (areEqual: 'props -> 'props -> bool) (render: 'props -> ReactElement) =
        #if FABLE_COMPILER
        reactMemo(render, areEqual)
        #else
        ofFunction render
        #endif

/// `memoBuilder` is similar to React.PureComponent but is built from only a render function.
/// If your function renders the same result given the same props, you can wrap it in a call to memoBuilder.
/// React will skip rendering the component, and reuse the last rendered result.
/// The resulting function shouldn't be used directly in a render but should be stored to be reused:
///
/// ```
/// type HelloProps = { Name: string }
/// let hello = memoBuilder "Hello" (fun p ->
///     span [ ]
///         [ str "Hello "; str p.Name ])
///
/// let view model =
///     hello { Name = model.Name }
/// ```
///
/// By default it will only shallowly compare complex objects in the props object. If you want control over the comparison, use `memoBuilderWith`.
let memoBuilder<'props> (name: string) (render: 'props -> ReactElement) : 'props -> ReactElement =
    #if FABLE_COMPILER
    render?displayName <- name
    #endif
    let memoType = ReactElementType.memo render
    fun props ->
        ReactElementType.create memoType props []

/// `memoBuilderWith` is similar to React.Component but is built from render and equality functions.
/// If your function renders the same result given the "same" props (according to `areEqual`), you can wrap it in a call to memoBuilder.
/// React will skip rendering the component, and reuse the last rendered result.
/// The resulting function shouldn't be used directly in a render but should be stored to be reused:
///
/// ```
/// type HelloProps = { Name: string }
/// let helloEquals p1 p2 = p1.Name = p2.Name
/// let hello = memoBuilderWith "Hello" helloEquals (fun p ->
///     span [ ]
///         [ str "Hello "; str p.Name ])
///
/// let view model =
///     hello { Name = model.Name }
/// ```
let memoBuilderWith<'props> (name: string) (areEqual: 'props -> 'props -> bool) (render: 'props -> ReactElement) : 'props -> ReactElement =
    #if FABLE_COMPILER
    render?displayName <- name
    #endif
    let memoType = ReactElementType.memoWith areEqual render
    fun props ->
        ReactElementType.create memoType props []

#if FABLE_COMPILER
/// Alias of `ofString`
let inline str (s: string): ReactElement = unbox s

/// Cast a string to a React element (erased in runtime)
let inline ofString (s: string): ReactElement = unbox s

/// Cast an option value to a React element (erased in runtime)
let inline ofOption (o: ReactElement option): ReactElement =
    match o with Some o -> o | None -> null // Option.toObj(o)

/// OBSOLETE: Use `ofOption`
[<System.Obsolete("Use ofOption")>]
let inline opt (o: ReactElement option): ReactElement = ofOption o

/// Cast an int to a React element (erased in runtime)
let inline ofInt (i: int): ReactElement = unbox i

/// Cast a float to a React element (erased in runtime)
let inline ofFloat (f: float): ReactElement = unbox f

/// Returns a list **from .render() method**
let inline ofList (els: ReactElement list): ReactElement = unbox(List.toArray els)

/// Returns an array **from .render() method**
let inline ofArray (els: ReactElement array): ReactElement = unbox els

/// A ReactElement when you don't want to render anything (null in javascript)
[<Emit("null")>]
let nothing: ReactElement = jsNative

#else
/// Alias of `ofString`
let inline str (s: string): ReactElement = HTMLNode.Text s :> ReactElement

/// Cast a string to a React element (erased in runtime)
let inline ofString (s: string): ReactElement = str s

/// Cast an option value to a React element (erased in runtime)
let inline ofOption (o: ReactElement option): ReactElement =
    match o with Some o -> o | None -> null // Option.toObj(o)

/// OBSOLETE: Use `ofOption`
[<System.Obsolete("Use ofOption")>]
let inline opt (o: ReactElement option): ReactElement = ofOption o

/// Cast an int to a React element (erased in runtime)
let inline ofInt (i: int): ReactElement = HTMLNode.RawText (string i) :> ReactElement

/// Cast a float to a React element (erased in runtime)
let inline ofFloat (f: float): ReactElement = HTMLNode.RawText (string f) :> ReactElement

/// Returns a list **from .render() method**
let inline ofList (els: ReactElement list): ReactElement = HTMLNode.List els :> ReactElement

/// Returns an array **from .render() method**
let inline ofArray (els: ReactElement array): ReactElement = HTMLNode.List els :> ReactElement

/// A ReactElement when you don't want to render anything (null in javascript)
let nothing: ReactElement = HTMLNode.Empty :> ReactElement

#endif


/// Instantiate a DOM React element
let inline domEl (tag: string) (props: IHTMLProp seq) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
    createElement(tag, keyValueList CaseRules.LowerFirst props, children)
#else
    createServerElement(tag, (props |> Seq.cast<IProp>), children, ServerElementType.Tag)
#endif

/// Instantiate a DOM React element (void)
let inline voidEl (tag: string) (props: IHTMLProp seq) : ReactElement =
#if FABLE_COMPILER
    createElement(tag, keyValueList CaseRules.LowerFirst props, [])
#else
    createServerElement(tag, (props |> Seq.cast<IProp>), [], ServerElementType.Tag)
#endif

/// Instantiate an SVG React element
let inline svgEl (tag: string) (props: IProp seq) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
    createElement(tag, keyValueList CaseRules.LowerFirst props, children)
#else
    createServerElement(tag, (props |> Seq.cast<IProp>), children, ServerElementType.Tag)
#endif

/// Instantiate a React fragment
let inline fragment (props: IFragmentProp seq) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
    createElement(jsConstructor<Fragment>, keyValueList CaseRules.LowerFirst props, children)
#else
    createServerElement(typeof<Fragment>, (props |> Seq.cast<IProp>), children, ServerElementType.Fragment)
#endif

// Standard elements
let inline a props children = domEl "a" props children
let inline abbr props children = domEl "abbr" props children
let inline address props children = domEl "address" props children
let inline article props children = domEl "article" props children
let inline aside props children = domEl "aside" props children
let inline audio props children = domEl "audio" props children
let inline b props children c = domEl "b" props children
let inline bdi props children = domEl "bdi" props children
let inline bdo props children = domEl "bdo" props children
let inline big props children = domEl "big" props children
let inline blockquote props children = domEl "blockquote" props children
let inline body props children = domEl "body" props children
let inline button props children = domEl "button" props children
let inline canvas props children = domEl "canvas" props children
let inline caption props children = domEl "caption" props children
let inline cite props children = domEl "cite" props children
let inline code props children = domEl "code" props children
let inline colgroup props children = domEl "colgroup" props children
let inline data props children = domEl "data" props children
let inline datalist props children = domEl "datalist" props children
let inline dd props children = domEl "dd" props children
let inline del props children = domEl "del" props children
let inline details props children = domEl "details" props children
let inline dfn props children = domEl "dfn" props children
let inline dialog props children = domEl "dialog" props children
let inline div props children = domEl "div" props children
let inline dl props children = domEl "dl" props children
let inline dt props children = domEl "dt" props children
let inline em props children = domEl "em" props children
let inline fieldset props children = domEl "fieldset" props children
let inline figcaption props children = domEl "figcaption" props children
let inline figure props children = domEl "figure" props children
let inline footer props children = domEl "footer" props children
let inline form props children = domEl "form" props children
let inline h1 props children = domEl "h1" props children
let inline h2 props children = domEl "h2" props children
let inline h3 props children = domEl "h3" props children
let inline h4 props children = domEl "h4" props children
let inline h5 props children = domEl "h5" props children
let inline h6 props children = domEl "h6" props children
let inline head props children = domEl "head" props children
let inline header props children = domEl "header" props children
let inline hgroup props children = domEl "hgroup" props children
let inline html props children = domEl "html" props children
let inline i props children = domEl "i" props children
let inline iframe props children = domEl "iframe" props children
let inline ins props children = domEl "ins" props children
let inline kbd props children = domEl "kbd" props children
let inline label props children = domEl "label" props children
let inline legend props children = domEl "legend" props children
let inline li props children = domEl "li" props children
let inline main props children = domEl "main" props children
let inline map props children = domEl "map" props children
let inline mark props children = domEl "mark" props children
let inline menu props children = domEl "menu" props children
let inline meter props children = domEl "meter" props children
let inline nav props children = domEl "nav" props children
let inline noscript props children = domEl "noscript" props children
let inline ``object`` props children b c = domEl "object" props children
let inline ol props children = domEl "ol" props children
let inline optgroup props children = domEl "optgroup" props children
let inline option props children = domEl "option" props children
let inline output props children = domEl "output" props children
let inline p props children = domEl "p" props children
let inline picture props children = domEl "picture" props children
let inline pre props children = domEl "pre" props children
let inline progress props children = domEl "progress" props children
let inline q props children = domEl "q" props children
let inline rp props children = domEl "rp" props children
let inline rt props children = domEl "rt" props children
let inline ruby props children = domEl "ruby" props children
let inline s props children = domEl "s" props children
let inline samp props children = domEl "samp" props children
let inline script props children = domEl "script" props children
let inline section props children = domEl "section" props children
let inline select props children = domEl "select" props children
let inline small props children = domEl "small" props children
let inline span props children = domEl "span" props children
let inline strong props children = domEl "strong" props children
let inline style props children = domEl "style" props children
let inline sub props children = domEl "sub" props children
let inline summary props children = domEl "summary" props children
let inline sup props children = domEl "sup" props children
let inline table props children = domEl "table" props children
let inline tbody props children = domEl "tbody" props children
let inline td props children = domEl "td" props children
let inline textarea props children = domEl "textarea" props children
let inline tfoot props children = domEl "tfoot" props children
let inline th props children = domEl "th" props children
let inline thead props children = domEl "thead" props children
let inline time props children = domEl "time" props children
let inline title props children = domEl "title" props children
let inline tr props children = domEl "tr" props children
let inline u props children = domEl "u" props children
let inline ul props children = domEl "ul" props children
let inline var props children = domEl "var" props children
let inline video props children = domEl "video" props children

// Void element
let inline area props = voidEl "area" props
let inline ``base`` props = voidEl "base" props
let inline br props = voidEl "br" props
let inline col props = voidEl "col" props
let inline embed props = voidEl "embed" props
let inline hr props = voidEl "hr" props
let inline img props = voidEl "img" props
let inline input props = voidEl "input" props
let inline keygen props = voidEl "keygen" props
let inline link props = voidEl "link" props
let inline menuitem props = voidEl "menuitem" props
let inline meta props = voidEl "meta" props
let inline param props = voidEl "param" props
let inline source props = voidEl "source" props
let inline track props = voidEl "track" props
let inline wbr props = voidEl "wbr" props

// SVG elements
let inline svg props children = svgEl "svg" props children
let inline circle props children = svgEl "circle" props children
let inline clipPath props children = svgEl "clipPath" props children
let inline defs props children = svgEl "defs" props children
let inline ellipse props children = svgEl "ellipse" props children
let inline g props children = svgEl "g" props children
let inline image props children = svgEl "image" props children
let inline line props children = svgEl "line" props children
let inline linearGradient props children = svgEl "linearGradient" props children
let inline mask props children = svgEl "mask" props children
let inline path props children = svgEl "path" props children
let inline pattern props children = svgEl "pattern" props children
let inline polygon props children = svgEl "polygon" props children
let inline polyline props children = svgEl "polyline" props children
let inline radialGradient props children = svgEl "radialGradient" props children
let inline rect props children = svgEl "rect" props children
let inline stop props children = svgEl "stop" props children
let inline text props children = svgEl "text" props children
let inline tspan props children = svgEl "tspan" props children

// Class list helpers
let classBaseList std classes =
    classes
    |> List.fold (fun complete -> function | (name,true) -> complete + " " + name | _ -> complete) std
    |> ClassName

let classList classes = classBaseList "" classes

/// Finds a DOM element by its ID and mounts the React element there
let inline mountById (domElId: string) (reactEl: ReactElement): unit =
    ReactDom.render(reactEl, Browser.document.getElementById(domElId))

/// Finds the first DOM element matching a CSS selector and mounts the React element there
let inline mountBySelector (domElSelector: string) (reactEl: ReactElement): unit =
    ReactDom.render(reactEl, Browser.document.querySelector(domElSelector))

type Fable.Import.React.FormEvent with
    /// Access the value from target
    /// Equivalent to `(this.target :?> Browser.HTMLInputElement).value`
    member this.Value =
        (this.target :?> Browser.HTMLInputElement).value

    /// Access the checked property from target
    /// Equivalent to `(this.target :?> Browser.HTMLInputElement).checked`
    member this.Checked =
        (this.target :?> Browser.HTMLInputElement).``checked``

// Helpers for ReactiveComponents (see #44)
module ReactiveComponents =
    type Props<'P, 'S, 'Msg> = {
        key: string
        props: 'P
        update: 'Msg -> 'S -> 'S
        view: Model<'P, 'S> -> ('Msg->unit) -> ReactElement
        init: 'P -> 'S
    }

    and State<'T> = {
        value: 'T
    }

    and Model<'P, 'S> = {
        props: 'P
        state: 'S
        children: ReactElement[]
    }

open ReactiveComponents

type ReactiveCom<'P, 'S, 'Msg>(initProps) =
    inherit Component<Props<'P, 'S, 'Msg>, State<'S>>(initProps)
    do base.setInitState { value = initProps.init(initProps.props) }

    override this.render() =
        let model =
            { props = this.props.props
              state = this.state.value
              children = this.children }
        this.props.view model (fun msg ->
            let newState = this.props.update msg this.state.value
            this.setState(fun _ _ -> { value = newState }))

/// Renders a stateful React component from functions similar to Elmish
///  * `init` - Initializes component state with given props
///  * `update` - Updates the state when `dispatch` is triggered
///  * `view` - Render function, receives a `ReactiveComponents.Model` object and a `dispatch` function
///  * `key` - The key is necessary to identify React elements in a list, an empty string can be passed otherwise
///  * `props` - External properties passed to the component each time it's rendered, usually from its parent
///  * `children` - A list of children React elements
let reactiveCom<'P, 'S, 'Msg>
        (init: 'P -> 'S)
        (update: 'Msg -> 'S -> 'S)
        (view: Model<'P, 'S> -> ('Msg->unit) -> ReactElement)
        (key: string)
        (props: 'P)
        (children: ReactElement seq): ReactElement =
    ofType<ReactiveCom<'P, 'S, 'Msg>, Props<'P, 'S, 'Msg>, State<'S>>
        { key=key; props=props; update=update; view=view; init=init }
        children
