open System

let Find_min L n =
    let rec out L n last init =
        match L with
        |[]-> init
        |sm::t ->
           if n<>1 then 
             let newL = t
             let newPred = sm
             let newn = n - 1
             out newL newn newPred init
              else if last>sm && sm<t.Head then init = true else init = false       
    out L n L.Head true

[<EntryPoint>]
let main argv =
    printfn "Введите индекс искомого элемента:"
    let k = System.Convert.ToInt32(System.Console.ReadLine())
    
    printfn "Количество элементов и список:"
    Program.RES (Find_min (Program.readL (Console.ReadLine() |> Convert.ToInt32)) k)
    
    0 