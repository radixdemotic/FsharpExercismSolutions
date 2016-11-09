module Exercism.DifferenceOfSquares

let square (term:int) = term * term

let squareOfSums (limit:int) = 
    seq {1..limit}
    |> Seq.sum
    |> square

let sumOfSquares (limit:int) = 
    seq {1..limit}
    |> Seq.sumBy square

let difference (limit:int) = 
    (squareOfSums limit) - (sumOfSquares limit)