[<JS>]
module Controls.Client

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Piglets

module V = Piglet.Validation
module C = Controls

open Data.Philosopher
open Data.Tea
open Data

let philoPiglet init =
    Piglet.Return (fun fn ln age died -> { FirstName = fn; LastName = ln; Age = age; Died = died })
    <*> Piglet.Yield init.FirstName
    <*> Piglet.Yield init.LastName
    <*> Piglet.Yield init.Age
    <*> Piglet.Yield init.Died

let renderPhilosopher fn ln age died =
    TR [
        TD [C.Input fn]
        TD [C.Input ln]
        TD [C.Input (Stream.Map string int age)]
        TD [C.Input (died |> Stream.Map Date.swedishLong (fun x -> (EcmaScript.Date x).ToDotNet()))]
        TD [] |> C.ShowString died Date.swedish
    ]

let renderPhilosophers philosophers =
    let zero = { FirstName = ""; LastName = ""; Age = 0; Died = EcmaScript.Date().ToDotNet() }

    Piglet.ManyInit philosophers zero philoPiglet
    |> Piglet.Render (fun ps ->
        Table [
            THead [
                ["First Name"; "Last Name"; "Age"; "Died"; "Formatted"]
                |> List.map (fun lbl -> TH [Text lbl])
                |> TR
            ]
            TBody [] |> C.RenderMany ps (fun _ -> renderPhilosopher)
        ]
    )

let teaPiglet init =
    Piglet.Return (fun name kind night price -> { Name = name; Kind = kind; Night = night; Price = price })
    <*> Piglet.Yield init.Name
    <*> Piglet.Yield init.Kind
    <*> Piglet.Yield init.Night
    <*> Piglet.Yield init.Price

let renderTea name kind nighttime price =
    TR [
        TD [] |> C.ShowString name id
        TD [
            C.Select kind [
                Black, "Black"
                Green, "Green"
                Oolong, "Oolong"
            ]
        ]
        TD [C.CheckBox nighttime]
        TD [C.Input (price |> Stream.Map string (fun x -> (EcmaScript.Number x).ToDotNet()))]
        TD [] |> C.ShowString price string
    ]

let renderTeas teas =
    let zero = { Name = ""; Kind = Black; Night = false; Price = (EcmaScript.Number 0).ToDotNet() }

    Piglet.ManyInit teas zero teaPiglet
    |> Piglet.Render (fun teas ->
        Table [
            THead [
                [""; "Kind"; "Nighttime"; "Price"; "Formatted"]
                |> List.map (fun lbl -> TH [Text lbl])
                |> TR
            ]
            TBody [] |> C.RenderMany teas (fun _ -> renderTea)
        ]
    )

let main () =
    Div [
        Philosopher.all() |> renderPhilosophers
        Br []
        Tea.all() |> renderTeas
    ]