namespace word_kata_test2_specification

open Language

module Operations =
    type GetDiagonal = Grid -> Word -> DiagonalDirections list
    type GetVertical = Grid -> Word -> VerticalDirections list
    type GetDirections = Grid -> Word -> AllDirections
    type GetLine =  GetDirections -> Grid -> Word -> AllDirections
