namespace word_kata_tests

open word_kata_specification
open word_kata_specification.Language
open word_kata_interpreter
open Diagonal
open WordSearch
open FsUnit
open Xunit

module DiagonalTests =
    type MyDirections = Language.Directions

    [<Fact>]
    let ``Given a grid and a word, it should return diagonal bottom right starting with words first letter``() =

        let grid = [ "abc"
                     "def"
                     "ghi" ]
        let word = { FirstLetter = 'a' ; Remaining = ['x' ; 'y'] }

        let submission : FirstLetterSubmission =
            { Grid = grid
              Word = word }

        let expected =
            [ { NW = "a"
                NE = "a"
                SW = "a"
                SE = "aei" } ]

        // Act & Assert
        submission
        |> Diagonal.singleLines
        |> should equal expected

    [<Fact>]
    let ``It should properly inject SingleLines into a GetSth``() =
        let grid =
            [ "abc"
              "def"
              "ghi" ]
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
            |> Some

        // Act & Assert
        submission
        |> directions getDirections 
        |> should equal expected


    [<Fact>]
    let ``get diagonal from the right edge of a grid``() =
        let grid =
            [ "abcm"
              "defn"
              "ghio"
              "jklp" ]
        let word = { FirstLetter = 'n' ; Remaining = ['o' ; 'p'; 'e'] }

        let submission : FirstLetterSubmission =
            { Grid = grid
              Word = word }
        
        
        let expected =
            [ { NW = "nc"
                NE = "n"
                SW = "nik"
                SE = "n" } ]

        // Act & Assert
        submission
        |> singleLines 
        |> should equal expected

    [<Fact>]
    let ``get diagonal when first letter of word does not exist in gird``() =
        let grid =
            [ "abcm"
              "defn"
              "ghio"
              "jklp" ]
        
        let word = { FirstLetter = 'x' ; Remaining = ['m' ; 'd'] }

        let submission : FirstLetterSubmission =
            {Grid = grid
             Word = word}
        
        let expected = List.empty<DiagonalDirections>

        // Act & Assert
        submission
        |> singleLines 
        |> should equal expected


    [<Fact>]
    let ``get diagonal in all directions``() =
        let grid =
            [ "abcm"
              "defn"
              "ghio"
              "jklp" ]
        let word = { FirstLetter = 'f' ; Remaining = ['x' ; 'y'] }

        let submission : FirstLetterSubmission =
            {Grid = grid
             Word = word}
        
        let expected =
            [ { NW = "fb"
                NE = "fm"
                SW = "fhj"
                SE = "fo" } ]

        // Act & Assert
        submission
        |> singleLines 
        |> should equal expected
