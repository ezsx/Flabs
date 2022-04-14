open System

let private getNewList list =
    let minElement = List.min list
    let indexOfMinElement = List.findIndex (fun element -> element = minElement) list
    let listBeforeMinElement = list.[0..(indexOfMinElement - 1)]
    let listAfterMinElement = list.[indexOfMinElement..(List.length list - 1)]
    listAfterMinElement @ listBeforeMinElement

let startTask =
    printf "Размер: "
    let listSize = Console.ReadLine() |> Convert.ToInt32
    let list = Program.readL listSize
    printf "Результат: "
    (getNewList list) |> Seq.iter (printf "%d ")
[<EntryPoint>]
let main argv =
    startTask
    0 