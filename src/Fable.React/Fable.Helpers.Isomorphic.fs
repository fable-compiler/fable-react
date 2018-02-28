module Fable.Helpers.Isomorphic

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.React

module Components =
    type [<Pojo>] HybridState = {
        isClient: bool
    }
    type [<Pojo>] HybridProps<'P> = {
        clientView: 'P -> ReactElement
        serverView: 'P -> ReactElement
        model: 'P
    }
    type HybridComponent<'P>(initProps) as this =
        inherit Component<HybridProps<'P>, HybridState>(initProps) with
        do this.setInitState { isClient=false }

        override x.componentDidMount() =
            this.setState { isClient=true }

        override x.render() =
            if x.state.isClient
            then x.props.clientView x.props.model
            else x.props.serverView x.props.model


open Components
open Fable.Helpers.React


let hybridView (clientView: 'model -> ReactElement) (serverView: 'model -> ReactElement) (model: 'model) =
#if FABLE_COMPILER
    ofType<HybridComponent<_>, _, _> { clientView=clientView; serverView=serverView; model=model } []
#else
    serverView model
#endif

