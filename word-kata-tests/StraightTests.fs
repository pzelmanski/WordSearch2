namespace work_kata_test2_Tests

open word_kata_test2_specification

module StraightTests =
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
                           Down = "adg"
                           Left = "a"
                           Right = "abc"} ]
                       |> MyDirections.Straight
                       |> Some
        // Act & Assert
        submission
        |> Straight.getDirections
        |> should equal expected

    [<Fact>]
    let ``Should return up properly``() =
        let grid =
            [ "abc"
              "def"
              "ghi" ]
        let word = "gxy"

        let submission =
            { Grid = grid
              Word = word }
        let expected = [ { Up = "gda"
                           Down = "g"
                           Left = "g"
                           Right = "ghi"} ]
                       |> MyDirections.Straight
                       |> Some
        // Act & Assert
        submission
        |> Straight.getDirections
        |> should equal expected
        
    [<Fact>]
    let ``Should return all properly``() =
        let grid =
            [ "abc"
              "def"
              "ghi" ]
        let word = "eio"

        let submission =
            { Grid = grid
              Word = word }
        let expected = [ { Up = "eb"
                           Down = "eh"
                           Left = "ed"
                           Right = "ef"} ]
                       |> MyDirections.Straight
                       |> Some
        // Act & Assert
        submission
        |> Straight.getDirections
        |> should equal expected
