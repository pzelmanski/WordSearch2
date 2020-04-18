namespace work_kata_test2_Tests

open word_kata_test2_specification

module VerticalTests =
    open Xunit
    open work_kata_test2
    open FsUnit
    open word_kata_test2_specification.Language

    type MyDirections = Language.Directions
    
    [<Fact>]
    let ``Should return down properly``() =
        let grid =
            [ "abc"
              "def"
              "ghi" ]
        let word = "axy"

        let submission =
            { Grid = grid
              Word = word }
        let expected = [ { Up = "a"
                           Down = "adg" } ]
                       |> MyDirections.Vertical
                       |> Some
        // Act & Assert
        submission
        |> Vertical.getDirections
        |> should equal expected
