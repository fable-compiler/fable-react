module Fable.ReactServer

#if !FABLE_COMPILER
open System.IO
open System.Text.RegularExpressions
open Fable.React
open Fable.React.Props
open System.Collections.Concurrent
open System.Collections.Generic

// Adapted from https://github.com/emotion-js/emotion/blob/182e34bab2b2028c96d513b67ed86faee1b642b2/packages/emotion-utils/src/index.js#L13
let private unitlessCssProps = HashSet ["animation-iteration-count"; "border-image-outset"; "border-image-slice"; "border-image-width"; "box-flex"; "box-flex-group"; "box-ordinal-group"; "column-count"; "columns"; "flex"; "flex-grow"; "flex-positive"; "flex-shrink"; "flex-negative"; "flex-order"; "grid-row"; "grid-row-end"; "grid-row-span"; "grid-row-start"; "grid-column"; "grid-column-end"; "grid-column-span"; "grid-column-start"; "font-weight"; "line-height"; "opacity"; "order"; "orphans"; "tab-size"; "widows"; "z-index"; "zoom"; "-webkit-line-clamp"; "fill-opacity"; "flood-opacity"; "stop-opacity"; "stroke-dasharray"; "stroke-dashoffset"; "stroke-miterlimit"; "stroke-opacity"; "stroke-width"]

let private voidTags = HashSet ["area"; "base"; "br"; "col"; "embed"; "hr"; "img"; "input"; "keygen"; "link"; "menuitem"; "meta"; "param"; "source"; "track"; "wbr"]

// Adapted from https://github.com/facebook/react/blob/37e4329bc81def4695211d6e3795a654ef4d84f5/packages/react-dom/src/server/escapeTextForBrowser.js#L49
let escapeHtml (sb:TextWriter) (str: string) =
  if isNull str then () else
  for c in str.ToCharArray() do
    match c with
    | '"' -> sb.Write("&quot")
    | '&' -> sb.Write("&amp;")
    | ''' -> sb.Write("&#x27;") // modified from escape-html; used to be '&#39'
    | '<' -> sb.Write("&lt;")
    | '>' -> sb.Write("&gt;")
    | c   -> sb.Write(c)

let inline private addUnit (html:TextWriter) (key: string) (value: string) =
  html.Write value
  if not (unitlessCssProps.Contains key) then
    html.Write "px"

let private cssPropsCache = ConcurrentDictionary<obj, string>()

let private cssProp (html:TextWriter) (key: string) (value: obj) =
  html.Write key
  html.Write ':'

  match value with
  | :? int as v -> addUnit html key (string v)
  | :? float as v -> addUnit html key (string v)
  | _ ->
    let getStringFromObj(v)=
        let isStringEnum = v.GetType().GetCustomAttributes(false)
                          |> Seq.exists (function
                              | :? Core.StringEnumAttribute -> true
                              | _ -> false)
        if isStringEnum then stringEnum v else v.ToString()
    
    let cssProp = cssPropsCache.GetOrAdd(value,System.Func<obj,string>(getStringFromObj))
    escapeHtml html cssProp

let private slugRegex = Regex("([A-Z])", RegexOptions.Compiled)
let inline private slugKey key =
  slugRegex.Replace(string key, "-$1").ToLower()

let private renderCssProp (html:TextWriter) (prop: CSSProp) =
  match prop with
  | AlignContent v -> cssProp html "align-content" v
  | AlignItems v -> cssProp html "align-items" v
  | AlignSelf v -> cssProp html "align-self" v
  | AlignmentAdjust v -> cssProp html "alignment-adjust" v
  | AlignmentBaseline v -> cssProp html "alignment-baseline" v
  | All v -> cssProp html "all" v
  | Animation v -> cssProp html "animation" v
  | AnimationDelay v -> cssProp html "animation-delay" v
  | AnimationDirection v -> cssProp html "animation-direction" v
  | AnimationDuration v -> cssProp html "animation-duration" v
  | AnimationFillMode v -> cssProp html "animation-fill-mode" v
  | AnimationIterationCount v -> cssProp html "animation-iteration-count" v
  | AnimationName v -> cssProp html "animation-name" v
  | AnimationPlayState v -> cssProp html "animation-play-state" v
  | AnimationTimingFunction v -> cssProp html "animation-timing-function" v
  | Appearance v -> cssProp html "appearance" v
  | BackfaceVisibility v -> cssProp html "backface-visibility" v
  | Background v -> cssProp html "background" v
  | BackgroundAttachment v -> cssProp html "background-attachment" v
  | BackgroundBlendMode v -> cssProp html "background-blend-mode" v
  | BackgroundClip v -> cssProp html "background-clip" v
  | BackgroundColor v -> cssProp html "background-color" v
  | BackgroundComposite v -> cssProp html "background-composite" v
  | BackgroundImage v -> cssProp html "background-image" v
  | BackgroundOrigin v -> cssProp html "background-origin" v
  | BackgroundPosition v -> cssProp html "background-position" v
  | BackgroundPositionX v -> cssProp html "background-position-x" v
  | BackgroundPositionY v -> cssProp html "background-position-y" v
  | BackgroundRepeat v -> cssProp html "background-repeat" v
  | BackgroundSize v -> cssProp html "background-size" v
  | BaselineShift v -> cssProp html "baseline-shift" v
  | Behavior v -> cssProp html "behavior" v
  | BlockSize v -> cssProp html "block-size" v
  | Border v -> cssProp html "border" v
  | BorderBlockEnd v -> cssProp html "border-block-end" v
  | BorderBlockEndColor v -> cssProp html "border-block-end-color" v
  | BorderBlockEndStyle v -> cssProp html "border-block-end-style" v
  | BorderBlockEndWidth v -> cssProp html "border-block-end-width" v
  | BorderBlockStart v -> cssProp html "border-block-start" v
  | BorderBlockStartColor v -> cssProp html "border-block-start-color" v
  | BorderBlockStartStyle v -> cssProp html "border-block-start-style" v
  | BorderBlockStartWidth v -> cssProp html "border-block-start-width" v
  | BorderBottom v -> cssProp html "border-bottom" v
  | BorderBottomColor v -> cssProp html "border-bottom-color" v
  | BorderBottomLeftRadius v -> cssProp html "border-bottom-left-radius" v
  | BorderBottomRightRadius v -> cssProp html "border-bottom-right-radius" v
  | BorderBottomStyle v -> cssProp html "border-bottom-style" v
  | BorderBottomWidth v -> cssProp html "border-bottom-width" v
  | BorderCollapse v -> cssProp html "border-collapse" v
  | BorderColor v -> cssProp html "border-color" v
  | BorderCornerShape v -> cssProp html "border-corner-shape" v
  | BorderImage v -> cssProp html "border-image" v
  | BorderImageOutset v -> cssProp html "border-image-outset" v
  | BorderImageRepeat v -> cssProp html "border-image-repeat" v
  | BorderImageSlice v -> cssProp html "border-image-slice" v
  | BorderImageSource v -> cssProp html "border-image-source" v
  | BorderImageWidth v -> cssProp html "border-image-width" v
  | BorderInlineEnd v -> cssProp html "border-inline-end" v
  | BorderInlineEndColor v -> cssProp html "border-inline-end-color" v
  | BorderInlineEndStyle v -> cssProp html "border-inline-end-style" v
  | BorderInlineEndWidth v -> cssProp html "border-inline-end-width" v
  | BorderInlineStart v -> cssProp html "border-inline-start" v
  | BorderInlineStartColor v -> cssProp html "border-inline-start-color" v
  | BorderInlineStartStyle v -> cssProp html "border-inline-start-style" v
  | BorderInlineStartWidth v -> cssProp html "border-inline-start-width" v
  | BorderLeft v -> cssProp html "border-left" v
  | BorderLeftColor v -> cssProp html "border-left-color" v
  | BorderLeftStyle v -> cssProp html "border-left-style" v
  | BorderLeftWidth v -> cssProp html "border-left-width" v
  | BorderRadius v -> cssProp html "border-radius" v
  | BorderRight v -> cssProp html "border-right" v
  | BorderRightColor v -> cssProp html "border-right-color" v
  | BorderRightStyle v -> cssProp html "border-right-style" v
  | BorderRightWidth v -> cssProp html "border-right-width" v
  | BorderSpacing v -> cssProp html "border-spacing" v
  | BorderStyle v -> cssProp html "border-style" v
  | BorderTop v -> cssProp html "border-top" v
  | BorderTopColor v -> cssProp html "border-top-color" v
  | BorderTopLeftRadius v -> cssProp html "border-top-left-radius" v
  | BorderTopRightRadius v -> cssProp html "border-top-right-radius" v
  | BorderTopStyle v -> cssProp html "border-top-style" v
  | BorderTopWidth v -> cssProp html "border-top-width" v
  | BorderWidth v -> cssProp html "border-width" v
  | Bottom v -> cssProp html "bottom" v
  | BoxAlign v -> cssProp html "box-align" v
  | BoxDecorationBreak v -> cssProp html "box-decoration-break" v
  | BoxDirection v -> cssProp html "box-direction" v
  | BoxFlex v -> cssProp html "box-flex" v
  | BoxFlexGroup v -> cssProp html "box-flex-group" v
  | BoxLineProgression v -> cssProp html "box-line-progression" v
  | BoxLines v -> cssProp html "box-lines" v
  | BoxOrdinalGroup v -> cssProp html "box-ordinal-group" v
  | BoxShadow v -> cssProp html "box-shadow" v
  | BoxSizing v -> cssProp html "box-sizing" v
  | BreakAfter v -> cssProp html "break-after" v
  | BreakBefore v -> cssProp html "break-before" v
  | BreakInside v -> cssProp html "break-inside" v
  | CaptionSide v -> cssProp html "caption-side" v
  | CaretColor v -> cssProp html "caret-color" v
  | Clear v -> cssProp html "clear" v
  | Clip v -> cssProp html "clip" v
  | ClipPath v -> cssProp html "clip-path" v
  | ClipRule v -> cssProp html "clip-rule" v
  | Color v -> cssProp html "color" v
  | ColorInterpolation v -> cssProp html "color-interpolation" v
  | ColorInterpolationFilters v -> cssProp html "color-interpolation-filters" v
  | ColorProfile v -> cssProp html "color-profile" v
  | ColorRendering v -> cssProp html "color-rendering" v
  | ColumnCount v -> cssProp html "column-count" v
  | ColumnFill v -> cssProp html "column-fill" v
  | ColumnGap v -> cssProp html "column-gap" v
  | ColumnRule v -> cssProp html "column-rule" v
  | ColumnRuleColor v -> cssProp html "column-rule-color" v
  | ColumnRuleStyle v -> cssProp html "column-rule-style" v
  | ColumnRuleWidth v -> cssProp html "column-rule-width" v
  | ColumnSpan v -> cssProp html "column-span" v
  | ColumnWidth v -> cssProp html "column-width" v
  | Columns v -> cssProp html "columns" v
  | CSSProp.Content v -> cssProp html "content" v
  | CounterIncrement v -> cssProp html "counter-increment" v
  | CounterReset v -> cssProp html "counter-reset" v
  | Cue v -> cssProp html "cue" v
  | CueAfter v -> cssProp html "cue-after" v
  | Cursor v -> cssProp html "cursor" v
  | Direction v -> cssProp html "direction" v
  | Display v -> cssProp html "display" v
  | DominantBaseline v -> cssProp html "dominant-baseline" v
  | EmptyCells v -> cssProp html "empty-cells" v
  | EnableBackground v -> cssProp html "enable-background" v
  | Fill v -> cssProp html "fill" v
  | FillOpacity v -> cssProp html "fill-opacity" v
  | FillRule v -> cssProp html "fill-rule" v
  | Filter v -> cssProp html "filter" v
  | Flex v -> cssProp html "flex" v
  | FlexAlign v -> cssProp html "flex-align" v
  | FlexBasis v -> cssProp html "flex-basis" v
  | FlexDirection v -> cssProp html "flex-direction" v
  | FlexFlow v -> cssProp html "flex-flow" v
  | FlexGrow v -> cssProp html "flex-grow" v
  | FlexItemAlign v -> cssProp html "flex-item-align" v
  | FlexLinePack v -> cssProp html "flex-line-pack" v
  | FlexOrder v -> cssProp html "flex-order" v
  | FlexShrink v -> cssProp html "flex-shrink" v
  | FlexWrap v -> cssProp html "flex-wrap" v
  | Float v -> cssProp html "float" v
  | FloodColor v -> cssProp html "flood-color" v
  | FloodOpacity v -> cssProp html "flood-opacity" v
  | FlowFrom v -> cssProp html "flow-from" v
  | Font v -> cssProp html "font" v
  | FontFamily v -> cssProp html "font-family" v
  | FontFeatureSettings v -> cssProp html "font-feature-settings" v
  | FontKerning v -> cssProp html "font-kerning" v
  | FontLanguageOverride v -> cssProp html "font-language-override" v
  | FontSize v -> cssProp html "font-size" v
  | FontSizeAdjust v -> cssProp html "font-size-adjust" v
  | FontStretch v -> cssProp html "font-stretch" v
  | FontStyle v -> cssProp html "font-style" v
  | FontSynthesis v -> cssProp html "font-synthesis" v
  | FontVariant v -> cssProp html "font-variant" v
  | FontVariantAlternates v -> cssProp html "font-variant-alternates" v
  | FontVariantCaps v -> cssProp html "font-variant-caps" v
  | FontVariantEastAsian v -> cssProp html "font-variant-east-asian" v
  | FontVariantLigatures v -> cssProp html "font-variant-ligatures" v
  | FontVariantNumeric v -> cssProp html "font-variant-numeric" v
  | FontVariantPosition v -> cssProp html "font-variant-position" v
  | FontWeight v -> cssProp html "font-weight" v
  | GlyphOrientationHorizontal v -> cssProp html "glyph-orientation-horizontal" v
  | GlyphOrientationVertical v -> cssProp html "glyph-orientation-vertical" v
  | Grid v -> cssProp html "grid" v
  | GridArea v -> cssProp html "grid-area" v
  | GridAutoColumns v -> cssProp html "grid-auto-columns" v
  | GridAutoFlow v -> cssProp html "grid-auto-flow" v
  | GridAutoRows v -> cssProp html "grid-auto-rows" v
  | GridColumn v -> cssProp html "grid-column" v
  | GridColumnEnd v -> cssProp html "grid-column-end" v
  | GridColumnGap v -> cssProp html "grid-column-gap" v
  | GridColumnStart v -> cssProp html "grid-column-start" v
  | GridGap v -> cssProp html "grid-gap" v
  | GridRow v -> cssProp html "grid-row" v
  | GridRowEnd v -> cssProp html "grid-row-end" v
  | GridRowGap v -> cssProp html "grid-row-gap" v
  | GridRowPosition v -> cssProp html "grid-row-position" v
  | GridRowSpan v -> cssProp html "grid-row-span" v
  | GridRowStart v -> cssProp html "grid-row-start" v
  | GridTemplate v -> cssProp html "grid-template" v
  | GridTemplateAreas v -> cssProp html "grid-template-areas" v
  | GridTemplateColumns v -> cssProp html "grid-template-columns" v
  | GridTemplateRows v -> cssProp html "grid-template-rows" v
  | HangingPunctuation v -> cssProp html "hanging-punctuation" v
  | CSSProp.Height v -> cssProp html "height" v
  | HyphenateLimitChars v -> cssProp html "hyphenate-limit-chars" v
  | HyphenateLimitLines v -> cssProp html "hyphenate-limit-lines" v
  | HyphenateLimitZone v -> cssProp html "hyphenate-limit-zone" v
  | Hyphens v -> cssProp html "hyphens" v
  | ImageOrientation v -> cssProp html "image-orientation" v
  | ImageRendering v -> cssProp html "image-rendering" v
  | ImageResolution v -> cssProp html "image-resolution" v
  | ImeMode v -> cssProp html "ime-mode" v
  | InlineSize v -> cssProp html "inline-size" v
  | Isolation v -> cssProp html "isolation" v
  | JustifyContent v -> cssProp html "justify-content" v
  | JustifySelf v -> cssProp html "justify-self" v
  | Kerning v -> cssProp html "kerning" v
  | LayoutGrid v -> cssProp html "layout-grid" v
  | LayoutGridChar v -> cssProp html "layout-grid-char" v
  | LayoutGridLine v -> cssProp html "layout-grid-line" v
  | LayoutGridMode v -> cssProp html "layout-grid-mode" v
  | LayoutGridType v -> cssProp html "layout-grid-type" v
  | Left v -> cssProp html "left" v
  | LetterSpacing v -> cssProp html "letter-spacing" v
  | LightingColor v -> cssProp html "lighting-color" v
  | LineBreak v -> cssProp html "line-break" v
  | LineClamp v -> cssProp html "line-clamp" v
  | LineHeight v -> cssProp html "line-height" v
  | ListStyle v -> cssProp html "list-style" v
  | ListStyleImage v -> cssProp html "list-style-image" v
  | ListStylePosition v -> cssProp html "list-style-position" v
  | ListStyleType v -> cssProp html "list-style-type" v
  | Margin v -> cssProp html "margin" v
  | MarginBlockEnd v -> cssProp html "margin-block-end" v
  | MarginBlockStart v -> cssProp html "margin-block-start" v
  | MarginBottom v -> cssProp html "margin-bottom" v
  | MarginInlineEnd v -> cssProp html "margin-inline-end" v
  | MarginInlineStart v -> cssProp html "margin-inline-start" v
  | MarginLeft v -> cssProp html "margin-left" v
  | MarginRight v -> cssProp html "margin-right" v
  | MarginTop v -> cssProp html "margin-top" v
  | MarkerEnd v -> cssProp html "marker-end" v
  | MarkerMid v -> cssProp html "marker-mid" v
  | MarkerStart v -> cssProp html "marker-start" v
  | MarqueeDirection v -> cssProp html "marquee-direction" v
  | MarqueeStyle v -> cssProp html "marquee-style" v
  | Mask v -> cssProp html "mask" v
  | MaskBorder v -> cssProp html "mask-border" v
  | MaskBorderRepeat v -> cssProp html "mask-border-repeat" v
  | MaskBorderSlice v -> cssProp html "mask-border-slice" v
  | MaskBorderSource v -> cssProp html "mask-border-source" v
  | MaskBorderWidth v -> cssProp html "mask-border-width" v
  | MaskClip v -> cssProp html "mask-clip" v
  | MaskComposite v -> cssProp html "mask-composite" v
  | MaskImage v -> cssProp html "mask-image" v
  | MaskMode v -> cssProp html "mask-mode" v
  | MaskOrigin v -> cssProp html "mask-origin" v
  | MaskPosition v -> cssProp html "mask-position" v
  | MaskRepeat v -> cssProp html "mask-repeat" v
  | MaskSize v -> cssProp html "mask-size" v
  | MaskType v -> cssProp html "mask-type" v
  | MaxFontSize v -> cssProp html "max-font-size" v
  | MaxHeight v -> cssProp html "max-height" v
  | MaxWidth v -> cssProp html "max-width" v
  | MinBlockSize v -> cssProp html "min-block-size" v
  | MinHeight v -> cssProp html "min-height" v
  | MinInlineSize v -> cssProp html "min-inline-size" v
  | MinWidth v -> cssProp html "min-width" v
  | MixBlendMode v -> cssProp html "mix-blend-mode" v
  | ObjectFit v -> cssProp html "object-fit" v
  | ObjectPosition v -> cssProp html "object-position" v
  | OffsetBlockEnd v -> cssProp html "offset-block-end" v
  | OffsetBlockStart v -> cssProp html "offset-block-start" v
  | OffsetInlineEnd v -> cssProp html "offset-inline-end" v
  | OffsetInlineStart v -> cssProp html "offset-inline-start" v
  | Opacity v -> cssProp html "opacity" v
  | Order v -> cssProp html "order" v
  | Orphans v -> cssProp html "orphans" v
  | Outline v -> cssProp html "outline" v
  | OutlineColor v -> cssProp html "outline-color" v
  | OutlineOffset v -> cssProp html "outline-offset" v
  | OutlineStyle v -> cssProp html "outline-style" v
  | OutlineWidth v -> cssProp html "outline-width" v
  | OverflowStyle v -> cssProp html "overflow-style" v
  | OverflowWrap v -> cssProp html "overflow-wrap" v
  | OverflowX v -> cssProp html "overflow-x" v
  | OverflowY v -> cssProp html "overflow-y" v
  | Padding v -> cssProp html "padding" v
  | PaddingBlockEnd v -> cssProp html "padding-block-end" v
  | PaddingBlockStart v -> cssProp html "padding-block-start" v
  | PaddingBottom v -> cssProp html "padding-bottom" v
  | PaddingInlineEnd v -> cssProp html "padding-inline-end" v
  | PaddingInlineStart v -> cssProp html "padding-inline-start" v
  | PaddingLeft v -> cssProp html "padding-left" v
  | PaddingRight v -> cssProp html "padding-right" v
  | PaddingTop v -> cssProp html "padding-top" v
  | PageBreakAfter v -> cssProp html "page-break-after" v
  | PageBreakBefore v -> cssProp html "page-break-before" v
  | PageBreakInside v -> cssProp html "page-break-inside" v
  | Pause v -> cssProp html "pause" v
  | PauseAfter v -> cssProp html "pause-after" v
  | PauseBefore v -> cssProp html "pause-before" v
  | Perspective v -> cssProp html "perspective" v
  | PerspectiveOrigin v -> cssProp html "perspective-origin" v
  | PointerEvents v -> cssProp html "pointer-events" v
  | Position v -> cssProp html "position" v
  | PunctuationTrim v -> cssProp html "punctuation-trim" v
  | Quotes v -> cssProp html "quotes" v
  | RegionFragment v -> cssProp html "region-fragment" v
  | Resize v -> cssProp html "resize" v
  | RestAfter v -> cssProp html "rest-after" v
  | RestBefore v -> cssProp html "rest-before" v
  | Right v -> cssProp html "right" v
  | RubyAlign v -> cssProp html "ruby-align" v
  | RubyMerge v -> cssProp html "ruby-merge" v
  | RubyPosition v -> cssProp html "ruby-position" v
  | ScrollBehavior v -> cssProp html "scroll-behavior" v
  | ScrollSnapCoordinate v -> cssProp html "scroll-snap-coordinate" v
  | ScrollSnapDestination v -> cssProp html "scroll-snap-destination" v
  | ScrollSnapType v -> cssProp html "scroll-snap-type" v
  | ShapeImageThreshold v -> cssProp html "shape-image-threshold" v
  | ShapeInside v -> cssProp html "shape-inside" v
  | ShapeMargin v -> cssProp html "shape-margin" v
  | ShapeOutside v -> cssProp html "shape-outside" v
  | ShapeRendering v -> cssProp html "shape-rendering" v
  | Speak v -> cssProp html "speak" v
  | SpeakAs v -> cssProp html "speak-as" v
  | StopColor v -> cssProp html "stop-color" v
  | StopOpacity v -> cssProp html "stop-opacity" v
  | Stroke v -> cssProp html "stroke" v
  | StrokeDasharray v -> cssProp html "stroke-dasharray" v
  | StrokeDashoffset v -> cssProp html "stroke-dashoffset" v
  | StrokeLinecap v -> cssProp html "stroke-linecap" v
  | StrokeLinejoin v -> cssProp html "stroke-linejoin" v
  | StrokeMiterlimit v -> cssProp html "stroke-miterlimit" v
  | StrokeOpacity v -> cssProp html "stroke-opacity" v
  | StrokeWidth v -> cssProp html "stroke-width" v
  | TabSize v -> cssProp html "tab-size" v
  | TableLayout v -> cssProp html "table-layout" v
  | TextAlign v -> cssProp html "text-align" v
  | TextAlignLast v -> cssProp html "text-align-last" v
  | TextAnchor v -> cssProp html "text-anchor" v
  | TextCombineUpright v -> cssProp html "text-combine-upright" v
  | TextDecoration v -> cssProp html "text-decoration" v
  | TextDecorationColor v -> cssProp html "text-decoration-color" v
  | TextDecorationLine v -> cssProp html "text-decoration-line" v
  | TextDecorationLineThrough v -> cssProp html "text-decoration-line-through" v
  | TextDecorationNone v -> cssProp html "text-decoration-none" v
  | TextDecorationOverline v -> cssProp html "text-decoration-overline" v
  | TextDecorationSkip v -> cssProp html "text-decoration-skip" v
  | TextDecorationStyle v -> cssProp html "text-decoration-style" v
  | TextDecorationUnderline v -> cssProp html "text-decoration-underline" v
  | TextEmphasis v -> cssProp html "text-emphasis" v
  | TextEmphasisColor v -> cssProp html "text-emphasis-color" v
  | TextEmphasisPosition v -> cssProp html "text-emphasis-position" v
  | TextEmphasisStyle v -> cssProp html "text-emphasis-style" v
  | TextHeight v -> cssProp html "text-height" v
  | TextIndent v -> cssProp html "text-indent" v
  | TextJustify v -> cssProp html "text-justify" v
  | TextJustifyTrim v -> cssProp html "text-justify-trim" v
  | TextKashidaSpace v -> cssProp html "text-kashida-space" v
  | TextLineThrough v -> cssProp html "text-line-through" v
  | TextLineThroughColor v -> cssProp html "text-line-through-color" v
  | TextLineThroughMode v -> cssProp html "text-line-through-mode" v
  | TextLineThroughStyle v -> cssProp html "text-line-through-style" v
  | TextLineThroughWidth v -> cssProp html "text-line-through-width" v
  | TextOrientation v -> cssProp html "text-orientation" v
  | TextOverflow v -> cssProp html "text-overflow" v
  | TextOverline v -> cssProp html "text-overline" v
  | TextOverlineColor v -> cssProp html "text-overline-color" v
  | TextOverlineMode v -> cssProp html "text-overline-mode" v
  | TextOverlineStyle v -> cssProp html "text-overline-style" v
  | TextOverlineWidth v -> cssProp html "text-overline-width" v
  | TextRendering v -> cssProp html "text-rendering" v
  | TextScript v -> cssProp html "text-script" v
  | TextShadow v -> cssProp html "text-shadow" v
  | TextTransform v -> cssProp html "text-transform" v
  | TextUnderlinePosition v -> cssProp html "text-underline-position" v
  | TextUnderlineStyle v -> cssProp html "text-underline-style" v
  | Top v -> cssProp html "top" v
  | TouchAction v -> cssProp html "touch-action" v
  | Transform v -> cssProp html "transform" v
  | TransformBox v -> cssProp html "transform-box" v
  | TransformOrigin v -> cssProp html "transform-origin" v
  | TransformOriginZ v -> cssProp html "transform-origin-z" v
  | TransformStyle v -> cssProp html "transform-style" v
  | Transition v -> cssProp html "transition" v
  | TransitionDelay v -> cssProp html "transition-delay" v
  | TransitionDuration v -> cssProp html "transition-duration" v
  | TransitionProperty v -> cssProp html "transition-property" v
  | TransitionTimingFunction v -> cssProp html "transition-timing-function" v
  | UnicodeBidi v -> cssProp html "unicode-bidi" v
  | UnicodeRange v -> cssProp html "unicode-range" v
  | UserFocus v -> cssProp html "user-focus" v
  | UserInput v -> cssProp html "user-input" v
  | UserSelect v -> cssProp html "user-select" v
  | VerticalAlign v -> cssProp html "vertical-align" v
  | Visibility v -> cssProp html "visibility" v
  | VoiceBalance v -> cssProp html "voice-balance" v
  | VoiceDuration v -> cssProp html "voice-duration" v
  | VoiceFamily v -> cssProp html "voice-family" v
  | VoicePitch v -> cssProp html "voice-pitch" v
  | VoiceRange v -> cssProp html "voice-range" v
  | VoiceRate v -> cssProp html "voice-rate" v
  | VoiceStress v -> cssProp html "voice-stress" v
  | VoiceVolume v -> cssProp html "voice-volume" v
  | WhiteSpace v -> cssProp html "white-space" v
  | WhiteSpaceTreatment v -> cssProp html "white-space-treatment" v
  | Widows v -> cssProp html "widows" v
  | CSSProp.Width v -> cssProp html "width" v
  | WillChange v -> cssProp html "will-change" v
  | WordBreak v -> cssProp html "word-break" v
  | WordSpacing v -> cssProp html "word-spacing" v
  | WordWrap v -> cssProp html "word-wrap" v
  | WrapFlow v -> cssProp html "wrap-flow" v
  | WrapMargin v -> cssProp html "wrap-margin" v
  | WrapOption v -> cssProp html "wrap-option" v
  | WritingMode v -> cssProp html "writing-mode" v
  | ZIndex v -> cssProp html "z-index" v
  | Zoom v -> cssProp html "zoom" v
  | CSSProp.Custom (key, value) -> cssProp html (slugKey key) value

let inline boolAttr (html:TextWriter) (key: string) (value: bool) =
  if value then html.Write key

let inline strAttr (html:TextWriter) (key: string) (value: string) =
  html.Write key
  html.Write "=\""
  escapeHtml html value
  html.Write '"'

let inline objAttr (html:TextWriter) (key: string) (value: obj) = strAttr html key (string value)

let private renderHtmlAttr (html:TextWriter) (attr: HTMLAttr) =
  match attr with
  | DefaultChecked v | Checked v -> boolAttr html "checked" v
  | DefaultValue v | Value v -> strAttr html "value" (string v)
  // TODO: Not sure if it's possible/easy to set multiple selected
  // options with an attribute in SSR, so do nothing for now
  | ValueMultiple _ -> ()
  | Accept v -> strAttr html "accept" v
  | AcceptCharset v -> strAttr html "accept-charset" v
  | AccessKey v -> strAttr html "accesskey" v
  | Action v -> strAttr html "action" v
  | AllowFullScreen v -> boolAttr html "allowfullscreen" v
  | AllowTransparency v -> boolAttr html "allowtransparency" v
  | Alt v -> strAttr html "alt" v
  | AriaAtomic v -> boolAttr html "aria-atomic" v
  | AriaBusy v -> boolAttr html "aria-busy" v
  | AriaChecked v -> boolAttr html "aria-checked" v
  | AriaColcount v -> strAttr html "aria-colcount" (string v)
  | AriaColindex v -> strAttr html "aria-colindex" (string v)
  | AriaColspan v -> strAttr html "aria-colspan" (string v)
  | AriaControls v -> strAttr html "aria-controls" v
  | AriaCurrent v -> strAttr html "aria-current" v
  | AriaDescribedBy v -> strAttr html "aria-describedby" v
  | AriaDetails v -> strAttr html "aria-details" v
  | AriaDisabled v -> boolAttr html "aria-disabled" v
  | AriaErrormessage v -> strAttr html "aria-errormessage" v
  | AriaExpanded v -> boolAttr html "aria-expanded" v
  | AriaFlowto v -> strAttr html "aria-flowto" v
  | AriaHasPopup v -> boolAttr html "aria-hasPopup" v
  | AriaHidden v -> boolAttr html "aria-hidden" v
  | AriaInvalid v -> strAttr html "aria-invalid" v
  | AriaKeyshortcuts v -> strAttr html "aria-keyshortcuts" v
  | AriaLabel v -> strAttr html "aria-label" v
  | AriaLabelledby v -> strAttr html "aria-labelledby" v
  | AriaLevel v -> strAttr html "aria-level" (string v)
  | AriaLive v -> strAttr html "aria-live" v
  | AriaModal v -> boolAttr html "aria-modal" v
  | AriaMultiline v -> boolAttr html "aria-multiline" v
  | AriaMultiselectable v -> boolAttr html "aria-multiselectable" v
  | AriaOrientation v -> strAttr html "aria-orientation" v
  | AriaOwns v -> strAttr html "aria-owns" v
  | AriaPlaceholder v -> strAttr html "aria-placeholder" v
  | AriaPosinset v -> strAttr html "aria-posinset" (string v)
  | AriaPressed v -> boolAttr html "aria-pressed" v
  | AriaReadonly v -> boolAttr html "aria-readonly" v
  | AriaRelevant v -> strAttr html "aria-relevant" v
  | AriaRequired v -> boolAttr html "aria-required" v
  | AriaRoledescription v -> strAttr html "aria-roledescription" v
  | AriaRowcount v -> strAttr html "aria-rowcount" (string v)
  | AriaRowindex v -> strAttr html "aria-rowindex" (string v)
  | AriaRowspan v -> strAttr html "aria-rowspan" (string v)
  | AriaSelected v -> boolAttr html "aria-selected" v
  | AriaSetsize v -> strAttr html "aria-setsize" (string v)
  | AriaSort v -> strAttr html "aria-sort" v
  | AriaValuemax v -> strAttr html "aria-valuemax" (string v)
  | AriaValuemin v -> strAttr html "aria-valuemin" (string v)
  | AriaValuenow v -> strAttr html "aria-valuenow" (string v)
  | AriaValuetext v -> strAttr html "aria-valuetext" v
  | Async v -> boolAttr html "async" v
  | AutoComplete v -> strAttr html "autocomplete" v
  | AutoFocus v -> boolAttr html "autofocus" v
  | AutoPlay v -> boolAttr html "autoplay" v
  | Capture v -> boolAttr html "capture" v
  | CellPadding v -> strAttr html "cellpadding" (string v)
  | CellSpacing v -> strAttr html "cellspacing" (string v)
  | CharSet v -> strAttr html "charset" v
  | Challenge v -> strAttr html "challenge" v
  | ClassID v -> strAttr html "class-id" v
  | ClassName v -> strAttr html "class" v
  | Class v -> strAttr html "class" v
  | Cols v -> strAttr html "cols" (string v)
  | ColSpan v -> strAttr html "colspan" (string v)
  | HTMLAttr.Content v -> strAttr html "content" v
  | ContentEditable v -> boolAttr html "contenteditable" v
  | ContextMenu v -> strAttr html "contextmenu" v
  | Controls v -> boolAttr html "controls" v
  | Coords v -> strAttr html "coords" v
  | CrossOrigin v -> strAttr html  "crossorigin" v
  // | Data v -> pair "data" v
  | DataToggle v -> strAttr html "data-toggle" v
  | DateTime v -> strAttr html "datetime" v
  | Default v -> boolAttr html "default" v
  | Defer v -> boolAttr html "defer" v
  | Dir v -> strAttr html "dir" v
  | Disabled v -> boolAttr html "disabled" v
  | Download v -> strAttr html "download" (string v)
  | Draggable v -> boolAttr html "draggable" v
  | EncType v -> strAttr html "enctype" v
  | Form v -> strAttr html "form" v
  | FormAction v -> strAttr html "formaction" v
  | FormEncType v -> strAttr html "formenctype" v
  | FormMethod v -> strAttr html "formmethod" v
  | FormNoValidate v -> boolAttr html  "formnovalidate" v
  | FormTarget v -> strAttr html "formtarget" v
  | FrameBorder v -> strAttr html "frameborder" (string v)
  | Headers v -> strAttr html "headers" v
  | HTMLAttr.Height v -> strAttr html "height" (string v)
  | Hidden v -> boolAttr html "hidden" v
  // -----
  | High v -> strAttr html "high" (string v)
  | Href v -> strAttr html "href" v
  | HrefLang v -> strAttr html "hreflang" v
  | HtmlFor v -> strAttr html "for" v
  | HttpEquiv v -> strAttr html "http-equiv" v
  | Icon v -> strAttr html "icon" v
  | Id v -> strAttr html "id" v
  | InputMode v -> strAttr html "inputmode" v
  | Integrity v -> strAttr html "integrity" v
  | Is v -> strAttr html "is" v
  | KeyParams v -> strAttr html "keyparams" v
  | KeyType v -> strAttr html "keytype" v
  | Kind v -> strAttr html "kind" v
  | Label v -> strAttr html "label" v
  | Lang v -> strAttr html "lang" v
  | List v -> strAttr html "list" v
  | Loop v -> boolAttr html "loop" v
  | Low v -> strAttr html "low" (string v)
  | Manifest v -> strAttr html "manifest" v
  | MarginHeight v -> strAttr html "marginheight" (string v)
  | MarginWidth v -> strAttr html "marginwidth" (string v)
  | Max v -> strAttr html "max" (string v)
  | MaxLength v -> strAttr html "maxlength" (string v)
  | Media v -> strAttr html "media" v
  | MediaGroup v -> strAttr html "mediagroup" v
  | Method v -> strAttr html "method" v
  | Min v -> strAttr html "min" (string v)
  | MinLength v -> strAttr html "minlength" (string v)
  | Multiple v -> boolAttr html "multiple" v
  | Muted v -> strAttr html "muted" (string v)
  | Name v -> strAttr html "name" v
  | NoValidate v -> boolAttr html "novalidate" v
  | Open v -> boolAttr html "open" v
  | Optimum v -> strAttr html "optimum" (string v)
  | Pattern v -> strAttr html "pattern" v
  | Placeholder v -> strAttr html "placeholder" v
  | Poster v -> strAttr html "poster" v
  | Preload v -> strAttr html "preload" v
  | RadioGroup v -> strAttr html "radiogroup" v
  | ReadOnly v -> boolAttr html "readonly" v
  | Rel v -> strAttr html "rel" v
  | Required v -> boolAttr html "required" v
  | Role v -> strAttr html "role" v
  | Rows v -> strAttr html "rows" (string v)
  | RowSpan v -> strAttr html "row-span" (string v)
  | Sandbox v -> strAttr html "sandbox" v
  | Scope v -> strAttr html "scope" v
  | Scoped v -> boolAttr html  "scoped" v
  | Scrolling v -> strAttr html "scrolling" v
  | Seamless v -> boolAttr html "seamless" v
  | Selected v -> boolAttr html "selected" v
  | Shape v -> strAttr html "shape" v
  | Size v -> strAttr html "size" (string v)
  | Sizes v -> strAttr html "sizes" v
  | Span v -> strAttr html "span" (string v)
  | SpellCheck v -> boolAttr html "spellcheck" v
  | Src v -> strAttr html "src" v
  | SrcDoc v -> strAttr html "srcdoc" v
  | SrcLang v -> strAttr html "srclang" v
  | SrcSet v -> strAttr html "srcset" v
  | Start v -> strAttr html "start" (string v)
  | Step v -> strAttr html "step" (string v)
  | Summary v -> strAttr html "summary" v
  | TabIndex v -> strAttr html "tabindex" (string v)
  | Target v -> strAttr html "target" v
  | Title v -> strAttr html "title" v
  | Type v -> strAttr html "type" v
  | UseMap v -> strAttr html "use-map" v
  | HTMLAttr.Width v -> strAttr html "width" (string v)
  | Wmode v -> strAttr html "wmode" v
  | Wrap v -> strAttr html "wrap" v
  | About v -> strAttr html "about" v
  | Datatype v -> strAttr html "datatype" v
  | Inlist v -> strAttr html "inlist" (string v)
  | Prefix v -> strAttr html "prefix" v
  | Property v -> strAttr html "property" v
  | Resource v -> strAttr html "resource" v
  | Typeof v -> strAttr html "typeof" v
  | Vocab v -> strAttr html "vocab" v
  | AutoCapitalize v -> strAttr html "auto-capitalize" v
  | AutoCorrect v -> strAttr html "auto-correct" v
  | AutoSave v -> strAttr html "auto-save" v
  // | Color v -> pair "color" v // Conflicts with CSSProp, shouldn't be used in HTML5
  | ItemProp v -> strAttr html "itemprop" v
  | ItemScope v -> boolAttr html "itemscope" v
  | ItemType v -> strAttr html "itemtype" v
  | ItemID v -> strAttr html "itemid" v
  | ItemRef v -> strAttr html "itemref" v
  | Results v -> strAttr html "results" (string v)
  | Security v -> strAttr html "security" v
  | Unselectable v -> boolAttr html "unselectable" v
  | Style cssList ->
    html.Write "style"
    html.Write "=\""

    cssList
    |> List.iteri( fun i cssProp ->
        if i > 0 then html.Write(';')
        renderCssProp html cssProp)
    html.Write '"'

  | HTMLAttr.Custom (key, value) -> strAttr html (key.ToLower()) (string value)
  | Data (key, value) -> strAttr html ("data-" + key) (string value)

let private renderSVGAttr (html:TextWriter) (attr: SVGAttr) =
  match attr with
  | SVGAttr.ClipPath v -> objAttr html "clip-path" v
  | SVGAttr.Cx v -> objAttr html "cx" v
  | SVGAttr.Cy v -> objAttr html "cy" v
  | SVGAttr.D v -> objAttr html "d" v
  | SVGAttr.Dx v -> objAttr html "dx" v
  | SVGAttr.Dy v -> objAttr html "dy" v
  | SVGAttr.Fill v -> objAttr html "fill" v
  | SVGAttr.FillOpacity v -> objAttr html "fill-opacity" v
  | SVGAttr.FontFamily v -> objAttr html "font-family" v
  | SVGAttr.FontSize v -> objAttr html "font-size" v
  | SVGAttr.Fx v -> objAttr html "fx" v
  | SVGAttr.Fy v -> objAttr html "fy" v
  | SVGAttr.GradientTransform v -> objAttr html "gradientTransform" v
  | SVGAttr.GradientUnits v -> objAttr html "gradientUnits" v
  | SVGAttr.Height v -> objAttr html "height" v
  | SVGAttr.MarkerEnd v -> objAttr html "marker-end" v
  | SVGAttr.MarkerMid v -> objAttr html "marker-mid" v
  | SVGAttr.MarkerStart v -> objAttr html "marker-start" v
  | SVGAttr.Offset v -> objAttr html "offset" v
  | SVGAttr.Opacity v -> objAttr html "opacity" v
  | SVGAttr.PatternContentUnits v -> objAttr html "patternContentUnits" v
  | SVGAttr.PatternUnits v -> objAttr html "patternUnits" v
  | SVGAttr.Points v -> objAttr html "points" v
  | SVGAttr.PreserveAspectRatio v -> objAttr html "preserveAspectRatio" v
  | SVGAttr.R v -> objAttr html "r" v
  | SVGAttr.Rx v -> objAttr html "rx" v
  | SVGAttr.Ry v -> objAttr html "ry" v
  | SVGAttr.SpreadMethod v -> objAttr html "spreadMethod" v
  | SVGAttr.StopColor v -> objAttr html "stop-color" v
  | SVGAttr.StopOpacity v -> objAttr html "stop-opacity" v
  | SVGAttr.Stroke v -> objAttr html "stroke" v
  | SVGAttr.StrokeDasharray v -> objAttr html "stroke-dasharray" v
  | SVGAttr.StrokeDashoffset v -> objAttr html "stroke-dashoffset" v
  | SVGAttr.StrokeLinecap v -> objAttr html "stroke-linecap" v
  | SVGAttr.StrokeMiterlimit v -> objAttr html "stroke-miterlimit" v
  | SVGAttr.StrokeOpacity v -> objAttr html "stroke-opacity" v
  | SVGAttr.StrokeWidth v -> objAttr html "stroke-width" v
  | SVGAttr.TextAnchor v -> objAttr html "text-anchor" v
  | SVGAttr.Transform v -> objAttr html "transform" v
  | SVGAttr.Version v -> objAttr html "version" v
  | SVGAttr.ViewBox v -> objAttr html "viewBox" v
  | SVGAttr.Width v -> objAttr html "width" v
  | SVGAttr.X1 v -> objAttr html "x1" v
  | SVGAttr.X2 v -> objAttr html "x2" v
  | SVGAttr.X v -> objAttr html "x" v
  | SVGAttr.XlinkActuate v -> objAttr html "xlink:actuate" v
  | SVGAttr.XlinkArcrole v -> objAttr html "xlink:arcrole" v
  | SVGAttr.XlinkHref v -> objAttr html "xlink:href" v
  | SVGAttr.XlinkRole v -> objAttr html "xlink:role" v
  | SVGAttr.XlinkShow v -> objAttr html "xlink:show" v
  | SVGAttr.XlinkTitle v -> objAttr html "xlink:title" v
  | SVGAttr.XlinkType v -> objAttr html "xlink:type" v
  | SVGAttr.XmlBase v -> objAttr html "xml:base" v
  | SVGAttr.XmlLang v -> objAttr html "xml:lang" v
  | SVGAttr.XmlSpace v -> objAttr html "xml:space" v
  | SVGAttr.Y1 v -> objAttr html "y1" v
  | SVGAttr.Y2 v -> objAttr html "y2" v
  | SVGAttr.Y v -> objAttr html "y" v
  | SVGAttr.Custom (key, value) -> objAttr html (slugKey key) value

let private renderAttrs (html:TextWriter) (attrs: IProp seq) tag =
  let mutable childHtml = None
  for attr in attrs do
    match attr with
    | :? DOMAttr as attr ->
      match attr with
      | DangerouslySetInnerHTML v ->
          childHtml <- Some v.__html
      | _ -> ()
    | :? HTMLAttr as attr ->
      match tag, attr with
      | "textarea", Value v
      | "textarea", DefaultValue v ->
          childHtml <- Some(string v)
      | _, _ ->
        html.Write ' '
        renderHtmlAttr html attr
    | :? SVGAttr as attr ->
      html.Write ' '
      renderSVGAttr html attr
    | _ -> ()

  childHtml

let rec private addReactMark htmlNode =
  match htmlNode with
  | HTMLNode.Node (tag, attrs, children) ->
    HTMLNode.Node (tag, attrs |> Seq.append [ Data ("reactroot", "") ] , children)
  | HTMLNode.List nodes ->
    HTMLNode.List (nodes |> Seq.cast |> Seq.map addReactMark |> Seq.cast)
  | h -> h

/// Cast a ReactElement safely to an HTMLNode.
/// Returns an empty node if input is not an HTMLNode.
let inline castHTMLNode (htmlNode: ReactElement): HTMLNode =
  match htmlNode with
  | :? HTMLNode as node -> node
  | _ -> HTMLNode.Empty

module Raw =
  /// Writes the nodes into a TextWriter. DOESN'T ADD `reactroot` attribute.
  let rec writeTo (html: TextWriter) (htmlNode: HTMLNode) : unit =
      match htmlNode with
      | HTMLNode.Text str -> escapeHtml html str
      | HTMLNode.RawText str -> html.Write str
      | HTMLNode.Node (tag, attrs, children) ->
        html.Write '<'
        html.Write tag

        let child = renderAttrs html attrs tag

        if voidTags.Contains tag then
          html.Write " />"
        else
          html.Write '>'

          match child with
          | Some c -> html.Write c
          | None ->
            for child in children do
              writeTo html (castHTMLNode child)

          html.Write "</"
          html.Write tag
          html.Write '>'
      | HTMLNode.List nodes ->
          for node in nodes do
            writeTo html (castHTMLNode node)
      | HTMLNode.Empty -> ()

let renderToString (htmlNode: ReactElement): string =
  let htmlNode = addReactMark (castHTMLNode htmlNode)
  use html = new StringWriter()
  htmlNode |> Raw.writeTo html
  html.ToString()
#endif
