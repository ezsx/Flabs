open System

let elemCount list el =
    let rec elemCountInternal list el count  =
        match list with
        | [] -> count
        | el0::t ->
            let newCount = if (el0 = el) then count + 1 else count
            elemCountInternal t el newCount
    elemCountInternal list el 0

let proc list =
    let rec procInternal list or_List el =
        match list with
        | [] -> el
        | el0::t ->
            let newEl = if (elemCount or_List el0) = 1 then el0 else el
            procInternal t or_List newEl
    procInternal list list list.Head

[<EntryPoint>]
let main argv =

    printfn "Количество элементов и список:"

    let list = Program.readL (Console.ReadLine() |> Convert.ToInt32)
   
    printfn "Результат: %d" (proc list)

    0