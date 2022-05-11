open System
type Maybe<'a> =
    | Just of 'a
    | Nothing 
//функтор 
let funktorMaybe f p =
    match p with
    | Just a -> Just (f a)
    | Nothing -> Nothing
//Аппликативный функтор
let appFunktorMaybe fp p =
    match fp, p with
    |Just f, Just a -> Just (f a)
    |_-> Nothing   
//Законы
let notChange x = x
let func_f x = x + 1
let func_g x = x * 2
[<EntryPoint>]
let main argv =
    let funktor = funktorMaybe (fun x-> x+1 ) (Just 2)
    Console.WriteLine(funktor)
    let appfunktor = appFunktorMaybe(Just(fun x->x+1))(Just 2)
    Console.WriteLine(appfunktor)
    //функтор
    //1 notChange – функция, которая возвращает неизменным значение аргумента => подъем этой функции в контекст не влияет на вычисление:
    // Подъем функции с одним аргументом и ее применение выполняет то же самое, что и map.
    Console.WriteLine (notChange funktor)
    Console.WriteLine (funktorMaybe notChange funktor)
    //2 Для двух функций f и g композиция их подъемов эквивалентна подъему композиции.
    let k1_1 = funktorMaybe func_f funktor
    let k1_2 = funktorMaybe func_g k1_1
    let k2 = funktorMaybe(func_f >> func_g) funktor
    Console.WriteLine("{0}, {1}",k1_2,k2)
    //аппликативный функтор
    //1 Нейтральный элемент Применение поднятой функции notChange к поднятому значению эквивалентно применению неподнятой функции notChange к неподнятому значению.
    Console.WriteLine (notChange appfunktor)
    Console.WriteLine (appFunktorMaybe (Just notChange) appfunktor)
    //2 Гомоморфизм Если y=f(x), то подъем функции f и значения х и применение к ним функции apply приведет к такому же результату, что и подъем y.
    let app_x = 1
    //let app_y = appFunktorMaybe func_f app_x -нельзя проверить средставами F#
    let apl_y = appFunktorMaybe (Just func_f) (Just app_x)
    Console.WriteLine("{0}",apl_y)
    //3 Закон 3 Аргументы apply можно менять местами.
    //4 Композиция функций apply ассоциативна. Из-за отсутствия встроенной функции <*> (apply) продемонстрировать проверку данного правила невозможно.
    0 