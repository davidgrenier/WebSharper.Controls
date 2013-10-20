[<JS>]
module Controls.Client

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Piglets

module V = Piglet.Validation
module C = Controls

open Data

let philoPiglet init =
    Piglet.Return (fun fn ln age died -> { Name = fn; LastName = ln; Age = age; Died = died })
    <*> Piglet.Yield init.Name
    <*> Piglet.Yield init.LastName
    <*> Piglet.Yield init.Age
    <*> Piglet.Yield init.Died

let main () =
    let data = philosophers()

    Piglet.Return id
    <*> Piglet.ManyInit data (philosopher "" "" 0 0 0 0) philoPiglet
    |> Piglet.Render (fun ps ->
        Table [
            ["First Name"; "Last Name"; "Age"; "Died"; "Formatted"]
            |> List.map (fun lbl -> TH [Text lbl])
            |> TR
        ]
        |> C.RenderMany ps (fun ops fn ln age died ->
            TR [
                TD [C.Input fn]
                TD [C.Input ln]
                TD [C.Input (Stream.Map string int age)]
                TD [
                    C.Input
                        (died |> Stream.Map (fun x -> x.ToEcma().ToLocaleString())
                        (fun x -> (EcmaScript.Date x).ToDotNet()))
                ]
                TD [] |> C.ShowString died swedish
            ]
        )
    )