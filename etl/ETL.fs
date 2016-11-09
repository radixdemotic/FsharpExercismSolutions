module Exercism.ETL

open System

let transform (old : Map<int , string list>) = 
    old |> Map.toSeq 
    //|> Seq.collect (fun (p, ls) -> Seq.map (fun (l: string) -> (l.ToLowerInvariant(), p)) ls)
    |> Seq.map (fun (point, letters) -> 
        (letters |> List.map (fun letter -> (letter.ToLower(), point))))
    |> List.concat 
    |> List.sort
    |> Map.ofSeq