let brokenPrinterAgent = MailboxProcessor.Start(fun inbox ->
    let rec messageLoop() = async{
        let! (msg:string) = inbox.Receive()
        let response = match msg with
        |"Что вершит судьбу человека в этом мире?" -> " Некое незримое существо или закон? Подобно длани господней парящей над миром. По крайней мере, истина - то, что человек не властен даже над своей волей "
        |"Жизнь человека определяться тем, что он считает истинным и правильным." -> " Это и формирует нашу реальность. Вот только что такое истина? Всего-лишь понятие, и реальность может оказаться миражем. А быть может люди живут в мире собственных иллюзий?"
        |"Слушай когда вернемся сделай что нибудь со своими волосами." -> "Я не вернусь в антейку."
        |"Поражение — это смерть." -> " Победа — жизнь. (ауф)"
        |_ -> "бро это не тот аниме"
        printfn "%s" response
        return! messageLoop()
        }
    messageLoop()
    )
let Spike = brokenPrinterAgent
let rec say () =
    let message = System.Console.ReadLine()
    if not (System.String.IsNullOrEmpty message) then 
        Spike.Post(message)
        say()    
let ForDemo = 
    printfn "Че типо дофига анимешник, давай докажи"
    say()
    0