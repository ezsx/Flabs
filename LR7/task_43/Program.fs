open System
[<EntryPoint>]
let main argv =
    let l = [ for i in 1 .. (Convert.ToInt32(Console.ReadLine())) -> Convert.ToInt32(Console.ReadLine()) ]
    printfn "%O" (List.length (List.filter (fun x->x=List.min (l)) l))
    0