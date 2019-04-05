namespace Fable.Helpers

[<System.Obsolete("Use Fable.React")>]
module React =
    /// Use Fable.React
    let obsolete<'T> : 'T = failwith "Use Fable.React"

namespace Fable.React

open Fable.Core
open Fable.Core.JsInterop
open Browser
open Props

type ReactElementType<'props> = interface end

type ReactComponentType<'props> =
    inherit ReactElementType<'props>
    abstract displayName: string option with get, set

#if !FABLE_COMPILER
type HTMLNode =
    | Text of string
    | RawText of string
    | Node of string * IProp seq * ReactElement seq
    | List of ReactElement seq
    | Empty
with interface ReactElement

type ServerElementType =
    | Tag
    | Fragment
    | Component

type ReactElementTypeWrapper<'P> =
    | Comp of obj
    | Fn of ('P -> ReactElement)
    | HtmlTag of string
    interface ReactElementType<'P>
#endif

type Hooks =
    /// More info at https://reactjs.org/docs/hooks-state
    [<Import("useState", from="react")>]
    static member useState<'T> (initialState: 'T): 'T * ('T->unit) = jsNative

    /// More info at https://reactjs.org/docs/hooks-effect
    [<Import("useEffect", from="react")>]
    static member useEffect<'T> (effect: unit -> unit, ?checkValues: obj[]): unit = jsNative

    /// More info at https://reactjs.org/docs/hooks-effect
    [<Import("useEffect", from="react")>]
    [<Emit("$0(() => { $1(); return $2 }{{,$3}})")>]
    static member useEffectDisposable<'T> (effect: unit -> unit, dispose: unit->unit, ?checkValues: obj[]): unit = jsNative

[<AutoOpen>]
module Extensions =
    type Browser.Types.Event with
        /// Access the value from target
        /// Equivalent to `(this.target :?> HTMLInputElement).value`
        member this.Value =
            (this.target :?> Browser.Types.HTMLInputElement).value

        /// Access the checked property from target
        /// Equivalent to `(this.target :?> HTMLInputElement).checked`
        member this.Checked =
            (this.target :?> Browser.Types.HTMLInputElement).``checked``

[<AutoOpen>]
module Helpers =

    [<Import("createElement", from="react")>]
    let createElement(comp: obj, props: obj, [<ParamList>] children: obj): ReactElement =
#if FABLE_COMPILER
        jsNative
#else
        HTMLNode.Empty :> _
#endif

#if !FABLE_COMPILER
    [<RequireQualifiedAccess>]
    module ServerRendering =
        let [<Literal>] private ChildrenName = "children"

        let private createServerElementPrivate(tag: obj, props: obj, children: ReactElement seq, elementType: ServerElementType) =
            match elementType with
            | ServerElementType.Tag ->
                HTMLNode.Node (string tag, props :?> IProp seq, children) :> ReactElement
            | ServerElementType.Fragment ->
                HTMLNode.List children :> ReactElement
            | ServerElementType.Component ->
                let tag = tag :?> System.Type
                let comp = System.Activator.CreateInstance(tag, props)
                let childrenProp = tag.GetProperty(ChildrenName)
                childrenProp.SetValue(comp, children |> Seq.toArray)
                let render = tag.GetMethod("render")
                render.Invoke(comp, null) :?> ReactElement

        let private createServerElementByFnPrivate(f, props, children) =
            let propsType = props.GetType()
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
                            values.Add (FSharp.Reflection.FSharpValue.GetRecordField(props, p))
                    FSharp.Reflection.FSharpValue.MakeRecord(propsType, values.ToArray()) :?> 'P
            f props

        // In most cases these functions are inlined (mainly for Fable optimizations)
        // so we create a proxy to avoid inlining big functions every time

        let createServerElement(tag: obj, props: obj, children: ReactElement seq, elementType: ServerElementType) =
            createServerElementPrivate(tag, props, children, elementType)

        let createServerElementByFn(f, props, children) =
            createServerElementByFnPrivate(f, props, children)
#endif

    /// Instantiate a component from a type inheriting React.Component
    /// Example: `ofType<MyComponent,_,_> { myProps = 5 } []`
    let inline ofType<'T,'P,'S when 'T :> Component<'P,'S>> (props: 'P) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
        createElement(jsConstructor<'T>, props, children)
#else
        ServerRendering.createServerElement(typeof<'T>, props, children, ServerElementType.Component)
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
        ServerRendering.createServerElementByFn(f, props, children)
#endif

    /// OBSOLETE: Use `ofFunction`
    [<System.Obsolete("Use ofFunction")>]
    let inline fn<'P> (f: 'P -> ReactElement) (props: 'P) (children: ReactElement seq): ReactElement =
        ofFunction f props children

    /// Instantiate an imported React component. The first two arguments must be string literals, "default" can be used for the first one.
    /// Example: `ofImport "Map" "leaflet" { x = 10; y = 50 } []`
    let inline ofImport<'P> (importMember: string) (importPath: string) (props: 'P) (children: ReactElement seq): ReactElement =
        createElement(import importMember importPath, props, children)

    [<RequireQualifiedAccess>]
    module ReactElementType =
        let inline ofComponent<'comp, 'props, 'state when 'comp :> Component<'props, 'state>> : ReactElementType<'props> =
#if FABLE_COMPILER
            jsConstructor<'comp> |> unbox
#else
            Comp (typeof<'comp>) :> _
#endif

        let inline ofFunction<'props> (f: 'props -> ReactElement): ReactElementType<'props> =
#if FABLE_COMPILER
            f |> unbox
#else
            Fn f :> _
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
            | Comp obj -> ServerRendering.createServerElement(obj, props, children, ServerElementType.Component)
            | Fn f -> ServerRendering.createServerElementByFn(f, props, children)
            | HtmlTag obj -> ServerRendering.createServerElement(obj, props, children, ServerElementType.Tag)
#endif

#if FABLE_COMPILER
        [<Import("memo", from="react")>]
        let private reactMemo<'props> (render: 'props -> ReactElement, areEqual: 'props -> 'props -> bool) : ReactElementType<'props> =
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

#if FABLE_COMPILER
    [<Emit("typeof $0 === 'function'")>]
    let private isFunction (x: obj): bool = jsNative

    [<Emit("typeof $0 === 'object' && !$0[Symbol.iterator]")>]
    let private isNonEnumerableObject (x: obj): bool = jsNative
#endif

    /// Same as F# equality but ignores functions in the first level of an object
    /// Useful in combination with memoBuilderWith for most cases (ignore Elmish dispatch, etc)
    let equalsButFunctions (x: 'a) (y: 'a) =
#if FABLE_COMPILER
        if obj.ReferenceEquals(x, y) then
            true
        elif isNonEnumerableObject x && not(isNull(box y)) then
            (true, JS.Object.keys (x)) ||> Seq.fold (fun eq k ->
                eq && (isFunction x?(k) || x?(k) = y?(k)))
        else (box x) = (box y)
#else
        x = y // Server rendering, won't be actually used
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

// TODO: Move conditional compilation to the body of the functions?
#if FABLE_COMPILER
    /// OBSOLETE: Use `ReactElementType.create`
    [<System.Obsolete("Use ReactElementType.create")>]
    let inline from<'P> (com: ReactElementType<'P>) (props: 'P) (children: ReactElement seq): ReactElement =
        createElement(com, props, children)

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
        ServerRendering.createServerElement(tag, (props |> Seq.cast<IProp>), children, ServerElementType.Tag)
#endif

    /// Instantiate a DOM React element (void)
    let inline voidEl (tag: string) (props: IHTMLProp seq) : ReactElement =
#if FABLE_COMPILER
        createElement(tag, keyValueList CaseRules.LowerFirst props, [])
#else
        ServerRendering.createServerElement(tag, (props |> Seq.cast<IProp>), [], ServerElementType.Tag)
#endif

    /// Instantiate an SVG React element
    let inline svgEl (tag: string) (props: IProp seq) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
        createElement(tag, keyValueList CaseRules.LowerFirst props, children)
#else
        ServerRendering.createServerElement(tag, (props |> Seq.cast<IProp>), children, ServerElementType.Tag)
#endif

    /// Instantiate a React fragment
    let inline fragment (props: IFragmentProp seq) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
        createElement(jsConstructor<Fragment>, keyValueList CaseRules.LowerFirst props, children)
#else
        ServerRendering.createServerElement(typeof<Fragment>, (props |> Seq.cast<IProp>), children, ServerElementType.Fragment)
#endif

    // Class list helpers
    let classBaseList baseClass classes =
        classes
        |> Seq.choose (fun (name, condition) ->
            if condition && not(System.String.IsNullOrEmpty(name)) then Some name
            else None)
        |> Seq.fold (fun state name -> state + " " + name) baseClass
        |> ClassName

    let classList classes = classBaseList "" classes

    /// Finds a DOM element by its ID and mounts the React element there
    let inline mountById (domElId: string) (reactEl: ReactElement): unit =
        Fable.ReactDom.render(reactEl, document.getElementById(domElId))

    /// Finds the first DOM element matching a CSS selector and mounts the React element there
    let inline mountBySelector (domElSelector: string) (reactEl: ReactElement): unit =
        Fable.ReactDom.render(reactEl, document.querySelector(domElSelector))
