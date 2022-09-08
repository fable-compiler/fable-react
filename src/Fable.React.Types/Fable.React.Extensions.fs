[<AutoOpen>]
module Fable.React.Extensions

open Fable.Core

type Browser.Types.Event with
    /// Access the value from target
    /// Equivalent to `(this.target :?> HTMLInputElement).value`
    [<Emit("$0.target.value")>]
    member this.Value: string =
        (this.target :?> Browser.Types.HTMLInputElement).value

    /// Access the checked property from target
    /// Equivalent to `(this.target :?> HTMLInputElement).checked`
    [<Emit("$0.target.checked")>]
    member this.Checked: bool =
        (this.target :?> Browser.Types.HTMLInputElement).``checked``
