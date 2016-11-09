open System

let x = [(1, ["A"; "E"; "I"; "O"; "U"; "L"; "N"; "R"; "S"; "T"]); 
                (2, ["D"; "G"]); 
                (3, ["B"; "C"; "M"; "P"]); 
                (4, ["F"; "H"; "V"; "W"; "Y"]); 
                (5, ["K"]); 
                (8, ["J"; "X"]); 
                (10, ["Q"; "Z"])] |> Map.ofSeq
x |> Map.toSeq |> Seq.map (fun (point, letters) -> letters |> List.map (fun letter -> (letter.ToLower(), point))) |> List.concat |> List.sort |> Map.ofSeq