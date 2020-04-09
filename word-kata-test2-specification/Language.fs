namespace word_kata_test2_specification

module Language =
    type SingleLine = string
    type Grid = SingleLine list
    type Word = string

    type DiagonalDirections =
        {
            NE : SingleLine
            NW : SingleLine
            SE : SingleLine
            SW : SingleLine
        }
