module Exercism.RobotName

open System

[<Literal>]
let letter = 2

[<Literal>]
let numeral = 3

let random = System.Random()

type Robot = { mutable Name : String }

let mutable generatedNames = set<string> []

let randomLetter() = 'A' |> int |> (fun l -> l + random.Next(0, (int 'Z'))) |> char |> string

let randomDigit() = random.Next(0,10) |> string

let assignSerial() = 
    (List.append [for _ in 1..letter -> randomLetter()]
    [for _ in 1..numeral -> randomDigit()])
    |> String.concat ""

let checkName name = 
    generatedNames.Contains name

let generateName() = 
    let mutable name = assignSerial()
    while checkName name do 
        name <- assignSerial()
    generatedNames <- generatedNames.Add(name)
    name

let mkRobot() = { Name = generateName() }

let name (bot : Robot) = 
    bot.Name

let reset (bot : Robot) = 
    mkRobot()