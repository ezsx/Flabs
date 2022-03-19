open System

let answer lang = 
    match lang with
        |"F#" | "Prolog" -> printfn "Подлиза"
        |"python" -> printfn "ясно лох"
        |"С++" -> printfn "а че у дурова конкурс не выйграл на маски в тг?"
        |"ruby" -> printfn "ты ваще в курсах что это?"
        |"css" -> printfn "ты че даун?"
        |"С#" -> printfn "ясно дефчушка"
        |"php" -> printfn "а че не css?"
        |other -> printfn "%s"(lang + "чел мне лень писать ответ под твой ЯП, но если это abap то я тебе сочувствую")

[<EntryPoint>]
let main argv =
    printfn "Введи любимый язык программирования:"
    let input = Console.ReadLine()
    
    answer input
    0