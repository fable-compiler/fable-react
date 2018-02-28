namespace Shared
open Fable.Core
open Fable.Core.JsInterop

type Counter = int

[<Pojo>]
type Model = {
  counter: Counter option
  someString: string
  someFloat: float
  someInt: int
}
