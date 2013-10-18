namespace Controls

open IntelliFactory.Html
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Sitelets

type Action =
    | [<CompiledName "">] Home

[<Sealed>]
type EntryPoint() =
    inherit Web.Control()

    [<JS>]
    override __.Body =
        Client.main() :> _

[<Sealed>]
type Website() =
    interface IWebsite<Action> with
        member __.Sitelet =
            Sitelet.Infer (fun Home ->
                Content.PageContent (fun _ ->
                    {
                        Page.Default with
                            Title = Some "WebSharper Controls"
                            Body = [Div [new EntryPoint()]]
                    }
                )
            )
        member __.Actions = []

[<assembly: Website(typeof<Website>)>]
do ()
