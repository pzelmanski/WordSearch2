namespace work_kata_test2_Tests

open word_kata_test2_specification
open work_kata_test2

module Tests =

    open FsUnit
    open Xunit
    open Diagonal
    open word_kata_test2_specification.Language
    open WordSearch

    type MyDirections = Language.Directions

    [<Fact>]
    let ``Given a grid and a word, it should return diagonal bottom right starting with words first letter``() =

        let grid = [ "abc"; "def"; "ghi" ]
        let word = "axy"

        let submission =
            { Grid = grid
              Word = word }

        let expected =
            [ { NW = "a"
                NE = "a"
                SW = "a"
                SE = "aei" } ]

        // Act & Assert
        Diagonal.singleLines submission |> should equal expected

    [<Fact>]
    let ``It should properly inject SingleLines into a GetSth``() =
        let grid =
            [ "abc"; "def"; "ghi" ]
        let word = "axy"
        let submission =
            { Grid = grid
              Word = word }

        let expected =
            [ { NW = "a"
                NE = "a"
                SW = "a"
                SE = "aei" } ]
            |> MyDirections.Diagonal

        // Act & Assert
        directions getDirections submission
        |> should equal expected


    [<Fact>]
    let ``get diagonal bottom right from the right edge of a grid``() =
        let grid =
            [ "abcm"; "defn"; "ghio"; "jklp" ]
        let word = "nope"
        let submission =
            { Grid = grid
              Word = word }
        
        
        let expected =
            [ { NW = "nc"
                NE = "n"
                SW = "nik"
                SE = "n" } ]

        // Act & Assert
        singleLines submission
        |> should equal expected

    [<Fact>]
    let ``get diagonal when first letter of word does not exist in gird``() =
        let grid =
            [ "abcm"; "defn"; "ghio"; "jklp" ]
        let word = "xmd"
        
        let submission =
            {Grid = grid
             Word = word}
        
        let expected = List.empty<DiagonalDirections>

        // Act & Assert
        singleLines submission
        |> should equal expected


    [<Fact>]
    let ``get diagonal in all directions``() =
        let grid =
            [ "abcm"; "defn"; "ghio"; "jklp" ]
        let word = "fxy"

        let submission =
            {Grid = grid
             Word = word}
        
        let expected =
            [ { NW = "fb"
                NE = "fm"
                SW = "fhj"
                SE = "fo" } ]

        // Act & Assert
        singleLines submission
        |> should equal expected
