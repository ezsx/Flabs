open System
let Sum (a,b) L= 
    let rec out L (a,b) sum = 
        match L with
        |[]->sum
        |i::s-> 
            let newSum = if i > a && i < b then sum+i else sum
            out s (a,b) newSum
    out L (a,b) 0
[<EntryPoint>]
let main argv =
    printfn "интервал, количество элементов и список:"
    System.Console.WriteLine(Sum (Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine())) (Program.readL(Console.ReadLine() |> Convert.ToInt32)))
    0 