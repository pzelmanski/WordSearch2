namespace work_kata_test2

open System.Linq
open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations

module Diagonal =
    let getPositionsOfWordsFirstLetter (wordToSearch: string) (verticalIndex: int) (line: string) =
        match line.IndexOf(wordToSearch.[0]) with
        | -1 -> None
        | index -> Some(verticalIndex, index)

    let northEast currentPos =
        (fst currentPos - 1, snd currentPos + 1) 
    let northWest currentPos =
        (fst currentPos - 1, snd currentPos - 1)
    let southEast currentPos =
        (fst currentPos + 1, snd currentPos + 1)
    let southWest currentPos =
        (fst currentPos + 1, snd currentPos - 1)

    let rec getSingleDiagonal(grid: Grid, stop: int * int, current: int * int, positionFunction): string =
        if (fst current >= fst stop
            || snd current >= snd stop
            || fst current < 0
            || snd current < 0) then ""
        else
            (string) grid.[fst current].[snd current]
            + getSingleDiagonal(grid, stop, (positionFunction current), positionFunction)

    let getDiagonalAllDirections (grid: Grid) (initialPosition: int * int) : DiagonalDirections =
        let maxPosition = Enumerable.Count grid
        {
           NE = getSingleDiagonal(grid, (maxPosition, maxPosition), initialPosition, northEast);
           NW = getSingleDiagonal(grid, (maxPosition, maxPosition), initialPosition, northWest);
           SE = getSingleDiagonal(grid, (maxPosition, maxPosition), initialPosition, southEast);
           SW = getSingleDiagonal(grid, (maxPosition, maxPosition), initialPosition, southWest)
        }

    let singleLines submission =
        submission.Grid
        |> List.mapi (getPositionsOfWordsFirstLetter submission.Word)
        |> List.choose id
        |> List.map (getDiagonalAllDirections submission.Grid)

    let mapTo (diagonal : DiagonalDirections list) : Directions =
        let d = diagonal
                |> List.map(fun v -> [v])
                |> List.concat
        Directions.Diagonal d
        
    let getDirections : GetDirections =
        fun submission ->
            singleLines submission
            |> mapTo