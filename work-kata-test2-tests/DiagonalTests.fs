namespace work_kata_test2_Tests

open work_kata_test2

module Tests =

    open FsUnit
    open Xunit
    open Diagonal
    open word_kata_test2_specification.Language
    open WordSearch


    [<Fact>]
    let ``Given a grid and a word, it should return diagonal bottom right starting with words first letter`` () =  
        let grid =
            [ "abc"
              "def"
              "ghi" ]
        let wordImLookingFor = "axy"
        let expected =
            [{
                NW = "a";
                NE = "a";
                SW = "a";
                SE = "aei"
            }]
        
        // Act & Assert
        wordImLookingFor
        |> Diagonal.singleLines grid 
        |> should equal expected


    [<Fact>]
    let ``It should properly inject SingleLines into a GetSth`` () =  
        let grid =
            [ "abc"
              "def"
              "ghi" ]
        let wordImLookingFor = "axy"
        let expected =
            [{
                NW = "a";
                NE = "a";
                SW = "a";
                SE = "aei"
            }] |> AllDirections.Diagonal
        
        // Act & Assert
        wordImLookingFor
        |> directions doSth grid 
        |> should equal expected


    [<Fact>]
    let ``get diagonal bottom right from the right edge of a grid`` () =  
        let grid =
            [ "abcm"
              "defn"
              "ghio"
              "jklp" ]
        let wordImLookingFor = "nope"
        let expected =
            [{
                NW = "nc";
                NE = "n";
                SW = "nik";
                SE = "n"
            }]
        
        // Act & Assert
        wordImLookingFor
        |> singleLines grid
        |> should equal expected

    [<Fact>]
    let ``get diagonal when first letter of word does not exist in gird`` () =  
        let grid =
            [ "abcm"
              "defn"
              "ghio"
              "jklp" ]
        let wordImLookingFor = "xmd"
        let expected = List.empty<DiagonalDirections>
        
        // Act & Assert
        wordImLookingFor
        |> singleLines grid
        |> should equal expected
        
        
    [<Fact>]
    let ``get diagonal in all directions`` () =  
        let grid =
            [ "abcm"
              "defn"
              "ghio"
              "jklp" ]
        let wordImLookingFor = "fxy"
        let expected =
            [{
                NW = "fb";
                NE = "fm";
                SW = "fhj";
                SE = "fo"
            }]

        // Act & Assert
        wordImLookingFor
        |> singleLines grid
        |> should equal expected
        