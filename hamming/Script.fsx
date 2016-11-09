// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

open System

//let x = [|'A'; 'G'; 'C'; 'T'; 'G'; 'C'; 'A'; 'G'; 'G'|]
//let y = [|'A'; 'C'; 'C'; 'G'; 'G'; 'A'; 'G'; 'T'; 'C'|]
//let z = Array.map2 (fun s1 s2 -> if s1 = s2 then 0 else 1) x y |> Array.sum
//
//let hamming (strand1:string) (strand2:string) =
//    Array.map2 (fun s1 s2 -> if s1 = s2 then 0 else 1) (strand1.ToCharArray()) (strand2.ToCharArray()) 
//    |> Array.sum

let string1 = "Free Beacon"
let spoonerism (phrase:string) = 
    let splitPhrase = phrase.Split [|' '|]
    splitPhrase.[1].Substring (0,1) + splitPhrase.[0].Substring (1, splitPhrase.[0].Length-1)
    + " " +
    splitPhrase.[0].Substring (0,1) + splitPhrase.[1].Substring (1, splitPhrase.[1].Length-1)
spoonerism string1