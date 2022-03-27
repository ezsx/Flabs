

open System

let isPrime x =
    let rec isPrimeInternal divCandidate =
        if divCandidate >= x then true
        else
            if (x % divCandidate = 0) then false
            else 
                let newDivCandidate = divCandidate + 1
                isPrimeInternal newDivCandidate
    isPrimeInternal 2

let divideF x func init =
    let rec df x func init curDiv =
        if curDiv = 0 then init
        else
            let newInit= if x % curDiv = 0 then func init curDiv else init
            let newDiv = curDiv - 1
            df x func newInit newDiv
    df x func init x


// LR5_17.1- Обход делителей числа с условием
let div_F_pred x predicate func init =
    let func1 init cur = if predicate cur then func init cur else init
    divideF x func1 init

let summ_del x =
    div_F_pred x (isPrime) (fun x y -> max x y) 1

[<EntryPoint>]
let main argv =
    printfn "Число: "
    let x = Console.ReadLine() |> Int32.Parse

    //Найти максимальный простой делитель числа.
    let t181 = summ_del x
    printfn "результат: %d" t181

    0