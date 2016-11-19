# fable-import-react-native-onesignal

Fable bindings for React Native OneSignal

## Installation

Install [fable-import-react-native](https://www.npmjs.com/package/fable-import-react-native) and follow the instructions for that package.

Follow install instructions for [react-native-onesignal](https://github.com/geektimecoil/react-native-onesignal) and then:

```sh
$ npm install --save-dev fable-import-react-native-onesignal
```

## Usage

Follow instructions for [react-native-onesignal](https://github.com/geektimecoil/react-native-onesignal).

### In F# project (.fsproj)

```xml
  <ItemGroup>
    <Compile Include="node_modules/fable-import-react-native-onesignal/Fable.Import.ReactNativePushOneSignal.fs" />
    <Compile Include="node_modules/fable-import-react-native-onesignal/Fable.Helpers.ReactNativeOneSignal.fs" />
  </ItemGroup>
```

### In F# script (.fsx)

```fsharp
#load "node_modules/fable-import-react-native-onesignal/Fable.Import.ReactNativeOneSignal.fs"
#load "node_modules/fable-import-react-native-onesignal/Fable.Helpers.ReactNativeOneSignal.fs"

...