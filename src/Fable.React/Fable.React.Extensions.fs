[<AutoOpen>]
module Fable.React.Extensions

type Browser.Types.Event with
    /// Access the value from target
    /// Equivalent to `(this.target :?> HTMLInputElement).value`
    member this.Value =
        (this.target :?> Browser.Types.HTMLInputElement).value

    /// Access the checked property from target
    /// Equivalent to `(this.target :?> HTMLInputElement).checked`
    member this.Checked =
        (this.target :?> Browser.Types.HTMLInputElement).``checked``
