open System

let ChoiceFunction  y x = 
    match y with
    | 1 -> Program.dividersFuncWithPredicate x (fun x -> Program.isPrime x) (fun x y -> max x y) 0
    | 2 -> Program.digitBypassWithPredicate x (fun x -> x % 5 <> 0)
    | _ -> Program.nod_mega x

[<EntryPoint>]
let main argv =

    Console.WriteLine("Введите номер функции и число: ")
    let data = (Console.ReadLine() |> Int32.Parse, Console.ReadLine() |> Int32.Parse)
    let result = ChoiceFunction (fst data) (snd data)
    printfn "Результат: %d"  result   
    0