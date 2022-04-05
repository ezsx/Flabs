
open System
let rec nechet xx init=
    match xx with
    | [] -> init
    | x::xs -> 
    if x % 2 <> 0 then
        let init_new=init+x
        nechet xs init_new
    else nechet xs init

let rec nechet_up xx =
    match xx with
    | [] -> 0
    | x::xs -> if x % 2 = 0 then x + nechet_up xs
               else nechet_up xs


[<EntryPoint>]
let main argv =
    printfn "Количество элементов и список:"
    Console.WriteLine (nechet (Program.readL(Console.ReadLine() |> Convert.ToInt32)) 0)
    0