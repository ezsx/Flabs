open System

let rec read_L n = 
    if n=0 then []
    else
        let head = Console.ReadLine() |> Convert.ToInt32
        let tail = read_L (n-1)
        head::tail

let rec print_L = function
    | [] -> ()
    | head::tail -> 
        printfn "%O" head
        print_L tail

let L_to_3 list func =
    let rec L_to_3_Internal L func curL =
        match list with
        | [] -> curL
        | el0::t ->
            let el1 = if t <> [] then t.Head else 1
            let el2 = if t <> [] then (if t.Tail <> [] then t.Tail.Head else 1) else 1
            let newElem = func el0 el1 el2
            let newL = curL @ [newElem] // Сдвигаем лист ещё на 2 вправо
            let shiftedL = if t <> [] then (if t.Tail <> [] then t.Tail.Tail else []) else []
            L_to_3_Internal shiftedL func newL
    L_to_3_Internal list func []

[<EntryPoint>]
let main argv =
    printfn "Укажите количество элементов в первой строке а затем элементы списка последовательно в каждой строке: "
    let L = read_L (Console.ReadLine() |> Convert.ToInt32)
    let new_l = L_to_3 L (fun x y z -> x + y + z)
    printfn "Результат:"
    print_L new_l
    0