open System
[<EntryPoint>]
let main argv =
    let l = [ for i in 1 .. (Convert.ToInt32(Console.ReadLine())) -> Console.ReadLine() ]
    printfn "%O , %O" (List.min l) (List.min (List.filter (fun x -> x<>(List.min l) ) l))
    0 