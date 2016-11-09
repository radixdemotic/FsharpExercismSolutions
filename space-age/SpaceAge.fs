module Exercism.SpaceAge

open System;

type Planet = Earth | Mercury | Venus | Mars | Jupiter | Saturn | Uranus | Neptune

type orbitalYear = { 
    Earth:decimal;
    Mercury:decimal;
    Venus:decimal;
    Mars:decimal;
    Jupiter:decimal;
    Saturn:decimal;
    Uranus:decimal;
    Neptune:decimal;
    }

let orbitalYear = {
    Earth = 1m;
    Mercury = 0.2408467m;
    Venus = 0.61519726m;
    Mars = 1.8808158m;
    Jupiter = 11.862615m;
    Saturn =  29.447498m;
    Uranus = 84.016846m;
    Neptune = 164.79132m;
    }

let earthYearInSeconds = 31557600m

let secondsToEarthYears seconds = 
    seconds / earthYearInSeconds

let planetAge orbitalYear seconds = 
    (secondsToEarthYears seconds) / orbitalYear

let spaceAge (planet:Planet) (seconds:decimal) = 
    let age = match planet with
                | Earth -> planetAge orbitalYear.Earth seconds
                | Mercury -> planetAge orbitalYear.Mercury seconds
                | Venus -> planetAge orbitalYear.Venus seconds
                | Mars -> planetAge orbitalYear.Mars seconds
                | Jupiter -> planetAge orbitalYear.Jupiter seconds
                | Saturn -> planetAge orbitalYear.Saturn seconds
                | Uranus -> planetAge orbitalYear.Uranus seconds
                | Neptune -> planetAge orbitalYear.Neptune seconds
    Decimal.Round(age, 2)