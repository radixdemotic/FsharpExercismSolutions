module Exercism.BeerSong

open System

[<Literal>]
let plural = 2

let verse beer = 
    match beer with
        | beer when beer > plural -> sprintf "%i bottles of beer on the wall, %i bottles of beer.\nTake one down and pass it around, %i bottles of beer on the wall.\n" beer beer (beer - 1)
        | beer when beer = plural -> sprintf "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n"
        | beer when beer = 1 -> sprintf "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n"
        | _ -> sprintf "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n"

let verses startBeer endBeer = 
    let lines = seq { for beer in startBeer .. -1 .. endBeer -> (verse beer) + "\n" }
    String.concat "" lines

let sing = verses 99 0