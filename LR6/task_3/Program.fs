open System

let Global_max L =
    let rec g L max= 
        match L with
        |[]->max
        |h::t-> 
               let newMax=if h>max then h else max
               let newL=t
               g newL newMax
    g L L.Head

let Find_max L n max=
    let rec p L n init=
        match L with
        |[]-> init
        |h::t ->
           if n<>1 then 
             let newL= t
             let newn=n-1
             p newL newn init
              else 
                   if h = max then init=true else init=false
    p L n true

let RES bool =
    let res = if bool<>true then printfn "Результат: Нет" else printf "Результат: Да"
    res

[<EntryPoint>]
let main argv =

    printfn "Количество элементов и список:"

    let L = Program.readL (Console.ReadLine() |> Convert.ToInt32)
    
    printfn "Введите индекс:"

    RES (Find_max L (System.Convert.ToInt32(System.Console.ReadLine())) (Global_max L))
    
    0