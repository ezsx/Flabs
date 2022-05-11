open FParsec
let ws = spaces
let str_ws s = pstring s .>> ws
let float_ws = pfloat .>> ws
let numberList = str_ws "[" >>. sepBy float_ws (str_ws ",") .>> str_ws "]"
let numberListFile = ws >>. numberList .>> eof
let (Success(y, _, _)) = run numberList "[1,  2,3 ,4  ,5]" //парсим строку с массивом и возвращаем ,например, его сумму
printf "%A" (List.sum y)