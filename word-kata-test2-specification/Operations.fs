namespace word_kata_test2_specification

open Language

module Operations =
    type GetDirections = Submission -> Directions
    type GetLine =  GetDirections -> Submission -> Directions
