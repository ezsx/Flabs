open System
let rec rStr n str=
    match n with 
    |0 -> str
    |_ -> 
        let s = Console.ReadLine()
        let newstr = str @ [s]
        let n1 = n - 1
        rStr n1 newstr

let rec wrstrl = function
    |[] -> let z = System.Console.ReadKey()
           0
    | (head : string)::tail -> 
                      System.Console.WriteLine(head)
                      wrstrl tail
let rec writePairs list =
    match list with
    |[] -> 0
    |_->
        Console.Write ("({0},{1}) ",fst list.Head,snd list.Head)
        writePairs list.Tail

let rec writeFrequencedList = function
    |[] -> let z = System.Console.ReadKey()
           0
    | head::tail -> 
                      writePairs head 
                      Console.WriteLine " "
                      writeFrequencedList tail
//кортеж вида: (буква : её частота в строке)
let freqList (s:string) = 
    let res = List.map (fun (x:char,x1:int)  -> (x , (Convert.ToDouble x1 ) / (Convert.ToDouble (String.length (String.filter (fun x-> x <> ' ') s)) )) )(List.countBy id (Seq.toList (s.ToLower())))
    res
//вычисляем РАЗНОСТЬ встречаемости букв в строке и алфавите
let Difference (frequedCharList: (string * ((char * float) list))) (alphabet:(char*float) list) =
    let difference = snd (List.maxBy (fun x-> snd x) (snd frequedCharList)) - snd (List.find (fun x -> (fst x) = (fst (List.maxBy (fun x-> snd x) (snd frequedCharList)))) alphabet)
    difference 
let ts1 str =    
    wrstrl (List.map (fun x-> fst x )(List.sortBy (fun x -> (Difference x (freqList (String.filter( fun x -> x <> ' ') (String.concat ("":string) (str))))) ) (List.map2(fun x y -> (x,y)) str (List.map (fun x -> freqList(x)) str) )))
//перевод аски 
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let str = rStr n []
    ts1 str
    0 