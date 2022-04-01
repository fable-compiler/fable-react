namespace Fable.React

open Fable.Core
open Fable.React
open Browser.Types

type IReactRoot =
    /// Render a React element into the root.
    abstract render: element: ReactElement -> unit

    /// Remove the root from the DOM.
    abstract unmount: unit -> unit

type IRootOptions =
    /// Optional callback called when React automatically recovers from errors.
    abstract onRecoverableError: (obj -> unit) with get, set

    /// Optional prefix React uses for ids generated by React.useId. Useful to avoid conflicts when using multiple roots on the same page. Must be the same prefix used on the server.
    abstract identifierPrefix: string with get, set

type ICreateRootOptions =
    inherit IRootOptions

type IHydrateRootOptions =
    inherit IRootOptions

type IReactDom =
    /// Render a React element into the DOM in the supplied container.
    /// If the React element was previously rendered into container, this will perform an update on it and only mutate the DOM as necessary to reflect the latest React element.
    /// If the optional callback is provided, it will be executed after the component is rendered or updated.
    abstract render: element: ReactElement * container: Element * ?callback: (unit->unit) -> unit

    /// Same as render(), but is used to hydrate a container whose HTML contents were rendered by ReactDOMServer. React will attempt to attach event listeners to the existing markup.
    abstract hydrate: element: ReactElement * container: Element * ?callback: (unit->unit) -> unit

    /// Remove a mounted React component from the DOM and clean up its event handlers and state. If no component was mounted in the container, calling this function does nothing. Returns true if a component was unmounted and false if there was no component to unmount.
    abstract unmountComponentAtNode: container: Element -> bool

    /// Creates a portal. Portals provide a way to render children into a DOM node that exists outside the hierarchy of the DOM component.
    abstract createPortal: child: ReactElement * container: Element -> ReactElement

type IReactDomClient =
    /// Create a React root for the supplied container and return the root. The root can be used to render a React element into the DOM with render.
    /// Requires React 18.
    abstract createRoot: container: Element * ?options: ICreateRootOptions -> IReactRoot

    /// Same as createRoot(), but is used to hydrate a container whose HTML contents were rendered by ReactDOMServer. React will attempt to attach event listeners to the existing markup.
    /// Requires React 18.
    abstract hydrateRoot: container: Element * element: ReactElement * ?options: IHydrateRootOptions -> IReactRoot

type IReactDomServer =
    /// Render a React element to its initial HTML. This should only be used on the server. React will return an HTML string. You can use this method to generate HTML on the server and send the markup down on the initial request for faster page loads and to allow search engines to crawl your pages for SEO purposes.
    /// If you call ReactDOM.render() on a node that already has this server-rendered markup, React will preserve it and only attach event handlers, allowing you to have a very performant first-load experience.
    abstract renderToString: element: ReactElement -> string

    /// Similar to renderToString, except this doesn't create extra DOM attributes such as data-reactid, that React uses internally. This is useful if you want to use React as a simple static page generator, as stripping away the extra attributes can save lots of bytes.
    abstract renderToStaticMarkup: element: ReactElement -> string

[<AutoOpen>]
module ReactDomBindings =
    #if FABLE_REPL_LIB
    [<Global("ReactDOM")>]
    #else
    [<Import("*", "react-dom")>]
    #endif
    let ReactDom: IReactDom = jsNative

    /// Requires React 18.
    #if FABLE_REPL_LIB
    [<Global("ReactDOM")>]
    #else
    [<Import("*", "react-dom/client")>]
    #endif
    let ReactDomClient: IReactDomClient = jsNative

    #if !FABLE_REPL_LIB
    [<Import("default", "react-dom/server")>]
    let ReactDomServer: IReactDomServer = jsNative
    #endif