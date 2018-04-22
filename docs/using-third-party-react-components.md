# Using third party React components

Using a third party (Javascript) React component is straightforward for most components. There are two ways of declaring a third party React component in F# - either by declaring a Pojo record for the props or by declaring a Discriminated Union where each case has one field.

Some components have a [Typescript](https://www.typescriptlang.org/) definition available, either because the component was authored in Typescript or someone created a type definition for the [Definitely Typed project](https://definitelytyped.org/). If this is the case then you can try the [ts2fable tool](https://github.com/fable-compiler/ts2fable) to convert this React component type definition from Typescript to a Fable type declaration - it might need some tweaking but for components with a big API surface this can be a real time saver.

## Using a React component by declaring a Discriminated Union props type

The basic steps when working with a Discriminated Union are:

### 1. Install the react component

Using yarn or npm, install the react component you want to use.

For example to use the [rc-progress React components](https://github.com/react-component/progress), run the following in your Fable project root:

```bash
yarn install rc-progress
```

### 2. Define the props type

Reference the **documentation of the React component** to find out which props the component supports and declare them as an F# type (see below for the two supported mechanisms). You can define only a subset of supported props in F# if you don't need to cover the full props options that the React component supports.

For example to expose the percent, strokeWidth and strokeColor props of the rc-progress components:

```fsharp
type ProgressProps =
  | Percent of int
  | StrokeWidth of int
  | StrokeColor of string
```

If one of the props is treated as a string enum in Javascript (e.g. if there is a size prop with the supported values "small", "normal" and "big"), then the `[<StringEnum>]` attribute can be very useful for defining helper types (see the [StringEnum docs](http://fable.io/docs/interacting.html#stringenum-attribute) for more info):

```fsharp
[<StringEnum>]
type Size =
  | Small
  | Normal
  | Big

type SomeComponentProps =
  | Size of Size
  | ...
```

### 3. Define the React component creation function

Using the `ofImport` function you instruct Fable which component should be instantiated when the creation function is called.

In the example of rc-progress, to declare a `progressLine` creation function that imports the `Line` component from the library `rc-progress`, you would declare it as follows.

Note the `keyValueList` function that is used to convert the props of type `IProgressProps list` to a Javascript object where they key is the lower case name of the DU case identifier and the value is the field value of the DU (e.g. if the list that is passed into the function is `[Percent 40; StrokeColor "red"]`, the Javascript object that will be passed to the `props` of the `Line` react component would look like this: `{ percent: 40, strokeColor: "red" }`)

```fsharp
let inline progressLine (props : ProgressProps list) (elems : ReactElement list) : ReactElement =
    ofImport "Line" "rc-progress" (keyValueList CaseRules.LowerFirst props) elems
```

### 4. Use the creation function in your view code

The function you declared in step 2 now behaves just like any other React component function.

To use the component in a [Fable-Elmish](https://fable-elmish.github.io/elmish/) view function:

```fsharp
let view (model : Model) (dispatch : Msg -> unit) =
  div
    []
    [ progressLine [ percent model.currentProgress; strokeColor: "red" ] [] ]
```

## Dynamic import using a Pojo

The dynamic import is similar to the approach above, but instead of declaring a DU you create a Pojo record. This looks more like normal F# code but can be unwieldy if you have a lot of optional props (which is often the case in complex React components)

```fsharp
[<Pojo>]
type ProgressProps =
  { percent : int
    strokeWidth : int
    strokeColor : string
  }

let inline progressLine (props : ProgressProps) (elems : ReactElement list) : ReactElement =
    ofImport "Line" "rc-progress" props elems
```

## Edgecases

This documentation needs to be extended to cover [Higher Order Components](https://reactjs.org/docs/higher-order-components.html) and maybe [Context](https://reactjs.org/docs/context.html), [Fragments](https://reactjs.org/docs/fragments.html) etc. Contributions are welcome!
