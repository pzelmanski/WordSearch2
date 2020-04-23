namespace word_kata_interpreter

open System.Linq
open word_kata_specification.Language
open word_kata_specification.Operations
open Converters
open LineGetter

module Diagonal =
    let northEast currentPos =
        {HorizontalIndex = currentPos.HorizontalIndex + 1; VerticalIndex = currentPos.VerticalIndex - 1} 
    let northWest currentPos =
        {HorizontalIndex = currentPos.HorizontalIndex - 1; VerticalIndex = currentPos.VerticalIndex - 1}
    let southEast currentPos =
        {HorizontalIndex = currentPos.HorizontalIndex + 1; VerticalIndex = currentPos.VerticalIndex + 1}
    let southWest currentPos =
        {HorizontalIndex = currentPos.HorizontalIndex - 1; VerticalIndex = currentPos.VerticalIndex + 1}

    let getDiagonalAllDirections (grid: Grid) (initialPosition: Coordinate) : DiagonalDirections =
        let maxPosition = Enumerable.Count grid
        {
           NE = getSingle(grid, {HorizontalIndex = maxPosition; VerticalIndex = maxPosition}, initialPosition, northEast);
           NW = getSingle(grid, {HorizontalIndex = maxPosition; VerticalIndex = maxPosition}, initialPosition, northWest);
           SE = getSingle(grid, {HorizontalIndex = maxPosition; VerticalIndex = maxPosition}, initialPosition, southEast);
           SW = getSingle(grid, {HorizontalIndex = maxPosition; VerticalIndex = maxPosition}, initialPosition, southWest)
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