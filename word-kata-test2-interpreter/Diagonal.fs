namespace work_kata_test2

open System.Linq
open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations
open Converters

module Diagonal =
    let northEast currentPos =
        {X = currentPos.X - 1; Y = currentPos.Y + 1} 
    let northWest currentPos =
        {X = currentPos.X - 1; Y = currentPos.Y - 1}
    let southEast currentPos =
        {X = currentPos.X + 1; Y = currentPos.Y + 1}
    let southWest currentPos =
        {X = currentPos.X + 1; Y = currentPos.Y - 1}

    let rec getSingleDiagonal(grid: Grid, stop: Coordinate, current: Coordinate, positionFunction): string =
        if (current.X >= stop.X
            || current.Y >= stop.Y
            || current.X < 0
            || current.Y < 0) then ""
        else
            (string) grid.[current.X].[current.Y]
            + getSingleDiagonal(grid, stop, (positionFunction current), positionFunction)

    let getDiagonalAllDirections (grid: Grid) (initialPosition: Coordinate) : DiagonalDirections =
        let maxPosition = Enumerable.Count grid
        {
           NE = getSingleDiagonal(grid, {X = maxPosition; Y = maxPosition}, initialPosition, northEast);
           NW = getSingleDiagonal(grid, {X = maxPosition; Y = maxPosition}, initialPosition, northWest);
           SE = getSingleDiagonal(grid, {X = maxPosition; Y = maxPosition}, initialPosition, southEast);
           SW = getSingleDiagonal(grid, {X = maxPosition; Y = maxPosition}, initialPosition, southWest)
        }

    let singleLines (singleLineSubmission : FirstLetterSubmission) =
        singleLineSubmission
        |> Coordinates.OfFirstLetter
        |> List.map (getDiagonalAllDirections singleLineSubmission.Grid)

    let mapTo (diagonal : DiagonalDirections list) : Directions =
        let d = diagonal
                |> List.map(fun v -> [v])
                |> List.concat
        Directions.Diagonal d
    
    let getDirections : GetDirections =
        fun submission ->
            submission |> submissionToFirstLetterSubmission
                       |> function
                           | Some firstLetterSubmission ->
                                    firstLetterSubmission
                                    |> singleLines
                                    |> mapTo
                                    |> Some
                           | None -> None