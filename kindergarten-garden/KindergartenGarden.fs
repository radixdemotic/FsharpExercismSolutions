﻿module Exercism.KinderGartenGarden

open System

type Plant =
    | Clover
    | Radishes
    | Grass
    | Violets

type Child = string
type Garden = Map<Child,Plant seq>

let defaultChildren = 
    [
        "Alice"; 
        "Bob"; 
        "Charlie"; 
        "David";
        "Eve"; 
        "Fred"; 
        "Ginny"; 
        "Harriet"; 
        "Ileana"; 
        "Joseph"; 
        "Kincaid"; 
        "Larry"
    ]

let split (s : string) = s.Split([|'\n'|], StringSplitOptions.None)

let parse plant =
    match plant with
    | 'C' -> Clover
    | 'R' -> Radishes
    | 'G' -> Grass
    | 'V' -> Violets
    | unknown -> failwithf "Unknown plant: %c" unknown

let garden children description : Garden = 
    let parsedPlants = 
        description
        |> split
        |> Seq.map (fun line -> line |> Seq.map parse)
    let plantsPerChild = 
        parsedPlants
        |> Seq.map (Seq.chunkBySize 2)
