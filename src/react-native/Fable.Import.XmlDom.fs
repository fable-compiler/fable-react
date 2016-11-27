namespace Fable.Import
open System
open Fable.Core
open Fable.Import.JS

module XmlDom =
    type DOMParserStatic =
        [<Emit("new $0()")>] abstract Create: unit -> DOMParser
        [<Emit("new $0($1...)")>] abstract Create: options: Options list -> DOMParser

    and XMLSerializerStatic =
        [<Emit("new $0()")>] abstract Create: unit -> XMLSerializer

    and DOMParser =
        abstract parseFromString: xmlsource: string * ?mimeType: string -> Browser.Document

    and XMLSerializer =
        abstract serializeToString: node: Browser.Node -> string

    and [<KeyValueList>] Options =
        | Locator of obj
        | ErrorHandler of Func<string, obj, obj>

    let [<Import("DOMParser","xmldom")>] DOMParser: DOMParserStatic = jsNative
    let [<Import("XMLSerializer","xmldom")>] XMLSerializer: XMLSerializerStatic = jsNative
