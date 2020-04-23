namespace word_kata_interpreter

open word_kata_specification.Language

module Coordinates =
    let private getPositionsOfWordsFirstLetter (firstLetter: FirstLetter) (verticalIndex: int) (line: string) =
        match line.IndexOf(firstLetter) with
        | -1 -> None
        | horizontalIndex -> Some {HorizontalIndex = horizontalIndex; VerticalIndex = verticalIndex}
    
    let OfFirstLetter (submission : FirstLetterSubmission) =
        submission.Grid
        |> List.mapi (getPositionsOfWordsFirstLetter submission.Word.FirstLetter)
        |> List.choose id