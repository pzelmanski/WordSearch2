namespace work_kata_test2

open System.Linq
open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations
open Converters


module Coordinates =
    let getPositionsOfWordsFirstLetter (wordToSearch: string) (verticalIndex: int) (line: string) =
        match line.IndexOf(wordToSearch.[0]) with
        | -1 -> None
        | index -> Some( )
    
    let singleLines submission =
        submission.Grid
        |> List.mapi (getPositionsOfWordsFirstLetter submission.Word)
        |> List.choose id
        
//    let getCoordinates : GetPositionOfFirstLetter =
        
        
        

module Diagonal =
    let getPositionsOfWordsFirstLetter (wordToSearch: FirstLetterWord) (verticalIndex: int) (line: string) =
        match line.IndexOf(wordToSearch.FirstLetter) with
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

    let singleLines (singleLineSubmission : FirstLetterSubmission) =
        singleLineSubmission.Grid
        |> List.mapi (getPositionsOfWordsFirstLetter singleLineSubmission.Word)
        |> List.choose id
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