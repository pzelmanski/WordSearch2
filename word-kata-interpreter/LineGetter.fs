namespace work_kata_test2

open word_kata_test2_specification.Language

module LineGetter =
    let rec getSingle(grid: Grid, stop: Coordinate, current: Coordinate, positionFunction): string =
        if (current.HorizontalIndex >= stop.HorizontalIndex
            || current.VerticalIndex >= stop.VerticalIndex
            || current.HorizontalIndex < 0
            || current.VerticalIndex < 0) then ""
        else
            (string) grid.[current.VerticalIndex].[current.HorizontalIndex]
            + getSingle(grid, stop, (positionFunction current), positionFunction)
