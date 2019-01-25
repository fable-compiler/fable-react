module rec Fable.React.Props

open Fable.Core
open Fable.Browser

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
    | Ref of (Dom.Element->unit)
    interface IHTMLProp

type DangerousHtml = {
    __html: string
}

type DOMAttr =
    | DangerouslySetInnerHTML of DangerousHtml
    | OnCut of (Dom.ClipboardEvent -> unit)
    | OnPaste of (Dom.ClipboardEvent -> unit)
    | OnCompositionEnd of (Dom.CompositionEvent -> unit)
    | OnCompositionStart of (Dom.CompositionEvent -> unit)
    | OnCopy of (Dom.ClipboardEvent -> unit)
    | OnCompositionUpdate of (Dom.CompositionEvent -> unit)
    | OnFocus of (Dom.FocusEvent -> unit)
    | OnBlur of (Dom.FocusEvent -> unit)
    | OnChange of (Dom.Event -> unit)
    | OnInput of (Dom.Event -> unit)
    | OnSubmit of (Dom.Event -> unit)
    | OnReset of (Dom.Event -> unit)
    | OnLoad of (Dom.Event -> unit)
    | OnError of (Dom.Event -> unit)
    | OnKeyDown of (Dom.KeyboardEvent -> unit)
    | OnKeyPress of (Dom.KeyboardEvent -> unit)
    | OnKeyUp of (Dom.KeyboardEvent -> unit)
    | OnAbort of (Dom.Event -> unit)
    | OnCanPlay of (Dom.Event -> unit)
    | OnCanPlayThrough of (Dom.Event -> unit)
    | OnDurationChange of (Dom.Event -> unit)
    | OnEmptied of (Dom.Event -> unit)
    | OnEncrypted of (Dom.Event -> unit)
    | OnEnded of (Dom.Event -> unit)
    | OnLoadedData of (Dom.Event -> unit)
    | OnLoadedMetadata of (Dom.Event -> unit)
    | OnLoadStart of (Dom.Event -> unit)
    | OnPause of (Dom.Event -> unit)
    | OnPlay of (Dom.Event -> unit)
    | OnPlaying of (Dom.Event -> unit)
    | OnProgress of (Dom.Event -> unit)
    | OnRateChange of (Dom.Event -> unit)
    | OnSeeked of (Dom.Event -> unit)
    | OnSeeking of (Dom.Event -> unit)
    | OnStalled of (Dom.Event -> unit)
    | OnSuspend of (Dom.Event -> unit)
    | OnTimeUpdate of (Dom.Event -> unit)
    | OnVolumeChange of (Dom.Event -> unit)
    | OnWaiting of (Dom.Event -> unit)
    | OnClick of (Dom.MouseEvent -> unit)
    | OnContextMenu of (Dom.MouseEvent -> unit)
    | OnDoubleClick of (Dom.MouseEvent -> unit)
    | OnDrag of (Dom.DragEvent -> unit)
    | OnDragEnd of (Dom.DragEvent -> unit)
    | OnDragEnter of (Dom.DragEvent -> unit)
    | OnDragExit of (Dom.DragEvent -> unit)
    | OnDragLeave of (Dom.DragEvent -> unit)
    | OnDragOver of (Dom.DragEvent -> unit)
    | OnDragStart of (Dom.DragEvent -> unit)
    | OnDrop of (Dom.DragEvent -> unit)
    | OnMouseDown of (Dom.MouseEvent -> unit)
    | OnMouseEnter of (Dom.MouseEvent -> unit)
    | OnMouseLeave of (Dom.MouseEvent -> unit)
    | OnMouseMove of (Dom.MouseEvent -> unit)
    | OnMouseOut of (Dom.MouseEvent -> unit)
    | OnMouseOver of (Dom.MouseEvent -> unit)
    | OnMouseUp of (Dom.MouseEvent -> unit)
    | OnSelect of (Dom.Event -> unit)
    | OnTouchCancel of (Dom.TouchEvent -> unit)
    | OnTouchEnd of (Dom.TouchEvent -> unit)
    | OnTouchMove of (Dom.TouchEvent -> unit)
    | OnTouchStart of (Dom.TouchEvent -> unit)
    | OnScroll of (Dom.UIEvent -> unit)
    | OnWheel of (Dom.WheelEvent -> unit)
    | OnAnimationStart of (Dom.AnimationEvent -> unit)
    | OnAnimationEnd of (Dom.AnimationEvent -> unit)
    | OnAnimationIteration of (Dom.AnimationEvent -> unit)
    | OnTransitionEnd of (Dom.TransitionEvent -> unit)
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
    | [<CompiledName("aria-controls")>] AriaControls of string
    | [<CompiledName("aria-expanded")>] AriaExpanded of bool
    | [<CompiledName("aria-haspopup")>] AriaHasPopup of bool
    | [<CompiledName("aria-pressed")>] AriaPressed of bool
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
