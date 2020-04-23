module work_kata_test2_Tests.WordSearchTests

open Xunit
open FsUnit
open word_kata_test2_specification
open word_kata_test2_specification.Language
open work_kata_test2

type MyDirections = Language.Directions



[<Fact>]
let ``Should return diagonal properly`` () =
    let grid =
        [ "abcde"
          "fshij"
          "klmno"
          "pqrst"
          "vwxyz" ]
    let word = "flry"

    let submission =
        { Grid = grid
          Word = word }

    let expected = true
    submission
    |> WordSearch.find 
    |> should equal expected


[<Fact>]
let ``Should return straight properly`` () =
    let grid =
        [ "abcde"
          "fshij"
          "klmno"
          "pqrst"
          "vwxyz" ]
    let word = "shij"

    let submission =
        { Grid = grid
          Word = word }

    let expected = true
    submission
    |> WordSearch.find 
    |> should equal expected
    


[<Fact>]
let ``Should return false when not found`` () =
    let grid =
        [ "abcde"
          "fshij"
          "klmno"
          "pqrst"
          "vwxyz" ]
    let word = "xxx"

    let submission =
        { Grid = grid
          Word = word }

    let expected = false
    submission
    |> WordSearch.find
    |> should equal expected
    

[<Fact>]
let ``Should return false when given empty string`` () =
    let grid =
        [ "abcde"
          "fshij"
          "klmno"
          "pqrst"
          "vwxyz" ]
    let word = ""

    let submission =
        { Grid = grid
          Word = word }

    let expected = false
    submission
    |> WordSearch.find
    |> should equal expected
