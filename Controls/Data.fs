module Controls.Data

type Philosopher =
    {
        FirstName: string
        LastName: string
        Age: int
        Died: System.DateTime
    }

let philosopher name last age year month day =
    {
        FirstName = name
        LastName = last
        Age = age
        Died = System.DateTime(year, month, day)
    }

[<RPC>]
let philosophers() =
    [|
        philosopher "Isaac" "Newton" 46 1727 3 20
        philosopher "Ludwig" "Wittgenstein" 62 1947 4 29
        philosopher "Érasme" "de Rotterdam" 69 1536 6 12
        philosopher "Heraclitus" "of Ephesus" 60 1 1 1
        philosopher "Friedrich" "Nietzsche" 55 1900 08 25
    |]

[<RPC>]
let swedish (date: System.DateTime) = date.ToString "yyyy-MM-dd"

type TeaKind = Black | Green | Oolong
type Tea =
    {
        Name: string
        Kind: TeaKind
        Night: bool
        Price: decimal
    }

let tea name kind night price = { Name = name; Kind = kind; Night = night; Price = price }

[<RPC>]
let teas() =
    [|
        tea "English Breakfast" Black false 4M
        tea "Long Life" Oolong true 9.5M
        tea "Gyokuro" Green false 19.5M
        tea "Quangzhou milk" Oolong false 12M
    |]