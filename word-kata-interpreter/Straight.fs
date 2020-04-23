namespace word_kata_interpreter

open System.Linq
open word_kata_specification.Language
open word_kata_specification.Operations
open Converters
open LineGetter

module Straight =
    let up currentPos = {HorizontalIndex = currentPos.HorizontalIndex; VerticalIndex = currentPos.VerticalIndex - 1} 
    let down currentPos = {HorizontalIndex = currentPos.HorizontalIndex; VerticalIndex = currentPos.VerticalIndex + 1}
    let left currentPos = {HorizontalIndex = currentPos.HorizontalIndex - 1; VerticalIndex = currentPos.VerticalIndex}
    let right currentPos = {HorizontalIndex = currentPos.HorizontalIndex + 1; VerticalIndex = currentPos.VerticalIndex}
    
    let private getDiagonalAllDirections (grid : Grid) (initialPosition: Coordinate) : StraightDirections =
        let maxPosition = Enumerable.Count grid 
        { Up = getSingle(grid, {HorizontalIndex = maxPosition; VerticalIndex = maxPosition}, initialPosition, up)
          Down = getSingle(grid, {HorizontalIndex = maxPosition; VerticalIndex = maxPosition}, initialPosition, down)
          Left = getSingle(grid, {HorizontalIndex = maxPosition; VerticalIndex = maxPosition}, initialPosition, left)
          Right = getSingle(grid, {HorizontalIndex = maxPosition; VerticalIndex = maxPosition}, initialPosition, right)}
        
    let private mapTo (diagonal : StraightDirections list) : Directions =
        let d = diagonal
                |> List.map(fun v -> [v])
                |> List.concat
        Directions.Straight d
     
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
