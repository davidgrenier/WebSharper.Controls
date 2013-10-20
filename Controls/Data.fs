module Controls.Data

module Philosopher =
    type T =
        {
            FirstName: string
            LastName: string
            Age: int
            Died: System.DateTime
        }

    let create name last age year month day =
        {
            FirstName = name
            LastName = last
            Age = age
            Died = System.DateTime(year, month, day)
        }

    [<RPC>]
    let all() =
        [|
            create "Isaac" "Newton" 46 1727 3 20
            create "Ludwig" "Wittgenstein" 62 1947 4 29
            create "Érasme" "de Rotterdam" 69 1536 6 12
            create "Heraclitus" "of Ephesus" 60 1 1 1
            create "Friedrich" "Nietzsche" 55 1900 08 25
        |]
        
module Tea =
    type Kind = Black | Green | Oolong
    type T =
        {
            Name: string
            Kind: Kind
            Night: bool
            Price: decimal
        }

    let create name kind night price = { Name = name; Kind = kind; Night = night; Price = price }

    [<RPC>]
    let all() =
        [|
            create "English Breakfast" Black false 4M
            create "Long Life" Oolong true 9.5M
            create "Gyokuro" Green false 19.5M
            create "Quangzhou milk" Oolong false 12M
        |]