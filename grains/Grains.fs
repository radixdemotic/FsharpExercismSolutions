module Exercism.Grains

open System

let chessTiles = 64

let baseGrain = 2I

let board = seq { for g in 0 .. chessTiles -> baseGrain ** g }

let square (tile:int) = 
    board |> Seq.take tile |> Seq.last

let total = board |> Seq.take chessTiles |> Seq.sum