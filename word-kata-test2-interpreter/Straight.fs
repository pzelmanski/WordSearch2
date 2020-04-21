namespace work_kata_test2

open System.Linq
open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations
open Converters
open LineGetter

module Straight =
    let up currentPos = {X = currentPos.X - 1; Y = currentPos.Y} 
    let down currentPos = {X = currentPos.X + 1; Y = currentPos.Y}
    let left currentPos = {X = currentPos.X; Y = currentPos.Y - 1}
    let right currentPos = {X = currentPos.X; Y = currentPos.Y + 1}
    
    let private getDiagonalAllDirections (grid : Grid) (initialPosition: Coordinate) : StraightDirections =
        let maxPosition = Enumerable.Count grid 
        { Up = getSingle(grid, {X = maxPosition; Y = maxPosition}, initialPosition, up)
          Down = getSingle(grid, {X = maxPosition; Y = maxPosition}, initialPosition, down)
          Left = getSingle(grid, {X = maxPosition; Y = maxPosition}, initialPosition, left)
          Right = getSingle(grid, {X = maxPosition; Y = maxPosition}, initialPosition, right)}
        
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
