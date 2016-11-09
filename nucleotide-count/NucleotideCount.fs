module Exercism.NucleoTideCount

open System

let dnaBases = set ['A'; 'C'; 'G'; 'T';]

//let validStrand strand = 
//    strand |> Set.ofSeq |> (=) dnaBases

let count (dnaBase : Char) (strand : string) = 
    if dnaBases.Contains dnaBase || strand = "" then
        strand 
        |> Seq.filter (fun b -> b = dnaBase)
        |> Seq.length
    else failwith "Invalid DNA nucleotide."

let nucleotideCounts (strand:string) = 
    [for b in dnaBases -> (b, (count b strand))] |> Map.ofList