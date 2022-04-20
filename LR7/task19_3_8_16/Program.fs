open System
let wordslen (s:string) = s.Split(' ') |> Array.map (fun w -> w.Length)
let wordsin = Console.ReadLine().Split(' ')
[<EntryPoint>]
let main argv =
    for i in wordsin do wordsin[Random.Shared.Next(0,wordsin.Length)] = wordsin[i]
    0