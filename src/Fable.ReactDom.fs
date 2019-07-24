namespace Fable.React

open Fable.Core
open System

[<AutoOpen>]
module ReactDomBindings =

    [<Obsolete("This binding has been moved to Fable.React.Dom package. Please install the new package.")>]
    let ReactDom: obj = jsNative

    #if !FABLE_REPL_LIB
    [<Obsolete("This binding has been moved to Fable.React.Dom package. Please install the new package.")>]
    let ReactDomServer: obj = jsNative
    #endif
