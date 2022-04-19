(* Для введенного числа N построить список неповторяющихся кортежей (a,b), таких, что существует пара (x,y): X*Y=N, НОД(X,Y)=d, a=X/d, b=Y/d .*)
open System
[<EntryPoint>]
let main argv =
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    let rec nod a b = if b = 0 then a else nod b (a % b)
    let res = List.map (fun x->(fst x / nod (fst x) (snd x)),(snd x /nod (fst x) (snd x))) (List.filter (fun x-> fst x * snd x=n) (List.allPairs [1..n] [1..n]))
    printfn "%A" res
    0 