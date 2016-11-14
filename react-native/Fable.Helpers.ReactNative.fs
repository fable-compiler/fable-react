[<Fable.Core.Erase>]
module internal Fable.Helpers.ReactNative

open System
open Fable.Import.ReactNative
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

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
        | InitialPage of float
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
        | RenderError of Func<React.ReactElement<ViewProperties>>
        | RenderLoading of Func<React.ReactElement<ViewProperties>>
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
        | Title of Func<Route, Navigator, float, NavState, React.ReactElement<obj>> 
        | LeftButton of Func<Route, Navigator, float, NavState, React.ReactElement<obj>>
        | RightButton of Func<Route, Navigator, float, NavState, React.ReactElement<obj>>

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
        | NavigationBar of React.ReactElement<obj> // React.ReactElement<Navigator.NavigationBarProperties> option
        | Navigator of Navigator
        | OnDidFocus of (unit->unit)
        | OnWillFocus of (unit->unit)
        | RenderScene of Func<Route, Navigator, React.ReactElement<obj>>
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
        | RefreshControl of React.ReactElement<RefreshControlProperties>
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
        | RenderFooter of Func<React.ReactElement<obj>>
        | RenderHeader of Func<React.ReactElement<obj>>
        | RenderRow of Func<'a, U2<string, float>, U2<string, float>, bool, React.ReactElement<obj>>
        | RenderScrollComponent of Func<ScrollViewProperties, React.ReactElement<ScrollViewProperties>>
        | RenderSectionHeader of Func<obj, U2<string, float>, React.ReactElement<obj>>
        | RenderSeparator of Func<U2<string, float>, U2<string, float>, bool, React.ReactElement<obj>>
        | ScrollRenderAheadDistance of float
        | Ref of Ref<obj>
        interface IListViewProperties

    [<KeyValueList>]
    type SwipeableListViewProps<'a> =
        | DataSource of SwipeableListViewDataSource<'a> // REQUIRED!
        | MaxSwipeDistance of float
        | RenderRow of Func<'a, U2<string, float>, U2<string, float>, bool, React.ReactElement<obj>> // REQUIRED!
        | RenderQuickActions of Func<'a, string, string, React.ReactElement<obj>> // REQUIRED!

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
        | OnValueChange of Func<bool, unit>
        | TestID of string
        | Value of bool
        | Style of IStyle list
        | Ref of Ref<Switch>
        interface ISwitchProperties

    [<KeyValueList>]
    type NavigationAnimatedViewProps =
        | Route of obj
        | Style of IStyle list
        | RenderOverlay of (obj -> React.ReactElement<obj>)
        | ApplyAnimation of (obj * obj -> unit)
        | RenderScene of (obj -> React.ReactElement<obj>)


    [<KeyValueList>]
    type INavigationHeaderProps =
        interface end

    [<KeyValueList>]
    type NavigationHeaderProps =
        | RenderTitleComponent of (NavigationTransitionProps -> React.ReactElement<obj>)
        | RenderLeftComponent of (NavigationTransitionProps -> React.ReactElement<obj>)
        | RenderRightComponent of (NavigationTransitionProps -> React.ReactElement<obj>)
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
        | RenderHeader of (NavigationTransitionProps -> React.ReactElement<obj>)
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

let inline localImage (path:string) : IImageSourceProperties list =
    Node.require.Invoke(path) |> unbox

let inline text (props:TextProperties list) (text:string): React.ReactElement<obj> = 
    React.createElement(
      RN.Text,
      unbox props,
      unbox text) |> unbox

let inline textInput (props: ITextInputProperties list) (text:string): React.ReactElement<obj> =
    React.createElement(
        RN.TextInput, 
        unbox props,
        unbox text) |> unbox

let inline createToolbarAction(title:string,showStatus:ToolbarActionShowStatus) : ToolbarAndroidAction =
    createObj [
        "title" ==> title
        "show" ==> showStatus
    ] |> unbox
    
let inline  createToolbarActionWithIcon(title:string,icon: IImageSourceProperties list,showStatus:ToolbarActionShowStatus) : ToolbarAndroidAction =
    createObj [
        "title" ==> title
        "icon" ==> icon
        "show" ==> showStatus
    ] |> unbox

let inline toolbarAndroid (props:IToolbarAndroidProperties list) (onActionSelected:int -> unit) : React.ReactElement<obj> = 
    React.createElement(
        RN.ToolbarAndroid,
        JS.Object.assign(
            createObj ["onActionSelected" ==> onActionSelected],
            props) |> unbox,
        unbox([||])) |> unbox

let inline keyboardAvoidingView (props:IKeyboardAvoidingViewProps list) : React.ReactElement<obj> = 
    React.createElement(
      RN.KeyboardAvoidingView,
      unbox props,
      unbox([||])) |> unbox

let inline view (props: IViewProperties list) (children: React.ReactElement<obj> list): React.ReactElement<obj> =
    React.createElement(
        RN.View, 
        unbox props,
        unbox(List.toArray children)) |> unbox

let inline webView (props:IWebViewProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.WebView,
      unbox props,
      unbox([||])) |> unbox

let inline segmentedControlIOS (props:ISegmentedControlIOSProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.SegmentedControlIOS,
      unbox props,
      unbox([||])) |> unbox

let inline activityIndicator (props:IActivityIndicatorProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.ActivityIndicator,
      unbox props,
      unbox([||])) |> unbox

let inline activityIndicatorIOS (props:IActivityIndicatorIOSProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.ActivityIndicatorIOS,
      unbox props,
      unbox([||])) |> unbox

let inline datePickerIOS (props:IDatePickerIOSProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.DatePickerIOS,
      unbox props,
      unbox([||])) |> unbox

let inline drawerLayoutAndroid (props:IDrawerLayoutAndroidProperties list) (renderNavigationView: unit -> React.ReactElement<obj>) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      RN.DrawerLayoutAndroid,
      JS.Object.assign(
            createObj ["renderNavigationView" ==> renderNavigationView],
            props)
        |> unbox,
        unbox(List.toArray children)) |> unbox

let inline pickerIOSItem (props:Picker.PickerIOSItemProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.PickerIOS.Item,
      unbox props,
      unbox([||])) |> unbox

let inline pickerItem (props:Picker.PickerItemProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.Picker.Item,
      unbox props,
      unbox([||])) |> unbox

let inline picker (props:IPickerProperties list) (children:React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      RN.Picker,
      unbox props,
      unbox children) |> unbox

let inline pickerIOS (props:Picker.PickerIOSProperties list) (children:React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      RN.PickerIOS,
      unbox props,
      unbox children) |> unbox

let inline progressBarAndroid (props:IProgressBarAndroidProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.ProgressBarAndroid,
      unbox props,
      unbox([||])) |> unbox

let inline progressViewIOS (props:IProgressViewIOSProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.ProgressViewIOS,
      unbox props,
      unbox([||])) |> unbox

let inline refreshControl (props:IRefreshControlProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.RefreshControl,
      unbox props,
      unbox([||])) |> unbox

let inline slider (props:ISliderProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.Slider,
      unbox props,
      unbox([||])) |> unbox

let inline sliderIOS (props:ISliderIOSProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.SliderIOS,
      unbox props,
      unbox([||])) |> unbox

let inline switchIOS (props:SwitchIOSProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.SwitchIOS,
      unbox props,
      unbox([||])) |> unbox

let inline image (props:IImageProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.Image,
      unbox props,
      unbox([||])) |> unbox

let inline imageWithChild (props: IImageProperties list) (child: React.ReactElement<obj>) : React.ReactElement<obj> =
    React.createElement(
        RN.Image, 
        unbox props,
        unbox([|child|])) |> unbox        

let inline listView<'a> (dataSource:ListViewDataSource<'a>) (props: IListViewProperties list)  : React.ReactElement<obj> =
    React.createElement(
        RN.ListView, 
        JS.Object.assign(
            createObj ["dataSource" ==> dataSource],
            props)
        |> unbox,
        unbox [||]) |> unbox

let inline mapView (props:IMapViewProperties list) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      RN.MapView,
      unbox props,
      unbox(List.toArray children)) |> unbox

let inline modal (props:ModalProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.Modal,
      unbox props,
      unbox([||])) |> unbox

let inline touchableWithoutFeedback (props:ITouchableWithoutFeedbackProperties list) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      RN.TouchableWithoutFeedback,
      unbox props,
      unbox(List.toArray children)) |> unbox

let inline touchableHighlight (props:ITouchableHighlightProperties list) (children: React.ReactElement<obj> list) : React.ReactElement<obj> = 
    React.createElement(
      RN.TouchableHighlight,
      unbox props,
      unbox (Array.ofList children)) |> unbox

let inline touchableHighlightWithChild (props:ITouchableHighlightProperties list) (child: React.ReactElement<obj>): React.ReactElement<obj> = 
    React.createElement(
      RN.TouchableHighlight,
      unbox props,
      unbox([|child|])) |> unbox

let inline touchableOpacity (props:ITouchableOpacityProperties list) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      RN.TouchableOpacity,
      unbox props,
      unbox(List.toArray children)) |> unbox

let inline touchableNativeFeedback (props:ITouchableNativeFeedbackProperties list) (children: React.ReactElement<obj> list): React.ReactElement<obj> = 
    React.createElement(
      RN.TouchableNativeFeedback,
      unbox props,
      unbox(List.toArray children)) |> unbox

let inline viewPagerAndroid (props: IViewPagerAndroidProperties list) (children: React.ReactElement<obj> list) : React.ReactElement<obj> =
    React.createElement(
        RN.ViewPagerAndroid, 
        props|> unbox,
        unbox(List.toArray children)) |> unbox

let inline navigator (props:INavigatorProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.Navigator,
      unbox props,
      unbox([||])) |> unbox

let inline styleSheet (props:StyleSheetProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.StyleSheet,
      unbox props,
      unbox([||])) |> unbox

let inline tabBarItem (props:ITabBarItemProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.TabBarIOS.Item,
      unbox props,
      unbox([||])) |> unbox

let inline tabBarIOS (props:ITabBarIOSProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.TabBarIOS,
      unbox props,
      unbox([||])) |> unbox

let inline scrollView (props:IScrollViewProperties list) (children: React.ReactElement<obj> list) : React.ReactElement<obj> = 
    React.createElement(
      RN.ScrollView,
      unbox props,
      unbox(List.toArray children)) |> unbox

let inline swipeableListView (props:SwipeableListViewProps<_> list) : React.ReactElement<obj> = 
    React.createElement(
      RN.SwipeableListView,
      unbox props,
      unbox([||])) |> unbox

let inline statusBar (props:IStatusBarProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.StatusBar,
      unbox props,
      unbox([||])) |> unbox

let inline switch (props:ISwitchProperties list) : React.ReactElement<obj> = 
    React.createElement(
      RN.Switch,
      unbox props,
      unbox([||])) |> unbox

let inline navigationHeader (props:INavigationHeaderProps list) (rendererProps:NavigationTransitionProps): React.ReactElement<obj> =
    React.createElement(
      RN.NavigationExperimental.Header,
      JS.Object.assign(props,rendererProps) |> unbox,
      unbox([||])) |> unbox

let inline navigationState (index:int) (routes:NavigationRoute list) =
    createObj ["index" ==> index
               "routes" ==> Array.ofList routes]
    |> unbox<NavigationState>

let inline navigationRoute (key:string) (title:string option) =
    createObj ["key" ==> key
               "title" ==> title]
    |> unbox<NavigationRoute>
    
let inline navigationCardStack (navigationState: NavigationState)
                               (renderScene: NavigationTransitionProps -> React.ReactElement<obj>)
                               (props:INavigationCardStackProps list): React.ReactElement<obj> = 
    React.createElement(
      RN.NavigationExperimental.CardStack,
      JS.Object.assign(
            createObj ["renderScene" ==> renderScene
                       "navigationState" ==> navigationState],
            props)
        |> unbox,
      unbox([||])) |> unbox

let inline navigationContainer (props:NavigationContainerProps list) : React.ReactElement<obj> = 
    React.createElement(
      RN.NavigationContainer,
      unbox props,
      unbox([||])) |> unbox

let inline navigationRootContainer (props:NavigationRootContainerProps list) : React.ReactElement<obj> = 
    React.createElement(
      RN.NavigationRootContainer,
      unbox props,
      unbox([||])) |> unbox

let inline navigationBar (props:NavigationBarProperties list) : React.ReactElement<obj> = 
    React.createElement(
      NavigatorStatic.Globals.NavigationBar,
      unbox props,
      unbox([||])) |> unbox

let inline breadcrumbNavigationBar (props:IBreadcrumbNavigationBarProperties list) : React.ReactElement<obj> = 
    React.createElement(
      NavigatorStatic.Globals.BreadcrumbNavigationBar,
      unbox props,
      unbox([||])) |> unbox

[<Emit("new ListView.DataSource({rowHasChanged: (r1, r2) => r1 !== r2})")>]
let emptyDataSource<'a>() : ListViewDataSource<'a> = failwith "JS only"

let inline newDataSource<'a> (elements:'a []) =
    emptyDataSource<'a>().cloneWithRows(unbox elements)

let inline updateDataSource<'a> (data:'a []) (dataSource : ListViewDataSource<'a>) : ListViewDataSource<'a> = 
    dataSource.cloneWithRows (unbox data) |> unbox

let inline createComponent<'T,'P,'S when 'T :> React.Component<'P,'S>> (props: 'P) (children: React.ReactElement<obj> list): React.ReactElement<obj> =
    unbox(React.createElement(U2.Case1(unbox typeof<'T>), toPlainJsObj props, unbox(List.toArray children)))

let inline createScene<'T,'P,'S when 'T :> React.Component<'P,'S>> (props: 'P) : React.ReactElement<obj> =
    unbox(React.createElement(U2.Case1(unbox typeof<'T>), toPlainJsObj props, unbox([||])))


[<Import("Buffer","buffer")>]
let Buffer = obj()

let inline encode (text: string, encoding:string) : string =
    (createNew Buffer text)?toString(encoding) |> unbox

let inline encodeBase64 (text: string) : string = encode(text,"base64")
let inline encodeAscii (text: string) : string = encode(text,"ascii") 

[<Import("BackAndroid","react-native")>]
let BackAndroid = obj()

let inline removeOnHardwareBackPressHandler (onHardwareBackPress: unit -> bool): unit =
    BackAndroid?removeEventListener("hardwareBackPress", onHardwareBackPress) |> ignore

let inline setOnHardwareBackPressHandler (onHardwareBackPress: unit -> bool): unit =
    BackAndroid?addEventListener("hardwareBackPress", onHardwareBackPress) |> ignore

let inline exitApp (): unit =
    BackAndroid?exitApp() |> ignore
    
[<Import("Linking","react-native")>]
let Linking = obj()

/// Opens the given URL
let inline openUrl (url:string) : unit =
    Linking?openURL(url) |> ignore

module Alert =
    [<Import("Alert","react-native")>]
    let Alert = obj()
    
    let inline private createButton(label:string,callback:unit -> unit) = 
        createObj [
            "text" ==> label
            "onPress" ==> callback
        ]

    /// Shows an alert button with one button 
    let inline alertWithOneButton (title:string,message:string,okText:string,onOk:unit -> unit) : unit =
        Alert?alert( title, message, [| createButton(okText,onOk) |]) |> ignore

    /// Shows an alert button with two buttons 
    let inline alertWithTwoButtons (title:string,message:string,cancelText:string,onCancel:unit -> unit,okText:string,onOk:unit -> unit) : unit =
        Alert?alert( title, message, [| createButton(cancelText,onCancel); createButton(okText,onOk) |]) |> ignore

    let inline confirm (title:string,message:string,cancelText:string,okText:string) =
        
        Async.FromContinuations(fun (onSuccess, onError, _) ->
            let onError() = onError(new Exception("Cancelled"))

            alertWithTwoButtons (title,message,cancelText,onError,okText,onSuccess)
        )

module NetInfo =
    [<Import("NetInfo","react-native")>]
    let NetInfo = obj()

    open Fable.Import.JS
    open Fable.Import.Browser

    let inline getConnectionType() : Async<string> = async {
        let fetchPromise : Promise<string> = NetInfo?fetch() |> unbox
        return! fetchPromise |> Async.AwaitPromise
    }

module ImageStore =
    [<Import("ImageStore","react-native")>]
    let ImageStore = obj()

    open Fable.Import.JS
    open Fable.Import.Browser

    let inline getBase64ForTag uri : Async<string> = 
        Async.FromContinuations(fun (onSuccess, onError, _) ->
            ImageStore?getBase64ForTag( uri, onSuccess, onError) |> ignore
        )

module Toast =
    [<Import("ToastAndroid","react-native")>]
    let Toast = obj()

    /// Shows a toast with short duration
    let inline showShort (message:string) : unit = 
        Toast?show(message,Toast?SHORT) |> unbox

    /// Shows a toast with long duration
    let inline showShort (message:string) : unit = 
        Toast?show(message,Toast?LONG) |> unbox

module Storage =
    open Fable.Core.JsInterop

    /// Loads a value as string with the given key from the local device storage. Returns None if the key is not found.
    let inline getItem (key:string) : Async<Option<_>> = async {
        let! v = Globals.AsyncStorage.getItem key |> Async.AwaitPromise
        match v with
        | null -> return Option.None
        | _ -> return Some v
    }

    /// Loads a value with the given key from the local device storage. Returns None if the key is not found.
    let inline load<'a> (key:string) : Async<'a option> = async {
        let! v = Globals.AsyncStorage.getItem key |> Async.AwaitPromise
        match v with
        | null -> return Option.None
        | _ -> return Some (ofJson v)
    }

    /// Saves a value with the given key to the local device storage.
    let inline setItem (k:string) (v:string) = async {
        let! v = Globals.AsyncStorage.setItem(k,v) |> Async.AwaitPromise
        ()
    }

    /// Saves a value with the given key to the local device storage.
    let inline save<'a> (k:string) (v:'a) = async {
        let s:string = toJson v
        let! v = Globals.AsyncStorage.setItem(k,s) |> Async.AwaitPromise
        ()
    }    
