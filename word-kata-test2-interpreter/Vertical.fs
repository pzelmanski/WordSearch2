namespace work_kata_test2

open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations

module Vertical =
    let ``do`` : GetVertical =
            fun submission -> 
            [{
                Up = "a"
                Down = "b"
            }]