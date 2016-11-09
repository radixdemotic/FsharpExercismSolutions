module Exercism.HelloWorld

let hello (name: string option) = 
    match name with 
    | None -> "Hello, World!"
    | Some (name) -> sprintf "Hello, %s" name