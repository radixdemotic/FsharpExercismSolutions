module Exercism.QueenAttack

//DO NOT SUBMIT

//jovaneyck
//another readable, elegant solution.

//let canAttack ((x1, y1) as f) ((x2, y2) as s) = 
//    if f = s then
//        invalidOp "Queens cannot occupy the same space"
//    else
//        x1 = x2 
//        || y1 = y2 
//        || (x2 - x1 |> abs) = (y2 - y1 |> abs)

let queenAttackRules ((x1, y1): int * int) ((x2, y2): int * int) = 
    x1 = x2 || y1 = y2 || (x2 - x1 |> abs) = (y2 - y1 |> abs)

let canAttack2 ((x1, y1) as q1) ((x2, y2) as q2) = 
    match q1, q2 with
    | (q1, q2) when q1 = q2 -> invalidOp "Queens cannot occupy the same space"
    | (q1, q2) -> queenAttackRules q1 q2