module Exercism.Raindrops

open System

let rainPrimes = Set [3; 5; 7]
let rainTerms = ["Pling"; "Plang"; "Plong"]
let rain = List.zip (rainPrimes |> List.ofSeq) rainTerms |> Map.ofList

let rec factorial current prime primeList = 
    match prime with 
    | prime when prime = current -> prime :: primeList
    | prime when current % prime = 0 -> factorial (current / prime) prime (prime :: primeList)
    | prime -> factorial current (prime + 1) primeList

let factorize n = 
    if n >= 2 then factorial n 2 []
    else [n]

let (|HasRain|NoRain|) (factorSet:Set<int>) = 
    if (Set.intersect factorSet rainPrimes) <> Set.empty then HasRain
    else NoRain

let convert number = 
    let factorSet = factorize number |> Set.ofList
    match factorSet with
    | HasRain -> Set.foldBack (fun factor state -> 
        if rain.ContainsKey factor then rain.Item factor + state 
        else state + "") factorSet ""
    | NoRain -> number.ToString()

//robkeim
//let convert num =
//    match num % 3, num % 5, num % 7 with
//    | 0, 0, 0 -> "PlingPlangPlong"
//
//    | 0, 0, _ -> "PlingPlang"
//    | 0, _, 0 -> "PlingPlong"
//    | _, 0, 0 -> "PlangPlong"
//    
//    | 0, _, _ -> "Pling"
//    | _, 0, _ -> "Plang"
//    | _, _, 0 -> "Plong"
//
//    | _, _, _ -> num |> sprintf "%A"

//ErikSchierboom
//let convert (number:int) =
//    let factors = [(3, "Pling"); (5, "Plang"); (7, "Plong")]
//    let factorStrings = [for (factor, str) in factors do if number % factor = 0 then yield str]
//    match factorStrings with
//    | [] -> number.ToString(CultureInfo.InvariantCulture)
//    | xs -> String.concat "" xs