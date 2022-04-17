open System
[<EntryPoint>]
let main argv =
    let l = [ for i in 1 .. (Convert.ToInt32(Console.ReadLine())) -> Convert.ToDouble(Console.ReadLine()) ]
    printfn "%O" (List.filter (fun x -> x>(List.average l) && x< (List.max l)) l)
    0 