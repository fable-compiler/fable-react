module Fable.Helpers.React

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

let [<Erase; Literal>] private React = "react"

module Props =
    [<KeyValueList>]
    type ICSSProp =
        interface end

    [<KeyValueList>]
    type CSSProp =
        | BoxFlex of float
        | BoxFlexGroup of float
        | ColumnCount of float
        | Flex of U2<float, string>
        | FlexGrow of float
        | FlexShrink of float
        | FontWeight of U2<float, string>
        | LineClamp of float
        | LineHeight of U2<float, string>
        | Opacity of float
        | Order of float
        | Orphans of float
        | Widows of float
        | ZIndex of float
        | Zoom of float
        | FontSize of U2<float, string>
        | FillOpacity of float
        | StrokeOpacity of float
        | StrokeWidth of float
        | AlignContent of obj
        | AlignItems of obj
        | AlignSelf of obj
        | AlignmentAdjust of obj
        | AlignmentBaseline of obj
        | AnimationDelay of obj
        | AnimationDirection of obj
        | AnimationIterationCount of obj
        | AnimationName of obj
        | AnimationPlayState of obj
        | Appearance of obj
        | BackfaceVisibility of obj
        | BackgroundBlendMode of obj
        | BackgroundColor of obj
        | BackgroundComposite of obj
        | BackgroundImage of obj
        | BackgroundOrigin of obj
        | BackgroundPositionX of obj
        | BackgroundRepeat of obj
        | BaselineShift of obj
        | Behavior of obj
        | Border of obj
        | BorderBottomLeftRadius of obj
        | BorderBottomRightRadius of obj
        | BorderBottomWidth of obj
        | BorderCollapse of obj
        | BorderColor of obj
        | BorderCornerShape of obj
        | BorderImageSource of obj
        | BorderImageWidth of obj
        | BorderLeft of obj
        | BorderLeftColor of obj
        | BorderLeftStyle of obj
        | BorderLeftWidth of obj
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
        | BoxLineProgression of obj
        | BoxLines of obj
        | BoxOrdinalGroup of obj
        | BreakAfter of obj
        | BreakBefore of obj
        | BreakInside of obj
        | Clear of obj
        | Clip of obj
        | ClipRule of obj
        | Color of obj
        | ColumnFill of obj
        | ColumnGap of obj
        | ColumnRule of obj
        | ColumnRuleColor of obj
        | ColumnRuleWidth of obj
        | ColumnSpan of obj
        | ColumnWidth of obj
        | Columns of obj
        | CounterIncrement of obj
        | CounterReset of obj
        | Cue of obj
        | CueAfter of obj
        | Direction of obj
        | Display of obj
        | Fill of obj
        | FillRule of obj
        | Filter of obj
        | FlexAlign of obj
        | FlexBasis of obj
        | FlexDirection of obj
        | FlexFlow of obj
        | FlexItemAlign of obj
        | FlexLinePack of obj
        | FlexOrder of obj
        | Float of obj
        | FlowFrom of obj
        | Font of obj
        | FontFamily of obj
        | FontKerning of obj
        | FontSizeAdjust of obj
        | FontStretch of obj
        | FontStyle of obj
        | FontSynthesis of obj
        | FontVariant of obj
        | FontVariantAlternates of obj
        | GridArea of obj
        | GridColumn of obj
        | GridColumnEnd of obj
        | GridColumnStart of obj
        | GridRow of obj
        | GridRowEnd of obj
        | GridRowPosition of obj
        | GridRowSpan of obj
        | GridTemplateAreas of obj
        | GridTemplateColumns of obj
        | GridTemplateRows of obj
        | Height of obj
        | HyphenateLimitChars of obj
        | HyphenateLimitLines of obj
        | HyphenateLimitZone of obj
        | Hyphens of obj
        | ImeMode of obj
        | LayoutGrid of obj
        | LayoutGridChar of obj
        | LayoutGridLine of obj
        | LayoutGridMode of obj
        | LayoutGridType of obj
        | Left of obj
        | LetterSpacing of obj
        | LineBreak of obj
        | ListStyle of obj
        | ListStyleImage of obj
        | ListStylePosition of obj
        | ListStyleType of obj
        | Margin of obj
        | MarginBottom of obj
        | MarginLeft of obj
        | MarginRight of obj
        | MarginTop of obj
        | MarqueeDirection of obj
        | MarqueeStyle of obj
        | Mask of obj
        | MaskBorder of obj
        | MaskBorderRepeat of obj
        | MaskBorderSlice of obj
        | MaskBorderSource of obj
        | MaskBorderWidth of obj
        | MaskClip of obj
        | MaskOrigin of obj
        | MaxFontSize of obj
        | MaxHeight of obj
        | MaxWidth of obj
        | MinHeight of obj
        | MinWidth of obj
        | Outline of obj
        | OutlineColor of obj
        | OutlineOffset of obj
        | Overflow of obj
        | OverflowStyle of obj
        | OverflowX of obj
        | Padding of obj
        | PaddingBottom of obj
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
        | RestAfter of obj
        | RestBefore of obj
        | Right of obj
        | RubyAlign of obj
        | RubyPosition of obj
        | ShapeImageThreshold of obj
        | ShapeInside of obj
        | ShapeMargin of obj
        | ShapeOutside of obj
        | Speak of obj
        | SpeakAs of obj
        | TabSize of obj
        | TableLayout of obj
        | TextAlign of obj
        | TextAlignLast of obj
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
        | TextEmphasisStyle of obj
        | TextHeight of obj
        | TextIndent of obj
        | TextJustifyTrim of obj
        | TextKashidaSpace of obj
        | TextLineThrough of obj
        | TextLineThroughColor of obj
        | TextLineThroughMode of obj
        | TextLineThroughStyle of obj
        | TextLineThroughWidth of obj
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
        | Width of obj
        | WordBreak of obj
        | WordSpacing of obj
        | WordWrap of obj
        | WrapFlow of obj
        | WrapMargin of obj
        | WrapOption of obj
        | WritingMode of obj
        interface ICSSProp

    [<KeyValueList>]
    type IProp =
        interface end

    [<KeyValueList>]
    type IHTMLProp =
        inherit IProp

    [<KeyValueList>]
    type Prop =
        | Key of string
        | Ref of (obj->unit)
        interface IHTMLProp

    [<KeyValueList>]
    type DOMAttr =
        | DangerouslySetInnerHTML of obj
        | OnCopy of (React.ClipboardEvent -> unit)
        | OnCut of (React.ClipboardEvent -> unit)
        | OnPaste of (React.ClipboardEvent -> unit)
        | OnCompositionEnd of (React.CompositionEvent -> unit)
        | OnCompositionStart of (React.CompositionEvent -> unit)
        | OnCompositionUpdate of (React.CompositionEvent -> unit)
        | OnFocus of (React.FocusEvent -> unit)
        | OnBlur of (React.FocusEvent -> unit)
        | OnChange of (React.FormEvent -> unit)
        | OnInput of (React.FormEvent -> unit)
        | OnSubmit of (React.FormEvent -> unit)
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
        interface IHTMLProp

    [<KeyValueList>]
    type HTMLAttr =
        | DefaultChecked of bool
        | DefaultValue of U2<string, ResizeArray<string>>
        | Accept of string
        | AcceptCharset of string
        | AccessKey of string
        | Action of string
        | AllowFullScreen of bool
        | AllowTransparency of bool
        | Alt of string
        | Async of bool
        | AutoComplete of string
        | AutoFocus of bool
        | AutoPlay of bool
        | Capture of bool
        | CellPadding of U2<float, string>
        | CellSpacing of U2<float, string>
        | CharSet of string
        | Challenge of string
        | Checked of bool
        | ClassID of string
        | ClassName of string
        | Cols of float
        | ColSpan of float
        | Content of string
        | ContentEditable of bool
        | ContextMenu of string
        | Controls of bool
        | Coords of string
        | CrossOrigin of string
        | Data of string
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
        | FrameBorder of U2<float, string>
        | Headers of string
        // | Height of U2<float, string> // Conflicts with CSSProp, shouldn't be used in HTML5
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
        | Max of U2<float, string>
        | MaxLength of float
        | Media of string
        | MediaGroup of string
        | Method of string
        | Min of U2<float, string>
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
        | Rows of float
        | RowSpan of float
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
        | Step of U2<float, string>
        | Style of ICSSProp list
        | Summary of string
        | TabIndex of float
        | Target of string
        | Title of string
        | Type of string
        | UseMap of string
        | Value of U2<string, ResizeArray<string>>
        | Width of U2<float, string>
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
        interface IHTMLProp

    [<KeyValueList>]
    type SVGAttr =
        | ClipPath of string
        | Cx of U2<float, string>
        | Cy of U2<float, string>
        | D of string
        | Dx of U2<float, string>
        | Dy of U2<float, string>
        | Fill of string
        | FillOpacity of U2<float, string>
        | FontFamily of string
        | FontSize of U2<float, string>
        | Fx of U2<float, string>
        | Fy of U2<float, string>
        | GradientTransform of string
        | GradientUnits of string
        | MarkerEnd of string
        | MarkerMid of string
        | MarkerStart of string
        | Offset of U2<float, string>
        | Opacity of U2<float, string>
        | PatternContentUnits of string
        | PatternUnits of string
        | Points of string
        | PreserveAspectRatio of string
        | R of U2<float, string>
        | Rx of U2<float, string>
        | Ry of U2<float, string>
        | SpreadMethod of string
        | StopColor of string
        | StopOpacity of U2<float, string>
        | Stroke of string
        | StrokeDasharray of string
        | StrokeLinecap of string
        | StrokeMiterlimit of string
        | StrokeOpacity of U2<float, string>
        | StrokeWidth of U2<float, string>
        | TextAnchor of string
        | Transform of string
        | Version of string
        | ViewBox of string
        | X1 of U2<float, string>
        | X2 of U2<float, string>
        | X of U2<float, string>
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
        | Y1 of U2<float, string>
        | Y2 of U2<float, string>
        | Y of U2<float, string>
        interface IProp

open Props

/// Instantiate a stateless component from a function
[<Import("createElement", from=React)>]
[<Emit("$0($1, $replace:Fable.Core.JsInterop.toPlainJsObj($2), $replace:Hack.toArrayNonEmpty($3))")>]
let fn (f: 'Props -> #React.ReactElement<obj>) (props: 'Props) (children: React.ReactElement<obj> list): React.ReactElement<obj> = jsNative

/// Instantiate a React component from a type inheriting React.Component<>
[<Import("createElement", from=React)>]
[<Emit("$0($'T, $replace:Fable.Core.JsInterop.toPlainJsObj($1), $replace:Hack.toArrayNonEmpty($2))")>]
let com<'T,'P,'S when 'T :> React.Component<'P,'S>> (props: 'P) (children: React.ReactElement<obj> list): React.ReactElement<obj> = jsNative

/// Instantiate an imported React component
[<Import("createElement", from=React)>]
[<Emit("$0($1, $replace:Fable.Core.JsInterop.toPlainJsObj($2), $replace:Hack.toArrayNonEmpty($3))")>]
let from<'P> (com: React.ComponentClass<'P>) (props: 'P) (children: React.ReactElement<obj> list): React.ReactElement<obj> = jsNative

/// Instantiate a DOM React element
[<Import("createElement", from=React)>]
[<Emit("$0($1, $2, $replace:Hack.toArrayNonEmpty($3))")>]
let domEl (tag: string) (props: IHTMLProp list) (children: React.ReactElement<obj> list): React.ReactElement<obj> = jsNative

/// Instantiate an SVG React element
[<Import("createElement", from=React)>]
[<Emit("$0($1, $2, $replace:Hack.toArrayNonEmpty($3))")>]
let svgEl (tag: string) (props: #IProp list) (children: React.ReactElement<obj> list): React.ReactElement<obj> = jsNative

[<Import("createElement", from=React); Emit("$0('a', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let a b c = domEl "a" b c
[<Import("createElement", from=React); Emit("$0('abbr', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let abbr b c = domEl "abbr" b c
[<Import("createElement", from=React); Emit("$0('address', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let address b c = domEl "address" b c
[<Import("createElement", from=React); Emit("$0('area', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let area b c = domEl "area" b c
[<Import("createElement", from=React); Emit("$0('article', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let article b c = domEl "article" b c
[<Import("createElement", from=React); Emit("$0('aside', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let aside b c = domEl "aside" b c
[<Import("createElement", from=React); Emit("$0('audio', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let audio b c = domEl "audio" b c
[<Import("createElement", from=React); Emit("$0('b', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let b b' c = domEl "b" b' c
[<Import("createElement", from=React); Emit("$0('base', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let ``base`` b c = domEl "base" b c
[<Import("createElement", from=React); Emit("$0('bdi', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let bdi b c = domEl "bdi" b c
[<Import("createElement", from=React); Emit("$0('bdo', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let bdo b c = domEl "bdo" b c
[<Import("createElement", from=React); Emit("$0('big', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let big b c = domEl "big" b c
[<Import("createElement", from=React); Emit("$0('blockquote', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let blockquote b c = domEl "blockquote" b c
[<Import("createElement", from=React); Emit("$0('body', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let body b c = domEl "body" b c
[<Import("createElement", from=React); Emit("$0('br', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let br b c = domEl "br" b c
[<Import("createElement", from=React); Emit("$0('button', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let button b c = domEl "button" b c
[<Import("createElement", from=React); Emit("$0('canvas', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let canvas b c = domEl "canvas" b c
[<Import("createElement", from=React); Emit("$0('caption', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let caption b c = domEl "caption" b c
[<Import("createElement", from=React); Emit("$0('cite', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let cite b c = domEl "cite" b c
[<Import("createElement", from=React); Emit("$0('code', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let code b c = domEl "code" b c
[<Import("createElement", from=React); Emit("$0('col', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let col b c = domEl "col" b c
[<Import("createElement", from=React); Emit("$0('colgroup', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let colgroup b c = domEl "colgroup" b c
[<Import("createElement", from=React); Emit("$0('data', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let data b c = domEl "data" b c
[<Import("createElement", from=React); Emit("$0('datalist', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let datalist b c = domEl "datalist" b c
[<Import("createElement", from=React); Emit("$0('dd', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let dd b c = domEl "dd" b c
[<Import("createElement", from=React); Emit("$0('del', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let del b c = domEl "del" b c
[<Import("createElement", from=React); Emit("$0('details', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let details b c = domEl "details" b c
[<Import("createElement", from=React); Emit("$0('dfn', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let dfn b c = domEl "dfn" b c
[<Import("createElement", from=React); Emit("$0('dialog', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let dialog b c = domEl "dialog" b c
[<Import("createElement", from=React); Emit("$0('div', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let div b c = domEl "div" b c
[<Import("createElement", from=React); Emit("$0('dl', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let dl b c = domEl "dl" b c
[<Import("createElement", from=React); Emit("$0('dt', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let dt b c = domEl "dt" b c
[<Import("createElement", from=React); Emit("$0('em', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let em b c = domEl "em" b c
[<Import("createElement", from=React); Emit("$0('embed', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let embed b c = domEl "embed" b c
[<Import("createElement", from=React); Emit("$0('fieldset', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let fieldset b c = domEl "fieldset" b c
[<Import("createElement", from=React); Emit("$0('figcaption', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let figcaption b c = domEl "figcaption" b c
[<Import("createElement", from=React); Emit("$0('figure', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let figure b c = domEl "figure" b c
[<Import("createElement", from=React); Emit("$0('footer', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let footer b c = domEl "footer" b c
[<Import("createElement", from=React); Emit("$0('form', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let form b c = domEl "form" b c
[<Import("createElement", from=React); Emit("$0('h1', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let h1 b c = domEl "h1" b c
[<Import("createElement", from=React); Emit("$0('h2', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let h2 b c = domEl "h2" b c
[<Import("createElement", from=React); Emit("$0('h3', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let h3 b c = domEl "h3" b c
[<Import("createElement", from=React); Emit("$0('h4', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let h4 b c = domEl "h4" b c
[<Import("createElement", from=React); Emit("$0('h5', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let h5 b c = domEl "h5" b c
[<Import("createElement", from=React); Emit("$0('h6', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let h6 b c = domEl "h6" b c
[<Import("createElement", from=React); Emit("$0('head', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let head b c = domEl "head" b c
[<Import("createElement", from=React); Emit("$0('header', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let header b c = domEl "header" b c
[<Import("createElement", from=React); Emit("$0('hgroup', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let hgroup b c = domEl "hgroup" b c
[<Import("createElement", from=React); Emit("$0('hr', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let hr b c = domEl "hr" b c
[<Import("createElement", from=React); Emit("$0('html', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let html b c = domEl "html" b c
[<Import("createElement", from=React); Emit("$0('i', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let i b c = domEl "i" b c
[<Import("createElement", from=React); Emit("$0('iframe', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let iframe b c = domEl "iframe" b c
[<Import("createElement", from=React); Emit("$0('img', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let img b c = domEl "img" b c
[<Import("createElement", from=React); Emit("$0('input', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let input b c = domEl "input" b c
[<Import("createElement", from=React); Emit("$0('ins', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let ins b c = domEl "ins" b c
[<Import("createElement", from=React); Emit("$0('kbd', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let kbd b c = domEl "kbd" b c
[<Import("createElement", from=React); Emit("$0('keygen', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let keygen b c = domEl "keygen" b c
[<Import("createElement", from=React); Emit("$0('label', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let label b c = domEl "label" b c
[<Import("createElement", from=React); Emit("$0('legend', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let legend b c = domEl "legend" b c
[<Import("createElement", from=React); Emit("$0('li', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let li b c = domEl "li" b c
[<Import("createElement", from=React); Emit("$0('link', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let link b c = domEl "link" b c
[<Import("createElement", from=React); Emit("$0('main', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let main b c = domEl "main" b c
[<Import("createElement", from=React); Emit("$0('map', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let map b c = domEl "map" b c
[<Import("createElement", from=React); Emit("$0('mark', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let mark b c = domEl "mark" b c
[<Import("createElement", from=React); Emit("$0('menu', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let menu b c = domEl "menu" b c
[<Import("createElement", from=React); Emit("$0('menuitem', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let menuitem b c = domEl "menuitem" b c
[<Import("createElement", from=React); Emit("$0('meta', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let meta b c = domEl "meta" b c
[<Import("createElement", from=React); Emit("$0('meter', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let meter b c = domEl "meter" b c
[<Import("createElement", from=React); Emit("$0('nav', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let nav b c = domEl "nav" b c
[<Import("createElement", from=React); Emit("$0('noscript', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let noscript b c = domEl "noscript" b c
[<Import("createElement", from=React); Emit("$0('object', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let ``object`` b c = domEl "object" b c
[<Import("createElement", from=React); Emit("$0('ol', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let ol b c = domEl "ol" b c
[<Import("createElement", from=React); Emit("$0('optgroup', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let optgroup b c = domEl "optgroup" b c
[<Import("createElement", from=React); Emit("$0('option', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let option b c = domEl "option" b c
[<Import("createElement", from=React); Emit("$0('output', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let output b c = domEl "output" b c
[<Import("createElement", from=React); Emit("$0('p', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let p b c = domEl "p" b c
[<Import("createElement", from=React); Emit("$0('param', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let param b c = domEl "param" b c
[<Import("createElement", from=React); Emit("$0('picture', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let picture b c = domEl "picture" b c
[<Import("createElement", from=React); Emit("$0('pre', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let pre b c = domEl "pre" b c
[<Import("createElement", from=React); Emit("$0('progress', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let progress b c = domEl "progress" b c
[<Import("createElement", from=React); Emit("$0('q', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let q b c = domEl "q" b c
[<Import("createElement", from=React); Emit("$0('rp', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let rp b c = domEl "rp" b c
[<Import("createElement", from=React); Emit("$0('rt', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let rt b c = domEl "rt" b c
[<Import("createElement", from=React); Emit("$0('ruby', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let ruby b c = domEl "ruby" b c
[<Import("createElement", from=React); Emit("$0('s', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let s b c = domEl "s" b c
[<Import("createElement", from=React); Emit("$0('samp', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let samp b c = domEl "samp" b c
[<Import("createElement", from=React); Emit("$0('script', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let script b c = domEl "script" b c
[<Import("createElement", from=React); Emit("$0('section', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let section b c = domEl "section" b c
[<Import("createElement", from=React); Emit("$0('select', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let select b c = domEl "select" b c
[<Import("createElement", from=React); Emit("$0('small', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let small b c = domEl "small" b c
[<Import("createElement", from=React); Emit("$0('source', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let source b c = domEl "source" b c
[<Import("createElement", from=React); Emit("$0('span', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let span b c = domEl "span" b c
[<Import("createElement", from=React); Emit("$0('strong', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let strong b c = domEl "strong" b c
[<Import("createElement", from=React); Emit("$0('style', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let style b c = domEl "style" b c
[<Import("createElement", from=React); Emit("$0('sub', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let sub b c = domEl "sub" b c
[<Import("createElement", from=React); Emit("$0('summary', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let summary b c = domEl "summary" b c
[<Import("createElement", from=React); Emit("$0('sup', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let sup b c = domEl "sup" b c
[<Import("createElement", from=React); Emit("$0('table', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let table b c = domEl "table" b c
[<Import("createElement", from=React); Emit("$0('tbody', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let tbody b c = domEl "tbody" b c
[<Import("createElement", from=React); Emit("$0('td', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let td b c = domEl "td" b c
[<Import("createElement", from=React); Emit("$0('textarea', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let textarea b c = domEl "textarea" b c
[<Import("createElement", from=React); Emit("$0('tfoot', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let tfoot b c = domEl "tfoot" b c
[<Import("createElement", from=React); Emit("$0('th', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let th b c = domEl "th" b c
[<Import("createElement", from=React); Emit("$0('thead', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let thead b c = domEl "thead" b c
[<Import("createElement", from=React); Emit("$0('time', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let time b c = domEl "time" b c
[<Import("createElement", from=React); Emit("$0('title', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let title b c = domEl "title" b c
[<Import("createElement", from=React); Emit("$0('tr', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let tr b c = domEl "tr" b c
[<Import("createElement", from=React); Emit("$0('track', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let track b c = domEl "track" b c
[<Import("createElement", from=React); Emit("$0('u', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let u b c = domEl "u" b c
[<Import("createElement", from=React); Emit("$0('ul', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let ul b c = domEl "ul" b c
[<Import("createElement", from=React); Emit("$0('var', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let var b c = domEl "var" b c
[<Import("createElement", from=React); Emit("$0('video', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let video b c = domEl "video" b c
[<Import("createElement", from=React); Emit("$0('wbr', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let wbr b c = domEl "wbr" b c
[<Import("createElement", from=React); Emit("$0('svg', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let svg b c = svgEl "svg" b c
[<Import("createElement", from=React); Emit("$0('circle', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let circle b c = svgEl "circle" b c
[<Import("createElement", from=React); Emit("$0('clipPath', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let clipPath b c = svgEl "clipPath" b c
[<Import("createElement", from=React); Emit("$0('defs', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let defs b c = svgEl "defs" b c
[<Import("createElement", from=React); Emit("$0('ellipse', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let ellipse b c = svgEl "ellipse" b c
[<Import("createElement", from=React); Emit("$0('g', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let g b c = svgEl "g" b c
[<Import("createElement", from=React); Emit("$0('image', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let image b c = svgEl "image" b c
[<Import("createElement", from=React); Emit("$0('line', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let line b c = svgEl "line" b c
[<Import("createElement", from=React); Emit("$0('linearGradient', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let linearGradient b c = svgEl "linearGradient" b c
[<Import("createElement", from=React); Emit("$0('mask', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let mask b c = svgEl "mask" b c
[<Import("createElement", from=React); Emit("$0('path', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let path b c = svgEl "path" b c
[<Import("createElement", from=React); Emit("$0('pattern', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let pattern b c = svgEl "pattern" b c
[<Import("createElement", from=React); Emit("$0('polygon', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let polygon b c = svgEl "polygon" b c
[<Import("createElement", from=React); Emit("$0('polyline', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let polyline b c = svgEl "polyline" b c
[<Import("createElement", from=React); Emit("$0('radialGradient', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let radialGradient b c = svgEl "radialGradient" b c
[<Import("createElement", from=React); Emit("$0('rect', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let rect b c = svgEl "rect" b c
[<Import("createElement", from=React); Emit("$0('stop', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let stop b c = svgEl "stop" b c
[<Import("createElement", from=React); Emit("$0('text', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let text b c = svgEl "text" b c
[<Import("createElement", from=React); Emit("$0('tspan', $1, $replace:Hack.toArrayNonEmpty($2))")>]
let tspan b c = svgEl "tspan" b c

/// Cast a string to a React element (erased in runtime)
let [<Emit("$0")>] str (s: string): React.ReactElement<obj> = unbox s
/// Cast an option value to a React element (erased in runtime)
let [<Emit("$0")>] opt (o: React.ReactElement<obj> option): React.ReactElement<obj> = unbox o
