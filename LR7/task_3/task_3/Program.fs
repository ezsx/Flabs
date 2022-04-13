open System
let rec readL n =
    printfn "Элементы списка: "
    List.init(n) (fun index->Console.ReadLine()|>Int32.Parse)
let readData = 
    printfn "Количество элементов:"
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readL n
let rec printL L=
    List.iter(fun x->printfn $"{x}") L
let check L n =
    if List.item n L = List.max L then true else false
[<EntryPoint>]
let main argv =
    let L=readData
    printfn "Индекс:"
    let n = System.Convert.ToInt32(System.Console.ReadLine()) - 1
    check L n|>Console.WriteLine
    0 