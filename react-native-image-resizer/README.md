# fable-import-react-native-image-resizer

Fable bindings for React Native Image Resizer

## Installation

Install [fable-import-react-native](https://www.npmjs.com/package/fable-import-react-native) and follow the instructions for that package.

Follow install instructions for [react-native-image-resizer](https://github.com/bamlab/react-native-image-resizer) and then:

```sh
$ npm install --save-dev fable-import-react-native-image-resizer
```

## Usage

Follow instructions for [react-native-image-resizer](https://github.com/bamlab/react-native-image-resizer).

### In F# project (.fsproj)

```xml
  <ItemGroup>
    <Compile Include="node_modules/fable-import-react-native-image-resizer/Fable.Import.ReactNativeImageResizer.fs" />
    <Compile Include="node_modules/fable-import-react-native-image-resizer/Fable.Helpers.ReactNativeImageResizer.fs" />
  </ItemGroup>
```

### In F# script (.fsx)

```fsharp
#load "node_modules/fable-import-react-native-image-resizer/Fable.Import.ReactNativeImageResizer.fs"
#load "node_modules/fable-import-react-native-image-resizer/Fable.Helpers.ReactNativeImageResizer.fs"


...
