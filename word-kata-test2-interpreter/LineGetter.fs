namespace work_kata_test2

open word_kata_test2_specification.Language

module LineGetter =
    let rec getSingle(grid: Grid, stop: Coordinate, current: Coordinate, positionFunction): string =
        if (current.X >= stop.X
            || current.Y >= stop.Y
            || current.X < 0
            || current.Y < 0) then ""
        else
            (string) grid.[current.Y].[current.X]
            + getSingle(grid, stop, (positionFunction current), positionFunction)
