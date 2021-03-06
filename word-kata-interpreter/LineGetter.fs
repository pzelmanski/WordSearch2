﻿namespace word_kata_interpreter

open word_kata_specification.Language

module LineGetter =
    let rec getSingle(grid: Grid, stop: Coordinate, current: Coordinate, positionFunction): string =
        if (current.HorizontalIndex >= stop.HorizontalIndex
            || current.VerticalIndex >= stop.VerticalIndex
            || current.HorizontalIndex < 0
            || current.VerticalIndex < 0) then ""
        else
            (string) grid.[current.VerticalIndex].[current.HorizontalIndex]
            + getSingle(grid, stop, (positionFunction current), positionFunction)
