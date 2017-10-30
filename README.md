# Fable.React

Fable bindings and helpers for React projects

# Why is Fable.ReactLeaflet library included in this repo?

One of the reasons not to add `ReactLeaflet` in `fable-import` was that repo only contains pure bindings which only have metadata and thus can be distributed just in `.dll` form. But `ReactLeaflet` contains actual code so it needs to include also sources in the distribution.

Adding `Fable.ReactLeaflet` to this repo makes it easier to maintain for us as a maintainer instead of having one repo per react package for example.
