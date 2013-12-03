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

[<JS>]
module Date =
    let (|LessThan|_|) v = function
        | x when x < v -> Some ()
        | _ -> None
    
    let pad = function
        | LessThan 10 & x -> "0" + string x
        | x -> string x

    let swedish (date: System.DateTime) =
        let day = pad date.Day
        let month = pad date.Month
        let year =
            match date.Year with
            | LessThan 10 & x -> "000" + string x
            | LessThan 100 & x -> "00" + string x
            | LessThan 1000 & x -> "0" + string x
            | x -> string x

        year + "-" + month + "-" + day

    let swedishLong (date: System.DateTime) =
        swedish date + " " + pad date.Hour + ":" + pad date.Minute + ":" + pad date.Second