# Fable.React

[![Open in Gitpod](https://gitpod.io/button/open-in-gitpod.svg)](https://gitpod.io/#https://github.com/fable-compiler/fable-react)

> **ATTENTION**: This package is less well maintained, for new Fable projects using React we recommend [Feliz](https://zaid-ajaj.github.io/Feliz/).

`Fable.React.Types` package contains bindings for [React](https://reactjs.org/).

`Fable.React` package contains helpers for writing for React projects using Fable.

When updating a package, edit the RELEASE_NOTES.md of the corresponding project and run `dotnet fsi build.fsx publish` to publish a new version.

## Documents

* [Server-Side Rendering tutorial](docs/server-side-rendering.md): A **Pure F#** solution for SSR, **No NodeJS Required!**
* [Using third party React components](docs/using-third-party-react-components.md): How to create binding so that third party Javascript React components can be used like stock React components in Fable code.
* [React error boundaries](docs/react-error-boundaries.md): Example on how to use react error boundaries in fable.
* [Function components, hooks and code splitting in Fable.React 5](https://fable.io/blog/Announcing-Fable-React-5.html)

## Other packages

This repository previously contained other packages like Fable.React.TransitionGroup, but they've been moved to their own repos. [Find here where](https://github.com/fable-compiler/fable-react/issues/145#issuecomment-478961364).
