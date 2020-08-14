## Using third party React components

Using a third party (Javascript) React component is straightforward for most components. There are three ways of declaring a third party React component in F# - either by declaring a Discriminated Union where each case has one field; by declaring a record type for the props with the Pojo attribute; or by using an untyped list of `(string * obj)` tuples. All three ways are described below.

Some components have a [Typescript](https://www.typescriptlang.org/) definition available, either because the component was authored in Typescript or someone created a type definition for the [Definitely Typed project](https://definitelytyped.org/). If this is the case then you can try the [ts2fable tool](https://github.com/fable-compiler/ts2fable) to convert this React component type definition from Typescript to a Fable type declaration - it might need some tweaking but for components with a big API surface this can be a real time saver.

## Table of contents

<!-- TOC -->

- [Using third party React components](#using-third-party-react-components)
- [Table of contents](#table-of-contents)
- [Using a React component by declaring a Discriminated Union props type](#using-a-react-component-by-declaring-a-discriminated-union-props-type)
  - [1. Install the react component](#1-install-the-react-component)
  - [2. Define the props type](#2-define-the-props-type)
  - [3. Define the React component creation function](#3-define-the-react-component-creation-function)
    - [Member Import](#member-import)
    - [Default Import](#default-import)
    - [Fields of imported items](#fields-of-imported-items)
    - [Directly creating the element](#directly-creating-the-element)
  - [4. Use the creation function in your view code](#4-use-the-creation-function-in-your-view-code)
  - [5. Get component state back into your code](#5-get-component-state-back-into-your-code)
- [Importing using a Pojo (plain old JS object) record](#importing-using-a-pojo-plain-old-js-object-record)
- [Passing in props as tuples (without a type declaration of the props)](#passing-in-props-as-tuples-without-a-type-declaration-of-the-props)
- [Edgecases](#edgecases)

<!-- /TOC -->

## Using a React component by declaring a Discriminated Union props type

The basic steps when working with a Discriminated Union are:

### 1. Install the react component

Using yarn or npm, install the react component you want to use.

For example to use the [rc-progress](https://github.com/react-component/progress) React component which we'll be using in this tutorial, run the following command inside your Fable project root folder:

```bash
yarn add rc-progress
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

There are several different ways to declare exports in Javascript (default imports, member imports, namespace imports); depending on how the Javascript React component was declared, you have to choose the right import. Refer to the [Fable docs](http://fable.io/docs/interacting.html#importing-javascript-code) for more information on imports.

Using the `ofImport` function you instruct Fable which component should be instantiated when the creation function is called.

#### Member Import

In the example of rc-progress, to declare a `progressLine` creation function that imports the `Line` component from the library `rc-progress`, you would declare it as follows.

```fsharp
open Fable.Core
open Fable.Helpers.React
open Fable.Import.React
open Fable.Core.JsInterop

let inline progressLine (props : ProgressProps list) (elems : ReactElement list) : ReactElement =
    ofImport "Line" "rc-progress" (keyValueList CaseRules.LowerFirst props) elems
```

The `keyValueList` function is used to convert the props of type `IProgressProps list` to a JavaScript object where the key is the lower case name of the discriminated union case identifier and the value is the field value of the discriminated union (e.g. if the list that is passed into the function is `[Percent 40; StrokeColor "red"]`, the Javascript object that will be passed to the `props` of the `Line` react component would look like this: `{ percent: 40, strokeColor: "red" }`)

In the docs of the [rc-progress](https://github.com/react-component/progress) React component the import style used is a *member import* (e.g. `import { Line, Circle } from 'rc-progress';`), so we refer to the component member `Line` directly in the ofImport expression.

#### Default Import

If the export is declard as a default export, then you would use ``"default"`` as the member name.
Taking [react-native-qrcode-scanner](https://github.com/moaazsidat/react-native-qrcode-scanner) as an example:

To translate the example

```js
import QRCodeScanner from 'react-native-qrcode-scanner';
```

you would declare your function like

```fsharp
let inline qr_code_scanner (props : QRCodeScannerProps list) : ReactElement =
    ofImport "default" "react-native-qrcode-scanner" (keyValueList CaseRules.LowerFirst props) []
```

#### Fields of imported items

Some React components must be instantiated as follows in JS:

```js
import { Select } from 'react-select'
let render = () => <Select.Creatable options={...} />
```

In this case, you can also use `ofImport` to directly access the field of the imported item:

```fsharp
// Import { Select } from "react-select" and then access the "Creatable" field
ofImport "Select.Creatable" "react-select" myOptions []

// Also compatible with default imports
ofImport "default.Creatable" "react-select" myOptions []
```

#### Directly creating the element

If you already have a reference to the imported component, then you can also use ``createElement``.

The default import above could also be rewritten like this:

```fsharp
let rnqs = importDefault "react-native-qrcode-scanner"
createElement(rnqs, (keyValueList CaseRules.LowerFirst props), [])
```

> Please note it's also OK to duplicate `ofImport` with same member and path. In this case, Fable will automatically group the imports.

```fsharp
let foo1 = ofImport "default" "react-foo" { height = 25 } []
let foo2 = ofImport "default" "react-foo" { height = 50 } []
```

### 4. Use the creation function in your view code

The function you declared in step 2 now behaves just like any other React component function.

To use the component in a [Fable-Elmish](https://fable-elmish.github.io/elmish/) view function:

```fsharp
let view (model : Model) (dispatch : Msg -> unit) =
  div
    []
    [ progressLine [ Percent model.currentProgress; StrokeColor "red" ] [] ]
```

### 5. Get component state back into your code

If you want to get from your component state back in F# code, you need to follow react documentation :
https://reactjs.org/docs/lifting-state-up.html to propagate component state to upper components.

Insert a function in your props to get state back.
```fsharp
// Define function in props
type ComponentProps =
  | GetState of (DateTime -> unit)
  | ...

// sample function matching props signature
let logDateTimeSelected (d : DateTime) =
  Fable.Import.Browser.console.log (sprintf "Date : %A" d)

// Component definition (here a calendar)
let inline Calendar (props : ComponentProps list) : Fable.Import.React.ReactElement =
    ofImport "default" "./CalendarComponent.tsx" (keyValueList CaseRules.LowerFirst props) []

// Component initialization with props
div [] [
  Calendar [ GetState logDateTimeSelected ]
]
```

On Javascript/TypeScript side, you need to use this props within your component
```js
// Define component props
export interface IComponentProps {
  // new props matching F# ComponentProps definition
  getState : ((date : Date) => void)
  ...
}

// within JS/TS event handler use your props function
  private _onSelectDate(date: Date): void {
    this.props.getState(date)
    ...
  }
```

## Importing using a record

This is similar to the approach above, but instead of declaring a DU you create a record. Using a record to express the props looks more like idiomatic F# code but it can be unwieldy if you have a lot of optional props. Since this is common with React components, using the DU approach above can often be more convenient.

```fsharp
type ProgressProps =
  { percent : int
    strokeWidth : int
    strokeColor : string
  }

let inline progressLine (props : ProgressProps) (elems : ReactElement list) : ReactElement =
    ofImport "Line" "rc-progress" props elems
```

## Untyped props

The third way of using a React component is to not give an F# type to the Props at all and simply pass a list of `(string * obj)` tuples to the `createObj` helper function which turns the list into a Javascript object and passes it as the props of the React component. This of course has the least level of type safety but it can be convenient for prototyping. The `==>` operator is defined in the [Fable.Core.JsInterop](https://fable.io/docs/communicate/js-from-fable.html#Plain-Old-JavaScript-Objects) module to make `(string * obj)` tuple creation easier to read.

```fsharp
open Fable.Core.JsInterop

ofImport "Line" "rc-progress" (createObj ["strokeWidth" ==> 5]) []

// You can also use anonymous records
ofImport "Line" "rc-progress" {| strokeWidth = 5 |} []
```

## Edge cases

This documentation needs to be extended to cover [Higher Order Components](https://reactjs.org/docs/higher-order-components.html) and maybe [Context](https://reactjs.org/docs/context.html), [Fragments](https://reactjs.org/docs/fragments.html) etc. Contributions are welcome!
