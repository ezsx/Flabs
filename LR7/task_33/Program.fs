open System
let prov L=
    let rec p L =
        if List.length L > 2 then
            if ( (List.item 0 L) * (List.item 1 L) ) < 0 then true else false
        else if (List.item 0 L)*(List.item 1 L)<0 then true else false
    p L                
[<EntryPoint>]
let main argv =
    Program.RES (prov [ for i in 1 .. (Convert.ToInt32(Console.ReadLine())) -> Convert.ToInt32(Console.ReadLine()) ])
    0