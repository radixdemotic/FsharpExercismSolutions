open System

let empty = [ ( 'A', 0 ); ( 'T', 0 ); ( 'C', 0 ); ( 'G', 0 ) ] |> Map.ofSeq
let strand = "AGCTCTCGCGA"
//    let result = strand |> Seq.countBy (fun a ->
//        if a = 'A' then 'A'
//        elif a = 'T' then 'T'
//        elif a = 'C' then 'C'
//        else 'G')

Seq.fold (fun (acc:int) (elem:Char) -> if elem = 'C' then acc + 1 else acc) 0 ""