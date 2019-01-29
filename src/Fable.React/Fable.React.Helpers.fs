namespace Fable.React

[<AutoOpen>]
module Helpers =

    open FSharp.Reflection
    open Fable.Core
    open Fable.Core.JsInterop
    open Browser
    open Props

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

    [<Erase>]
    type ReactElementTypeWrapper<'P> =
        | Comp of obj
        | Fn of ('P -> ReactElement)
        | HtmlTag of string
        interface ReactElementType<'P>

    [<RequireQualifiedAccess>]
    module ReactElementType =
        let inline ofComponent<'comp, 'props, 'state when 'comp :> Component<'props, 'state>> =
            #if FABLE_COMPILER
            unbox<ReactComponentType<'props>> jsConstructor<'comp>
            #else
            Comp (typeof<'comp>) :> ReactElementType<'props>
            #endif

        let inline ofFunction<'props> (f: 'props -> ReactElement) =
            #if FABLE_COMPILER
            unbox<ReactComponentType<'props>> f
            #else
            Fn f :> ReactElementType<'props>
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
            | Comp obj -> createServerElement(obj, props, children, ServerElementType.Component)
            | Fn f -> createServerElementByFn(f, props, children)
            | HtmlTag obj -> createServerElement(obj, props, children, ServerElementType.Tag)
            #endif

        #if FABLE_COMPILER
        [<Import("memo", from="react")>]
        let private reactMemo<'props> (render: 'props -> ReactElement, areEqual: 'props -> 'props -> bool) : ReactComponentType<'props> =
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

    // Class list helpers
    let classBaseList std classes =
        classes
        |> List.fold (fun complete -> function | (name,true) -> complete + " " + name | _ -> complete) std
        |> ClassName

    let classList classes = classBaseList "" classes

    /// Finds a DOM element by its ID and mounts the React element there
    let inline mountById (domElId: string) (reactEl: ReactElement): unit =
        Fable.ReactDom.render(reactEl, document.getElementById(domElId))

    /// Finds the first DOM element matching a CSS selector and mounts the React element there
    let inline mountBySelector (domElSelector: string) (reactEl: ReactElement): unit =
        Fable.ReactDom.render(reactEl, document.querySelector(domElSelector))

    type Browser.Types.Event with
        /// Access the value from target
        /// Equivalent to `(this.target :?> HTMLInputElement).value`
        member this.Value =
            (this.target :?> Browser.Types.HTMLInputElement).value

        /// Access the checked property from target
        /// Equivalent to `(this.target :?> HTMLInputElement).checked`
        member this.Checked =
            (this.target :?> Browser.Types.HTMLInputElement).``checked``

namespace Fable.Helpers

[<System.Obsolete("Use Fable.React")>]
module React =
    /// Use Fable.React
    let obsolete<'T> : 'T = failwith "Use Fable.React"