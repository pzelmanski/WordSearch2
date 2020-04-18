namespace work_kata_test2

open word_kata_test2_specification.Language
open word_kata_test2_specification.Operations

module Vertical =
    let getDirections : GetDirections =
            fun submission -> 
            Directions.Vertical [{
                Up = "a"
                Down = "b"
            }]
         
