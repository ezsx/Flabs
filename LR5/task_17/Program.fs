open System

let divideF x func init =
    let rec df x func init curDiv =
        if curDiv = 0 then init
        else
            let newInit= if x % curDiv = 0 then func init curDiv else init
            let newDiv = curDiv - 1
            df x func newInit newDiv
    df x func init x

let rec nod x y =
    if x = 0 || y = 0 then x + y      
    else
        let newX = if x > y then x % y else x
        let newY = if x <= y then y % x else y
        nod newX newY

let primesFunc x func init =
    let rec pf x func init curPrime =
        if curPrime <= 0 then init
            
        else
            let newInit = if nod x curPrime = 1 then func init curPrime else init
            let newPrime = curPrime - 1
            pf x func newInit newPrime
    pf x func init x

// LR5_17.1- Обход делителей числа с условием
let div_F_pred x predicate func init =
    let func1 init cur = if predicate cur then func init cur else init
    divideF x func1 init

// LR5_17.2 - Обход взаимнопростых чисел с условием
let prime_with_Pred x predicate func init =
    let func1 init cur = if predicate cur then func init cur else init
    primesFunc x func1 init

[<EntryPoint>]
let main argv =
    printfn "Числа: "
    let x = Console.ReadLine() |> Int32.Parse

    //Сумма делителей числа, которые меньше 30
    let t171 = div_F_pred x (fun x -> x < 30) (fun x y -> x + y) 0
    printfn "результат_1: %d" t171

    //Сумма взаимно простых компонентов числа x, которые больше 30
    let t172 = prime_with_Pred x (fun x -> x > 30) (fun x y -> x + y) 0
    printfn "результат_2: %d" t172
    0