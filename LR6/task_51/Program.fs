open System
let rec freq L el cc =
    match L with
    |[] -> cc
    | i::s -> 
        let cc1 = cc + 1
        if i = el then freq s el cc1 else freq s el cc

let n_L1 L =
    let rec L1 L newL=
        match L with
        |[] -> newL
        |i::s ->
              if freq L i 0 = 1 then 
                let newL1=newL@[i]
                L1 s newL1
              else L1 s newL         
    L1 L []
    
let n_L2 L lc =
    let rec L2 L lc ll2 =
        match lc with
             |[]-> ll2
             |i::s ->
                 let newE= freq L i 0
                 let newL=ll2@[newE]
                 L2 L s newL
    L2 L lc []

[<EntryPoint>]
let main argv =
    printfn "Количество элементов и список:"
    let l= Program.readL(Console.ReadLine() |> Convert.ToInt32)
    printfn"L1 "
    Program.printL (n_L1 l)
    printfn"L2 "
    Program.printL (n_L2 l (n_L1 l))
    0 