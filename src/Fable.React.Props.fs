module rec Fable.React.Props

open Fable.Core
open Fable.Core.JsInterop
open Browser.Types

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
    | Ref of (Element->unit)
    /// To be used in combination with `useRef` hook
    | [<System.Obsolete("Use RefValue")>] [<CompiledName("ref")>] RefHook of IRefHook<Element option>
    | [<CompiledName("ref")>] RefValue of IRefValue<Element option>
    interface IHTMLProp

type DangerousHtml = {
    __html: string
}

type DOMAttr =
    | DangerouslySetInnerHTML of DangerousHtml
    | OnCut of (ClipboardEvent -> unit)
    | OnPaste of (ClipboardEvent -> unit)
    | OnCompositionEnd of (CompositionEvent -> unit)
    | OnCompositionStart of (CompositionEvent -> unit)
    | OnCopy of (ClipboardEvent -> unit)
    | OnCompositionUpdate of (CompositionEvent -> unit)
    | OnFocus of (FocusEvent -> unit)
    | OnBlur of (FocusEvent -> unit)
    | OnChange of (Event -> unit)
    | OnInput of (Event -> unit)
    | OnSubmit of (Event -> unit)
    | OnReset of (Event -> unit)
    | OnLoad of (Event -> unit)
    | OnError of (Event -> unit)
    | OnKeyDown of (KeyboardEvent -> unit)
    | OnKeyPress of (KeyboardEvent -> unit)
    | OnKeyUp of (KeyboardEvent -> unit)
    | OnAbort of (Event -> unit)
    | OnCanPlay of (Event -> unit)
    | OnCanPlayThrough of (Event -> unit)
    | OnDurationChange of (Event -> unit)
    | OnEmptied of (Event -> unit)
    | OnEncrypted of (Event -> unit)
    | OnEnded of (Event -> unit)
    | OnLoadedData of (Event -> unit)
    | OnLoadedMetadata of (Event -> unit)
    | OnLoadStart of (Event -> unit)
    | OnPause of (Event -> unit)
    | OnPlay of (Event -> unit)
    | OnPlaying of (Event -> unit)
    | OnProgress of (Event -> unit)
    | OnRateChange of (Event -> unit)
    | OnSeeked of (Event -> unit)
    | OnSeeking of (Event -> unit)
    | OnStalled of (Event -> unit)
    | OnSuspend of (Event -> unit)
    | OnTimeUpdate of (Event -> unit)
    | OnVolumeChange of (Event -> unit)
    | OnWaiting of (Event -> unit)
    | OnClick of (MouseEvent -> unit)
    | OnContextMenu of (MouseEvent -> unit)
    | OnDoubleClick of (MouseEvent -> unit)
    | OnDrag of (DragEvent -> unit)
    | OnDragEnd of (DragEvent -> unit)
    | OnDragEnter of (DragEvent -> unit)
    | OnDragExit of (DragEvent -> unit)
    | OnDragLeave of (DragEvent -> unit)
    | OnDragOver of (DragEvent -> unit)
    | OnDragStart of (DragEvent -> unit)
    | OnDrop of (DragEvent -> unit)
    | OnMouseDown of (MouseEvent -> unit)
    | OnMouseEnter of (MouseEvent -> unit)
    | OnMouseLeave of (MouseEvent -> unit)
    | OnMouseMove of (MouseEvent -> unit)
    | OnMouseOut of (MouseEvent -> unit)
    | OnMouseOver of (MouseEvent -> unit)
    | OnMouseUp of (MouseEvent -> unit)
    | OnSelect of (Event -> unit)
    | OnTouchCancel of (TouchEvent -> unit)
    | OnTouchEnd of (TouchEvent -> unit)
    | OnTouchMove of (TouchEvent -> unit)
    | OnTouchStart of (TouchEvent -> unit)
    | OnScroll of (UIEvent -> unit)
    | OnWheel of (WheelEvent -> unit)
    | OnAnimationStart of (AnimationEvent -> unit)
    | OnAnimationEnd of (AnimationEvent -> unit)
    | OnAnimationIteration of (AnimationEvent -> unit)
    | OnTransitionEnd of (TransitionEvent -> unit)
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

[<StringEnum; RequireQualifiedAccess>]
/// Specifies the display behavior (the type of rendering box) of an element.
type DisplayOptions =
    /// The element is completely removed
    | None
    /// Sets this property to its default value. Read more about [CSS Initial value](https://www.w3schools.com/CSSref/css_initial.asp)
    | Initial
    /// Inherits this property from its parent element. Read about [CSS Inherit](https://www.w3schools.com/CSSref/css_inherit.asp)
    | Inherit
    /// Displays an element as an inline element (like `<span>`). Any height and width properties will have no effect.
    | Inline
    /// Displays an element as a block element (like `<p>`). It starts on a new line, and takes up the whole width.
    | Block
    /// Makes the container disappear, making the child elements children of the element the next level up in the DOM.
    | Contents
    /// Displays an element as a block-level flex container.
    | Flex
    /// Displays an element as a block-level grid container.
    | Grid
    /// Let the element behave like a `<table>` element
    | Table
    /// Displays an element as an inline-level block container. The element itself is formatted as an inline element, but you can apply height and width values
    | [<CompiledName "inline-block">] InlineBlock
    /// Displays an element as an inline-level flex container.
    | [<CompiledName "inline-flex">] InlineFlex
    /// Displays an element as an inline-level grid container.
    | [<CompiledName "inline-grid">] InlineGrid
    /// The element is displayed as an inline-level table.
    | [<CompiledName "inline-table">] InlineTable
    /// Let the element behave like a `<li>` element.
    | [<CompiledName "list-item">] ListItem
    /// Let the element behave like a `<caption>` element
    | [<CompiledName "table-caption">] TableCaption
    /// Let the element behave like a `<colgroup>` element.
    | [<CompiledName "table-column-group">] TableColumnGroup
    /// Let the element behave like a `<thead>` element.
    | [<CompiledName "table-header-group">] TableHeaderGroup
    /// Let the element behave like a `<tfoot>` element.
    | [<CompiledName "table-footer-group">] TableFooterGroup
    /// Let the element behave like a `<tbody>` element.
    | [<CompiledName "table-row-group">] TableRowGroup
    /// Let the element behave like a `<td>` element.
    | [<CompiledName "table-cell">] TableCell
    /// Let the element behave like a `<col>` element.
    | [<CompiledName "table-column">] TableColumn
    /// Let the element behave like a `<tr>` element.
    | [<CompiledName "table-row">] TableRow

[<StringEnum; RequireQualifiedAccess>]
/// Modifies the behavior of the [flex-wrap](https://www.w3schools.com/CSSref/css3_pr_flex-wrap.asp) property. It is similar to [align-items](https://www.w3schools.com/CSSref/css3_pr_align-items.asp), but instead of aligning flex items, it aligns flex lines.
type AlignContentOptions =
    /// Default value. Lines stretch to take up the remaining space.
    | Stretch
    /// Lines are packed toward the center of the flex container.
    | Center
    /// /// Sets this property to its default value. Read more about [CSS Initial value](https://www.w3schools.com/CSSref/css_initial.asp)
    | Initial
    /// Inherits this property from its parent element. Read about [CSS Inherit](https://www.w3schools.com/CSSref/css_inherit.asp)
    | Inherit
    /// Lines are packed toward the start of the flex container.
    | [<CompiledName "flex-start">] FlexStart
    /// Lines are packed toward the end of the flex container.
    | [<CompiledName "flex-end">] FlexEnd
    /// Lines are evenly distributed in the flex container.
    | [<CompiledName "space-between">] SpaceBetween
    /// Lines are evenly distributed in the flex container, with half-size spaces on either end.
    | [<CompiledName "space-around">] SpaceAround

[<StringEnum; RequireQualifiedAccess>]
/// Specifies the default alignment for items inside the flexible container.
type AlignItemsOptions =
    /// The effect of this keyword is dependent of the layout mode we are in. [Read more](https://developer.mozilla.org/en-US/docs/Web/CSS/align-items#Values)
    | Normal
    /// Items are positioned at the baseline of the container
    | Baseline
    /// Default. Items are stretched to fit the container.
    | Stretch
    /// Items are positioned at the center of the container.
    | Center
    /// Sets this property to its default value. Read more about [CSS Initial value](https://www.w3schools.com/CSSref/css_initial.asp)
    | Initial
    /// Inherits this property from its parent element. Read about [CSS Inherit](https://www.w3schools.com/CSSref/css_inherit.asp)
    | Inherit
    /// Items are positioned at the beginning of the container.
    | [<CompiledName "flex-start">] FlexStart
    /// Items are positioned at the end of the container.
    | [<CompiledName "flex-end">] FlexEnd

[<StringEnum; RequireQualifiedAccess>]
/// Specifies the default alignment for items inside the flexible container.
type AlignSelfOptions =
    /// Default. The element inherits its parent container's align-items property, or "stretch" if it has no parent container.
    | Auto
    /// The element is positioned at the baseline of the container.
    | Baseline
    /// The element is positioned to fit the container.
    | Stretch
    /// The element is positioned at the center of the container.
    | Center
    /// Sets this property to its default value. Read more about [CSS Initial value](https://www.w3schools.com/CSSref/css_initial.asp)
    | Initial
    /// Inherits this property from its parent element. Read about [CSS Inherit](https://www.w3schools.com/CSSref/css_inherit.asp)
    | Inherit
    /// The element is positioned at the beginning of the container.
    | [<CompiledName "flex-start">] FlexStart
    /// The element is positioned at the end of the container.
    | [<CompiledName "flex-end">] FlexEnd

[<StringEnum; RequireQualifiedAccess>]
type TextAlignOptions =
    /// Aligns the text to the left.
    | Left
    /// Aligns the text to the right.
    | Right
    /// Centers the text.
    | Center
    /// Stretches the lines so that each line has equal width (like in newspapers and magazines).
    | Justify
    /// Sets this property to its default value. Read more about [CSS Initial value](https://www.w3schools.com/CSSref/css_initial.asp)
    | Initial
    /// Inherits this property from its parent element. Read about [CSS Inherit](https://www.w3schools.com/CSSref/css_inherit.asp)
    | Inherit

[<StringEnum; RequireQualifiedAccess>]
/// Specifies the type of positioning method used for an element (static, relative, absolute, fixed, or sticky).
type PositionOptions =
    /// Default value. Elements render in order, as they appear in the document flow.
    | Static
    /// The element is positioned relative to its first positioned (not static) ancestor element.
    | Absolute
    /// The element is positioned relative to the browser window.
    | Fixed
    /// The element is positioned relative to its normal position, so "left:20px" adds 20 pixels to the element's LEFT position.
    | Relative
    /// The element is positioned based on the user's scroll position.
    ///
    /// A sticky element toggles between relative and fixed, depending on the scroll position. It is positioned relative until a given offset position is met in the viewport - then it "sticks" in place (like position:fixed).
    | Sticky
    /// Sets this property to its default value. Read more about [CSS Initial value](https://www.w3schools.com/CSSref/css_initial.asp)
    | Initial
    /// Inherits this property from its parent element. Read about [CSS Inherit](https://www.w3schools.com/CSSref/css_inherit.asp)
    | Inherit

[<StringEnum; RequireQualifiedAccess>]
/// https://drafts.csswg.org/css-overflow-3/#propdef-overflow
type OverflowOptions =
    /// There is no special handling of overflow, that is, the box’s content is rendered outside the box if positioned there. The box is not a scroll container.
    | Visible
    /// This value indicates that the box’s content is clipped to its padding box and that the UA must not provide any scrolling user interface to view the content outside the clipping region, nor allow scrolling by direct intervention of the user, such as dragging on a touch screen or using the scrolling wheel on a mouse. However, the content must still be scrollable programatically, for example using the mechanisms defined in  [CSSOM-VIEW], and the box is therefore still a scroll container.
    | Hidden
    /// Like hidden, this value indicates that the box’s content is clipped to its padding box and that no scrolling user interface should be provided by the UA to view the content outside the clipping region. In addition, unlike overflow: hidden which still allows programmatic scrolling, overflow: clip forbids scrolling entirely, through any mechanism, and therefore the box is not a scroll container.
    | Clip
    /// This value indicates that the content is clipped to the padding box, but can be scrolled into view (and therefore the box is a scroll container). Furthermore, if the user agent uses a scrolling mechanism that is visible on the screen (such as a scroll bar or a panner), that mechanism should be displayed whether or not any of its content is clipped. This avoids any problem with scrollbars appearing and disappearing in a dynamic environment. When the target medium is print, overflowing content may be printed; it is not defined where it may be printed.
    | Scroll
    /// Like scroll when the box has scrollable overflow; like hidden otherwise. Thus, if the user agent uses a scrolling mechanism that is visible on the screen (such as a scroll bar or a panner), that mechanism will only be displayed if there is overflow.
    | Auto

type CSSProp =
    | AlignContent of AlignContentOptions
    | AlignItems of AlignItemsOptions
    | AlignSelf of AlignSelfOptions
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
    | Display of DisplayOptions
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
    | OverflowStyle of obj
    | OverflowWrap of obj
    | OverflowX of OverflowOptions
    | OverflowY of OverflowOptions
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
    | Position of PositionOptions
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
    | TextAlign of TextAlignOptions
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
    static member Overflow (overflow: OverflowOptions, ?overflowY: OverflowOptions) =
        CSSProp.Custom ("overflow",  unbox overflow + " " + unbox overflowY)

#if FABLE_COMPILER
let inline Style (css: CSSProp list): HTMLAttr =
    !!("style", keyValueList CaseRules.LowerFirst css)

let inline Data (key: string, value: obj): HTMLAttr =
    !!("data-" + key, value)
#endif
