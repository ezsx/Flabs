// For more information see https://aka.ms/fsharp-console-apps
open System
let rec solve xx =
    match xx with
    | [] -> 0
    | x::xs -> if x % 2 <> 0 then x + solve xs
               else solve xs
[<EntryPoint>]
    let main argv =
        let smth = (solve [for i in 1 .. (Convert.ToInt32(Console.ReadLine())) -> Convert.ToInt32(Console.ReadLine())])
        printfn "%A" smth
        0