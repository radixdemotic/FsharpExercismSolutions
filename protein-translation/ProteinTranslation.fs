module Exercism.ProteinTranslation

open System

[<Literal>]
let rnaBaseLength = 3

let rnaBases = set ['A'; 'C'; 'G'; 'U';]

//assumes all codon groups in the input string will find a match later.
let validCodon (check:string) = (Set.isSubset (check |> Set.ofSeq) rnaBases) && (check.Length % rnaBaseLength = 0)

let aminosRnaCodons = [["Methionine"; "AUG"];
                        ["Phenylalanine"; "UUU"; "UUC"];
                        ["Leucine"; "UUA"; "UUG";"CUU";"CUC";"CUA";"CUG"];
                        ["Isoleucine";"AUU";"AUC";"AUA";"AUG"];
                        ["Serine";"UCU"; "UCC"; "UCA"; "UCG"];
                        ["Tyrosine"; "UAU"; "UAC"];
                        ["Cysteine"; "UGU"; "UGC"];
                        ["Tryptophan"; "UGG"];
                        ["STOP"; "UAA"; "UAG"; "UGA"]]

let rnaCodonTable = aminosRnaCodons 
                    |> List.collect (fun aminoRnaCodon -> 
                    [for r in aminoRnaCodon.Tail -> (r, aminoRnaCodon.Head)])

let splitCodon (codon:string) =
    codon |> Seq.chunkBySize rnaBaseLength |> Seq.map (fun rna -> String.Concat(rna)) |> List.ofSeq

let getRnaPair (codon:string) = 
    rnaCodonTable |> List.find (fun (rna, acid) -> rna = codon)

let codonToStop (codonList:string list) = 
    codonList |> List.takeWhile (fun codon -> (getRnaPair codon |> snd) <> "STOP")

let buildAminos (codonList: string list) = 
    codonList |> List.map (fun codon -> getRnaPair codon |> snd)

let translate (codon:string) = 
    if validCodon codon then
        codon
        |> splitCodon
        |> codonToStop
        |> buildAminos
    else invalidArg codon "Codon unrecognizable"