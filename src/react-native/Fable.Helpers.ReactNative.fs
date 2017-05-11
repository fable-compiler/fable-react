module Fable.Helpers.ReactNative

open System
open Fable.Import.ReactNative
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.PowerPack

type RN = ReactNative.Globals

type Ref<'t> = ('t -> unit)

module Props =

    [<StringEnum; RequireQualifiedAccess>]
    type ToolbarActionShowStatus =
    | IfRoom
    | Always
    | Never

    [<StringEnum; RequireQualifiedAccess>]
    type Alignment =
    | Auto
    | [<CompiledName("flex-start")>] FlexStart
    | Center
    | [<CompiledName("flex-end")>] FlexEnd
    | Stretch

    [<StringEnum; RequireQualifiedAccess>]
    type ItemAlignment =
    | [<CompiledName("flex-start")>] FlexStart
    | Center
    | [<CompiledName("flex-end")>] FlexEnd
    | Stretch

    [<StringEnum; RequireQualifiedAccess>]
    type TextAlignment =
    | Auto
    | Default
    | Left
    | Center
    | Right
    | Justify

    [<StringEnum; RequireQualifiedAccess>]
    type TextAlignVertical =
    | Auto
    | Top
    | Bottom
    | Center

    [<StringEnum; RequireQualifiedAccess>]
    type JustifyContent =
    | [<CompiledName("flex-start")>] FlexStart
    | Center
    | [<CompiledName("flex-end")>] FlexEnd
    | [<CompiledName("space-between")>] SpaceBetween
    | [<CompiledName("space-around")>] SpaceAround

    [<StringEnum; RequireQualifiedAccess>]
    type FlexDirection =
    | Row
    | [<CompiledName("row-reverse")>] RowReverse
    | Column
    | [<CompiledName("column-reverse")>] ColumnReverse

    [<StringEnum; RequireQualifiedAccess>]
    type FlexWrap =
    | Row
    | [<CompiledName("wrap")>] Wrap
    | Column
    | [<CompiledName("nowrap")>] NoWrap

    [<StringEnum; RequireQualifiedAccess>]
    type KeyboardType =
    | Default
    | [<CompiledName("email-address")>] EmailAddress
    | Numeric
    | [<CompiledName("phone-pad")>] PhonePad
    /// only iOS
    | [<CompiledName("ascii-capable")>] AsciiCapable
    | [<CompiledName("numbers-and-punctuation")>] NumbersAndPunctuation
    | [<CompiledName("url")>] Url
    | [<CompiledName("number-pad")>] NumberPad
    | [<CompiledName("name-phone-pad")>] NamePhonePad
    | [<CompiledName("decimal-pad")>] DecimalPad
    | Twitter
    | [<CompiledName("web-search")>] WebSearch

    [<StringEnum; RequireQualifiedAccess>]
    type Position =
    | Row
    | [<CompiledName("absolute")>] Absolute
    | Column
    | [<CompiledName("relative")>] Relative

    [<StringEnum; RequireQualifiedAccess>]
    type ResizeMode =
    | Contain
    | Cover
    | Stretch
    | Conter
    | Repeat

    [<StringEnum; RequireQualifiedAccess>]
    type ReturnKeyType =
    | Done
    | Go
    | Next
    | Search
    | Send
    | None
    | Previous
    | Default
    | [<CompiledName("emergency-call")>] EmergencyCall
    | Google
    | Join
    | Route
    | Yahoo

    [<StringEnum; RequireQualifiedAccess>]
    type AutoCapitalizeType =
    | None
    | Sentences
    | Words
    | Characters

    [<StringEnum; RequireQualifiedAccess>]
    type KeyboardDismissMode  =
    | None
    | [<CompiledName("on-drag")>] OnDrag

    [<StringEnum; RequireQualifiedAccess>]
    type DrawerLockMode =
    | Unlocked
    | [<CompiledName("locked-closed")>] LockedClosed
    | [<CompiledName("locked-open")>] LockedOpen

    [<StringEnum; RequireQualifiedAccess>]
    type AlignSelf =
        | Auto

    [<StringEnum; RequireQualifiedAccess>]
    type TextDecorationStyle =
        | Solid | Double | Dotted | Dashed

    [<StringEnum; RequireQualifiedAccess>]
    type FontStyle =
        | Normal | Italic

    [<StringEnum; RequireQualifiedAccess>]
    type WritingDirection =
        | Auto | Ltr | Rtl

    [<StringEnum; RequireQualifiedAccess>]
    type ScrollState =
        Idle | Dragging | Settling

    [<StringEnum; RequireQualifiedAccess>]
    type FontWeight =
        | Normal
        | Bold
        | [<CompiledName("100")>] F100
        | [<CompiledName("200")>] F200
        | [<CompiledName("300")>] F300
        | [<CompiledName("400")>] F400
        | [<CompiledName("500")>] F500
        | [<CompiledName("600")>] F600
        | [<CompiledName("700")>] F700
        | [<CompiledName("800")>] F800
        | [<CompiledName("900")>] F900

    [<StringEnum; RequireQualifiedAccess>]
    type TextDecorationLine =
        | None | Underline
        | ``Line-through``
        | ``Underline line-through``

    [<StringEnum; RequireQualifiedAccess>]
    type LineBreakMode =
        | Head | Middle | Tail | Clip

    [<StringEnum; RequireQualifiedAccess>]
    type AutoCapitalize =
        | None | Sentences | Words | Characters

    [<StringEnum; RequireQualifiedAccess>]
    type BackfaceVisibility =
        | Visible | Hidden

    [<StringEnum; RequireQualifiedAccess>]
    type BorderStyle =
        | Solid | Dotted | Dashed

    [<StringEnum; RequireQualifiedAccess>]
    type Overflow =
        | Visible | Hidden

    [<StringEnum; RequireQualifiedAccess>]
    type Behavior =
        | Height | Position | Padding

    [<StringEnum; RequireQualifiedAccess>]
    type NavigationType =
        | Other | Click

    [<StringEnum; RequireQualifiedAccess>]
    type Size =
        | Small | Large

    [<StringEnum; RequireQualifiedAccess>]
    type Mode =
        | Date | Time | Datetime

    [<StringEnum; RequireQualifiedAccess>]
    type DatePickerIOSMode =
        | Dialog | Dropdown

    [<StringEnum; RequireQualifiedAccess>]
    type StyleAttr =
        | Horizontal | Normal | Small | Large | Inverse | SmallInverse | LargeInverse

    [<StringEnum; RequireQualifiedAccess>]
    type ProgressViewStyle =
        | Default | Bar

    [<StringEnum; RequireQualifiedAccess>]
    type AnimationType =
        | None | Slide | Fade

    [<StringEnum; RequireQualifiedAccess>]
    type SystemIcon =
        | Bookmarks | Contacts | Downloads | Favorites | Featured | History | More | ``Most-recent`` | ``Most-viewed`` | Recents | Search | ``Top-rated``

    [<StringEnum; RequireQualifiedAccess>]
    type Dim =
        | Window | Screen

    [<StringEnum; RequireQualifiedAccess>]
    type IndicatorStyle =
        | Default | Black | White

    [<StringEnum; RequireQualifiedAccess>]
    type DecelerationRate =
        | Fast | Normal

    [<StringEnum; RequireQualifiedAccess>]
    type AlertButtonStyle =
        | Default | Cancel | Destructive

    [<StringEnum; RequireQualifiedAccess>]
    type GroupTypes =
        | Album | All | Event | Faces | Library | PhotoStream | SavedPhotos

    [<StringEnum; RequireQualifiedAccess>]
    type AssetType =
        | All | Videos | Photos

    [<StringEnum; RequireQualifiedAccess>]
    type ShowHideTransition =
        | Fade | Slide

    [<StringEnum; RequireQualifiedAccess>]
    type Direction =
        | Horizontal | Vertical

    [<KeyValueList>]
    type IStyle =
        interface end

    [<KeyValueList>]
    type IScrollViewStyle =
        inherit IStyle

    [<KeyValueList>]
    type ISwitchIOSStyle =
        inherit IStyle

    [<KeyValueList>]
    type ITextStyle =
        inherit IStyle

    [<KeyValueList>]
    type ITextStyleIOS =
        inherit IStyle

    [<KeyValueList>]
    type ITextStyleAndroid =
        inherit IStyle

    [<KeyValueList>]
    type IImageStyle =
        inherit IStyle

    [<KeyValueList>]
    type ITransformsStyle =
        inherit IStyle

    [<KeyValueList>]
    type IViewStyle =
        inherit IStyle

    [<KeyValueList>]
    type IFlexStyle =
        inherit IStyle

    [<KeyValueList>]
    type IGestureResponderHandlers =
        interface end

    [<KeyValueList>]
    type IToolbarAndroidProperties =
        interface end

    [<KeyValueList>]
    type ISegmentedControlIOSProperties =
        interface end

    [<KeyValueList>]
    type IWebViewProperties =
        interface end

    [<KeyValueList>]
    type IWebViewPropertiesAndroid =
        inherit IWebViewProperties

    [<KeyValueList>]
    type IWebViewPropertiesIOS =
        inherit IWebViewProperties

    [<KeyValueList>]
    type IDatePickerIOSProperties =
        interface end

    [<KeyValueList>]
    type IDrawerLayoutAndroidProperties =
        interface end

    [<KeyValueList>]
    type IPickerProperties =
        interface end

    [<KeyValueList>]
    type IProgressBarAndroidProperties =
        interface end

    [<KeyValueList>]
    type IProgressViewIOSProperties =
        interface end

    [<KeyValueList>]
    type IRefreshControlProperties =
        interface end

    [<KeyValueList>]
    type ISliderProperties =
        interface end

    [<KeyValueList>]
    type ISliderIOSProperties =
        interface end

    [<KeyValueList>]
    type ITabBarItemProperties =
        interface end

    [<KeyValueList>]
    type ITabBarIOSProperties =
        interface end

    [<KeyValueList>]
    type IListViewProperties =
        interface end

    [<KeyValueList>]
    type IScrollViewProperties =
        inherit IListViewProperties

    [<KeyValueList>]
    type IStatusBarProperties =
        interface end

    [<KeyValueList>]
    type ISwitchProperties =
        interface end

    [<KeyValueList>]
    type IKeyboardAvoidingViewProps =
        interface end

    [<KeyValueList>]
    type IActivityIndicatorProperties =
        interface end

    [<KeyValueList>]
    type IActivityIndicatorIOSProperties =
        interface end

    [<KeyValueList>]
    type IMapViewProperties  =
        interface end

    [<KeyValueList>]
    type IMapViewPropertiesAndroid  =
        inherit IMapViewProperties

    [<KeyValueList>]
    type IViewPropertiesIOS =
        interface end

    [<KeyValueList>]
    type IViewPropertiesAndroid =
        interface end

    [<KeyValueList>]
    type IViewPagerAndroidProperties =
        interface end

    [<KeyValueList>]
    type IViewProperties =
        inherit IViewPropertiesAndroid
        inherit IViewPropertiesIOS
        inherit IToolbarAndroidProperties
        inherit IGestureResponderHandlers
        inherit IViewPagerAndroidProperties
        inherit IKeyboardAvoidingViewProps
        inherit IWebViewProperties
        inherit ISegmentedControlIOSProperties
        inherit IActivityIndicatorProperties
        inherit IActivityIndicatorIOSProperties
        inherit IDatePickerIOSProperties
        inherit IDrawerLayoutAndroidProperties
        inherit IPickerProperties
        inherit IProgressBarAndroidProperties
        inherit IProgressViewIOSProperties
        inherit IRefreshControlProperties
        inherit ISliderProperties
        inherit ISliderIOSProperties
        inherit ITabBarItemProperties
        inherit ITabBarIOSProperties
        inherit IScrollViewProperties
        inherit IStatusBarProperties
        inherit ISwitchProperties
        inherit IMapViewProperties

    [<KeyValueList>]
    type ITouchable =
        inherit IScrollViewProperties
        inherit IMapViewProperties
        inherit IViewProperties

    [<KeyValueList>]
    type TransformsStyle =
        | Transform of obj * obj * obj * obj * obj * obj * obj * obj * obj * obj * obj * obj
        | TransformMatrix of ResizeArray<float>
        | Rotation of float
        | ScaleX of float
        | ScaleY of float
        | TranslateX of float
        | TranslateY of float
        interface ITransformsStyle

    [<KeyValueList>]
    type FlexStyle =
        | AlignItems of ItemAlignment
        | AlignSelf of Alignment
        | BorderBottomWidth of float
        | BorderLeftWidth of float
        | BorderRightWidth of float
        | BorderTopWidth of float
        | BorderWidth of float
        | Bottom of float
        | Flex of float
        | FlexDirection of FlexDirection
        | FlexWrap of FlexWrap
        | Height of float
        | JustifyContent of JustifyContent
        | Left of float
        | MinWidth of float
        | MaxWidth of float
        | MinHeight of float
        | MaxHeight of float
        | Margin of float
        | MarginBottom of float
        | MarginHorizontal of float
        | MarginLeft of float
        | MarginRight of float
        | MarginTop of float
        | MarginVertical of float
        | Padding of float
        | PaddingBottom of float
        | PaddingHorizontal of float
        | PaddingLeft of float
        | PaddingRight of float
        | PaddingTop of float
        | PaddingVertical of float
        | Position of Position
        | Right of float
        | Top of float
        | Width of float
        | ZIndex of float
        interface IFlexStyle


    [<KeyValueList>]
    type ViewStyle =
        | BackfaceVisibility of string
        | BackgroundColor of string
        | BorderBottomColor of string
        | BorderBottomLeftRadius of float
        | BorderBottomRightRadius of float
        | BorderBottomWidth of float
        | BorderColor of string
        | BorderLeftColor of string
        | BorderRadius of float
        | BorderRightColor of string
        | BorderRightWidth of float
        | BorderStyle of BorderStyle
        | BorderTopColor of string
        | BorderTopLeftRadius of float
        | BorderTopRightRadius of float
        | BorderTopWidth of float
        | Opacity of float
        | Overflow of Overflow
        | ShadowColor of string
        | ShadowOffset of obj
        | ShadowOpacity of float
        | ShadowRadius of float
        | Elevation of float
        | TestID of string
        interface IViewStyle

    [<KeyValueList>]
    type Insets =
        | Top of float
        | Left of float
        | Bottom of float
        | Right of float

    [<KeyValueList>]
    type Touchable =
        | OnTouchStart of (GestureResponderEvent -> unit)
        | OnTouchMove of (GestureResponderEvent -> unit)
        | OnTouchEnd of (GestureResponderEvent -> unit)
        | OnTouchCancel of (GestureResponderEvent -> unit)
        | OnTouchEndCapture of (GestureResponderEvent -> unit)
        interface ITouchable

    [<KeyValueList>]
    type LayoutAnimationAnim =
        | Duration of float
        | Delay of float
        | SpringDamping of float
        | InitialVelocity of float
        | Type of string
        | Property of string

    [<KeyValueList>]
    type LayoutAnimationConfig =
        | Delay of float //REQUIRED!
        | Create of LayoutAnimationAnim
        | Update of LayoutAnimationAnim
        | Delete of LayoutAnimationAnim

    [<KeyValueList>]
    type TextStyleIOS =
        | LetterSpacing of float
        | TextDecorationColor of string
        | TextDecorationStyle of TextDecorationStyle
        | WritingDirection of WritingDirection
        interface ITextStyleIOS

    [<KeyValueList>]
    type TextStyleAndroid =
        | TextAlignVertical of TextAlignVertical
        interface ITextStyleAndroid

    [<KeyValueList>]
    type TextStyle =
        | Color of string
        | FontFamily of string
        | FontSize of float
        | FontStyle of FontStyle
        | FontWeight of FontWeight
        | LetterSpacing of float
        | LineHeight of float
        | TextAlign of TextAlignment
        | TextDecorationLine of TextDecorationLine
        | TextDecorationStyle of TextDecorationStyle
        | TextDecorationColor of string
        | TextShadowColor of string
        | TextShadowOffset of obj
        | TextShadowRadius of float
        | TestID of string
        interface ITextStyle

    [<KeyValueList>]
    type ITextPropertiesIOS =
        interface end

    [<KeyValueList>]
    type ITextProperties =
        inherit ITextPropertiesIOS

    [<KeyValueList>]
    type TextPropertiesIOS =
        | AllowFontScaling of bool // REQUIRED!
        | SuppressHighlighting of bool
        interface ITextPropertiesIOS

    [<KeyValueList>]
    type TextProperties =
        | AllowFontScaling of bool
        | LineBreakMode of LineBreakMode
        | NumberOfLines of float
        | OnLayout of Func<LayoutChangeEvent, unit>
        | OnPress of (unit->unit)
        | Style of IStyle list
        | TestID of string
        interface ITextProperties

    [<KeyValueList>]
    type ITextInputIOSProperties =
        interface end

    [<KeyValueList>]
    type ITextInputAndroidProperties =
        interface end

    [<KeyValueList>]
    type ITextInputProperties =
        inherit ITextInputIOSProperties
        inherit ITextInputAndroidProperties

    module TextInput =
        [<KeyValueList>]
        type TextInputIOSProperties =
            | ClearButtonMode of string
            | ClearTextOnFocus of bool
            | EnablesReturnKeyAutomatically of bool
            | OnKeyPress of (unit->unit)
            | SelectionState of obj
            interface ITextInputIOSProperties

        [<KeyValueList>]
        type TextInputAndroidProperties =
            | NumberOfLines of float
            | ReturnKeyLabel of string
            | TextAlign of string
            | TextAlignVertical of string
            | UnderlineColorAndroid of string
            interface ITextInputAndroidProperties

        [<KeyValueList>]
        type TextInputProperties =
            | AutoCapitalize of AutoCapitalize
            | AutoCorrect of bool
            | AutoFocus of bool
            | BlurOnSubmit of bool
            | DefaultValue of string
            | Editable of bool
            | KeyboardType of KeyboardType
            | MaxLength of float
            | Multiline of bool
            | OnBlur of (unit->unit)
            | OnChange of (obj -> unit)
            | OnChangeText of (string -> unit)
            | OnEndEditing of (obj -> unit)
            | OnFocus of (unit->unit)
            | OnLayout of Func<obj, unit>
            | OnSelectionChange of (unit->unit)
            | OnSubmitEditing of Func<obj, unit>
            | Password of bool
            | Placeholder of string
            | PlaceholderTextColor of string
            | ReturnKeyType of ReturnKeyType
            | SecureTextEntry of bool
            | SelectTextOnFocus of bool
            | SelectionColor of string
            | Style of IStyle list
            | TestID of string
            | Value of string
            interface ITextInputProperties

    module Toolbar =
        [<KeyValueList>]
        type ToolbarAndroidProperties =
            | Actions of ToolbarAndroidAction []
            | ContentInsetEnd of float
            | ContentInsetStart of float
            | Logo of obj
            | NavIcon of obj
            | OnIconClicked of (unit->unit)
            | OverflowIcon of obj
            | Rtl of bool
            | Style of IStyle list
            | Subtitle of string
            | SubtitleColor of string
            | TestID of string
            | Title of string
            | TitleColor of string
            | Ref of Ref<ToolbarAndroid>
            interface IToolbarAndroidProperties

    [<KeyValueList>]
    type GestureResponderHandlers =
        | OnStartShouldSetResponder of Func<GestureResponderEvent, bool>
        | OnMoveShouldSetResponder of Func<GestureResponderEvent, bool>
        | OnResponderGrant of Func<GestureResponderEvent, unit>
        | OnResponderReject of Func<GestureResponderEvent, unit>
        | OnResponderMove of Func<GestureResponderEvent, unit>
        | OnResponderRelease of Func<GestureResponderEvent, unit>
        | OnResponderTerminationRequest of Func<GestureResponderEvent, bool>
        | OnResponderTerminate of Func<GestureResponderEvent, unit>
        | OnStartShouldSetResponderCapture of Func<GestureResponderEvent, bool>
        | OnMoveShouldSetResponderCapture of (unit->unit)
        interface IGestureResponderHandlers

    type ViewPropertiesIOS =
        | AccessibilityTraits of U2<string, ResizeArray<string>>
        | ShouldRasterizeIOS of bool
        interface IViewPropertiesIOS

    type ViewPropertiesAndroid =
        | AccessibilityComponentType of string
        | AccessibilityLiveRegion of string
        | Collapsable of bool
        | ImportantForAccessibility of string
        | NeedsOffscreenAlphaCompositing of bool
        | RenderToHardwareTextureAndroid of bool
        interface IViewPropertiesAndroid

    [<KeyValueList>]
    type ViewProperties =
        | AccessibilityLabel of string
        | Accessible of bool
        | HitSlop of obj
        | OnAcccessibilityTap of (unit->unit)
        | OnLayout of Func<LayoutChangeEvent, unit>
        | OnMagicTap of (unit->unit)
        | PointerEvents of PointerEvents
        | RemoveClippedSubviews of bool
        | Style of IStyle list
        | TestID of string
        interface IViewProperties

    [<KeyValueList>]
    type ViewPagerAndroidProperties =
        | InitialPage of int
        | ScrollEnabled of bool
        | OnPageScroll of Func<NativeSyntheticEvent<ViewPagerAndroidOnPageScrollEventData>, unit>
        | OnPageSelected of Func<NativeSyntheticEvent<ViewPagerAndroidOnPageSelectedEventData>, unit>
        | OnPageScrollStateChanged of Func<ScrollState, unit>
        | KeyboardDismissMode of KeyboardDismissMode
        | PageMargin of float
        | Style of IStyle list
        | Ref of Ref<obj>
        interface IViewPagerAndroidProperties

    [<KeyValueList>]
    type KeyboardAvoidingViewProps =
        | Behavior of Behavior
        | KeyboardVerticalOffset of float // REQUIRED!
        | Ref of Ref<obj>
        interface IKeyboardAvoidingViewProps

    [<KeyValueList>]
    type WebViewPropertiesAndroid =
        | JavaScriptEnabled of bool
        | DomStorageEnabled of bool
        interface IWebViewPropertiesAndroid

    [<KeyValueList>]
    type WebViewPropertiesIOS =
        | AllowsInlineMediaPlayback of bool
        | Bounces of bool
        | DecelerationRate of DecelerationRate
        | OnShouldStartLoadWithRequest of Func<WebViewIOSLoadRequestEvent, bool>
        | ScrollEnabled of bool
        interface IWebViewPropertiesIOS

    [<KeyValueList>]
    type WebViewUriSource =
        | Uri of string
        | Method of string
        | Headers of obj
        | Body of string

    [<KeyValueList>]
    type WebViewHtmlSource =
        | Html of string // REQUIRED!
        | BaseUrl of string

    [<KeyValueList>]
    type WebViewProperties =
        | AutomaticallyAdjustContentInsets of bool
        | Bounces of bool
        | ContentInset of Insets
        | Html of string
        | InjectedJavaScript of string
        | OnError of Func<NavState, unit>
        | OnLoad of Func<NavState, unit>
        | OnLoadEnd of Func<NavState, unit>
        | OnLoadStart of Func<NavState, unit>
        | OnNavigationStateChange of Func<NavState, unit>
        | OnShouldStartLoadWithRequest of Func<bool>
        | RenderError of Func<React.ReactElement>
        | RenderLoading of Func<React.ReactElement>
        | ScrollEnabled of bool
        | StartInLoadingState of bool
        | Style of IStyle list
        | Url of string
        | Source of U3<WebViewUriSource, WebViewHtmlSource, float>
        | MediaPlaybackRequiresUserAction of bool
        | ScalesPageToFit of bool
        | Ref of Ref<obj>
        interface IWebViewProperties

    [<KeyValueList>]
    type SegmentedControlIOSProperties =
        | Enabled of bool
        | Momentary of bool
        | OnChange of Func<NativeSyntheticEvent<NativeSegmentedControlIOSChangeEvent>, unit>
        | OnValueChange of Func<string, unit>
        | SelectedIndex of float
        | TintColor of string
        | Values of ResizeArray<string>
        | Ref of Ref<SegmentedControlIOS>
        interface ISegmentedControlIOSProperties

    [<KeyValueList>]
    type NavigatorIOSProperties =
        | BarTintColor of string
        | InitialRoute of Route
        | ItemWrapperStyle of ViewStyle list
        | NavigationBarHidden of bool
        | ShadowHidden of bool
        | TintColor of string
        | TitleTextColor of string
        | Translucent of bool
        | Style of IStyle list

    module ActivityIndicator =
        [<KeyValueList>]
        type ActivityIndicatorProperties =
            | Animating of bool
            | Color of string
            | HidesWhenStopped of bool
            | Size of Size
            | Style of IStyle list
            | Ref of Ref<ActivityIndicator>
            interface IViewProperties


        [<KeyValueList>]
        type ActivityIndicatorIOSProperties =
            | Animating of bool
            | Color of string
            | HidesWhenStopped of bool
            | OnLayout of Func<obj, unit>
            | Size of Size
            | Style of IStyle list
            | Ref of Ref<ActivityIndicatorIOS>
            interface IViewProperties

    [<KeyValueList>]
    type DatePickerIOSProperties =
        | Date of DateTime
        | MaximumDate of DateTime
        | MinimumDate of DateTime
        | MinuteInterval of float
        | Mode of DatePickerIOSMode
        | OnDateChange of Func<DateTime, unit>
        | TimeZoneOffsetInMinutes of float
        | Ref of Ref<DatePickerIOS>
        interface IDatePickerIOSProperties

    [<KeyValueList>]
    type DrawerLayoutAndroidProperties =
        | DrawerBackgroundColor of string
        | DrawerLockMode of DrawerLockMode
        | DrawerPosition of DrawerLayoutAndroidPosition
        | DrawerWidth of float
        | KeyboardDismissMode of KeyboardDismissMode
        | OnDrawerClose of (unit->unit)
        | OnDrawerOpen of (unit->unit)
        | OnDrawerSlide of Func<DrawerSlideEvent, unit>
        | OnDrawerStateChanged of Func<ScrollState, unit>
        | RenderNavigationView of Func<obj>
        | StatusBarBackgroundColor of obj
        | Ref of Ref<obj>
        interface IDrawerLayoutAndroidProperties

    module Picker =
        [<KeyValueList>]
        type PickerIOSItemProperties =
            | Value of U2<string, float>
            | Label of string


        [<KeyValueList>]
        type PickerItemProperties =
            | Label of string // REQUIRED!
            | Value of obj
            | Color of string
            | TestID of string


        [<KeyValueList>]
        type PickerPropertiesIOS =
            | ItemStyle of IStyle list
            | Ref of Ref<obj>
            interface IPickerProperties

        [<KeyValueList>]
        type PickerPropertiesAndroid =
            | Enabled of bool
            | Mode of Mode
            | Prompt of string
            | Ref of Ref<obj>
            interface IPickerProperties

        [<KeyValueList>]
        type PickerProperties =
            | OnValueChange of Func<obj, float, unit>
            | SelectedValue of obj
            | Style of IStyle list
            | TestId of string
            | Ref of Ref<Picker>
            interface IPickerProperties

        [<KeyValueList>]
        type PickerIOSProperties =
            | ItemStyle of ViewStyle list
            interface IPickerProperties

    module ProgressBar =
        [<KeyValueList>]
        type ProgressBarAndroidProperties =
            | Style of IStyle list
            | StyleAttr of StyleAttr
            | Indeterminate of bool
            | Progress of float
            | Color of string
            | TestID of string
            | Ref of Ref<ProgressBarAndroid>
            interface IProgressBarAndroidProperties

        [<KeyValueList>]
        type ProgressViewIOSProperties =
            | Style of IStyle list
            | ProgressViewStyle of ProgressViewStyle
            | Progress of float
            | ProgressTintColor of string
            | TrackTintColor of string
            | ProgressImage of obj
            | TrackImage of obj
            | Ref of Ref<ProgressViewIOS>
            interface IProgressViewIOSProperties

    [<KeyValueList>]
    type RefreshControlPropertiesIOS =
        | TintColor of string
        | Title of string
        | TitleColor of string
        | Ref of Ref<obj>
        interface IRefreshControlProperties


    [<KeyValueList>]
    type RefreshControlPropertiesAndroid =
        | Colors of ResizeArray<string>
        | Enabled of bool
        | ProgressBackgroundColor of string
        | Size of float
        | ProgressViewOffset of float
        | Ref of Ref<obj>
        interface IRefreshControlProperties

    [<KeyValueList>]
    type RefreshControlProperties =
        | OnRefresh of (unit->unit)
        | Refreshing of bool
        | Ref of Ref<RefreshControl>
        interface IRefreshControlProperties

    [<KeyValueList>]
    type SliderPropertiesIOS =
        | MaximumTrackImage of obj
        | MaximumTrackTintColor of string
        | MinimumTrackImage of string
        | MinimumTrackTintColor of string
        | ThumbImage of obj
        | TrackImage of obj
        | Ref of Ref<Slider>
        interface ISliderProperties

    [<KeyValueList>]
    type SliderProperties =
        | Disabled of bool
        | MaximumValue of float
        | MinimumValue of float
        | OnSlidingComplete of Func<float, unit>
        | OnValueChange of Func<float, unit>
        | Step of float
        | Style of IStyle list
        | TestID of string
        | Value of float
        interface ISliderProperties

    [<KeyValueList>]
    type SliderIOSProperties =
        | Disabled of bool
        | MaximumValue of float
        | MaximumTrackTintColor of string
        | MinimumValue of float
        | MinimumTrackImage of obj
        | MinimumTrackTintColor of string
        | OnSlidingComplete of (unit->unit)
        | OnValueChange of Func<float, unit>
        | Step of float
        | Style of IStyle list
        | Value of float
        | Ref of Ref<SliderIOS>
        interface ISliderIOSProperties

    [<KeyValueList>]
    type SwitchIOSStyle =
        | Height of float
        | Width of float
        interface ISwitchIOSStyle

    [<KeyValueList>]
    type SwitchIOSProperties =
        | Disabled of bool
        | OnTintColor of string
        | OnValueChange of Func<bool, unit>
        | ThumbTintColor of string
        | TintColor of string
        | Value of bool
        | Style of IStyle list

    [<KeyValueList>]
    type ImageStyle =
        | ResizeMode of string
        | BackfaceVisibility of BackfaceVisibility
        | BorderBottomLeftRadius of float
        | BorderBottomRightRadius of float
        | BackgroundColor of string
        | BorderColor of string
        | BorderWidth of float
        | BorderRadius of float
        | BorderTopLeftRadius of float
        | BorderTopRightRadius of float
        | Overflow of Overflow
        | OverlayColor of string
        | TintColor of string
        | Opacity of float
        interface IImageStyle

    [<KeyValueList>]
    type IImagePropertiesIOS =
        interface end

    [<KeyValueList>]
    type IImageProperties =
        inherit IImagePropertiesIOS

    [<KeyValueList>]
    type IImageSourceProperties =
        interface end

    [<KeyValueList>]
    type ImageSourceProperties =
        | Uri of string
        | IsStatic of bool
        interface IImageSourceProperties

    [<KeyValueList>]
    type ImagePropertiesIOS =
        | AccessibilityLabel of string
        | Accessible of bool
        | CapInsets of Insets
        | DefaultSource of IImageSourceProperties list
        | OnError of Func<obj, unit>
        | OnProgress of (unit->unit)
        interface IImagePropertiesIOS

    [<KeyValueList>]
    type ImageProperties =
        | OnLayout of Func<LayoutChangeEvent, unit>
        | OnLoad of (unit->unit)
        | OnLoadEnd of (unit->unit)
        | OnLoadStart of (unit->unit)
        | ResizeMode of ResizeMode
        | Source of IImageSourceProperties list
        | Style of IStyle list
        | TestID of string
        interface IImageProperties


    [<KeyValueList>]
    type MapViewAnnotation =
        | Latitude of float
        | Longitude of float
        | AnimateDrop of bool
        | Title of string
        | Subtitle of string
        | HasLeftCallout of bool
        | HasRightCallout of bool
        | OnLeftCalloutPress of (unit->unit)
        | OnRightCalloutPress of (unit->unit)
        | Id of string

    type MapViewRegion =
        | Latitude of float
        | Longitude of float
        | LatitudeDelta of float
        | LongitudeDelta of float

    [<KeyValueList>]
    type MapViewOverlay =
        | Coordinates of ResizeArray<obj>
        | LineWidth of float
        | StrokeColor of obj
        | FillColor of obj
        | Id of string

    [<KeyValueList>]
    type MapViewPropertiesIOS =
        | ShowsPointsOfInterest of bool
        | Annotations of ResizeArray<MapViewAnnotation>
        | FollowUserLocation of bool
        | LegalLabelInsets of Insets
        | MapType of string
        | MaxDelta of float
        | MinDelta of float
        | Overlays of ResizeArray<MapViewOverlay>
        | ShowsCompass of bool

    [<KeyValueList>]
    type MapViewPropertiesAndroid =
        | Active of bool
        interface IMapViewPropertiesAndroid

    [<KeyValueList>]
    type MapViewProperties =
        | OnAnnotationPress of (unit->unit)
        | OnRegionChange of Func<MapViewRegion, unit>
        | OnRegionChangeComplete of Func<MapViewRegion, unit>
        | PitchEnabled of bool
        | Region of MapViewRegion
        | RotateEnabled of bool
        | ScrollEnabled of bool
        | ShowsUserLocation of bool
        | Style of IStyle list
        | ZoomEnabled of bool
        | Ref of Ref<obj>
        interface IMapViewProperties

    [<KeyValueList>]
    type ModalProperties =
        | Animated of bool
        | AnimationType of AnimationType
        | Transparent of bool
        | Visible of bool
        | OnRequestClose of (unit->unit)
        | OnShow of Func<NativeSyntheticEvent<obj>, unit>

    [<KeyValueList>]
    type ITouchableHighlightProperties =
        interface end

    [<KeyValueList>]
    type ITouchableOpacityProperties =
        interface end

    [<KeyValueList>]
    type ITouchableNativeFeedbackProperties =
        interface end

    [<KeyValueList>]
    type ITouchableWithoutFeedbackIOSProperties =
        interface end

    [<KeyValueList>]
    type ITouchableWithoutFeedbackAndroidProperties =
        interface end

    [<KeyValueList>]
    type ITouchableWithoutFeedbackProperties =
        inherit ITouchableWithoutFeedbackAndroidProperties
        inherit ITouchableWithoutFeedbackIOSProperties
        inherit ITouchableNativeFeedbackProperties
        inherit ITouchableOpacityProperties
        inherit ITouchableHighlightProperties

    [<KeyValueList>]
    type TouchableWithoutFeedbackAndroidProperties =
        | AccessibilityComponentType of string
        interface ITouchableWithoutFeedbackAndroidProperties

    [<KeyValueList>]
    type TouchableWithoutFeedbackIOSProperties =
        | AccessibilityTraits of U2<string, ResizeArray<string>>
        interface ITouchableWithoutFeedbackIOSProperties

    [<KeyValueList>]
    type TouchableWithoutFeedbackProperties =
        | Accessible of bool
        | DelayLongPress of float
        | DelayPressIn of float
        | DelayPressOut of float
        | Disabled of bool
        | HitSlop of obj
        | OnLayout of Func<LayoutChangeEvent, unit>
        | OnLongPress of (unit->unit)
        | OnPress of (unit->unit)
        | OnPressIn of (unit->unit)
        | OnPressOut of (unit->unit)
        | Style of IStyle list
        | PressRetentionOffset of obj
        interface ITouchableWithoutFeedbackProperties

    [<KeyValueList>]
    type TouchableHighlightProperties =
        | ActiveOpacity of float
        | OnHideUnderlay of (unit->unit)
        | OnShowUnderlay of (unit->unit)
        | Style of IStyle list
        | UnderlayColor of string
        interface ITouchableHighlightProperties

    [<KeyValueList>]
    type TouchableOpacityProperties =
        | ActiveOpacity of float
        interface ITouchableOpacityProperties


    [<KeyValueList>]
    type TouchableNativeFeedbackProperties =
        | Background of obj
        interface ITouchableNativeFeedbackProperties

    [<KeyValueList>]
    type NavigationBarRouteMapper =
        | Title of Func<Route, Navigator, float, NavState, React.ReactElement>
        | LeftButton of Func<Route, Navigator, float, NavState, React.ReactElement>
        | RightButton of Func<Route, Navigator, float, NavState, React.ReactElement>

    [<KeyValueList>]
    type NavigationBarProperties =
        | Navigator of Navigator
        | RouteMapper of NavigationBarRouteMapper
        | NavState of NavState
        | Style of IStyle list

    [<KeyValueList>]
    type INavigatorProperties =
        interface end

    [<KeyValueList>]
    type NavigatorProperties =
        | ConfigureScene of Func<Route, ResizeArray<Route>, SceneConfig>
        | InitialRoute of Route
        | InitialRouteStack of ResizeArray<Route>
        | NavigationBar of React.ReactElement // React.ReactElement option
        | Navigator of Navigator
        | OnDidFocus of (unit->unit)
        | OnWillFocus of (unit->unit)
        | RenderScene of Func<Route, Navigator, React.ReactElement>
        | SceneStyle of ViewStyle list
        | DebugOverlay of bool
        interface INavigatorProperties

    module ToolBar =
        [<KeyValueList>]
        type TabBarItemProperties =
            | Badge of U2<string, float>
            | Icon of U2<obj, string>
            | OnPress of (unit->unit)
            | Selected of bool
            | SelectedIcon of U2<obj, string>
            | Style of IStyle list
            | SystemIcon of SystemIcon
            | Title of string
            | Ref of Ref<obj>
            interface IViewProperties

        [<KeyValueList>]
        type TabBarIOSProperties =
            | BarTintColor of string
            | Style of IStyle list
            | TintColor of string
            | Translucent of bool
            | UnselectedTintColor of string
            | Ref of Ref<obj>
            interface IViewProperties

    [<KeyValueList>]
    type ScrollViewStyle =
        | BackfaceVisibility of BackfaceVisibility
        | BackgroundColor of string
        | BorderColor of string
        | BorderTopColor of string
        | BorderRightColor of string
        | BorderBottomColor of string
        | BorderLeftColor of string
        | BorderRadius of float
        | BorderTopLeftRadius of float
        | BorderTopRightRadius of float
        | BorderBottomLeftRadius of float
        | BorderBottomRightRadius of float
        | BorderStyle of BorderStyle
        | BorderWidth of float
        | BorderTopWidth of float
        | BorderRightWidth of float
        | BorderBottomWidth of float
        | BorderLeftWidth of float
        | Opacity of float
        | Overflow of Overflow
        | ShadowColor of string
        | ShadowOffset of obj
        | ShadowOpacity of float
        | ShadowRadius of float
        | Elevation of float
        interface IScrollViewStyle

    [<KeyValueList>]
    type IScrollViewPropertiesIOS =
        inherit IScrollViewProperties

    [<KeyValueList>]
    type ScrollViewPropertiesIOS =
        | AlwaysBounceHorizontal of bool
        | AlwaysBounceVertical of bool
        | AutomaticallyAdjustContentInsets of bool
        | Bounces of bool
        | BouncesZoom of bool
        | CanCancelContentTouches of bool
        | CenterContent of bool
        | ContentInset of Insets
        | ContentOffset of PointProperties
        | DecelerationRate of DecelerationRate
        | DirectionalLockEnabled of bool
        | IndicatorStyle of IndicatorStyle
        | MaximumZoomScale of float
        | MinimumZoomScale of float
        | OnRefreshStart of (unit->unit)
        | OnScrollAnimationEnd of (unit->unit)
        | ScrollEnabled of bool
        | ScrollEventThrottle of float
        | ScrollIndicatorInsets of Insets
        | ScrollsToTop of bool
        | SnapToAlignment of string
        | SnapToInterval of float
        | StickyHeaderIndices of ResizeArray<float>
        | ZoomScale of float
        interface IScrollViewPropertiesIOS

    [<KeyValueList>]
    type IScrollViewPropertiesAndroid =
        inherit IScrollViewProperties

    [<KeyValueList>]
    type ScrollViewPropertiesAndroid =
        | EndFillColor of string
        | ScrollPerfTag of string
        interface IScrollViewPropertiesAndroid

    [<KeyValueList>]
    type ScrollViewProperties =
        | ContentContainerStyle of ViewStyle list
        | Horizontal of bool
        | KeyboardDismissMode of string
        | KeyboardShouldPersistTaps of bool
        | OnScroll of Func<obj, unit>
        | PagingEnabled of bool
        | RemoveClippedSubviews of bool
        | ShowsHorizontalScrollIndicator of bool
        | ShowsVerticalScrollIndicator of bool
        | Style of IStyle list
        | RefreshControl of React.ReactElement
        | Ref of Ref<ScrollView>
        interface IScrollViewProperties


    [<KeyValueList>]
    type ListViewProperties<'a>  =
        | DataSource of ListViewDataSource<'a>
        | EnableEmptySections of bool
        | InitialListSize of float
        | OnChangeVisibleRows of Func<ResizeArray<obj>, ResizeArray<obj>, unit>
        | OnEndReached of (unit->unit)
        | OnEndReachedThreshold of float
        | PageSize of float
        | RemoveClippedSubviews of bool
        | RenderFooter of Func<React.ReactElement>
        | RenderHeader of Func<React.ReactElement>
        | RenderRow of Func<'a, U2<string, float>, U2<string, float>, bool, React.ReactElement>
        | RenderScrollComponent of Func<ScrollViewProperties, React.ReactElement>
        | RenderSectionHeader of Func<obj, U2<string, float>, React.ReactElement>
        | RenderSeparator of Func<U2<string, float>, U2<string, float>, bool, React.ReactElement>
        | ScrollRenderAheadDistance of float
        | Ref of Ref<obj>
        interface IListViewProperties

    [<KeyValueList>]
    type SwipeableListViewProps<'a> =
        | DataSource of SwipeableListViewDataSource<'a> // REQUIRED!
        | MaxSwipeDistance of float
        | RenderRow of Func<'a, U2<string, float>, U2<string, float>, bool, React.ReactElement> // REQUIRED!
        | RenderQuickActions of Func<'a, string, string, React.ReactElement> // REQUIRED!

    [<KeyValueList>]
    type ActionSheetIOSOptions =
        | Title of string
        | Options of ResizeArray<string>
        | CancelButtonIndex of float
        | DestructiveButtonIndex of float
        | Message of string

    [<KeyValueList>]
    type ShareActionSheetIOSOptions =
        | Message of string
        | Url of string


    [<KeyValueList>]
    type DatePickerAndroidOpenOption =
        | Date of U2<DateTime, float>
        | MinDate of U2<DateTime, float>
        | MaxDate of U2<DateTime, float>

    [<KeyValueList>]
    type PanResponderCallbacks =
        | OnMoveShouldSetPanResponder of Func<GestureResponderEvent, PanResponderGestureState, bool>
        | OnStartShouldSetPanResponder of Func<GestureResponderEvent, PanResponderGestureState, unit>
        | OnPanResponderGrant of Func<GestureResponderEvent, PanResponderGestureState, unit>
        | OnPanResponderMove of Func<GestureResponderEvent, PanResponderGestureState, unit>
        | OnPanResponderRelease of Func<GestureResponderEvent, PanResponderGestureState, unit>
        | OnPanResponderTerminate of Func<GestureResponderEvent, PanResponderGestureState, unit>
        | OnMoveShouldSetPanResponderCapture of Func<GestureResponderEvent, PanResponderGestureState, bool>
        | OnStartShouldSetPanResponderCapture of Func<GestureResponderEvent, PanResponderGestureState, bool>
        | OnPanResponderReject of Func<GestureResponderEvent, PanResponderGestureState, unit>
        | OnPanResponderStart of Func<GestureResponderEvent, PanResponderGestureState, unit>
        | OnPanResponderEnd of Func<GestureResponderEvent, PanResponderGestureState, unit>
        | OnPanResponderTerminationRequest of Func<GestureResponderEvent, PanResponderGestureState, bool>

    module StatusBar =
        [<KeyValueList>]
        type StatusBarPropertiesIOS =
            | BarStyle of StatusBarStyle list
            | NetworkActivityIndicatorVisible of bool
            | ShowHideTransition of ShowHideTransition
            interface IStatusBarProperties

        [<KeyValueList>]
        type StatusBarPropertiesAndroid =
            | BackgroundColor of obj
            | Translucent of bool
            interface IStatusBarProperties

    [<KeyValueList>]
    type StatusBarProperties =
        | Animated of bool
        | Hidden of bool
        interface IStatusBarProperties

    [<KeyValueList>]
    type SwitchPropertiesIOS =
        | OnTintColor of string
        | ThumbTintColor of string
        | TintColor of string
        | Ref of Ref<Switch>
        interface ISwitchProperties

    [<KeyValueList>]
    type SwitchProperties =
        | Disabled of bool
        | TestID of string
        | Style of IStyle list
        | Ref of Ref<Switch>
        interface ISwitchProperties

    [<KeyValueList>]
    type NavigationAnimatedViewProps =
        | Route of obj
        | Style of IStyle list
        | RenderOverlay of (obj -> React.ReactElement)
        | ApplyAnimation of (obj * obj -> unit)
        | RenderScene of (obj -> React.ReactElement)


    [<KeyValueList>]
    type INavigationHeaderProps =
        interface end

    [<KeyValueList>]
    type NavigationHeaderProps =
        | RenderTitleComponent of (NavigationTransitionProps -> React.ReactElement)
        | RenderLeftComponent of (NavigationTransitionProps -> React.ReactElement)
        | RenderRightComponent of (NavigationTransitionProps -> React.ReactElement)
        | StatusBarHeight of U2<float,Animated.Value>
        | OnNavigateBack of (unit -> unit)
        interface INavigationHeaderProps

    [<KeyValueList>]
    type INavigationCardStackProps =
        interface end

    [<KeyValueList>]
    type NavigationCardStackProps =
        | Direction of Direction
        | Style of IStyle list
        | EnableGestures of bool
        | GestureResponseDistance of float
        | CardStyle of IStyle list
        | RenderHeader of (NavigationTransitionProps -> React.ReactElement)
        | OnNavigateBack of (unit -> unit)
        interface INavigationCardStackProps

    [<KeyValueList>]
    type IBreadcrumbNavigationBarProperties =
        interface end

    [<KeyValueList>]
    type BreadcrumbNavigationBarProperties =
        | Navigator of Navigator
        | RouteMapper of NavigatorStatic.BreadcrumbNavigationBarRouteMapper
        | NavState of NavState
        | Style of IStyle list
        interface IBreadcrumbNavigationBarProperties

open Props
module R = Fable.Helpers.React

[<Emit("require($0)")>]
// Use `require` to load a local image
let localImage (path:string) : IImageSourceProperties list = jsNative

let inline internal createElement(c: React.ComponentClass<'T>, props: obj, children: React.ReactElement list) =
    R.from c (unbox props) children

let text (props:TextProperties list) (text:string): React.ReactElement =
    createElement(RN.Text, props, [React.str text])

let textInput (props: ITextInputProperties list) : React.ReactElement =
    createElement(RN.TextInput, props, [])

let createToolbarAction(title:string,showStatus:ToolbarActionShowStatus) : ToolbarAndroidAction =
    createObj [
        "title" ==> title
        "show" ==> showStatus
    ]

let createToolbarActionWithIcon(title:string,icon: IImageSourceProperties list,showStatus:ToolbarActionShowStatus) : ToolbarAndroidAction =
    createObj [
        "title" ==> title
        "icon" ==> icon
        "show" ==> showStatus
    ]

let toolbarAndroid (props:IToolbarAndroidProperties list) (onActionSelected:int -> unit) : React.ReactElement =
    createElement(
        RN.ToolbarAndroid,
        JS.Object.assign(
            createObj ["onActionSelected" ==> onActionSelected],
            props), [])

let keyboardAvoidingView (props:IKeyboardAvoidingViewProps list) (children: React.ReactElement list): React.ReactElement =
    createElement(
      RN.KeyboardAvoidingView,
      props,
      children)

let view (props: IViewProperties list) (children: React.ReactElement list): React.ReactElement =
    createElement(
        RN.View,
        props,
        children)

let webView (props:IWebViewProperties list) : React.ReactElement =
    createElement(
      RN.WebView,
      props, [])

let segmentedControlIOS (props:ISegmentedControlIOSProperties list) : React.ReactElement =
    createElement(
      RN.SegmentedControlIOS,
      props, [])

let activityIndicator (props:IActivityIndicatorProperties list) : React.ReactElement =
    createElement(
      RN.ActivityIndicator,
      props, [])

let activityIndicatorIOS (props:IActivityIndicatorIOSProperties list) : React.ReactElement =
    createElement(
      RN.ActivityIndicatorIOS,
      props, [])

let datePickerIOS (props:IDatePickerIOSProperties list) : React.ReactElement =
    createElement(
      RN.DatePickerIOS,
      props, [])

let drawerLayoutAndroid (props:IDrawerLayoutAndroidProperties list) (renderNavigationView: unit -> React.ReactElement) (children: React.ReactElement list): React.ReactElement =
    createElement(
      RN.DrawerLayoutAndroid,
      JS.Object.assign(
            createObj ["renderNavigationView" ==> renderNavigationView],
            props),
      children)

let pickerIOSItem (props:Picker.PickerIOSItemProperties list) : React.ReactElement =
    createElement(
      RN.PickerIOS.Item,
      props, [])

let pickerItem (props:Picker.PickerItemProperties list) : React.ReactElement =
    createElement(
      RN.Picker.Item,
      props, [])

let picker (props:IPickerProperties list) (children:React.ReactElement list): React.ReactElement =
    createElement(
      RN.Picker,
      props,
      children)

let pickerIOS (props:Picker.PickerIOSProperties list) (children:React.ReactElement list): React.ReactElement =
    createElement(
      RN.PickerIOS,
      props,
      children)

let progressBarAndroid (props:IProgressBarAndroidProperties list) : React.ReactElement =
    createElement(
      RN.ProgressBarAndroid,
      props, [])

let progressViewIOS (props:IProgressViewIOSProperties list) : React.ReactElement =
    createElement(
      RN.ProgressViewIOS,
      props, [])

let refreshControl (props:IRefreshControlProperties list) : React.ReactElement =
    createElement(
      RN.RefreshControl,
      props, [])

let slider (props:ISliderProperties list) : React.ReactElement =
    createElement(
      RN.Slider,
      props, [])

let sliderIOS (props:ISliderIOSProperties list) : React.ReactElement =
    createElement(
      RN.SliderIOS,
      props, [])

let switchIOS (props:SwitchIOSProperties list) : React.ReactElement =
    createElement(
      RN.SwitchIOS,
      props, [])

let image (props:IImageProperties list) : React.ReactElement =
    createElement(
      RN.Image,
      props, [])

let imageWithChild (props: IImageProperties list) (child: React.ReactElement) : React.ReactElement =
    createElement(
        RN.Image,
        props,
        [child])

let listView<'a> (dataSource:ListViewDataSource<'a>) (props: IListViewProperties list)  : React.ReactElement =
    createElement(
        RN.ListView,
        JS.Object.assign(
            createObj ["dataSource" ==> dataSource],
            props), [])

let mapView (props:IMapViewProperties list) (children: React.ReactElement list): React.ReactElement =
    createElement(
      RN.MapView,
      props,
      children)

let modal (props:ModalProperties list) : React.ReactElement =
    createElement(
      RN.Modal,
      props, [])

let touchableWithoutFeedback (props:ITouchableWithoutFeedbackProperties list) (children: React.ReactElement list): React.ReactElement =
    createElement(
      RN.TouchableWithoutFeedback,
      props,
      children)

let touchableHighlight (props:ITouchableHighlightProperties list) (children: React.ReactElement list) : React.ReactElement =
    createElement(
      RN.TouchableHighlight,
      props,
      children)

let touchableHighlightWithChild (props:ITouchableHighlightProperties list) (child: React.ReactElement): React.ReactElement =
    createElement(
      RN.TouchableHighlight,
      props,
      [child])

let touchableOpacity (props:ITouchableOpacityProperties list) (children: React.ReactElement list): React.ReactElement =
    createElement(
      RN.TouchableOpacity,
      props,
      children)

let touchableNativeFeedback (props:ITouchableNativeFeedbackProperties list) (children: React.ReactElement list): React.ReactElement =
    createElement(
      RN.TouchableNativeFeedback,
      props,
      children)

let viewPagerAndroid (props: IViewPagerAndroidProperties list) (children: React.ReactElement list) : React.ReactElement =
    createElement(
        RN.ViewPagerAndroid,
        props,
        children)

let navigator (props:INavigatorProperties list) : React.ReactElement =
    createElement(
      RN.Navigator,
      props, [])

let styleSheet (props:StyleSheetProperties list) : React.ReactElement =
    createElement(
      RN.StyleSheet,
      props, [])

let tabBarItem (props:ITabBarItemProperties list) : React.ReactElement =
    createElement(
      RN.TabBarIOS.Item,
      props, [])

let tabBarIOS (props:ITabBarIOSProperties list) : React.ReactElement =
    createElement(
      RN.TabBarIOS,
      props, [])

let scrollView (props:IScrollViewProperties list) (children: React.ReactElement list) : React.ReactElement =
    createElement(
      RN.ScrollView,
      props,
      children)

let swipeableListView (props:SwipeableListViewProps<_> list) : React.ReactElement =
    createElement(
      RN.SwipeableListView,
      props, [])

let statusBar (props:IStatusBarProperties list) : React.ReactElement =
    createElement(
      RN.StatusBar,
      props, [])

let switch (props:ISwitchProperties list) (onValueChange: bool -> unit) (value:bool) : React.ReactElement =
    createElement(
      RN.Switch,
      JS.Object.assign(
            createObj ["onValueChange" ==> onValueChange
                       "value" ==> value],
            props), [])

let navigationHeader (props:INavigationHeaderProps list) (rendererProps:NavigationTransitionProps): React.ReactElement =
    createElement(
      RN.NavigationExperimental.Header,
      JS.Object.assign(props, rendererProps), [])

let navigationState (index:int) (routes:NavigationRoute list): NavigationState =
    createObj ["index" ==> index
               "routes" ==> Array.ofList routes]
    |> unbox

let navigationRoute (key:string) (title:string option): NavigationRoute =
    createObj ["key" ==> key
               "title" ==> title]
    |> unbox

let navigationCardStack (navigationState: NavigationState)
                               (renderScene: NavigationTransitionProps -> React.ReactElement)
                               (props:INavigationCardStackProps list): React.ReactElement =
    createElement(
      RN.NavigationExperimental.CardStack,
      JS.Object.assign(
            createObj ["renderScene" ==> renderScene
                       "navigationState" ==> navigationState],
            props), [])

let navigationContainer (props:NavigationContainerProps list) : React.ReactElement =
    createElement(
      RN.NavigationContainer,
      props, [])

let navigationRootContainer (props:NavigationRootContainerProps list) : React.ReactElement =
    createElement(
      RN.NavigationRootContainer,
      props, [])

let navigationBar (props:NavigationBarProperties list) : React.ReactElement =
    createElement(
      NavigatorStatic.Globals.NavigationBar,
      props, [])

let breadcrumbNavigationBar (props:IBreadcrumbNavigationBarProperties list) : React.ReactElement =
    createElement(
      NavigatorStatic.Globals.BreadcrumbNavigationBar,
      props, [])

let emptyDataSource<'a>() : ListViewDataSource<'a> =
    RN.ListView.DataSource.Create(
        unbox(createObj ["rowHasChanged" ==> fun r1 r2 -> r1 <> r2])
    ) |> unbox

let newDataSource<'a> (elements:'a []) =
    emptyDataSource<'a>().cloneWithRows(unbox elements)

let updateDataSource<'a> (data:'a []) (dataSource : ListViewDataSource<'a>) : ListViewDataSource<'a> =
    dataSource.cloneWithRows (unbox data)

// [<Emit(typeof<React.Emitter>, "Com")>]
// let createComponent<'T,'P,'S when 'T :> React.Component<'P,'S>> (props: 'P) (children: React.ReactElement list): React.ReactElement = jsNative

// [<Emit(typeof<React.Emitter>, "Com")>]
// let createScene<'T,'P,'S when 'T :> React.Component<'P,'S>> (props: 'P) : React.ReactElement = jsNative

[<Import("Buffer","buffer")>]
[<Emit("$0.from($1).toString($2)")>]
let encode (text: string, encoding:string) : string = jsNative

let encodeBase64 (text: string) : string = encode(text,"base64")
let encodeAscii (text: string) : string = encode(text,"ascii")

[<Import("BackAndroid","react-native")>]
let private BackAndroid = obj()

let removeOnHardwareBackPressHandler (onHardwareBackPress: unit -> bool): unit =
    BackAndroid?removeEventListener("hardwareBackPress", onHardwareBackPress) |> ignore

let setOnHardwareBackPressHandler (onHardwareBackPress: unit -> bool): unit =
    BackAndroid?addEventListener("hardwareBackPress", onHardwareBackPress) |> ignore

let exitApp (): unit =
    BackAndroid?exitApp() |> ignore

[<Import("Linking","react-native")>]
let private Linking = obj()

/// Opens the given URL
let openUrl (url:string) : unit =
    Linking?openURL(url) |> ignore


module Keyboard =
    [<Import("Keyboard","react-native")>]
    let private Keyboard = obj()

    /// Dismisses the keyboard
    let dismiss() : unit =
        Keyboard?dismiss() |> ignore    

module Alert =
    [<Import("Alert","react-native")>]
    let private Alert = obj()

    let private createButton(label:string,callback:unit -> unit) =
        createObj [
            "text" ==> label
            "onPress" ==> callback
        ]

    /// Shows an alert with many buttons
    let alert (title:string,message:string,buttons: (string * (unit -> unit)) seq) : unit =
        Alert?alert( title, message, Seq.map createButton buttons |> Seq.toArray ) |> ignore        

    /// Shows an alert button with one button
    let alertWithOneButton (title:string,message:string,okText:string,onOk:unit -> unit) : unit =
        alert( title, message, [ okText,onOk ]) |> ignore

    /// Shows an alert button with two buttons
    let alertWithTwoButtons (title:string,message:string,cancelText:string,onCancel:unit -> unit,okText:string,onOk:unit -> unit) : unit =
        alert( title, message, [ (cancelText,onCancel); (okText,onOk) ]) |> ignore

    let confirm (title:string,message:string,cancelText:string,okText:string) =
        Promise.create(fun onSuccess onError ->
            let onError() = onError(new Exception("Cancelled"))
            alertWithTwoButtons (title,message,cancelText,onError,okText,onSuccess)
        )

module NetInfo =
    [<Import("NetInfo","react-native")>]
    let private NetInfo = obj()

    open Fable.Import.JS
    open Fable.Import.Browser

    let getConnectionType() : Promise<string> =
        NetInfo?fetch() |> unbox

/// ImageStore contains functions which help to deal with image data on the device.
module ImageStore =
    [<Import("ImageStore","react-native")>]
    let private ImageStore = obj()

    /// Retrieves the base64-encoded data for an image in the ImageStore. If the specified URI does not match an image in the store, an exception will be raised.
    let getBase64ForTag uri : JS.Promise<string> =
        Promise.create(fun onSuccess onError ->
            ImageStore?getBase64ForTag(uri, onSuccess, onError) |> ignore
        )

    /// Stores a base64-encoded image in the ImageStore, and returns a URI that can be used to access or display the image later.
    /// Images are stored in memory only, and must be manually deleted when you are finished with them by calling removeImageForTag().
    let addImageFromBase64 imageData : JS.Promise<string> =
        Promise.create(fun onSuccess onError ->
            ImageStore?addImageFromBase64(imageData, onSuccess, onError) |> ignore
        )

module Toast =
    [<Import("ToastAndroid","react-native")>]
    let private Toast = obj()

    /// Shows a toast with short duration
    let showShort (message:string) : unit =
        Toast?show(message,Toast?SHORT) |> unbox

    /// Shows a toast with long duration
    let showLong (message:string) : unit =
        Toast?show(message,Toast?LONG) |> unbox

module Storage =
    open Fable.Core.JsInterop

    /// Loads a value as string with the given key from the local device storage.
    /// Returns None if the key is not found.
    let getItem (key:string) : JS.Promise<string option> =
        Globals.AsyncStorage.getItem key
        |> Promise.map (function
            | null -> Option.None
            | v -> Some v)

    /// Loads a value with the given key from the local device storage.
    /// Returns None if the key is not found.
    let [<PassGenerics>] load<'a> (key:string) : JS.Promise<'a option> =
        Globals.AsyncStorage.getItem key
        |> Promise.map (function
            | null -> Option.None
            | v -> Some (ofJson v))

    /// Saves a value with the given key to the local device storage.
    let setItem (k:string) (v:string): JS.Promise<unit> =
        unbox(Globals.AsyncStorage.setItem(k,v))

    /// Saves a value with the given key to the local device storage.
    let [<PassGenerics>] save<'a> (k:string) (v:'a): JS.Promise<unit> =
        unbox(Globals.AsyncStorage.setItem(k, toJson v))

