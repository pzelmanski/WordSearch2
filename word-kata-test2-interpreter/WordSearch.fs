namespace work_kata_test2

open System.Linq
open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations

module WordSearch =
    let GetPositionsOfWordsFirstLetter (wordToSearch: string) (verticalIndex: int) (line: string) =
        match line.IndexOf(wordToSearch.[0]) with
        | -1 -> None
        | index -> Some(index, verticalIndex)

    let GetNextPosition1 currentPos =
        (fst currentPos + 1, snd currentPos + 1)
    let GetNextPosition2 currentPos =
        (fst currentPos + 1, snd currentPos - 1)
    let GetNextPosition3 currentPos =
        (fst currentPos - 1, snd currentPos + 1)
    let GetNextPosition4 currentPos =
        (fst currentPos - 1, snd currentPos - 1)

    let rec GetDiagonal(grid: Grid, stop: int * int, current: int * int, positionFunction): string =
        if (fst current >= fst stop || snd current >= snd stop) then ""
        else
            (string) grid.[snd current].[fst current]
            + GetDiagonal(grid, stop, (positionFunction current), positionFunction)

    let GetDiagonalBottomDown (grid: Grid) (initialPosition: int * int) =
        let maxPostion = Enumerable.Count grid
        GetDiagonal(grid, (maxPostion, maxPostion), initialPosition, GetNextPosition1) +
        GetDiagonal(grid, (maxPostion, maxPostion), initialPosition, GetNextPosition2) +
        GetDiagonal(grid, (maxPostion, maxPostion), initialPosition, GetNextPosition3) +
        GetDiagonal(grid, (maxPostion, maxPostion), initialPosition, GetNextPosition4)
        

    let In: GetDiagonal =
        fun grid word ->
            let x =
                grid
                |> List.mapi (GetPositionsOfWordsFirstLetter word) // (int * int) list
                |> List.choose id

            let y = x |> List.map (GetDiagonalBottomDown grid)
            y
