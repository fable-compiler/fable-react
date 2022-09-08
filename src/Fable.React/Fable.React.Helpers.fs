namespace Fable.React

open Fable.Core
open Fable.Core.JsInterop
open Browser
open Props

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

[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module ReactElementType =
    let inline ofComponent<'comp, 'props, 'state when 'comp :> Component<'props, 'state>> : ReactElementType<'props> =
#if FABLE_REPL_LIB
        failwith "Cannot create React components from types in Fable REPL"
#else
#if FABLE_COMPILER
        jsConstructor<'comp> |> unbox
#else
        Comp (typeof<'comp>) :> _
#endif
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
        ReactBindings.React.createElement(comp, props, children)
#else
        match (comp :?> ReactElementTypeWrapper<'props>) with
        | Comp obj -> ServerRendering.createServerElement(obj, props, children, ServerElementType.Component)
        | Fn f -> ServerRendering.createServerElementByFn(f, props, children)
        | HtmlTag obj -> ServerRendering.createServerElement(obj, props, children, ServerElementType.Tag)
#endif

    /// React.memo is a higher order component. It’s similar to React.PureComponent but for function components instead of classes.
    /// If your function component renders the same result given the same props, you can wrap it in a call to React.memo.
    /// React will skip rendering the component, and reuse the last rendered result.
    /// By default it will only shallowly compare complex objects in the props object. If you want control over the comparison, you can use `memoWith`.
    let memo<'props> (render: 'props -> ReactElement) =
#if FABLE_COMPILER
        ReactBindings.React.memo(render, unbox null)
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
        ReactBindings.React.memo(render, areEqual)
#else
        ofFunction render
#endif


[<AutoOpen>]
module Helpers =
    [<System.Obsolete("Use ReactBindings.React.createElement")>]
    let inline createElement(comp: obj, props: obj, [<ParamList>] children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
        ReactBindings.React.createElement(comp, props, children)
#else
        HTMLNode.Empty :> _
#endif

    /// Instantiate a component from a type inheriting React.Component
    /// Example: `ofType<MyComponent,_,_> { myProps = 5 } []`
    let inline ofType<'T,'P,'S when 'T :> Component<'P,'S>> (props: 'P) (children: ReactElement seq): ReactElement =
        ReactElementType.create ReactElementType.ofComponent<'T,_,_> props children

    [<System.Obsolete("Use ofType")>]
    let inline com<'T,'P,'S when 'T :> Component<'P,'S>> (props: 'P) (children: ReactElement seq): ReactElement =
        ofType<'T, 'P, 'S> props children

    let inline ofFunction<'P> (f: 'P -> ReactElement) (props: 'P) (children: ReactElement seq): ReactElement =
        ReactElementType.create (ReactElementType.ofFunction f) props children

    /// Instantiate an imported React component. The first two arguments must be string literals, "default" can be used for the first one.
    /// Example: `ofImport "Map" "leaflet" { x = 10; y = 50 } []`
    let inline ofImport<'P> (importMember: string) (importPath: string) (props: 'P) (children: ReactElement seq): ReactElement =
#if FABLE_REPL_LIB
        failwith "Cannot import React components in Fable REPL"
#else
#if FABLE_COMPILER
        ReactBindings.React.createElement(import importMember importPath, props, children)
#else
        failwith "Cannot import React components in .NET"
#endif
#endif

#if FABLE_COMPILER
    [<Emit("typeof $0 === 'function'")>]
    let private isFunction (x: obj): bool = jsNative

    [<Emit("typeof $0 === 'object' && !$0[Symbol.iterator]")>]
    let private isNonEnumerableObject (x: obj): bool = jsNative
#endif

    /// Normal structural F# comparison, but ignores top-level functions (e.g. Elmish dispatch).
    /// Can be used e.g. with the `FunctionComponent.Of` `memoizeWith` parameter.
    let equalsButFunctions (x: 'a) (y: 'a) =
#if FABLE_COMPILER
        if obj.ReferenceEquals(x, y) then
            true
        elif isNonEnumerableObject x && not(isNull(box y)) then
            let keys = JS.Constructors.Object.keys x
            let length = keys.Count
            let mutable i = 0
            let mutable result = true
            while i < length && result do
                let key = keys.[i]
                i <- i + 1
                let xValue = x?(key)
                result <- isFunction xValue || xValue = y?(key)
            result
        else
            (box x) = (box y)
#else
        // Server rendering, won't be actually used
        // Avoid `x = y` because it will force 'a to implement structural equality
        false
#endif

    /// Comparison similar to default React.memo, but ignores functions (e.g. Elmish dispatch).
    /// Performs a memberwise comparison where value types and strings are compared by value,
    /// and other types by reference.
    /// Can be used e.g. with the `FunctionComponent.Of` `memoizeWith` parameter.
    let memoEqualsButFunctions (x: 'a) (y: 'a) =
#if FABLE_COMPILER
        if obj.ReferenceEquals(x, y) then
            true
        elif isNonEnumerableObject x && not(isNull(box y)) then
            let keys = JS.Constructors.Object.keys x
            let length = keys.Count
            let mutable i = 0
            let mutable result = true
            while i < length && result do
                let key = keys.[i]
                i <- i + 1
                let xValue = x?(key)
                result <- isFunction xValue || obj.ReferenceEquals(xValue, y?(key))
            result
        else
            false
#else
        // Server rendering, won't be actually used
        // Avoid `x = y` because it will force 'a to implement structural equality
        false
#endif

    [<System.Obsolete("Use FunctionComponent.Of with memoizeWith")>]
    let memoBuilder<'props> (name: string) (render: 'props -> ReactElement) : 'props -> ReactElement =
#if FABLE_COMPILER
        render?displayName <- name
#endif
        let memoType = ReactElementType.memo render
        fun props ->
            ReactElementType.create memoType props []

    [<System.Obsolete("Use FunctionComponent.Of with memoizeWith")>]
    let memoBuilderWith<'props> (name: string) (areEqual: 'props -> 'props -> bool) (render: 'props -> ReactElement) : 'props -> ReactElement =
#if FABLE_COMPILER
        render?displayName <- name
#endif
        let memoType = ReactElementType.memoWith areEqual render
        fun props ->
            ReactElementType.create memoType props []

    [<System.Obsolete("Use ReactElementType.create")>]
    let inline from<'P> (com: ReactElementType<'P>) (props: 'P) (children: ReactElement seq): ReactElement =
        ReactElementType.create com props children

    /// Alias of `ofString`
    let inline str (s: string): ReactElement =
#if FABLE_COMPILER
        unbox s
#else
        HTMLNode.Text s :> ReactElement
#endif

    /// Cast a string to a React element (erased in runtime)
    let inline ofString (s: string): ReactElement =
        str s
        
    /// The equivalent of `sprintf (...) |> str`
    let inline strf format =
        Printf.kprintf str format

    /// Cast an option value to a React element (erased in runtime)
    let inline ofOption (o: ReactElement option): ReactElement =
        match o with Some o -> o | None -> null // Option.toObj(o)

    [<System.Obsolete("Use ofOption")>]
    let opt (o: ReactElement option): ReactElement =
        ofOption o

    /// Cast an int to a React element (erased in runtime)
    let inline ofInt (i: int): ReactElement =
#if FABLE_COMPILER
        unbox i
#else
        HTMLNode.RawText (string i) :> ReactElement
#endif

    /// Cast a float to a React element (erased in runtime)
    let inline ofFloat (f: float): ReactElement =
#if FABLE_COMPILER
        unbox f
#else
        HTMLNode.RawText (string f) :> ReactElement
#endif

    /// Returns a list **from .render() method**
    let inline ofList (els: ReactElement list): ReactElement =
#if FABLE_COMPILER
        unbox(List.toArray els)
#else
        HTMLNode.List els :> ReactElement
#endif

    /// Returns an array **from .render() method**
    let inline ofArray (els: ReactElement array): ReactElement =
#if FABLE_COMPILER
        unbox els
#else
        HTMLNode.List els :> ReactElement
#endif

    /// A ReactElement when you don't want to render anything (null in javascript)
    let nothing: ReactElement =
#if FABLE_COMPILER
        null
#else
        HTMLNode.Empty :> ReactElement
#endif

    /// Instantiate a DOM React element
    let inline domEl (tag: string) (props: IHTMLProp seq) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
        ReactBindings.React.createElement(tag, keyValueList CaseRules.LowerFirst props, children)
#else
        ServerRendering.createServerElement(tag, (props |> Seq.cast<IProp>), children, ServerElementType.Tag)
#endif

    /// Instantiate a DOM React element (void)
    let inline voidEl (tag: string) (props: IHTMLProp seq) : ReactElement =
#if FABLE_COMPILER
        ReactBindings.React.createElement(tag, keyValueList CaseRules.LowerFirst props, [])
#else
        ServerRendering.createServerElement(tag, (props |> Seq.cast<IProp>), [], ServerElementType.Tag)
#endif

    /// Instantiate an SVG React element
    let inline svgEl (tag: string) (props: IProp seq) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
        ReactBindings.React.createElement(tag, keyValueList CaseRules.LowerFirst props, children)
#else
        ServerRendering.createServerElement(tag, (props |> Seq.cast<IProp>), children, ServerElementType.Tag)
#endif

    /// Instantiate a React fragment
    let inline fragment (props: IFragmentProp seq) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
        ReactBindings.React.createElement(ReactBindings.React.Fragment, keyValueList CaseRules.LowerFirst props, children)
#else
        ServerRendering.createServerElement(typeof<Fragment>, (props |> Seq.cast<IProp>), children, ServerElementType.Fragment)
#endif

    /// Accepts a context value to be passed to consuming components that are descendants of this Provider.
    /// One Provider can be connected to many consumers. Providers can be nested to override values deeper within the tree.
    /// Important: In SSR, this is ignored, and the DEFAULT value is consumed!
    /// More info at https://reactjs.org/docs/context.html#contextprovider
    let inline contextProvider (ctx: IContext<'T>) (value: 'T) (children: ReactElement seq): ReactElement =
#if FABLE_COMPILER
        ReactBindings.React.createElement(ctx?Provider, createObj ["value" ==> value], children)
#else
        fragment [] children
#endif

    /// Consumes a context value, either from the nearest parent in the tree, or from the default value.
    /// Important: in SSR, this will always consume the context DEFAULT value!
    /// More info at https://reactjs.org/docs/context.html#contextconsumer
    let inline contextConsumer (ctx: IContext<'T>) (children: 'T -> ReactElement): ReactElement =
#if FABLE_COMPILER
        ReactBindings.React.createElement(ctx?Consumer, null, [!!children])
#else
        let ctx = ctx :?> ISSRContext<_>
        fragment [] [children(ctx.DefaultValue)]
#endif

    /// Creates a Context object. When React renders a component that subscribes to this Context
    /// object it will read the current context value from the closest matching Provider above it
    /// in the tree. More info at https://reactjs.org/docs/context.html#reactcreatecontext
    let inline createContext (defaultValue: 'T): IContext<'T> =
#if FABLE_COMPILER
        ReactBindings.React.createContext(defaultValue)
#else
        upcast { new ISSRContext<_> with member __.DefaultValue = defaultValue }
#endif

    /// To be used in constructors of class components
    /// (for function components use `useRef` hook)
    let inline createRef (initialValue: 'T): IRefValue<'T> =
#if FABLE_COMPILER
        ReactBindings.React.createRef(initialValue)
#else
        { new IRefValue<_> with
            member __.current with get() = initialValue and set _ = () }
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
    /// Important: Not available in SSR
    let inline mountById (domElId: string) (reactEl: ReactElement): unit =
#if FABLE_COMPILER
        ReactDom.render(reactEl, document.getElementById(domElId))
#else
        failwith "mountById is not available for SSR"
#endif
    /// Finds the first DOM element matching a CSS selector and mounts the React element there
    /// Important: Not available in SSR
    let inline mountBySelector (domElSelector: string) (reactEl: ReactElement): unit =
#if FABLE_COMPILER
        ReactDom.render(reactEl, document.querySelector(domElSelector))
#else
        failwith "mountBySelector is not available for SSR"
#endif
