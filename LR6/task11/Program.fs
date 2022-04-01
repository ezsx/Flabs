open System

let rec readL n = 
    if n=0 then []
    else
        let head = Console.ReadLine() |> Convert.ToInt32
        let tail = readL (n-1)
        head::tail

let rec printL = function
    | [] -> ()
    | head::tail -> 
        printfn "%O" head
        printL tail

let to3 L func =
    let rec to3Internal L func curL =
        match L with
        | [] -> curL
        | el0::t ->
            let el1 = if t <> [] then t.Head else 1
            let el2 = if t <> [] then (if t.Tail <> [] then t.Tail.Head else 1) else 1
            let newel = func el0 el1 el2
            let newL = curL @ [newel]
            let shiftL = if t <> [] then (if t.Tail <> [] then t.Tail.Tail else []) else []
            to3Internal shiftL func newL
    to3Internal L func []

[<EntryPoint>]
let main argv =
    printfn "Количество элементов и список:"
    let L = readL (Console.ReadLine() |> Convert.ToInt32)
    let new_L = to3 L (fun x y z -> x + y + z)
    printfn "Результат: "
    printL new_L
    0