module internal Fable.Helpers.ReactToolbox

open Fable.Core
open Fable.Import
open Fable.Import.JS
open Fable.Import.React
open Fable.Core.JsInterop
open React.Props
open System

[<AutoOpen>]
module Props =

    type [<Erase>] Props =
        | ClassName of string
        | Key of string
        | OnClick of Function
        | OnMouseUp of Function
        | OnMouseEnter of Function
        | OnMouseLeave of Function
        | OnMouseDown of Function
        | OnContextMenu of Function
        | OnDoubleClick of Function
        | OnDrag of Function
        | OnDragEnd of Function
        | OnDragEnter of Function
        | OnDragExit of Function
        | OnDragLeave of Function
        | OnDragOver of Function
        | OnDragStart of Function
        | OnDrop of Function
        | OnMouseMove of Function
        | OnMouseOut of Function
        | OnMouseOver of Function
        | OnTouchCancel of Function
        | OnTouchEnd of Function
        | OnTouchMove of Function
        | OnTouchStart of Function
        | Style of CSSProperties
        interface Fable.Helpers.React.Props.IHTMLProp
        interface Fable.Helpers.React.Props.ICSSProp

    type internal IReactToolboxProp =
        inherit Fable.Helpers.React.Props.IHTMLProp
        inherit Fable.Helpers.React.Props.ICSSProp

open Props

let styles = JsInterop.importAll<obj> "react-toolbox/lib/commons.scss"

[<KeyValueList>]
type AppBarTheme =
    | AppBar of string
    | Fixed of string
    | Flat of string
    | Title of string
    | LeftIcon of string
    | RightIcon of string
[<KeyValueList>]
type AppBarProps =
    | Children of React.ReactNode
    | Fixed of bool
    | Flat of bool
    | Title of string
    | LeftIcon of string
    | OnLeftIconClick of Function
    | RightIcon of string
    | OnRightIconClick of Function
    | Theme of AppBarTheme
    interface IReactToolboxProp
let AppBar = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/app_bar"
let inline appBar b c = Fable.Helpers.React.from AppBar b c

[<KeyValueList>]
type AutocompleteTheme =
    | Active of string
    | Autocomplete of string
    | Focus of string
    | Input of string
    | Label of string
    | Suggestion of string
    | Suggestions of string
    | Up of string
    | Value of string
    | Values of string
[<KeyValueList>]
type AutocompleteProps =
    | Direction of (* TODO StringEnum auto | up | down *) string
    | Disabled of bool
    | Error of string
    | Label of string
    | Multiple of bool
    | OnChange of Function
    | SelectedPosition of (* TODO StringEnum above | below *) string
    | ShowSuggestionsWHenValueIsSet of bool
    | Source of obj
    | SuggestionMatch of (* TODO StringEnum start | anywhere | word *) string
    | Theme of AutocompleteTheme
    | Value of obj
    interface IReactToolboxProp
let Autocomplete = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/autocomplete"
let inline autocomplete b c = Fable.Helpers.React.from Autocomplete b c

[<KeyValueList>]
type AvatarTheme =
    | Avatar of string
    | Image of string
    | Letter of string
[<KeyValueList>]
type AvatarProps =
    | Children of React.ReactNode
    | Cover of bool
    | Icon of U2<React.ReactNode, string>
    | Image of U2<React.ReactNode, string>
    | Theme of AvatarTheme
    | Title of string
    interface IReactToolboxProp
let Avatar = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/avatar"
let inline avatar b c = Fable.Helpers.React.from Avatar b c

[<KeyValueList>]
type ButtonTheme =
    | Accent of string
    | Button of string
    | Flat of string
    | Floating of string
    | Icon of string
    | Inverse of string
    | Mini of string
    | Neutral of string
    | Primary of string
    | Raised of string
    | RippleWrapper of string
    | Toggle of string
[<KeyValueList>]
type ButtonProps =
    | Accent of bool
    | Children of React.ReactNode
    | Disabled of bool
    | Flat of bool
    | Floating of bool
    | Href of string
    | Icon of U2<React.ReactNode, string>
    | Inverse of bool
    | Label of string
    | Mini of bool
    | Neutral of bool
    | Primary of bool
    | Raised of bool
    | Ripple of bool
    | Theme of ButtonTheme
    interface IReactToolboxProp
let Button = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/button"
let inline button b c = Fable.Helpers.React.from Button b c
[<KeyValueList>]
type IconButtonTheme =
    | Accent of string
    | Button of string
    | Icon of string
    | Inverse of string
    | Neutral of string
    | Primary of string
    | RippleWrapper of string
    | Toggle of string
[<KeyValueList>]
type IconButtonProps =
    | Accent of bool
    | Children of React.ReactNode
    | Disabled of bool
    | Href of string
    | Icon of U2<React.ReactNode, string>
    | Inverse of bool
    | Neutral of bool
    | Primary of bool
    | Ripple of bool
    | Theme of IconButtonTheme
    interface IReactToolboxProp
let IconButton = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/button"
let inline iconButton b c = Fable.Helpers.React.from IconButton b c

[<KeyValueList>]
type CardTheme =
    | Card of string
    | Raised of string
[<KeyValueList>]
type CardProps =
    | Children of React.ReactNode
    | Raised of bool
    | Theme of CardTheme
    interface IReactToolboxProp
let Card = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/card"
let inline card b c = Fable.Helpers.React.from Card b c
[<KeyValueList>]
type CardActionsTheme =
    | CardActions of string
[<KeyValueList>]
type CardActionsProps =
    | Children of React.ReactNode
    | Theme of CardActionsTheme
    interface IReactToolboxProp
let CardActions = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/card"
let inline cardActions b c = Fable.Helpers.React.from CardActions b c
[<KeyValueList>]
type CardMediaTheme =
    | CardMedia of string
    | Content of string
    | ContentOverlay of string
    | Square of string
    | Wide of string
[<KeyValueList>]
type CardMediaProps =
    | AspectRatio of (* TODO StringEnum wide | square *) string
    | Children of React.ReactNode
    | Color of string
    | ContentOverlay of bool
    | Image of U2<React.ReactNode, string>
    | Theme of CardMediaTheme
    interface IReactToolboxProp
let CardMedia = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/card"
let inline cardMedia b c = Fable.Helpers.React.from CardMedia b c
[<KeyValueList>]
type CardTextTheme =
    | CardText of string
[<KeyValueList>]
type CardTextProps =
    | Children of React.ReactNode
    | Theme of CardTextTheme
    interface IReactToolboxProp
let CardText = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/card"
let inline cardText b c = Fable.Helpers.React.from CardText b c
[<KeyValueList>]
type CardTitleTheme =
    | Large of string
    | Title of string
    | Small of string
    | Subtitle of string
[<KeyValueList>]
type CardTitleProps =
    | Avatar of U2<React.ReactNode, string>
    | Children of React.ReactNode
    | Subtitle of U2<React.ReactNode, string>
    | Theme of CardTitleTheme
    | Title of U2<React.ReactNode, string>
    interface IReactToolboxProp
let CardTitle = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/card"
let inline cardTitle b c = Fable.Helpers.React.from CardTitle b c

[<KeyValueList>]
type CheckboxTheme =
    | Check of string
    | Checked of string
    | Disabled of string
    | Field of string
    | Input of string
    | Ripple of string
    | Text of string
[<KeyValueList>]
type CheckboxProps =
    | Checked of bool
    | Disabled of bool
    | Label of U2<React.ReactNode, string>
    | Name of string
    | OnBlur of Function
    | OnChange of (bool -> unit)
    | Theme of CheckboxTheme
    interface IReactToolboxProp
let Checkbox = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/checkbox"
let inline checkbox b c = Fable.Helpers.React.from Checkbox b c

[<KeyValueList>]
type ChipTheme =
    | Avatar of string
    | Chip of string
    | Deletable of string
    | Delete of string
    | DeleteIcon of string
    | DeleteX of string
[<KeyValueList>]
type ChipProps =
    | Children of React.ReactNode
    | Deletable of bool
    | OnDeleteClick of Function
    | Theme of ChipTheme
    interface IReactToolboxProp
let Chip = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/chip"
let inline chip b c = Fable.Helpers.React.from Chip b c

[<KeyValueList>]
type DatePickerTheme =
    | Active of string
    | Button of string
    | Calendar of string
    | CalendarWrapper of string
    | Date of string
    | Day of string
    | Days of string
    | Dialog of string
    | Disabled of string
    | Header of string
    | Input of string
    | Month of string
    | MonthsDisplay of string
    | Next of string
    | Prev of string
    | Title of string
    | Week of string
    | Year of string
    | Years of string
    | YearsDisplay of string
[<KeyValueList>]
type DatePickerProps =
    | AutoOk of bool
    | Error of string
    | Icon of U2<React.ReactNode, string>
    | InputClassName of string
    | InputFormat of Function
    | Label of string
    | MaxDate of DateTime
    | MinDate of DateTime
    | Name of string
    | OnChange of Function
    | OnEscKeyDown of Function
    | OnOverlayClick of Function
    | Theme of DatePickerTheme
    | Value of U2<DateTime, string>
    interface IReactToolboxProp
let DatePicker = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/date_picker"
let inline datePicker b c = Fable.Helpers.React.from DatePicker b c

[<KeyValueList>]
type DialogTheme =
    | Active of string
    | Body of string
    | Button of string
    | Dialog of string
    | Navigation of string
    | Title of string
[<KeyValueList>]
type DialogActionProps =
    | Label of string
    | OnClick of (React.MouseEvent -> unit)
    interface IReactToolboxProp
[<KeyValueList>]
type DialogProps =
    | Actions of IHTMLProp list array
    | Active of bool
    | Children of React.ReactNode
    | OnEscKeyDown of Function
    | OnOverlayClick of Function
    | OnOverlayMouseDown of Function
    | OnOverlayMouseMove of Function
    | OnOverlayMouseUp of Function
    | Theme of DialogTheme
    | Title of string
    | Type of string
    interface IReactToolboxProp
let Dialog = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/dialog"
let inline dialog b c = Fable.Helpers.React.from Dialog b c

[<KeyValueList>]
type DrawerTheme =
    | Active of string
    | Content of string
    | Drawer of string
    | Left of string
    | Right of string
[<KeyValueList>]
type DrawerProps =
    | Active of bool
    | Children of React.ReactNode
    | OnOverlayClick of (React.MouseEvent -> unit)
    | Theme of DrawerTheme
    | Type of (* TODO StringEnum left | right *) string
    interface IReactToolboxProp
let Drawer = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/drawer"
let inline drawer b c = Fable.Helpers.React.from Drawer b c


type DropdownWrapper<'TVal,'T> =
    { item: 'T
      value: 'TVal }
[<KeyValueList>]
type DropdownTheme =
    | Active of string
    | Disabled of string
    | Dropdown of string
    | Error of string
    | Errored of string
    | Field of string
    | Label of string
    | Selected of string
    | TemplateValue of string
    | Up of string
    | Value of string
    | Values of string
[<KeyValueList>]
type DropdownProps<'TVal,'T> =
    | AllowBlank of bool
    | Auto of bool
    | Disabled of bool
    | Error of string
    | Label of string
    | Name of string
    | OnBlur of Function
    | OnChange of ('TVal -> unit)
    | OnFocus of Function
    | Source of DropdownWrapper<'TVal,'T> array
    | Template of (DropdownWrapper<'TVal,'T> -> ReactElement<obj>)
    | Theme of DropdownTheme
    | Value of 'TVal
    interface IReactToolboxProp
let Dropdown = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/dropdown"
let inline dropdown b c = Fable.Helpers.React.from Dropdown b c

[<KeyValueList>]
type FontIconProps =
    | Children of React.ReactNode
    | Value of U2<React.ReactNode, string>
    interface IReactToolboxProp
let FontIcon = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/font_icon"
let inline fontIcon b c = Fable.Helpers.React.from FontIcon b c

[<KeyValueList>]
type InputTheme =
    | Bar of string
    | Counter of string
    | Disabled of string
    | Error of string
    | Errored of string
    | Hidden of string
    | Hint of string
    | Icon of string
    | Input of string
    | InputElement of string
    | Required of string
    | WithIcon of string
[<KeyValueList>]
type InputProps =
    | Children of React.ReactNode
    | Disabled of bool
    | Error of string
    | Floating of bool
    | Hint of string
    | Icon of U2<React.ReactNode, string>
    | Label of string
    | MaxLength of float
    | Multiline of bool
    | Name of string
    | OnBlur of Function
    | OnChange of (string -> unit)
    | OnFocus of Function
    | OnKeyPress of Function
    | Required of bool
    | Theme of InputTheme
    | Type of string
    | Value of obj
    interface IReactToolboxProp
let Input = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/input"
let inline input b c = Fable.Helpers.React.from Input b c

[<KeyValueList>]
type LayoutTheme =
    | Layout of string
[<KeyValueList>]
type LayoutProps =
    | Children of ReactElement<obj> // U3<NavDrawer, Panel, Sidebar>
    | Theme of LayoutTheme
    interface IReactToolboxProp
let Layout = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/layout"
let inline layout b c = Fable.Helpers.React.from Layout b c
[<KeyValueList>]
type NavDrawerTheme =
    | Active of string
    | DrawerContent of string
    | LgPermangent of string
    | MdPermangent of string
    | NavDrawer of string
    | Pinned of string
    | Scrim of string
    | ScrollY of string
    | SmPermanent of string
    | Wide of string
    | XlPermanent of string
    | XxlPermangent of string
    | XxxlPermangent of string
[<KeyValueList>]
type NavDrawerProps =
    | Active of bool
    | Children of React.ReactNode
    | OnOverlayClick of (React.MouseEvent -> unit)
    | PermanentAt of (* TODO StringEnum sm | md | lg | xl | xxl | xxxl *) string
    | Pinned of bool
    | ScrollY of bool
    | Theme of NavDrawerTheme
    | Width of (* TODO StringEnum normal | wide *) string
    interface IReactToolboxProp
let NavDrawer = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/layout"
let inline navDrawer b c = Fable.Helpers.React.from NavDrawer b c
[<KeyValueList>]
type PanelTheme =
    | Panel of string
    | ScrollY of string
[<KeyValueList>]
type PanelProps =
    | Children of React.ReactNode
    | ScrollY of bool
    | Theme of PanelTheme
    interface IReactToolboxProp
let Panel = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/layout"
let inline panel b c = Fable.Helpers.React.from Panel b c
[<KeyValueList>]
type SidebarTheme =
    | Pinned of string
    | ScrollY of string
    | Sidebar of string
    | SidebarContent of string
[<KeyValueList>]
type SidebarProps =
    | Children of React.ReactNode
    | Pinned of bool
    | ScrollY of bool
    | Theme of SidebarTheme
    | Width of float
    interface IReactToolboxProp
let Sidebar = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/layout"
let inline sidebar b c = Fable.Helpers.React.from Sidebar b c

[<KeyValueList>]
type LinkTheme =
    | Active of string
    | Icon of string
    | Link of string
[<KeyValueList>]
type LinkProps =
    | Active of bool
    | Children of React.ReactNode
    | Count of float
    | Href of string
    | Icon of U2<React.ReactNode, string>
    | Label of string
    | Theme of LinkTheme
    interface IReactToolboxProp
let Link = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/link"
let inline link b c = Fable.Helpers.React.from Link b c

[<KeyValueList>]
type ListTheme =
    | List of string
[<KeyValueList>]
type ListProps =
    | Children of React.ReactNode
    | Ripple of bool
    | Selectable of bool
    | Theme of ListTheme
    interface IReactToolboxProp
let List = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/list"
let inline list b c = Fable.Helpers.React.from List b c
[<KeyValueList>]
type ListCheckboxTheme =
    | Checkbox of string
    | CheckboxItem of string
    | Disabled of string
    | Item of string
    | ItemContentRoot of string
    | ItemText of string
    | Large of string
    | Primary of string
[<KeyValueList>]
type ListCheckboxProps =
    | Caption of string
    | Checked of bool
    | Disabled of bool
    | Legend of string
    | Name of string
    | OnBlur of Function
    | OnChange of Function
    | OnFocus of Function
    | Theme of ListCheckboxTheme
    interface IReactToolboxProp
let ListCheckbox = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/list"
let inline listCheckbox b c = Fable.Helpers.React.from ListCheckbox b c
[<KeyValueList>]
type ListDividerTheme =
    | Divider of string
    | Inset of string
and ListDividerProps =
    | Inset of bool
    | Theme of ListDividerTheme
    interface IReactToolboxProp
let ListDivider = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/list"
let inline listDivider b c = Fable.Helpers.React.from ListDivider b c
[<KeyValueList>]
type ListItemTheme =
    | Disabled of string
    | Item of string
    | ItemAction of string
    | ItemContentRoot of string
    | ItemText of string
    | Large of string
    | Left of string
    | ListItem of string
    | Primary of string
    | Right of string
    | Selectable of string
[<KeyValueList>]
type ListItemProps =
    | Avatar of U2<React.ReactNode, string>
    | Caption of string
    | Children of React.ReactNode
    | Disabled of bool
    | ItemContent of React.ReactNode
    | LeftActions of ReactElement<obj> array
    | LeftIcon of U2<React.ReactNode, string>
    | Legend of string
    | RightActions of ReactElement<obj> array
    | RightIcon of U2<ReactElement<obj>, string>
    | Ripple of bool
    | Selectable of bool
    | Theme of ListItemTheme
    | To of string
    interface IReactToolboxProp
let ListItem = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/list"
let inline listItem b c = Fable.Helpers.React.from ListItem b c
[<KeyValueList>]
type ListSubHeaderTheme =
    | Subheader of string
[<KeyValueList>]
type ListSubHeaderProps =
    | Caption of string
    | Theme of ListSubHeaderTheme
    interface IReactToolboxProp
let ListSubHeader = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/list"
let inline listSubHeader b c = Fable.Helpers.React.from ListSubHeader b c

[<KeyValueList>]
type MenuTheme =
    | Active of string
    | BottomLeft of string
    | BottomRight of string
    | Menu of string
    | MenuInner of string
    | Outline of string
    | Rippled of string
    | Static of string
    | TopLeft of string
    | TopRight of string
[<KeyValueList>]
type MenuProps =
    | Active of bool
    | Children of React.ReactNode
    | OnHide of Function
    | OnSelect of Function
    | OnShow of Function
    | Outline of bool
    | Position of (* TODO StringEnum auto | static | topLeft | topRight | bottomLeft | bottomRight *) string
    | Ripple of bool
    | Selectable of bool
    | Selected of obj
    | Theme of MenuTheme
    interface IReactToolboxProp
let Menu = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/menu"
let inline menu b c = Fable.Helpers.React.from Menu b c
[<KeyValueList>]
type IconMenuTheme =
    | Icon of string
    | IconMenu of string
[<KeyValueList>]
type IconMenuProps =
    | Children of React.ReactNode
    | Icon of U2<React.ReactNode, string>
    | IconRipple of bool
    | MenuRipple of bool
    | OnHide of Function
    | OnSelect of Function
    | OnShow of Function
    | Position of (* TODO StringEnum auto | static | topLeft | topRight | bottomLeft | bottomRight *) string
    | Selectable of bool
    | Selected of obj
    | Theme of IconMenuTheme
    interface IReactToolboxProp
let IconMenu = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/menu"
let inline iconMenu b c = Fable.Helpers.React.from IconMenu b c
[<KeyValueList>]
type MenuDividerTheme =
    | MenuDivider of string
[<KeyValueList>]
type MenuDividerProps =
    | Theme of MenuDividerTheme
    interface IReactToolboxProp
let MenuDivider = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/menu"
let inline menuDivider b c = Fable.Helpers.React.from MenuDivider b c
[<KeyValueList>]
type MenuItemTheme =
    | Caption of string
    | Disabled of string
    | Icon of string
    | MenuItem of string
    | Selected of string
    | Shortcut of string
[<KeyValueList>]
type MenuItemProps =
    | Caption of string
    | Children of React.ReactNode
    | Disabled of bool
    | Icon of U2<React.ReactNode, string>
    | Selected of bool
    | Shortcut of string
    | Theme of MenuItemTheme
    | Value of obj
    interface IReactToolboxProp
let MenuItem = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/menu"
let inline menuItem b c = Fable.Helpers.React.from MenuItem b c

[<KeyValueList>]
type NavigationTheme =
    | Button of string
    | Horizontal of string
    | Link of string
    | Vertical of string
[<KeyValueList>]
type NavigationProps =
    | Actions of ResizeArray<obj>
    | Children of React.ReactNode
    | Routes of ResizeArray<obj>
    | Theme of NavigationTheme
    | Type of (* TODO StringEnum vertical | horizontal *) string
    interface IReactToolboxProp
let Navigation = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/navigation"
let inline navigation b c = Fable.Helpers.React.from Navigation b c

[<KeyValueList>]
type ProgressBarTheme =
    | Buffer of string
    | Circle of string
    | Circular of string
    | Indeterminate of string
    | Linear of string
    | Multicolor of string
    | Path of string
    | Value of string
[<KeyValueList>]
type ProgressBarProps =
    | Buffer of float
    | Max of float
    | Min of float
    | Mode of (* TODO StringEnum determinate | indeterminate *) string
    | Multicolor of bool
    | Theme of ProgressBarTheme
    | Type of (* TODO StringEnum linear | circular *) string
    | Value of float
    interface IReactToolboxProp
let ProgressBar = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/progress_bar"
let inline progressBar b c = Fable.Helpers.React.from ProgressBar b c

[<KeyValueList>]
type RadioGroupProps =
    | Children of React.ReactNode
    | Disabled of bool
    | Name of string
    | OnChange of Function
    | Value of obj
    interface IReactToolboxProp
let RadioGroup = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/radio"
let inline radioGroup b c = Fable.Helpers.React.from RadioGroup b c
[<KeyValueList>]
type RadioButtonTheme =
    | Radio of string
    | RadioChecked of string
    | Ripple of string
    | Disabled of string
    | Field of string
    | Input of string
    | Text of string
[<KeyValueList>]
type RadioButtonProps =
    | Checked of bool
    | Disabled of bool
    | Label of U2<React.ReactNode, string>
    | Name of string
    | OnBlur of Function
    | OnChange of Function
    | OnFocus of Function
    | Theme of RadioButtonTheme
    | Value of obj
    interface IReactToolboxProp
let RadioButton = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/radio"
let inline radioButton b c = Fable.Helpers.React.from RadioButton b c

[<KeyValueList>]
type RippleTheme =
    | Ripple of string
    | RippleActive of string
    | RippleRestarting of string
    | RippleWrapper of string
[<KeyValueList>]
type RippleProps =
    | Children of React.ReactNode
    | Disabled of bool
    | OnRippleEnded of Function
    | Spread of float
    | Theme of RippleTheme
    interface IReactToolboxProp
let Ripple = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/ripple"
let inline ripple b c = Fable.Helpers.React.from Ripple b c

[<KeyValueList>]
type SliderTheme =
    | Container of string
    | Editable of string
    | Innerknob of string
    | Innerprogress of string
    | Input of string
    | Knob of string
    | Pinned of string
    | Pressed of string
    | Progress of string
    | Ring of string
    | Slider of string
    | Snap of string
    | Snaps of string
[<KeyValueList>]
type SliderProps =
    | Editable of bool
    | Max of float
    | Min of float
    | OnChange of Function
    | Pinned of bool
    | Snaps of bool
    | Step of float
    | Theme of SliderTheme
    | Value of float
    interface IReactToolboxProp
let Slider = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/slider"
let inline slider b c = Fable.Helpers.React.from Slider b c

[<KeyValueList>]
type SnackbarTheme =
    | Accept of string
    | Active of string
    | Button of string
    | Cancel of string
    | Icon of string
    | Label of string
    | Snackbar of string
    | Warning of string
[<KeyValueList>]
type SnackbarProps =
    | Action of string
    | Active of bool
    | Icon of U2<React.ReactNode, string>
    | Label of string
    | OnTimeout of Function
    | Theme of SnackbarTheme
    | Timeout of float
    | Type of (* TODO StringEnum accept | cancel | warning *) string
    interface IReactToolboxProp
let Snackbar = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/snackbar"
let inline snackbar b c = Fable.Helpers.React.from Snackbar b c

[<KeyValueList>]
type SwitchTheme =
    | Disabled of string
    | Field of string
    | Input of string
    | Off of string
    | On of string
    | Ripple of string
    | Text of string
    | Thumb of string
[<KeyValueList>]
type SwitchProps =
    | Checked of bool
    | Disabled of bool
    | Label of string
    | Name of string
    | OnBlur of Function
    | OnChange of (bool -> unit)
    | OnFocus of Function
    | Theme of SwitchTheme
    interface IReactToolboxProp
let Switch = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/switch"
let inline switch b c = Fable.Helpers.React.from Switch b c

[<KeyValueList>]
type TableTheme =
    | Editable of string
    | Row of string
    | Selectable of string
    | Selected of string
    | Table of string
[<KeyValueList>]
type TableProps =
    | Heading of bool
    | Model of obj
    | OnChange of Function
    | OnSelect of Function
    | Selectable of bool
    | MultiSelectable of bool
    | Selected of ResizeArray<obj>
    | Source of ResizeArray<obj>
    | Theme of TableTheme
    interface IReactToolboxProp
let Table = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/table"
let inline table b c = Fable.Helpers.React.from Table b c

[<KeyValueList>]
type TabsTheme =
    | Active of string
    | Navigation of string
    | Pointer of string
    | Tabs of string
    | Tab of string
[<KeyValueList>]
type TabsProps =
    | Children of React.ReactNode
    | DisableAnimatedBottomBorder of bool
    | Index of int
    | OnChange of (int -> unit)
    | Theme of TabsTheme
    interface IReactToolboxProp
let Tabs = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/tabs"
let inline tabs b c = Fable.Helpers.React.from Tabs b c
[<KeyValueList>]
type TabTheme =
    | Active of string
    | Disabled of string
    | Hidden of string
    | Label of string
[<KeyValueList>]
type TabProps =
    | Active of bool
    | ActiveClassName of string
    | Disabled of bool
    | Hidden of bool
    | Label of string
    | OnActive of Function
    | Theme of TabTheme
    interface IReactToolboxProp
let Tab = importMember<ComponentClass<IHTMLProp list>> "react-toolbox/lib/tabs"
let inline tab b c = Fable.Helpers.React.from Tab b c

[<KeyValueList>]
type TimePickerTheme =
    | Active of string
    | Am of string
    | AmFormat of string
    | Ampm of string
    | Button of string
    | Clock of string
    | ClockWrapper of string
    | Dialog of string
    | Face of string
    | Hand of string
    | Header of string
    | Hours of string
    | HoursDisplay of string
    | Input of string
    | Knob of string
    | Minutes of string
    | MinutesDisplay of string
    | Number of string
    | Placeholder of string
    | Pm of string
    | PmFormat of string
    | Separator of string
    | Small of string
[<KeyValueList>]
type TimePickerProps =
    | Error of string
    | Icon of U2<React.ReactNode, string>
    | InputClassName of string
    | Format of (* TODO StringEnum 24hr | ampm *) string
    | Label of string
    | OnChange of Function
    | Theme of TimePickerTheme
    | Value of DateTime
    interface IReactToolboxProp
let TimePicker = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/time_picker"
let inline timePicker b c = Fable.Helpers.React.from TimePicker b c

[<KeyValueList>]
type TooltipTheme =
    | Tooltip of string
    | TooltipActive of string
    | TooltipWrapper of string
[<KeyValueList>]
type TooltipProps =
    | Theme of TooltipTheme
    | Tooltip of string
    | TooltipDelay of float
    | TooltipHideOnClick of bool
    interface IReactToolboxProp
let Tooltip = importDefault<ComponentClass<IHTMLProp list>> "react-toolbox/lib/tooltip"
let inline tooltip b c = Fable.Helpers.React.from Tooltip b c