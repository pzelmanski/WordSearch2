namespace word_kata_test2_specification

open Language

module Operations =
    type GetDiagonal = Submission -> DiagonalDirections list
    type GetVertical = Submission -> VerticalDirections list
    type GetDirections = Submission -> Directions
    type GetLine =  GetDirections -> Submission -> Directions
