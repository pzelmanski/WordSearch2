module Tests

open work_kata_test2
open FsUnit
open Xunit
open WordSearch


[<Fact>]
let ``Given a grid and a word, it should return diagonal bottom right starting with words first letter`` () =  
    let grid =
        [ "abc"
          "def"
          "ghi" ]
    let wordImLookingFor = "axy"
    let expected = ["aei"]
    
    // Act & Assert
    wordImLookingFor
    |> In grid 
    |> should equal expected

[<Fact>]
let ``get diagonal bottom right from the middle of a grid`` () =  
    let grid =
        [ "abcm"
          "defn"
          "ghio"
          "jklp" ]
    let wordImLookingFor = "exy"
    let expected = ["eip"]
    
    // Act & Assert
    wordImLookingFor
    |> In grid 
    |> should equal expected

[<Fact>]
let ``get diagonal bottom right from the right edge of a grid`` () =  
    let grid =
        [ "abcm"
          "defn"
          "ghio"
          "jklp" ]
    let wordImLookingFor = "nope"
    let expected = ["n"]
    
    // Act & Assert
    wordImLookingFor
    |> In grid
    |> should equal expected

[<Fact>]
let ``get diagonal bottom right when first letter of word does not exist in gird`` () =  
    let grid =
        [ "abcm"
          "defn"
          "ghio"
          "jklp" ]
    let wordImLookingFor = "xmd"
    
    // Act & Assert
    wordImLookingFor
    |> In grid
    |> should equal List.empty<string>
    
    
[<Fact>]
let ``get diagonal in all directions when first letter of word does not exist in gird`` () =  
    let grid =
        [ "abcm"
          "defn"
          "ghio"
          "jklp" ]
    let wordImLookingFor = "fxy"
    let expected = ["fb"; "fm"; "fhj"; "fo"]

    // Act & Assert
    wordImLookingFor
    |> In grid
    |> should equal expected
    