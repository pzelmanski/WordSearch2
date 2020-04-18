namespace work_kata_test2

open System.Linq
open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations
open Converters

module Vertical =
    let up currentPos = {X = currentPos.X - 1; Y = currentPos.Y} 
    let down currentPos = {X = currentPos.X + 1; Y = currentPos.Y}

    let rec getSingleVertical(grid: Grid, stop: Coordinate, current: Coordinate, positionFunction): string =
        if (current.X >= stop.X
            || current.Y >= stop.Y
            || current.X < 0
            || current.Y < 0) then ""
        else
            (string) grid.[current.X].[current.Y]
            + getSingleVertical(grid, stop, (positionFunction current), positionFunction)
    
    let private getDiagonalAllDirections (grid : Grid) (initialPosition: Coordinate) : VerticalDirections =
        let maxPosition = Enumerable.Count grid 
        { Up = getSingleVertical(grid, {X = maxPosition; Y = maxPosition}, initialPosition, up)
          Down = getSingleVertical(grid, {X = maxPosition; Y = maxPosition}, initialPosition, down) }
        
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
                
 
