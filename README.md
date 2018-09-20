# Fable.React

Fable bindings and helpers for React projects

## Documents

* [Server-Side Rendering tutorial](docs/server-side-rendering.md): A **Pure F#** solution for SSR, **No NodeJS Required!**
* [Using third party React components](docs/using-third-party-react-components.md): How to create binding so that third party Javascript React components can be used like stock React components in Fable code.
* [React error boundaries](docs/react-error-boundaries.md): Example on how to use react error boundaries in fable.


## Why does this repository include bindings for React JS libraries?

Fable bindings for JS libraries maintained by the Fable team are in [fable-import](https://github.com/fable-compiler/fable-import). However, that repository only contains _pure bindings_ (which only have metadata and thus can be distributed just in `.dll` form), while libraries like `Fable.ReactLeaflet` contain actual code that must be compiled to JS, so they need to include also the sources in the distribution.

Keeping the bindings for React JS libraries in this repository makes it easier to maintain them, even if each of the libraries has its own Nuget package.
