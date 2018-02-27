module Fable.Helpers.ReactServer

open System.Text

open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

// Adapted from https://github.com/emotion-js/emotion/blob/182e34bab2b2028c96d513b67ed86faee1b642b2/packages/emotion-utils/src/index.js#L13
let unitlessCssProps = set [ "animation-iteration-count"; "border-image-outset"; "border-image-slice"; "border-image-width"; "box-flex"; "box-flex-group"; "box-ordinal-group"; "column-count"; "columns"; "flex"; "flex-grow"; "flex-positive"; "flex-shrink"; "flex-negative"; "flex-order"; "grid-row"; "grid-row-end"; "grid-row-span"; "grid-row-start"; "grid-column"; "grid-column-end"; "grid-column-span"; "grid-column-start"; "font-weight"; "line-height"; "opacity"; "order"; "orphans"; "tab-size"; "widows"; "z-index"; "zoom"; "-webkit-line-clamp"; "fill-opacity"; "flood-opacity"; "stop-opacity"; "stroke-dasharray"; "stroke-dashoffset"; "stroke-miterlimit"; "stroke-opacity"; "stroke-width" ]

let inline private addUnit (key: string) (value: string) =
  if unitlessCssProps |> Set.contains key |> not
  then value + "px"
  else value

let private cssProp (key: string) (value: obj) =
  let value =
    match value with
    | :? int as v -> (addUnit key (string v))
    | :? float as v -> (addUnit key (string v))
    | _ -> value.ToString()

  key + ": " + value + ";"

let private renderCssProp (prop: CSSProp): string =
  match prop with
  | AlignContent v -> cssProp "align-content" v
  | AlignItems v -> cssProp "align-items" v
  | AlignSelf v -> cssProp "align-self" v
  | AlignmentAdjust v -> cssProp "alignment-adjust" v
  | AlignmentBaseline v -> cssProp "alignment-baseline" v
  | All v -> cssProp "all" v
  | Animation v -> cssProp "animation" v
  | AnimationDelay v -> cssProp "animation-delay" v
  | AnimationDirection v -> cssProp "animation-direction" v
  | AnimationDuration v -> cssProp "animation-duration" v
  | AnimationFillMode v -> cssProp "animation-fill-mode" v
  | AnimationIterationCount v -> cssProp "animation-iteration-count" v
  | AnimationName v -> cssProp "animation-name" v
  | AnimationPlayState v -> cssProp "animation-play-state" v
  | AnimationTimingFunction v -> cssProp "animation-timing-function" v
  | Appearance v -> cssProp "appearance" v
  | BackfaceVisibility v -> cssProp "backface-visibility" v
  | Background v -> cssProp "background" v
  | BackgroundAttachment v -> cssProp "background-attachment" v
  | BackgroundBlendMode v -> cssProp "background-blend-mode" v
  | BackgroundClip v -> cssProp "background-clip" v
  | BackgroundColor v -> cssProp "background-color" v
  | BackgroundComposite v -> cssProp "background-composite" v
  | BackgroundImage v -> cssProp "background-image" v
  | BackgroundOrigin v -> cssProp "background-origin" v
  | BackgroundPosition v -> cssProp "background-position" v
  | BackgroundPositionX v -> cssProp "background-position-x" v
  | BackgroundPositionY v -> cssProp "background-position-y" v
  | BackgroundRepeat v -> cssProp "background-repeat" v
  | BackgroundSize v -> cssProp "background-size" v
  | BaselineShift v -> cssProp "baseline-shift" v
  | Behavior v -> cssProp "behavior" v
  | BlockSize v -> cssProp "block-size" v
  | Border v -> cssProp "border" v
  | BorderBlockEnd v -> cssProp "border-block-end" v
  | BorderBlockEndColor v -> cssProp "border-block-end-color" v
  | BorderBlockEndStyle v -> cssProp "border-block-end-style" v
  | BorderBlockEndWidth v -> cssProp "border-block-end-width" v
  | BorderBlockStart v -> cssProp "border-block-start" v
  | BorderBlockStartColor v -> cssProp "border-block-start-color" v
  | BorderBlockStartStyle v -> cssProp "border-block-start-style" v
  | BorderBlockStartWidth v -> cssProp "border-block-start-width" v
  | BorderBottom v -> cssProp "border-bottom" v
  | BorderBottomColor v -> cssProp "border-bottom-color" v
  | BorderBottomLeftRadius v -> cssProp "border-bottom-left-radius" v
  | BorderBottomRightRadius v -> cssProp "border-bottom-right-radius" v
  | BorderBottomStyle v -> cssProp "border-bottom-style" v
  | BorderBottomWidth v -> cssProp "border-bottom-width" v
  | BorderCollapse v -> cssProp "border-collapse" v
  | BorderColor v -> cssProp "border-color" v
  | BorderCornerShape v -> cssProp "border-corner-shape" v
  | BorderImage v -> cssProp "border-image" v
  | BorderImageOutset v -> cssProp "border-image-outset" v
  | BorderImageRepeat v -> cssProp "border-image-repeat" v
  | BorderImageSlice v -> cssProp "border-image-slice" v
  | BorderImageSource v -> cssProp "border-image-source" v
  | BorderImageWidth v -> cssProp "border-image-width" v
  | BorderInlineEnd v -> cssProp "border-inline-end" v
  | BorderInlineEndColor v -> cssProp "border-inline-end-color" v
  | BorderInlineEndStyle v -> cssProp "border-inline-end-style" v
  | BorderInlineEndWidth v -> cssProp "border-inline-end-width" v
  | BorderInlineStart v -> cssProp "border-inline-start" v
  | BorderInlineStartColor v -> cssProp "border-inline-start-color" v
  | BorderInlineStartStyle v -> cssProp "border-inline-start-style" v
  | BorderInlineStartWidth v -> cssProp "border-inline-start-width" v
  | BorderLeft v -> cssProp "border-left" v
  | BorderLeftColor v -> cssProp "border-left-color" v
  | BorderLeftStyle v -> cssProp "border-left-style" v
  | BorderLeftWidth v -> cssProp "border-left-width" v
  | BorderRadius v -> cssProp "border-radius" v
  | BorderRight v -> cssProp "border-right" v
  | BorderRightColor v -> cssProp "border-right-color" v
  | BorderRightStyle v -> cssProp "border-right-style" v
  | BorderRightWidth v -> cssProp "border-right-width" v
  | BorderSpacing v -> cssProp "border-spacing" v
  | BorderStyle v -> cssProp "border-style" v
  | BorderTop v -> cssProp "border-top" v
  | BorderTopColor v -> cssProp "border-top-color" v
  | BorderTopLeftRadius v -> cssProp "border-top-left-radius" v
  | BorderTopRightRadius v -> cssProp "border-top-right-radius" v
  | BorderTopStyle v -> cssProp "border-top-style" v
  | BorderTopWidth v -> cssProp "border-top-width" v
  | BorderWidth v -> cssProp "border-width" v
  | Bottom v -> cssProp "bottom" v
  | BoxAlign v -> cssProp "box-align" v
  | BoxDecorationBreak v -> cssProp "box-decoration-break" v
  | BoxDirection v -> cssProp "box-direction" v
  | BoxFlex v -> cssProp "box-flex" v
  | BoxFlexGroup v -> cssProp "box-flex-group" v
  | BoxLineProgression v -> cssProp "box-line-progression" v
  | BoxLines v -> cssProp "box-lines" v
  | BoxOrdinalGroup v -> cssProp "box-ordinal-group" v
  | BoxShadow v -> cssProp "box-shadow" v
  | BoxSizing v -> cssProp "box-sizing" v
  | BreakAfter v -> cssProp "break-after" v
  | BreakBefore v -> cssProp "break-before" v
  | BreakInside v -> cssProp "break-inside" v
  | CaptionSide v -> cssProp "caption-side" v
  | CaretColor v -> cssProp "caret-color" v
  | Clear v -> cssProp "clear" v
  | Clip v -> cssProp "clip" v
  | ClipPath v -> cssProp "clip-path" v
  | ClipRule v -> cssProp "clip-rule" v
  | Color v -> cssProp "color" v
  | ColorInterpolation v -> cssProp "color-interpolation" v
  | ColorInterpolationFilters v -> cssProp "color-interpolation-filters" v
  | ColorProfile v -> cssProp "color-profile" v
  | ColorRendering v -> cssProp "color-rendering" v
  | ColumnCount v -> cssProp "column-count" v
  | ColumnFill v -> cssProp "column-fill" v
  | ColumnGap v -> cssProp "column-gap" v
  | ColumnRule v -> cssProp "column-rule" v
  | ColumnRuleColor v -> cssProp "column-rule-color" v
  | ColumnRuleStyle v -> cssProp "column-rule-style" v
  | ColumnRuleWidth v -> cssProp "column-rule-width" v
  | ColumnSpan v -> cssProp "column-span" v
  | ColumnWidth v -> cssProp "column-width" v
  | Columns v -> cssProp "columns" v
  | CSSProp.Content v -> cssProp "content" v
  | CounterIncrement v -> cssProp "counter-increment" v
  | CounterReset v -> cssProp "counter-reset" v
  | Cue v -> cssProp "cue" v
  | CueAfter v -> cssProp "cue-after" v
  | Cursor v -> cssProp "cursor" v
  | Direction v -> cssProp "direction" v
  | Display v -> cssProp "display" v
  | DominantBaseline v -> cssProp "dominant-baseline" v
  | EmptyCells v -> cssProp "empty-cells" v
  | EnableBackground v -> cssProp "enable-background" v
  | Fill v -> cssProp "fill" v
  | FillOpacity v -> cssProp "fill-opacity" v
  | FillRule v -> cssProp "fill-rule" v
  | Filter v -> cssProp "filter" v
  | Flex v -> cssProp "flex" v
  | FlexAlign v -> cssProp "flex-align" v
  | FlexBasis v -> cssProp "flex-basis" v
  | FlexDirection v -> cssProp "flex-direction" v
  | FlexFlow v -> cssProp "flex-flow" v
  | FlexGrow v -> cssProp "flex-grow" v
  | FlexItemAlign v -> cssProp "flex-item-align" v
  | FlexLinePack v -> cssProp "flex-line-pack" v
  | FlexOrder v -> cssProp "flex-order" v
  | FlexShrink v -> cssProp "flex-shrink" v
  | FlexWrap v -> cssProp "flex-wrap" v
  | Float v -> cssProp "float" v
  | FloodColor v -> cssProp "flood-color" v
  | FloodOpacity v -> cssProp "flood-opacity" v
  | FlowFrom v -> cssProp "flow-from" v
  | Font v -> cssProp "font" v
  | FontFamily v -> cssProp "font-family" v
  | FontFeatureSettings v -> cssProp "font-feature-settings" v
  | FontKerning v -> cssProp "font-kerning" v
  | FontLanguageOverride v -> cssProp "font-language-override" v
  | FontSize v -> cssProp "font-size" v
  | FontSizeAdjust v -> cssProp "font-size-adjust" v
  | FontStretch v -> cssProp "font-stretch" v
  | FontStyle v -> cssProp "font-style" v
  | FontSynthesis v -> cssProp "font-synthesis" v
  | FontVariant v -> cssProp "font-variant" v
  | FontVariantAlternates v -> cssProp "font-variant-alternates" v
  | FontVariantCaps v -> cssProp "font-variant-caps" v
  | FontVariantEastAsian v -> cssProp "font-variant-east-asian" v
  | FontVariantLigatures v -> cssProp "font-variant-ligatures" v
  | FontVariantNumeric v -> cssProp "font-variant-numeric" v
  | FontVariantPosition v -> cssProp "font-variant-position" v
  | FontWeight v -> cssProp "font-weight" v
  | GlyphOrientationHorizontal v -> cssProp "glyph-orientation-horizontal" v
  | GlyphOrientationVertical v -> cssProp "glyph-orientation-vertical" v
  | Grid v -> cssProp "grid" v
  | GridArea v -> cssProp "grid-area" v
  | GridAutoColumns v -> cssProp "grid-auto-columns" v
  | GridAutoFlow v -> cssProp "grid-auto-flow" v
  | GridAutoRows v -> cssProp "grid-auto-rows" v
  | GridColumn v -> cssProp "grid-column" v
  | GridColumnEnd v -> cssProp "grid-column-end" v
  | GridColumnGap v -> cssProp "grid-column-gap" v
  | GridColumnStart v -> cssProp "grid-column-start" v
  | GridGap v -> cssProp "grid-gap" v
  | GridRow v -> cssProp "grid-row" v
  | GridRowEnd v -> cssProp "grid-row-end" v
  | GridRowGap v -> cssProp "grid-row-gap" v
  | GridRowPosition v -> cssProp "grid-row-position" v
  | GridRowSpan v -> cssProp "grid-row-span" v
  | GridRowStart v -> cssProp "grid-row-start" v
  | GridTemplate v -> cssProp "grid-template" v
  | GridTemplateAreas v -> cssProp "grid-template-areas" v
  | GridTemplateColumns v -> cssProp "grid-template-columns" v
  | GridTemplateRows v -> cssProp "grid-template-rows" v
  | HangingPunctuation v -> cssProp "hanging-punctuation" v
  | CSSProp.Height v -> cssProp "height" v
  | HyphenateLimitChars v -> cssProp "hyphenate-limit-chars" v
  | HyphenateLimitLines v -> cssProp "hyphenate-limit-lines" v
  | HyphenateLimitZone v -> cssProp "hyphenate-limit-zone" v
  | Hyphens v -> cssProp "hyphens" v
  | ImageOrientation v -> cssProp "image-orientation" v
  | ImageRendering v -> cssProp "image-rendering" v
  | ImageResolution v -> cssProp "image-resolution" v
  | ImeMode v -> cssProp "ime-mode" v
  | InlineSize v -> cssProp "inline-size" v
  | Isolation v -> cssProp "isolation" v
  | JustifyContent v -> cssProp "justify-content" v
  | Kerning v -> cssProp "kerning" v
  | LayoutGrid v -> cssProp "layout-grid" v
  | LayoutGridChar v -> cssProp "layout-grid-char" v
  | LayoutGridLine v -> cssProp "layout-grid-line" v
  | LayoutGridMode v -> cssProp "layout-grid-mode" v
  | LayoutGridType v -> cssProp "layout-grid-type" v
  | Left v -> cssProp "left" v
  | LetterSpacing v -> cssProp "letter-spacing" v
  | LightingColor v -> cssProp "lighting-color" v
  | LineBreak v -> cssProp "line-break" v
  | LineClamp v -> cssProp "line-clamp" v
  | LineHeight v -> cssProp "line-height" v
  | ListStyle v -> cssProp "list-style" v
  | ListStyleImage v -> cssProp "list-style-image" v
  | ListStylePosition v -> cssProp "list-style-position" v
  | ListStyleType v -> cssProp "list-style-type" v
  | Margin v -> cssProp "margin" v
  | MarginBlockEnd v -> cssProp "margin-block-end" v
  | MarginBlockStart v -> cssProp "margin-block-start" v
  | MarginBottom v -> cssProp "margin-bottom" v
  | MarginInlineEnd v -> cssProp "margin-inline-end" v
  | MarginInlineStart v -> cssProp "margin-inline-start" v
  | MarginLeft v -> cssProp "margin-left" v
  | MarginRight v -> cssProp "margin-right" v
  | MarginTop v -> cssProp "margin-top" v
  | MarkerEnd v -> cssProp "marker-end" v
  | MarkerMid v -> cssProp "marker-mid" v
  | MarkerStart v -> cssProp "marker-start" v
  | MarqueeDirection v -> cssProp "marquee-direction" v
  | MarqueeStyle v -> cssProp "marquee-style" v
  | Mask v -> cssProp "mask" v
  | MaskBorder v -> cssProp "mask-border" v
  | MaskBorderRepeat v -> cssProp "mask-border-repeat" v
  | MaskBorderSlice v -> cssProp "mask-border-slice" v
  | MaskBorderSource v -> cssProp "mask-border-source" v
  | MaskBorderWidth v -> cssProp "mask-border-width" v
  | MaskClip v -> cssProp "mask-clip" v
  | MaskComposite v -> cssProp "mask-composite" v
  | MaskImage v -> cssProp "mask-image" v
  | MaskMode v -> cssProp "mask-mode" v
  | MaskOrigin v -> cssProp "mask-origin" v
  | MaskPosition v -> cssProp "mask-position" v
  | MaskRepeat v -> cssProp "mask-repeat" v
  | MaskSize v -> cssProp "mask-size" v
  | MaskType v -> cssProp "mask-type" v
  | MaxFontSize v -> cssProp "max-font-size" v
  | MaxHeight v -> cssProp "max-height" v
  | MaxWidth v -> cssProp "max-width" v
  | MinBlockSize v -> cssProp "min-block-size" v
  | MinHeight v -> cssProp "min-height" v
  | MinInlineSize v -> cssProp "min-inline-size" v
  | MinWidth v -> cssProp "min-width" v
  | MixBlendMode v -> cssProp "mix-blend-mode" v
  | ObjectFit v -> cssProp "object-fit" v
  | ObjectPosition v -> cssProp "object-position" v
  | OffsetBlockEnd v -> cssProp "offset-block-end" v
  | OffsetBlockStart v -> cssProp "offset-block-start" v
  | OffsetInlineEnd v -> cssProp "offset-inline-end" v
  | OffsetInlineStart v -> cssProp "offset-inline-start" v
  | Opacity v -> cssProp "opacity" v
  | Order v -> cssProp "order" v
  | Orphans v -> cssProp "orphans" v
  | Outline v -> cssProp "outline" v
  | OutlineColor v -> cssProp "outline-color" v
  | OutlineOffset v -> cssProp "outline-offset" v
  | OutlineStyle v -> cssProp "outline-style" v
  | OutlineWidth v -> cssProp "outline-width" v
  | Overflow v -> cssProp "overflow" v
  | OverflowStyle v -> cssProp "overflow-style" v
  | OverflowWrap v -> cssProp "overflow-wrap" v
  | OverflowX v -> cssProp "overflow-x" v
  | OverflowY v -> cssProp "overflow-y" v
  | Padding v -> cssProp "padding" v
  | PaddingBlockEnd v -> cssProp "padding-block-end" v
  | PaddingBlockStart v -> cssProp "padding-block-start" v
  | PaddingBottom v -> cssProp "padding-bottom" v
  | PaddingInlineEnd v -> cssProp "padding-inline-end" v
  | PaddingInlineStart v -> cssProp "padding-inline-start" v
  | PaddingLeft v -> cssProp "padding-left" v
  | PaddingRight v -> cssProp "padding-right" v
  | PaddingTop v -> cssProp "padding-top" v
  | PageBreakAfter v -> cssProp "page-break-after" v
  | PageBreakBefore v -> cssProp "page-break-before" v
  | PageBreakInside v -> cssProp "page-break-inside" v
  | Pause v -> cssProp "pause" v
  | PauseAfter v -> cssProp "pause-after" v
  | PauseBefore v -> cssProp "pause-before" v
  | Perspective v -> cssProp "perspective" v
  | PerspectiveOrigin v -> cssProp "perspective-origin" v
  | PointerEvents v -> cssProp "pointer-events" v
  | Position v -> cssProp "position" v
  | PunctuationTrim v -> cssProp "punctuation-trim" v
  | Quotes v -> cssProp "quotes" v
  | RegionFragment v -> cssProp "region-fragment" v
  | Resize v -> cssProp "resize" v
  | RestAfter v -> cssProp "rest-after" v
  | RestBefore v -> cssProp "rest-before" v
  | Right v -> cssProp "right" v
  | RubyAlign v -> cssProp "ruby-align" v
  | RubyMerge v -> cssProp "ruby-merge" v
  | RubyPosition v -> cssProp "ruby-position" v
  | ScrollBehavior v -> cssProp "scroll-behavior" v
  | ScrollSnapCoordinate v -> cssProp "scroll-snap-coordinate" v
  | ScrollSnapDestination v -> cssProp "scroll-snap-destination" v
  | ScrollSnapType v -> cssProp "scroll-snap-type" v
  | ShapeImageThreshold v -> cssProp "shape-image-threshold" v
  | ShapeInside v -> cssProp "shape-inside" v
  | ShapeMargin v -> cssProp "shape-margin" v
  | ShapeOutside v -> cssProp "shape-outside" v
  | ShapeRendering v -> cssProp "shape-rendering" v
  | Speak v -> cssProp "speak" v
  | SpeakAs v -> cssProp "speak-as" v
  | StopColor v -> cssProp "stop-color" v
  | StopOpacity v -> cssProp "stop-opacity" v
  | Stroke v -> cssProp "stroke" v
  | StrokeDasharray v -> cssProp "stroke-dasharray" v
  | StrokeDashoffset v -> cssProp "stroke-dashoffset" v
  | StrokeLinecap v -> cssProp "stroke-linecap" v
  | StrokeLinejoin v -> cssProp "stroke-linejoin" v
  | StrokeMiterlimit v -> cssProp "stroke-miterlimit" v
  | StrokeOpacity v -> cssProp "stroke-opacity" v
  | StrokeWidth v -> cssProp "stroke-width" v
  | TabSize v -> cssProp "tab-size" v
  | TableLayout v -> cssProp "table-layout" v
  | TextAlign v -> cssProp "text-align" v
  | TextAlignLast v -> cssProp "text-align-last" v
  | TextAnchor v -> cssProp "text-anchor" v
  | TextCombineUpright v -> cssProp "text-combine-upright" v
  | TextDecoration v -> cssProp "text-decoration" v
  | TextDecorationColor v -> cssProp "text-decoration-color" v
  | TextDecorationLine v -> cssProp "text-decoration-line" v
  | TextDecorationLineThrough v -> cssProp "text-decoration-line-through" v
  | TextDecorationNone v -> cssProp "text-decoration-none" v
  | TextDecorationOverline v -> cssProp "text-decoration-overline" v
  | TextDecorationSkip v -> cssProp "text-decoration-skip" v
  | TextDecorationStyle v -> cssProp "text-decoration-style" v
  | TextDecorationUnderline v -> cssProp "text-decoration-underline" v
  | TextEmphasis v -> cssProp "text-emphasis" v
  | TextEmphasisColor v -> cssProp "text-emphasis-color" v
  | TextEmphasisPosition v -> cssProp "text-emphasis-position" v
  | TextEmphasisStyle v -> cssProp "text-emphasis-style" v
  | TextHeight v -> cssProp "text-height" v
  | TextIndent v -> cssProp "text-indent" v
  | TextJustify v -> cssProp "text-justify" v
  | TextJustifyTrim v -> cssProp "text-justify-trim" v
  | TextKashidaSpace v -> cssProp "text-kashida-space" v
  | TextLineThrough v -> cssProp "text-line-through" v
  | TextLineThroughColor v -> cssProp "text-line-through-color" v
  | TextLineThroughMode v -> cssProp "text-line-through-mode" v
  | TextLineThroughStyle v -> cssProp "text-line-through-style" v
  | TextLineThroughWidth v -> cssProp "text-line-through-width" v
  | TextOrientation v -> cssProp "text-orientation" v
  | TextOverflow v -> cssProp "text-overflow" v
  | TextOverline v -> cssProp "text-overline" v
  | TextOverlineColor v -> cssProp "text-overline-color" v
  | TextOverlineMode v -> cssProp "text-overline-mode" v
  | TextOverlineStyle v -> cssProp "text-overline-style" v
  | TextOverlineWidth v -> cssProp "text-overline-width" v
  | TextRendering v -> cssProp "text-rendering" v
  | TextScript v -> cssProp "text-script" v
  | TextShadow v -> cssProp "text-shadow" v
  | TextTransform v -> cssProp "text-transform" v
  | TextUnderlinePosition v -> cssProp "text-underline-position" v
  | TextUnderlineStyle v -> cssProp "text-underline-style" v
  | Top v -> cssProp "top" v
  | TouchAction v -> cssProp "touch-action" v
  | Transform v -> cssProp "transform" v
  | TransformBox v -> cssProp "transform-box" v
  | TransformOrigin v -> cssProp "transform-origin" v
  | TransformOriginZ v -> cssProp "transform-origin-z" v
  | TransformStyle v -> cssProp "transform-style" v
  | Transition v -> cssProp "transition" v
  | TransitionDelay v -> cssProp "transition-delay" v
  | TransitionDuration v -> cssProp "transition-duration" v
  | TransitionProperty v -> cssProp "transition-property" v
  | TransitionTimingFunction v -> cssProp "transition-timing-function" v
  | UnicodeBidi v -> cssProp "unicode-bidi" v
  | UnicodeRange v -> cssProp "unicode-range" v
  | UserFocus v -> cssProp "user-focus" v
  | UserInput v -> cssProp "user-input" v
  | VerticalAlign v -> cssProp "vertical-align" v
  | Visibility v -> cssProp "visibility" v
  | VoiceBalance v -> cssProp "voice-balance" v
  | VoiceDuration v -> cssProp "voice-duration" v
  | VoiceFamily v -> cssProp "voice-family" v
  | VoicePitch v -> cssProp "voice-pitch" v
  | VoiceRange v -> cssProp "voice-range" v
  | VoiceRate v -> cssProp "voice-rate" v
  | VoiceStress v -> cssProp "voice-stress" v
  | VoiceVolume v -> cssProp "voice-volume" v
  | WhiteSpace v -> cssProp "white-space" v
  | WhiteSpaceTreatment v -> cssProp "white-space-treatment" v
  | Widows v -> cssProp "widows" v
  | CSSProp.Width v -> cssProp "width" v
  | WillChange v -> cssProp "will-change" v
  | WordBreak v -> cssProp "word-break" v
  | WordSpacing v -> cssProp "word-spacing" v
  | WordWrap v -> cssProp "word-wrap" v
  | WrapFlow v -> cssProp "wrap-flow" v
  | WrapMargin v -> cssProp "wrap-margin" v
  | WrapOption v -> cssProp "wrap-option" v
  | WritingMode v -> cssProp "writing-mode" v
  | ZIndex v -> cssProp "z-index" v
  | Zoom v -> cssProp "zoom" v
  | CSSProp.Custom (key, value) -> cssProp key value

let private renderHtmlAttr (attr: HTMLAttr): string =
  let inline pair (key: string) (value: string) = key + "=\"" + value + "\""
  let inline boolAttr (key: string) (value: bool) = if value then key else ""
  match attr with
  | DefaultChecked v | Checked v -> boolAttr "checked" v
  | DefaultValue v |  Value v -> pair "value" v
  | Accept v -> pair "accept" v
  | AcceptCharset v -> pair "accept-charset" v
  | AccessKey v -> pair "accesskey" v
  | Action v -> pair "action" v
  | AllowFullScreen v -> boolAttr "allowfullscreen" v
  | AllowTransparency v -> boolAttr "allowtransparency" v
  | Alt v -> pair "alt" v
  | AriaHasPopup v -> boolAttr "aria-haspopup" v
  | AriaExpanded v -> boolAttr "aria-expanded" v
  | Async v -> boolAttr "async" v
  | AutoComplete v -> pair "autocomplete" v
  | AutoFocus v -> boolAttr "autofocus" v
  | AutoPlay v -> boolAttr "autoplay" v
  | Capture v -> boolAttr "capture" v
  | CellPadding v -> pair "cellpadding" (string v)
  | CellSpacing v -> pair "cellspacing" (string v)
  | CharSet v -> pair "charset" v
  | Challenge v -> pair "challenge" v
  | ClassID v -> pair "class-id" v
  | ClassName v -> pair "class" v
  | Class v -> pair "class" v
  | Cols v -> pair "cols" (string v)
  | ColSpan v -> pair "colspan" (string v)
  | Content v -> pair "content" v
  | ContentEditable v -> boolAttr "contenteditable" v
  | ContextMenu v -> pair "contextmenu" v
  | Controls v -> boolAttr "controls" v
  | Coords v -> pair "coords" v
  | CrossOrigin v -> pair "crossorigin" v
  // | Data v -> pair "data" v
  | DataToggle v -> pair "data-toggle" v
  | DateTime v -> pair "datetime" v
  | Default v -> boolAttr "default" v
  | Defer v -> boolAttr "defer" v
  | Dir v -> pair "dir" v
  | Disabled v -> boolAttr "disabled" v
  | Download v -> pair "download" (string v)
  | Draggable v -> boolAttr "draggable" v
  | EncType v -> pair "enctype" v
  | Form v -> pair "form" v
  | FormAction v -> pair "formaction" v
  | FormEncType v -> pair "formenctype" v
  | FormMethod v -> pair "formmethod" v
  | FormNoValidate v -> boolAttr "formnovalidate" v
  | FormTarget v -> pair "formtarget" v
  | FrameBorder v -> pair "frameborder" (string v)
  | Headers v -> pair "headers" v
  | HTMLAttr.Height v -> pair "height" (string v)
  | Hidden v -> boolAttr "hidden" v
  // -----
  | High v -> pair "high" (string v)
  | Href v -> pair "href" v
  | HrefLang v -> pair "hreflang" v
  | HtmlFor v -> pair "for" v
  | HttpEquiv v -> pair "http-equiv" v
  | Icon v -> pair "icon" v
  | Id v -> pair "id" v
  | InputMode v -> pair "inputmode" v
  | Integrity v -> pair "integrity" v
  | Is v -> pair "is" v
  | KeyParams v -> pair "keyparams" v
  | KeyType v -> pair "keytype" v
  | Kind v -> pair "kind" v
  | Label v -> pair "label" v
  | Lang v -> pair "lang" v
  | List v -> pair "list" v
  | Loop v -> boolAttr "loop" v
  | Low v -> pair "low" (string v)
  | Manifest v -> pair "manifest" v
  | MarginHeight v -> pair "marginheight" (string v)
  | MarginWidth v -> pair "marginwidth" (string v)
  | Max v -> pair "max" (string v)
  | MaxLength v -> pair "maxlength" (string v)
  | Media v -> pair "media" v
  | MediaGroup v -> pair "mediagroup" v
  | Method v -> pair "method" v
  | Min v -> pair "min" (string v)
  | MinLength v -> pair "minlength" (string v)
  | Multiple v -> boolAttr "multiple" v
  | Muted v -> pair "muted" (string v)
  | Name v -> pair "name" v
  | NoValidate v -> boolAttr "novalidate" v
  | Open v -> boolAttr "open" v
  | Optimum v -> pair "optimum" (string v)
  | Pattern v -> pair "pattern" v
  | Placeholder v -> pair "placeholder" v
  | Poster v -> pair "poster" v
  | Preload v -> pair "preload" v
  | RadioGroup v -> pair "radiogroup" v
  | ReadOnly v -> boolAttr "readonly" v
  | Rel v -> pair "rel" v
  | Required v -> boolAttr "required" v
  | Role v -> pair "role" v
  | Rows v -> pair "rows" (string v)
  | RowSpan v -> pair "row-span" (string v)
  | Sandbox v -> pair "sandbox" v
  | Scope v -> pair "scope" v
  | Scoped v -> boolAttr "scoped" v
  | Scrolling v -> pair "scrolling" v
  | Seamless v -> boolAttr "seamless" v
  | Selected v -> boolAttr "selected" v
  | Shape v -> pair "shape" v
  | Size v -> pair "size" (string v)
  | Sizes v -> pair "sizes" v
  | Span v -> pair "span" (string v)
  | SpellCheck v -> boolAttr "spellcheck" v
  | Src v -> pair "src" v
  | SrcDoc v -> pair "srcdoc" v
  | SrcLang v -> pair "srclang" v
  | SrcSet v -> pair "srcset" v
  | Start v -> pair "start" (string v)
  | Step v -> pair "step" (string v)
  | Summary v -> pair "summary" v
  | TabIndex v -> pair "tabindex" (string v)
  | Target v -> pair "target" v
  | Title v -> pair "title" v
  | Type v -> pair "type" v
  | UseMap v -> pair "use-map" v
  | HTMLAttr.Width v -> pair "width" (string v)
  | Wmode v -> pair "wmode" v
  | Wrap v -> pair "wrap" v
  | About v -> pair "about" v
  | Datatype v -> pair "datatype" v
  | Inlist v -> pair "inlist" (string v)
  | Prefix v -> pair "prefix" v
  | Property v -> pair "property" v
  | Resource v -> pair "resource" v
  | Typeof v -> pair "typeof" v
  | Vocab v -> pair "vocab" v
  | AutoCapitalize v -> pair "auto-capitalize" v
  | AutoCorrect v -> pair "auto-correct" v
  | AutoSave v -> pair "auto-save" v
  // | Color v -> pair "color" v // Conflicts with CSSProp, shouldn't be used in HTML5
  | ItemProp v -> pair "itemprop" v
  | ItemScope v -> boolAttr "itemscope" v
  | ItemType v -> pair "itemtype" v
  | ItemID v -> pair "itemid" v
  | ItemRef v -> pair "itemref" v
  | Results v -> pair "results" (string v)
  | Security v -> pair "security" v
  | Unselectable v -> boolAttr "unselectable" v
  | Style cssList ->
    let css = StringBuilder()
    for cssProp in cssList do
      css.Append(renderCssProp cssProp) |> ignore
      css.Append(" ") |> ignore
    pair "style" (css.ToString())

  | Custom (key, value) -> pair key (string value)
  | Data (key, value) -> pair ("data-" + key) (string value)

let private renderSVGAttr (attr: SVGAttr): string =
  let inline pair (key: string) (value: obj) = key + "=\"" +  (string value) + "\""
  match attr with
  | SVGAttr.ClipPath v -> pair "clip-path" v
  | SVGAttr.Cx v -> pair "cx" v
  | SVGAttr.Cy v -> pair "cy" v
  | SVGAttr.D v -> pair "d" v
  | SVGAttr.Dx v -> pair "dx" v
  | SVGAttr.Dy v -> pair "dy" v
  | SVGAttr.Fill v -> pair "fill" v
  | SVGAttr.FillOpacity v -> pair "fill-opacity" v
  | SVGAttr.FontFamily v -> pair "font-family" v
  | SVGAttr.FontSize v -> pair "font-size" v
  | SVGAttr.Fx v -> pair "fx" v
  | SVGAttr.Fy v -> pair "fy" v
  | SVGAttr.GradientTransform v -> pair "gradient-transform" v
  | SVGAttr.GradientUnits v -> pair "gradient-units" v
  | SVGAttr.Height v -> pair "height" v
  | SVGAttr.MarkerEnd v -> pair "marker-end" v
  | SVGAttr.MarkerMid v -> pair "marker-mid" v
  | SVGAttr.MarkerStart v -> pair "marker-start" v
  | SVGAttr.Offset v -> pair "offset" v
  | SVGAttr.Opacity v -> pair "opacity" v
  | SVGAttr.PatternContentUnits v -> pair "pattern-content-units" v
  | SVGAttr.PatternUnits v -> pair "pattern-units" v
  | SVGAttr.Points v -> pair "points" v
  | SVGAttr.PreserveAspectRatio v -> pair "preserve-aspect-ratio" v
  | SVGAttr.R v -> pair "r" v
  | SVGAttr.Rx v -> pair "rx" v
  | SVGAttr.Ry v -> pair "ry" v
  | SVGAttr.SpreadMethod v -> pair "spread-method" v
  | SVGAttr.StopColor v -> pair "stop-color" v
  | SVGAttr.StopOpacity v -> pair "stop-opacity" v
  | SVGAttr.Stroke v -> pair "stroke" v
  | SVGAttr.StrokeDasharray v -> pair "stroke-dasharray" v
  | SVGAttr.StrokeLinecap v -> pair "stroke-linecap" v
  | SVGAttr.StrokeMiterlimit v -> pair "stroke-miterlimit" v
  | SVGAttr.StrokeOpacity v -> pair "stroke-opacity" v
  | SVGAttr.StrokeWidth v -> pair "stroke-width" v
  | SVGAttr.TextAnchor v -> pair "text-anchor" v
  | SVGAttr.Transform v -> pair "transform" v
  | SVGAttr.Version v -> pair "version" v
  | SVGAttr.ViewBox v -> pair "view-box" v
  | SVGAttr.Width v -> pair "width" v
  | SVGAttr.X1 v -> pair "x1" v
  | SVGAttr.X2 v -> pair "x2" v
  | SVGAttr.X v -> pair "x" v
  | SVGAttr.XlinkActuate v -> pair "xlink:actuate" v
  | SVGAttr.XlinkArcrole v -> pair "xlink:arcrole" v
  | SVGAttr.XlinkHref v -> pair "xlink:href" v
  | SVGAttr.XlinkRole v -> pair "xlink:role" v
  | SVGAttr.XlinkShow v -> pair "xlink:show" v
  | SVGAttr.XlinkTitle v -> pair "xlink:title" v
  | SVGAttr.XlinkType v -> pair "xlink:type" v
  | SVGAttr.XmlBase v -> pair "xml:base" v
  | SVGAttr.XmlLang v -> pair "xml:lang" v
  | SVGAttr.XmlSpace v -> pair "xml:space" v
  | SVGAttr.Y1 v -> pair "y1" v
  | SVGAttr.Y2 v -> pair "y2" v
  | SVGAttr.Y v -> pair "y" v
  | SVGAttr.Custom (key, value) -> pair key value

let private renderAttrs (attrs: IHTMLProp seq) =
  let html = StringBuilder()
  let mutable childHtml = None
  for attr in attrs do
    match attr with
    | :? DOMAttr as attr ->
      match attr with
      | DangerouslySetInnerHTML v ->
          childHtml <- Some v.__html
      | _ -> ()
    | :? HTMLAttr as attr ->
      html.Append(renderHtmlAttr attr) |> ignore
      html.Append(" ") |> ignore
    | _ -> ()

  html.ToString().Trim(), childHtml

let renderToString (htmlNode: ReactElement): string =

  let rec render (htmlNode: ReactElement): string =
    let inline renderList (nodes: HTMLNode seq) =
      let html = StringBuilder()
      for node in nodes do
        html.Append(render node) |> ignore
      html.ToString()

    match htmlNode :?> HTMLNode with
    | HTMLNode.Text str -> str
    | HTMLNode.Node (tag, attrs, children) ->
      let attrs, child = renderAttrs (attrs |> Seq.cast)
      let child =
        match child with
        | Some c -> c
        | None -> (renderList (children |> Seq.cast))
      let attrs = if attrs = "" then attrs else " " + attrs
      "<" + tag + attrs + ">" + child + "</" + tag + ">"
    | HTMLNode.List nodes -> renderList (nodes |> Seq.cast)

  render htmlNode
