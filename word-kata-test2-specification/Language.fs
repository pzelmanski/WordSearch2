namespace word_kata_test2_specification


module Language =
    type SingleLine = string
    type Grid = SingleLine list
    type Word = string
    type Submission =
        {
            Grid : Grid
            Word : Word
        }
    
    type DiagonalDirections =
        {
            NE : SingleLine
            NW : SingleLine
            SE : SingleLine
            SW : SingleLine
        }
    
    type VerticalDirections =
        {
            Up : SingleLine
            Down : SingleLine
        }
    
    type Directions =
        | Diagonal of DiagonalDirections list
        | Vertical of VerticalDirections list
