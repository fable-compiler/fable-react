# fable-import-react

Fable bindings for React

## Installation

```sh
$ npm install --save react react-dom fable-core fable-powerpack fable-react
```

## Usage

### F# project (.fsproj)

```xml
  <ItemGroup>
    <Reference Include="node_modules/fable-core/Fable.Core.dll" />
    <Reference Include="node_modules/fable-powerpack/Fable.PowerPack.dll" />
    <Reference Include="node_modules/fable-react/Fable.React.dll" />
  </ItemGroup>
```

### F# script (.fsx)

```fsharp
#r "node_modules/fable-core/Fable.Core.dll"
#r "node_modules/fable-powerpack/Fable.PowerPack.dll"
#r "node_modules/fable-react/Fable.React.dll"

open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props
```
