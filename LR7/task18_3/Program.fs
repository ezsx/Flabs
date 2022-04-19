open System (*Объединить два произвольных массива в один.*)
[<EntryPoint>]
let main argv =
    printf "%A" (Array.concat [ List.toArray [ for i in 1 .. (Convert.ToInt32(Console.ReadLine())) -> Convert.ToInt32(Console.ReadLine()) ]; List.toArray [ for i in 1 .. (Convert.ToInt32(Console.ReadLine())) -> Convert.ToInt32(Console.ReadLine()) ];])
    0