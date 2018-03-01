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

/// Isomorphic helper function for conditional executaion
/// it will execute `clientFn model` in the client side and `serverFn model` in the server side
let inline hybridExec clientFn serverFn model =
    ServerRenderingInternal.hybridExec clientFn serverFn model

let hybridView (clientView: 'model -> ReactElement) (serverView: 'model -> ReactElement) (model: 'model) =
#if FABLE_COMPILER
    ofType<HybridComponent<_>, _, _> { clientView=clientView; serverView=serverView; model=model } []
#else
    serverView model
#endif



// /// Isomorphic helper function for Fable.Core.JsInterop.import,
// /// it works exactly the same as import in client side, but would return Unchecked.defaultof<'T> in server side instead of throw an runtime error immediately
// [<Emit("""import "$1" from "$2" """)>]
// let inline importOrDefault<'T> selector path =
//     Unchecked.defaultof<'T>

// /// Isomorphic helper function for Fable.Core.JsInterop.importAll,
// /// it works exactly the same as importAll in client side, but would return Unchecked.defaultof<'T> in server side instead of throw an runtime error immediately
// let inline importAllOrDefault<'T> path =
//     importOrDefault<'T> "*" path



// /// Isomorphic helper function for Fable.Core.JsInterop.importDefault,
// /// it works exactly the same as importDefault in client side, but would return Unchecked.defaultof<'T> in server side instead of throw an runtime error immediately
// let inline importDefaultOrDefault<'T> path =
//     importOrDefault<'T> "default" path

// /// Isomorphic helper function for Fable.Core.JsInterop.importSideEffects,
// /// it works exactly the same as importSideEffects in client side, but would ignore in server side instead of throw an runtime error immediately
// let inline importSideEffectsOrDefault path =
//     hybridExec importSideEffects ignore path
