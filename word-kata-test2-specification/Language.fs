namespace word_kata_test2_specification


module Language =
    
    type X = int
    type Y = int
    type Coordinate = (X * Y)
    type Coordinates = Coordinate list
    type SingleLine = string
    type Grid = SingleLine list
    type Word = string
    
    type FirstLetter = char
    
    type FirstLetterWord = {
                     FirstLetter : FirstLetter
                     Remaining : char list
                  }
    
    type FirstLetterSubmission =
        {
            Grid : Grid
            Word : FirstLetterWord
        }
        
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
