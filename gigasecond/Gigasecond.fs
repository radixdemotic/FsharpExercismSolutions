module Exercism.Gigasecond

open System

let giga = 10. ** 9.

let gigasecond (input:DateTime) =
    input.AddSeconds(giga).Date