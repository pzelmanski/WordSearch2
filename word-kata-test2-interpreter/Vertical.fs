namespace work_kata_test2

open System.Linq
open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations
open Converters
open LineGetter

module Vertical =
    let up currentPos = {X = currentPos.X - 1; Y = currentPos.Y} 
    let down currentPos = {X = currentPos.X + 1; Y = currentPos.Y}
    
    let private getDiagonalAllDirections (grid : Grid) (initialPosition: Coordinate) : VerticalDirections =
        let maxPosition = Enumerable.Count grid 
        { Up = getSingle(grid, {X = maxPosition; Y = maxPosition}, initialPosition, up)
          Down = getSingle(grid, {X = maxPosition; Y = maxPosition}, initialPosition, down) }
        
    let private mapTo (diagonal : VerticalDirections list) : Directions =
        let d = diagonal
                |> List.map(fun v -> [v])
                |> List.concat
        Directions.Vertical d
     
    let getDirections : GetDirections =
        fun submission ->
            submission |> submissionToFirstLetterSubmission
                       |> function
                           | Some singleLineSubmission ->
                                  singleLineSubmission
                                  |> Coordinates.OfFirstLetter
                                  |> List.map (getDiagonalAllDirections singleLineSubmission.Grid)
                                  |> mapTo
                                  |> Some
                           | None -> None
                
 
