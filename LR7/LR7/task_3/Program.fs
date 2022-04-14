open System

let rec readL n =
    printfn "Элементы списка: "
    List.init(n) (fun index->Console.ReadLine()|>Int32.Parse)
let readN = 
    printfn "Количество элементов:"
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readL n
let rec printL L=
    List.iter(fun x->printfn $"{x}") L
let check L n =
    if List.item n L = List.max L then true else false
let RES bool =
    let res = if bool<>true then printfn "Результат: Нет" else printf "Результат: Да"
    res
[<EntryPoint>]
let main argv =
    let L=readN
    printfn "Индекс:"
    let n = System.Convert.ToInt32(System.Console.ReadLine()) - 1
    RES (check L n)
    0 