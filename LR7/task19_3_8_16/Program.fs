open System
open Microsoft.FSharp.Core
type t_3  = {rnd: int
             word_3: string[]
             count: int
             Text: string}
type t_8 ={count_8: int
           word_8: string[]}
type t_16 ={word_18: string[]}
[<EntryPoint>]
let main argv =
    let word_in = Console.ReadLine().Split(' ')
    let word_in_2 = Console.ReadLine().Split(' ')
    let initial_3 = {rnd = Random.Shared.Next(0,word_in.Length) ;word_3 = word_in; count = word_in.Length; Text=""}
    let permut_word_3 = 
        (word_in,initial_3) ||> Array.foldBack (fun a acc ->
            let n_rnd = Random.Shared.Next(0,acc.count)
            let n_text = acc.Text  + acc.word_3[n_rnd] + " "
            let n_word = acc.word_3|>Array.filter (fun l -> l <> (acc.word_3[n_rnd]))
            {acc with
                Text = n_text
                word_3 = n_word
                count = acc.count - 1
                rnd = n_rnd}
        ) 
    let initial_8 = {count_8 = 0; word_8=word_in}
    let count_word_chet_8 = 
        (word_in,initial_8) ||> Array.foldBack (fun a acc ->
            let n_count = if (((Array.last acc.word_8).Length )% 2 = 0) then acc.count_8+1 else acc.count_8
            let n_word = acc.word_8|>Array.filter (fun l -> l <> (Array.last acc.word_8))
            {acc with
                count_8 = n_count
                word_8 = n_word}        
        )
    let initial_18 = {word_18 = [||]}
    let sort_18 = 
        (word_in_2,initial_18) ||> Array.foldBack (fun a acc ->
            let white_word = (Array.find (fun l -> l = "белый") word_in_2)
            let blue_word = (Array.find (fun l -> l = "синий" ) word_in_2)
            let red_word = (Array.find (fun l -> l = "красный") word_in_2)
            let n_word = Array.append (Array.append (Array.append [||] [|white_word|]) [|blue_word|]) [|red_word|] 
            {acc with
                word_18 = n_word}        
        )
    printfn "%A" word_in
    printfn "%A" count_word_chet_8.count_8
    printfn "%A" permut_word_3.Text
    printfn "%A" sort_18.word_18
    0