namespace Shared.Types

type Counter = int

type Model =
    {
      counter: Counter option
      someString: string
      someFloat: float
      someInt: int
    }
    static member Empty =
        { counter = None
          someString = ""
          someFloat = 0.
          someInt = 0 }

type Msg =
| Increment
| Decrement
| Init of Result<Model, exn>