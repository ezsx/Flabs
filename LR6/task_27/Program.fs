open System

let Shift L =
    let rec out L i cc =
        if cc <> 0 then L @ [i] else
        match L with
        |[] -> L
        |i::t ->
            let newcc = cc + 1
            out t i newcc 
    out L 0 0
[<EntryPoint>]
let main argv =
    printfn "Количество элементов и список:"
    Program.printL (Shift (Program.readL(Console.ReadLine() |> Convert.ToInt32))) 
    0 