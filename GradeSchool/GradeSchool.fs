module Exercism.School

//jovaneyck

//The test begins by passing in the empty map, so there's no need
//for a persistent structure within the code. This is a perfect implementation.

open System

let empty = Map.empty

let grade gradeKey school = 
    match school |> Map.tryFind gradeKey with
    | Some students -> students
    | None -> []

let add student gradeKey school = 
    let currentStudents = school |> grade gradeKey
    school |> Map.add gradeKey ((student :: currentStudents) |> List.sort)

let roster school = school |> Map.toSeq