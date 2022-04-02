open System

let div L t predicate=
    let rec out L t=
        match L with
        |[]-> 0
        |(i:int)::s->
           if predicate t then 
             System.Console.WriteLine(i) 
             let newN = t - 1
             let newL = s
             out newL newN
           else 
             let newN = t - 1
             let newL=s
             out newL newN
    out L t     
 
[<EntryPoint>]
let main argv =
    printfn "Количество элементов и список:"
    let i = Console.ReadLine() |> Convert.ToInt32
    let l = Program.readL(i)
    div l i (fun x -> if x%2=0 then true else false)|>ignore
    div l i (fun x -> if x%2=1 then true else false)|>ignore
    0 