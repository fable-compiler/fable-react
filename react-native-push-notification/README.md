# fable-import-react-native-push-notification

Fable bindings for React Native Image Picker

## Installation

Install [fable-import-react-native](https://www.npmjs.com/package/fable-import-react-native) and follow the instructions for that package.

Follow install instructions for [react-native-push-notification](https://github.com/zo0r/react-native-push-notification) and then:

```sh
$ npm install --save-dev fable-import-react-native-push-notification
```

## Usage

Follow instructions for [react-native-push-notification](https://github.com/zo0r/react-native-push-notification).

### In F# project (.fsproj)

```xml
  <ItemGroup>
    <Compile Include="node_modules/able-import-react-native-push-notification/Fable.Import.ReactNativePushNotification.fs" />
    <Compile Include="node_modules/able-import-react-native-push-notification/Fable.Helpers.ReactNativePushNotification.fs" />
  </ItemGroup>
```

### In F# script (.fsx)

```fsharp
#load "node_modules/able-import-react-native-push-notification/Fable.Import.ReactNativePushNotification.fs"
#load "node_modules/able-import-react-native-push-notification/Fable.Helpers.ReactNativePushNotification.fs"

...