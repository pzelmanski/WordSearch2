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

    let rec getDiagonal(grid: Grid, stop: int * int, current: int * int, positionFunction): string =
        if (fst current >= fst stop
            || snd current >= snd stop
            || fst current < 0
            || snd current < 0) then ""
        else
            (string) grid.[fst current].[snd current]
            + getDiagonal(grid, stop, (positionFunction current), positionFunction)

    let getDiagonalBottomDown (grid: Grid) (initialPosition: int * int) : DiagonalDirections =
        let maxPosition = Enumerable.Count grid
        {
           NE = getDiagonal(grid, (maxPosition, maxPosition), initialPosition, northEast);
           NW = getDiagonal(grid, (maxPosition, maxPosition), initialPosition, northWest);
           SE = getDiagonal(grid, (maxPosition, maxPosition), initialPosition, southEast);
           SW = getDiagonal(grid, (maxPosition, maxPosition), initialPosition, southWest)
        }

    let singleLines: GetDiagonal =
        fun grid word ->
            grid
            |> List.mapi (getPositionsOfWordsFirstLetter word)
            |> List.choose id
            |> List.map (getDiagonalBottomDown grid)

    let mapTo (diagonal : DiagonalDirections list) : AllDirections =
        let d = diagonal
                |> List.map(fun v -> [v])
                |> List.concat
        AllDirections.Diagonal d
        
    let doSth grid word : AllDirections =
        singleLines grid word
        |> mapTo