[<AutoOpen>]
module Controls.Pervasives

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

type JS = JavaScriptAttribute
type RPC = RemoteAttribute

[<AutoOpen; JS>]
module Operators =
    let (++) (e: Element) text = e -- Text text
    let (|+) (e: Element) clazz = e.AddClass clazz; e