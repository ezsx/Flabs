// Learn more about F# at http://fsharp.org

open System

let glob list =
    let rec g list max= 
        match list with
        |[]->max
        |h::t-> 
               let newMax=if h>max then h else max
               let newList=t
               g newList newMax
    g list list.Head

let Poisk list n max=
    let rec p list n init=
        match list with
        |[]-> init
        |h::t ->
           if n<>1 then 
             let newList= t
             let newn=n-1
             p newList newn init
              else 
                   if h = max then init=true else init=false
    p list n true
let RES bool =
    let res = if bool<>true then printfn "Результат: Нет" else printf "Результат: Да"
    res

[<EntryPoint>]
let main argv =

    printfn "Количество элементов и список:"

    let list = Program.read_L (Console.ReadLine() |> Convert.ToInt32)
    
    printfn "Введите индекс:"

    RES (Poisk list (System.Convert.ToInt32(System.Console.ReadLine())) (glob list))
    
    0