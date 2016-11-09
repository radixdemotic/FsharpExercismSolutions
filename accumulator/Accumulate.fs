module Exercism.Accumulate

open System

let accumulate mapping data = 
    match data with
    | [] -> List.empty
    | data -> [for d in data -> mapping d] 