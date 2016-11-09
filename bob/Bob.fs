module Exercism.Bob

open System

let isQuestion (um:string) = 
    um.EndsWith("?")

let isYell (um:string) = 
    let y = um.ToCharArray() |> Array.filter(Char.IsLetter) 
    if Array.empty = y then false
    else Array.TrueForAll (y, fun c -> Char.IsUpper c)

let isNothing (um:string) = 
    um.Trim() = ""

type Teen = {
    Question : string
    Yell : string
    Nothing : string
    Stuff : string
    }

let (|Question|Yell|Nothing|Stuff|) um = 
    if isYell um then Yell
    elif isQuestion um then Question
    elif isNothing um then Nothing
    else Stuff

let bob = { Question = "Sure."; Yell = "Whoa, chill out!"; Nothing = "Fine. Be that way!"; Stuff = "Whatever." }

let hey um = 
    match um with 
    |Yell ->  bob.Yell
    |Question -> bob.Question
    |Nothing -> bob.Nothing
    |Stuff -> bob.Stuff