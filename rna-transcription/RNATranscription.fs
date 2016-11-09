module Exercism.RNATranscription

open System

let toRna (dna:string) = 
    dna |> Seq.map ( fun a -> 
        match a with 
        | 'G' -> 'C'
        | 'C' -> 'G'
        | 'T' -> 'A'
        | 'A' -> 'U'
        | a -> failwith "Invalid base in DNA string."
    ) |> String.Concat

//Annie Linux
//let mapping = [('G','C');('C','G');('T','A');('A','U')] |> Map.ofList
//let toRna = String.map (fun x -> Map.find x mapping)