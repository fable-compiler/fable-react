# fable-import-react-native-popup-menu

Fable bindings for react-native-popup-menu

## Installation

Install [fable-import-react-native](https://www.npmjs.com/package/fable-import-react-native) and follow the instructions for that package.

Follow install instructions for [react-native-popup-menu](https://github.com/instea/react-native-popup-menu) and then:

```sh
$ npm install --save-dev fable-import-react-native-popup-menu
```

## Usage

Follow instructions for [react-native-barcodescanner](https://github.com/instea/react-native-popup-menu).

### In F# project (.fsproj)

```xml
  <ItemGroup>
    <Compile Include="node_modules/able-import-react-native-popup-menu/Fable.Import.ReactNativePopupMenu.fs" />
    <Compile Include="node_modules/able-import-react-native-popup-menu/Fable.Helpers.ReactNativePopupMenu.fs" />
  </ItemGroup>
```

### In F# script (.fsx)

```fsharp
#load "node_modules/able-import-react-native-popup-menu/Fable.Import.ReactNativePopupMenu.fs"
#load "node_modules/able-import-react-native-popup-menu/Fable.Helpers.ReactNativePopupMenu.fs"

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
module RN = Fable.Import.ReactNative
open Fable.Helpers.ReactNativePopupMenu
open Fable.Helpers.ReactNativePopupMenu.Props


```