namespace word_kata_test2_specification


module Language =
    type Index = int
    type Coordinate = { HorizontalIndex : Index ; VerticalIndex : Index }
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
    
    type StraightDirections =
        {
            Up : SingleLine
            Down : SingleLine
            Left : SingleLine
            Right : SingleLine
        }
    
    type Directions =
        | Diagonal of DiagonalDirections list
        | Straight of StraightDirections list
    
    type AllDirections =
        {
            Lines : SingleLine list
            
        }
    
