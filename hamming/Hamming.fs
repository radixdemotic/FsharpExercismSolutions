module Exercism.Hamming

open System

let compute (strand1:string) (strand2:string) =
    Array.map2 (fun s1 s2 -> if s1 = s2 then 0 else 1) (strand1.ToCharArray()) (strand2.ToCharArray()) 
    |> Array.sum

//    mpriestman 
//    let compute (a : string) (b : string) =
//    Seq.map2 (<>) a b
//    |> Seq.filter id
//    |> Seq.length
//strings can be operated on as sequences
//no need to convert to character array
//here the id operator for identity is passed as the filter function