

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

let digitBypassWithPredicate number predicate =
    let rec procInternal x mult =
        if(x = 0) then mult
        else
            let newM = if predicate (x % 10) then mult*(x%10) else mult
            let newX = x / 10
            procInternal newX newM
    procInternal number 1

let rec nod x y =
    if x = 0 || y = 0 then x + y      
    else
        let newX = if x > y then x % y else x
        let newY = if x <= y then y % x else y
        nod newX newY

let dividersFunc x func init =
    let rec df x func init curDiv =
        if curDiv = 0 then init
        else
            let newInit= if x % curDiv = 0 then func init curDiv else init
            let newDiv = curDiv - 1
            df x func newInit newDiv
    df x func init x

let dividersFuncWithPredicate x predicate func init =
    let func1 init cur = if predicate cur then func init cur else init
    dividersFunc x func1 init

// LR5_17.1- Обход делителей числа с условием
let div_F_pred x predicate func init =
    let func1 init cur = if predicate cur then func init cur else init
    divideF x func1 init

let summ_del x =
    div_F_pred x (isPrime) (fun x y -> max x y) 1

let mult_num x =
    digitBypassWithPredicate x (fun x -> x%5<>0)

let nod_mega x=
    nod (dividersFuncWithPredicate x (fun x -> x%2 > 0 && not(isPrime x)) (fun x y -> max x y) 1) (digitBypassWithPredicate x (fun x -> true))
    
    

[<EntryPoint>]
let main argv =
    printfn "Число: "
    let x = Console.ReadLine() |> Int32.Parse

    //Найти максимальный простой делитель числа.
    let t181 = summ_del x
    printfn "максимальный простой делитель числа: %d" t181

    let t182 = mult_num x
    printfn "произведение цифр числа, не делящихся на 5: %d" t182

    let t183 = nod_mega x
    printfn "сумма всех делителей числа, взаимно простых с суммой
    цифр числа и не взаимно простых с произведением цифр числа: %d" t183

    0