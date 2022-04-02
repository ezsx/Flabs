open System
let Find_local_max L n=
    let rec out L n last init=
        match L with
        |[]-> init
        |s::i ->
           if n<>1 then 
             let newL= i
             let newLast= s
             let newn = n - 1
             out newL newn newLast init
              else if last < s && s > i.Head then init = true else init = false
    out L n L.Head true

[<EntryPoint>]
let main argv =
    printfn "Индекс искомого элемента:"
    let el = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "Количество элементов и список:"
    Program.RES (Find_local_max (Program.readL(Console.ReadLine() |> Convert.ToInt32)) el)
    0 