namespace word_kata_interpreter

open word_kata_specification.Language
open word_kata_specification.Operations

module WordSearch =
    let directions : GetLine =
            fun fn submission ->
                fn submission
    
    let getLinesInAllDirections (submission : Submission) =
        { Lines =
            submission
                |> directions Diagonal.getDirections
                |> function
                    | Some x -> Converters.directionsIntoSingleLinesList x
                    | None -> []
            |> List.append (
                submission
                    |> directions Straight.getDirections
                    |> function
                        | Some x -> Converters.directionsIntoSingleLinesList x
                        | None -> [])}
    
    let HasWordInIt (word : Word)(allDirections : AllDirections) : bool =
        allDirections.Lines
        |> List.contains word
    
    let find submission =
        submission
        |> getLinesInAllDirections 
        |> HasWordInIt submission.Word
        