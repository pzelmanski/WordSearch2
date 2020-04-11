namespace work_kata_test2_Tests

module VerticalTests =
    open Xunit
    open work_kata_test2
    open FsUnit
    open word_kata_test2_specification.Language

    [<Fact>]
    let ``Should return``() =
        let grid =
            [ "abc"; "def"; "ghi" ]
        let wordImLookingFor = "axy"

        // Act & Assert
        wordImLookingFor
        |> Vertical.``do`` grid
        |> should equal
               [ { Up = "a"
                   Down = "b" } ]
