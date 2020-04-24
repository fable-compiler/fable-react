### 6.2.0

- Fix notation for SVG attributes SSR (by @mvsmal)

### 6.1.0

- FunctionComponent: Suspend memoize during HMR

### 6.0.0

- Rework FunctionComponent to make it easier to use, it is also supporting HMR out of the box

### 5.3.6

- Add `JustifySelf` used in Grid containers @Luiz-Monad
- Add `StrokeDashoffset` to `SVGAttr`

### 5.3.5

- Complete aria props @Krzysztof-Cieslak

### 5.3.4

- Removed Hyphen from CssProp #183 @SCullman

### 5.3.3

- Fix missing hyphens for some typed css props #181 @SCullman

### 5.3.2

- Fix Hooks.useEffectDisposable closure @dbrattli

### 5.3.1

- SSR: Fix race condition in CSS props cache @forki
- Add CSSProp.UserSelect

### 5.3.0

- Use typed options for remaining CSS props with untyped value @jannesiera
- SSR: Void tags should contain a space @forki
- SSR: Fix StringEnum CSS props
- SSR: Cache CSS props

### 5.2.7

- Add `forwardRef` @Luiz-Monad
- Add `useReducer` @nojaf

### 5.2.6

- Fix #167: Add `withKey` argument to `FunctionComponent.Of`

### 5.2.5

- Fix #166: Expose `mountById`/`mountBySelector` in .NET

### 5.2.4

- Add `contextConsumer`

### 5.2.3

- Fix `Hooks.useStateLazy`

### 5.2.2

- Undeprecate `ofFunction`

### 5.2.1

- Add React Context

### 5.1.0

- Add non-generic `ReactElementType`
- Add memoEqualsButFunctions @vbfox

### 5.0.0

- Function components
- React hooks
- Type-safe CSS props
- Code splitting

### 5.0.0-beta-009

- Add `FunctionComponent`

### 5.0.0-beta-007

- Add `LazyComponent.FromExternalFunction`

### 5.0.0-beta-006

- Add some additional hooks

### 5.0.0-beta-004

- Fix `Hooks.useEffectDisposable` and `equalsButFunctions`

### 5.0.0-beta-003

- Add `equalsButFunctions` @vbfox

### 5.0.0-beta-002

- Fix `object` tag
- Fix effect hook

### 5.0.0-beta-001

- Add type-safe css properties @Zaid-Ajaj

### 5.0.0-alpha-005

- Change dependency to Fable.Browser.Dom
- Rename namespace to Fable.React
- Add Hooks' support

### 5.0.0-alpha-004

- Fix `b`

### 5.0.0-alpha-003

- Fix compilation with fable-splitter and `allFiles` #122 @nojaf
- Add `ValueMultiple` prop for `select` elements with `Multiple` prop #123

### 5.0.0-alpha-002

- Fix typos in doc comment of `memoBuilderWith` and `memoBuilder`

### 5.0.0-alpha-001

- Add bindings for `React.memo`
- Add `nothing` helper

### 4.1.1

- Mark `setState: 'S` as obsolete @SirUppyPancakes
- Enable writing into a TextWritter in SSR @thinkbeforecoding

### 4.0.1

- Update Fable 2 deps to stable version

### 4.0.0

- Release stable version
- Make `Data` type consistent across compiler directive

### 4.0.0-alpha-001

Alpha version for Fable 2

### 3.1.2

- Include documentation in the package
- Add `FromEvent.Value` helper

### 3.1.1

- Remove ReactiveComponents.Model.key as React doesn't allow access to props.key

### 3.1.0

- Speed-up Server-Side rendering @forki
- Make escapeHtml faster @zaaack

### 3.0.0

- Stable version

### 3.0.0-alpha-003

- Give precedence to CSSProps

### 3.0.0-alpha-002

- Add Server Side Rendering Support

### 3.0.0-alpha-001

- Alpha release of next major version

### 2.1.0

- Add React PureComponent and Fragment (@vbfox)

### 2.0.0

- Stable version

### 2.0.0-beta-002

- Add BoxShadow CSSProp (@worldbeater)
- Add Class as alias of ClassName

### 2.0.0-beta-001

- Add `reactiveCom` helper (stateful mini-Elmish component)
- Add `mountById` and `mountBySelectors`
- Add abstract methods to `React.Component` so users have autocompletion and docs when overriding
- Uniform helpers API: ofType, ofFunction, ofImport, ofOption, ofArray...

### 1.2.2

- Add Height to SVGProp

### 1.2.1

- Use new `ParamList` attribute

### 1.2.0

- Release stable version

### 1.2.0-beta-003

- Add CSSProp.OverflowY

### 1.2.0-beta-002

- Target netstandard1.6 again

### 1.2.0-beta-001

- Upgrade to netstandard2.0
- Add react-dom/server methods
- Add Animation and Transition events
- Remove Erased union types from Prop helpers (breaking)
- Give precedence to CSSProps
- Fix SVG elements with mixed props
- Comment Data and uncomment Height HTMLProps
- Add CSSProp.Cursor

### 1.1.0

- Release stable version
