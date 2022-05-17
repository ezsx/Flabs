// Learn more about F# at http://fsharp.org
open System
open System.Text.RegularExpressions
type driver_license(nam:string, surnam:string, birtDt:DateTime, plac:string, extDt: DateTime, expDt:DateTime,nm:string ) =
    member this.name:string = nam
    member this.surnam:string = surnam
    member this.birthDt:DateTime = birtDt
    member this.place:string = plac
    member this.extrDT:DateTime = extDt
    member this.exprDT:DateTime = expDt
    member this.num:string = nm
    override this.Equals(b) =
          match b with
          | :? driver_license as p -> (this.num) = (p.num)
          | _ -> false
    override this.GetHashCode() = this.num.GetHashCode()
    override this.ToString() = "\nВодительские права:"+"\n Имя: "+ this.name + "\n Фамилия: " + this.surnam+ "\n Дата рождения: "+ this.birthDt.ToShortDateString()  + "\n Место рождения: " + this.place+ "\n Дата выдачи: "+ this.extrDT.ToShortDateString() + "\n Дата конца срока: "+ this.exprDT.ToShortDateString() + "\n Номер: " + this.num.ToString()+"\n"

let driverLicenseNumEquality (dr1:driver_license) (dr2:driver_license) =
    if dr1.num = dr2.num then true
    else false

let (|Regex|) pattern input =
   let m = Regex.Match(input,pattern)
   if (m.Success) then Some m.Groups.[1].Value else None

let createDrLWithValidate = 
    let dtRegex = "^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
    //регулярка отсюда: https://overcoder.net/q/8601/regex-%D0%B4%D0%BB%D1%8F-%D0%BF%D1%80%D0%BE%D0%B2%D0%B5%D1%80%D0%BA%D0%B8-%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%82%D0%B0-%D0%B4%D0%B0%D1%82%D1%8B-%D0%B4%D0%B4-%D0%BC%D0%BC-%D0%B3%D0%B3%D0%B3%D0%B3#:~:text=%5E(%3F%3A(%3F%3A31(%5C/%7C%2D%7C%5C.)(%3F%3A0%3F%5B13578%5D%7C1%5B02%5D))%5C1%7C(%3F%3A(%3F%3A29%7C30)(%5C/%7C%2D%7C%5C.)(%3F%3A0,4(%3F%3A(%3F%3A1%5B6%2D9%5D%7C%5B2%2D9%5D%5Cd)%3F%5Cd%7B2%7D)%24
    let strRegex = "@[A-Z][a-z]*"
    let surname = Console.ReadLine()
    let name = Console.ReadLine()
    let (birthdayDT:string) = Console.ReadLine()
    let (place:string) = Console.ReadLine()
    let extDate = Console.ReadLine()
    let expDate = Console.ReadLine()
    let num = Console.ReadLine()
       
    if (Regex.IsMatch(name,strRegex) && Regex.IsMatch(surname,strRegex)
        && Regex.IsMatch(birthdayDT,dtRegex) && Regex.IsMatch(place,strRegex)&&
        Regex.IsMatch(extDate,dtRegex)&& Regex.IsMatch(expDate,dtRegex)&& Regex.IsMatch(num,"^[0-9]{2}[ ]{1}[0-9]{2}[ ]{1}[0-9]{6}$")) then 
        Some(driver_license(name,surname,DateTime.Parse birthdayDT,place,DateTime.Parse extDate,DateTime.Parse expDate, num))
    else
        None


[<EntryPoint>]
let main argv =
    let drL1 = driver_license("плохойпарень","хорошийпоц",DateTime.Parse "02.07.2000","Рига",DateTime.Parse "29.01.2020",DateTime.Parse "29.01.2030","11 22 027389")
    Console.WriteLine drL1
    let drL2 = driver_license("Платина","Бедолага",DateTime.Parse "02.06.1998","Прага",DateTime.Parse "01.02.2018",DateTime.Parse "01.02.2018","33 66 917389")
    Console.WriteLine drL2
    match driverLicenseNumEquality drL1 drL2 with
    |true-> Console.WriteLine("Номера документов совпадают")
    |false-> Console.WriteLine("Номера документов не совпадают")
    
    let q1 = createDrLWithValidate 
    match q1 with
    |driver_license -> Console.WriteLine "Объет успешно создан"
    |None->Console.WriteLine "Объект не создан"
    0 