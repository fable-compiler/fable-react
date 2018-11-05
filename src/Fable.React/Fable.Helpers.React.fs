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

/// Instantiate an imported React component
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

[<RequireQualifiedAccess>]
module ReactElementType =
    let inline ofComponent<'comp, 'props, 'state when 'comp :> Component<'props, 'state>> : ReactComponentType<'props> =
        unbox jsConstructor<'comp>

    let inline ofFunction<'props> (f: 'props -> ReactElement) : ReactComponentType<'props> =
        unbox f

    let inline ofHtmlElement<'props> (name: string): ReactElementType<'props> =
        unbox name

    /// Create a ReactElement to be rendered from an element type, props and children
    let inline create<'props> (comp: ReactElementType<'props>) (props: 'props) (children: ReactElement seq): ReactElement =
        createElement(comp, props, children)

type PropsEqualityComparison<'props> = 'props -> 'props -> bool

[<Import("memo", from="react")>]
let private reactMemo<'props> (render: 'props -> ReactElement) : ReactComponentType<'props> =
    jsNative

/// React.memo is a higher order component. It’s similar to React.PureComponent but for function components instead of
/// classes.
///
/// If your function component renders the same result given the same props, you can wrap it in a call to React.memo
/// for a performance boost in some cases by memoizing the result. This means that React will skip rendering the
/// component, and reuse the last rendered result.
///
/// By default it will only shallowly compare complex objects in the props object. If you want control over the
/// comparison, you can use `memoWith`.
let memo<'props> (name: string) (render: 'props -> ReactElement) : ReactComponentType<'props> =
    render?displayName <- name
    reactMemo(render)

[<Import("memo", from="react")>]
let private reactMemoWith<'props> (render: 'props -> ReactElement, areEqual: PropsEqualityComparison<'props>) : ReactComponentType<'props> =
    jsNative

/// React.memo is a higher order component. It’s similar to React.PureComponent but for function components instead of
/// classes.
///
/// If your function component renders the same result given the same props, you can wrap it in a call to React.memo
/// for a performance boost in some cases by memoizing the result. This means that React will skip rendering the
/// component, and reuse the last rendered result.
///
/// This version allow you to control the comparison used instead of the default shallow one by provide a custom
/// comparison function.
let memoWith<'props> (name: string) (areEqual: PropsEqualityComparison<'props>) (render: 'props -> ReactElement) : ReactComponentType<'props> =
    render?displayName <- name
    reactMemoWith(render, areEqual)

/// Create a ReactElement to be rendered from an element type, props and children
let inline ofElementType<'props> (comp: ReactElementType<'props>) (props: 'props) (children: ReactElement seq): ReactElement =
    ReactElementType.create comp props children

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
let inline a b c = domEl "a" b c
let inline abbr b c = domEl "abbr" b c
let inline address b c = domEl "address" b c
let inline article b c = domEl "article" b c
let inline aside b c = domEl "aside" b c
let inline audio b c = domEl "audio" b c
let inline b b' c = domEl "b" b' c
let inline bdi b c = domEl "bdi" b c
let inline bdo b c = domEl "bdo" b c
let inline big b c = domEl "big" b c
let inline blockquote b c = domEl "blockquote" b c
let inline body b c = domEl "body" b c
let inline button b c = domEl "button" b c
let inline canvas b c = domEl "canvas" b c
let inline caption b c = domEl "caption" b c
let inline cite b c = domEl "cite" b c
let inline code b c = domEl "code" b c
let inline colgroup b c = domEl "colgroup" b c
let inline data b c = domEl "data" b c
let inline datalist b c = domEl "datalist" b c
let inline dd b c = domEl "dd" b c
let inline del b c = domEl "del" b c
let inline details b c = domEl "details" b c
let inline dfn b c = domEl "dfn" b c
let inline dialog b c = domEl "dialog" b c
let inline div b c = domEl "div" b c
let inline dl b c = domEl "dl" b c
let inline dt b c = domEl "dt" b c
let inline em b c = domEl "em" b c
let inline fieldset b c = domEl "fieldset" b c
let inline figcaption b c = domEl "figcaption" b c
let inline figure b c = domEl "figure" b c
let inline footer b c = domEl "footer" b c
let inline form b c = domEl "form" b c
let inline h1 b c = domEl "h1" b c
let inline h2 b c = domEl "h2" b c
let inline h3 b c = domEl "h3" b c
let inline h4 b c = domEl "h4" b c
let inline h5 b c = domEl "h5" b c
let inline h6 b c = domEl "h6" b c
let inline head b c = domEl "head" b c
let inline header b c = domEl "header" b c
let inline hgroup b c = domEl "hgroup" b c
let inline html b c = domEl "html" b c
let inline i b c = domEl "i" b c
let inline iframe b c = domEl "iframe" b c
let inline ins b c = domEl "ins" b c
let inline kbd b c = domEl "kbd" b c
let inline label b c = domEl "label" b c
let inline legend b c = domEl "legend" b c
let inline li b c = domEl "li" b c
let inline main b c = domEl "main" b c
let inline map b c = domEl "map" b c
let inline mark b c = domEl "mark" b c
let inline menu b c = domEl "menu" b c
let inline meter b c = domEl "meter" b c
let inline nav b c = domEl "nav" b c
let inline noscript b c = domEl "noscript" b c
let inline ``object`` b c = domEl "object" b c
let inline ol b c = domEl "ol" b c
let inline optgroup b c = domEl "optgroup" b c
let inline option b c = domEl "option" b c
let inline output b c = domEl "output" b c
let inline p b c = domEl "p" b c
let inline picture b c = domEl "picture" b c
let inline pre b c = domEl "pre" b c
let inline progress b c = domEl "progress" b c
let inline q b c = domEl "q" b c
let inline rp b c = domEl "rp" b c
let inline rt b c = domEl "rt" b c
let inline ruby b c = domEl "ruby" b c
let inline s b c = domEl "s" b c
let inline samp b c = domEl "samp" b c
let inline script b c = domEl "script" b c
let inline section b c = domEl "section" b c
let inline select b c = domEl "select" b c
let inline small b c = domEl "small" b c
let inline span b c = domEl "span" b c
let inline strong b c = domEl "strong" b c
let inline style b c = domEl "style" b c
let inline sub b c = domEl "sub" b c
let inline summary b c = domEl "summary" b c
let inline sup b c = domEl "sup" b c
let inline table b c = domEl "table" b c
let inline tbody b c = domEl "tbody" b c
let inline td b c = domEl "td" b c
let inline textarea b c = domEl "textarea" b c
let inline tfoot b c = domEl "tfoot" b c
let inline th b c = domEl "th" b c
let inline thead b c = domEl "thead" b c
let inline time b c = domEl "time" b c
let inline title b c = domEl "title" b c
let inline tr b c = domEl "tr" b c
let inline u b c = domEl "u" b c
let inline ul b c = domEl "ul" b c
let inline var b c = domEl "var" b c
let inline video b c = domEl "video" b c

// Void element
let inline area b = voidEl "area" b
let inline ``base`` b = voidEl "base" b
let inline br b = voidEl "br" b
let inline col b = voidEl "col" b
let inline embed b = voidEl "embed" b
let inline hr b = voidEl "hr" b
let inline img b = voidEl "img" b
let inline input b = voidEl "input" b
let inline keygen b = voidEl "keygen" b
let inline link b = voidEl "link" b
let inline menuitem b = voidEl "menuitem" b
let inline meta b = voidEl "meta" b
let inline param b = voidEl "param" b
let inline source b = voidEl "source" b
let inline track b = voidEl "track" b
let inline wbr b = voidEl "wbr" b

// SVG elements
let inline svg b c = svgEl "svg" b c
let inline circle b c = svgEl "circle" b c
let inline clipPath b c = svgEl "clipPath" b c
let inline defs b c = svgEl "defs" b c
let inline ellipse b c = svgEl "ellipse" b c
let inline g b c = svgEl "g" b c
let inline image b c = svgEl "image" b c
let inline line b c = svgEl "line" b c
let inline linearGradient b c = svgEl "linearGradient" b c
let inline mask b c = svgEl "mask" b c
let inline path b c = svgEl "path" b c
let inline pattern b c = svgEl "pattern" b c
let inline polygon b c = svgEl "polygon" b c
let inline polyline b c = svgEl "polyline" b c
let inline radialGradient b c = svgEl "radialGradient" b c
let inline rect b c = svgEl "rect" b c
let inline stop b c = svgEl "stop" b c
let inline text b c = svgEl "text" b c
let inline tspan b c = svgEl "tspan" b c

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
