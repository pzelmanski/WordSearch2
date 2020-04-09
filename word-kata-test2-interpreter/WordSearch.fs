namespace work_kata_test2

open System.Linq
open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations

module WordSearch =
    let getPositionsOfWordsFirstLetter (wordToSearch: string) (verticalIndex: int) (line: string) =
        match line.IndexOf(wordToSearch.[0]) with
        | -1 -> None
        | index -> Some(index, verticalIndex)

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
            (string) grid.[snd current].[fst current]
            + getDiagonal(grid, stop, (positionFunction current), positionFunction)

    let getDiagonalBottomDown (grid: Grid) (initialPosition: int * int) : DiagonalDirections =
        let maxPosition = Enumerable.Count grid
        {
           NE = getDiagonal(grid, (maxPosition, maxPosition), initialPosition, northEast);
           NW = getDiagonal(grid, (maxPosition, maxPosition), initialPosition, northWest);
           SE = getDiagonal(grid, (maxPosition, maxPosition), initialPosition, southEast);
           SW = getDiagonal(grid, (maxPosition, maxPosition), initialPosition, southWest)
        }

    let ``in``: GetDiagonal =
        fun grid word ->
            let x =
                grid
                |> List.mapi (getPositionsOfWordsFirstLetter word) // (int * int) list
                |> List.choose id

            let y = x |> List.map (getDiagonalBottomDown grid)
            y
