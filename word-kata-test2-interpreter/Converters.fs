namespace work_kata_test2

open word_kata_test2_specification.Operations
open word_kata_test2_specification.Language

module Converters =
    let submissionToFirstLetterSubmission : SubmissionIntoFirstLetterSubmission =
        fun submission ->
            submission.Word.ToCharArray()
                |> Array.toList
                |> function
                    | h::[] -> Some {
                            Grid  = submission.Grid
                            Word  = {
                                FirstLetter = h
                                Remaining = []
                            }
                        }
                    | h::t -> Some {
                            Grid  = submission.Grid
                            Word  = {
                                FirstLetter = h
                                Remaining = t
                            }
                        }
                    | _ -> None
