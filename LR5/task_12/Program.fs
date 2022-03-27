open System

let answer lang = 
    match lang with
        |"F#" | "Prolog" ->   "Подлиза"
        |"python" ->   "ясно лох"
        |"С++" ->   "а че у дурова конкурс не выйграл на маски в тг?"
        |"ruby" ->   "ты ваще в курсах что это?"
        |"css" ->   "ты че даун?"
        |"С#" ->   "ясно дефчушка"
        |"php" ->   "а че не css?"
        |other ->   (lang + "чел мне лень писать ответ под твой ЯП, но если это abap то я тебе сочувствую")

[<EntryPoint>]
let main argv =
      
    //12.1
    (Console.ReadLine>>answer>>Console.WriteLine)()
    
    //12.2
    let f input (output:string->unit) answer = output(answer(input()))
    f Console.ReadLine Console.WriteLine answer
    0
