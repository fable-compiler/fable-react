namespace Fable.React

/// Helpers for ReactiveComponents (see #44)
module ReactiveComponents =

    type Props<'P, 'S, 'Msg> =
      { key: string
        props: 'P
        update: 'Msg -> 'S -> 'S
        view: Model<'P, 'S> -> ('Msg->unit) -> ReactElement
        init: 'P -> 'S }

    and State<'T> =
      { value: 'T }

    and Model<'P, 'S> =
      { props: 'P
        state: 'S
        children: ReactElement[] }

    type ReactiveCom<'P, 'S, 'Msg>(initProps) =
        inherit Component<Props<'P, 'S, 'Msg>, State<'S>>(initProps)
        do base.setInitState { value = initProps.init(initProps.props) }

        override this.render() =
            let model =
                { props = this.props.props
                  state = this.state.value
                  children = this.children }
            this.props.view model (fun msg ->
                let newState = this.props.update msg this.state.value
                this.setState(fun _ _ -> { value = newState }))

[<AutoOpen>]
module ReactiveComponentsHelpers =
    open ReactiveComponents

    /// Renders a stateful React component from functions similar to Elmish
    ///  * `init` - Initializes component state with given props
    ///  * `update` - Updates the state when `dispatch` is triggered
    ///  * `view` - Render function, receives a `ReactiveComponents.Model` object and a `dispatch` function
    ///  * `key` - The key is necessary to identify React elements in a list, an empty string can be passed otherwise
    ///  * `props` - External properties passed to the component each time it's rendered, usually from its parent
    ///  * `children` - A list of children React elements
    let reactiveCom<'P, 'S, 'Msg>
            (init: 'P -> 'S)
            (update: 'Msg -> 'S -> 'S)
            (view: Model<'P, 'S> -> ('Msg->unit) -> ReactElement)
            (key: string)
            (props: 'P)
            (children: ReactElement seq): ReactElement =
        ofType<ReactiveCom<'P, 'S, 'Msg>, Props<'P, 'S, 'Msg>, State<'S>>
            { key=key; props=props; update=update; view=view; init=init }
            children
