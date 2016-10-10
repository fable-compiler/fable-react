# fable-import-react-native-barcodescanner

Fable bindings for React Native Barcode Scanner

## Installation

Install [fable-import-react-native](https://www.npmjs.com/package/fable-import-react-native) and follow the instructions for that package.

Follow install instructions for [react-native-barcodescanner](https://github.com/ideacreation/react-native-barcodescanner) and then:

```sh
$ npm install --save-dev fable-import-react-native-barcodescanner
```

## Usage

Follow instructions for [react-native-barcodescanner](https://github.com/ideacreation/react-native-barcodescanner).

### In F# project (.fsproj)

```xml
  <ItemGroup>
    <Compile Include="node_modules/able-import-react-native-barcodescanner/Fable.Import.ReactNativeBarcodeScanner.fs" />
    <Compile Include="node_modules/able-import-react-native-barcodescanner/Fable.Helpers.ReactNativeBarcodeScanner.fs" />
  </ItemGroup>
```

### In F# script (.fsx)

```fsharp
#load "node_modules/able-import-react-native-barcodescanner/Fable.Import.ReactNativeBarcodeScanner.fs"
#load "node_modules/able-import-react-native-barcodescanner/Fable.Helpers.ReactNativeBarcodeScanner.fs"

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
module RN = Fable.Import.ReactNative
open Fable.Helpers.ReactNativeBarcodeScanner
open Fable.Helpers.ReactNativeBarcodeScanner.Props

...

barcodeScanner [BarcodeScannerProperties.OnBarCodeRead (fun result -> ... )] 


```