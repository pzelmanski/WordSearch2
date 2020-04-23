namespace word_kata_tests

open word_kata_specification
open Xunit
open word_kata_interpreter
open FsUnit
open word_kata_specification.Language

module StraightTests =
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
