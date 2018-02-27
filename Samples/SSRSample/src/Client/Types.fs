module Client.Types

open Shared

type Msg =
| Increment
| Decrement
| Init of Result<Model, exn>
