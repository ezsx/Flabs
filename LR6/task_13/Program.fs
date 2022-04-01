open System

let min_el L =
    let rec minE L init =
        match L with
        |[]-> init
        |h::t ->
          let newInit = if h<init then h else init
          let newL=t
          minE newL newInit          
    minE L L.Head

let go_end L=
    let rec change L =
        match L with
        |[]-> L
        |h::t -> 
           if min_el L = h then L else 
           let newL=t@[h]
           change newL
    change L
        
[<EntryPoint>]
let main argv =
    printfn "Количество элементов и список:"
    Program.printL (go_end (Program.readL (Console.ReadLine() |> Convert.ToInt32)))
    0