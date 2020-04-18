namespace word_kata_test2_specification

open Language

module Operations =
    type SubmissionIntoFirstLetterSubmission = Submission -> FirstLetterSubmission option
    type GetPositionOfFirstLetter = FirstLetterSubmission -> Coordinates
    type GetDirections = Submission -> Directions option
    type GetLine = GetDirections -> Submission -> Directions option
