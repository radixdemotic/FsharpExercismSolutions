module Exercism.Triangle

open System

type TriangleKind = 
    | Equilateral
    | Isosceles
    | Scalene

let validTriangle ( (legA, legB, legC) : (Decimal * Decimal * Decimal) ) = 
    (legA > 0m) && (legB > 0m) && (legC > 0m) &&
    legA + legB > legC && 
    legB + legC > legA && 
    legA + legC > legB

let kind (legA : Decimal) (legB : Decimal) (legC : Decimal) =
    if validTriangle (legA, legB, legC) then
        match (legA, legB, legC) with
            | (a, b, c) when ((a = b) && (b = c)) -> TriangleKind.Equilateral
            | (a, b, c) when ((a = b) || (b = c) || (a = c)) -> TriangleKind.Isosceles
            | (_, _, _) -> TriangleKind.Scalene
    else
        raise (new InvalidOperationException())