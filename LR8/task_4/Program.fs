open System

[<AbstractClass>]
type Fig() =
    abstract member Square: unit -> double

type IPrint = interface 
    abstract member Print: unit -> unit
    end

type Rectangle(ap:double, bp:double)=
    inherit Fig()
    let mutable width = ap
    let mutable height = bp
    member this.ReadWriteWidth
        with get() = width
        and set(value) = width <-value
    member this.ReadWriteHeight
        with get() = height
        and set(value) = height <-value
    override this.Square() = (height * width)
    override this.ToString() = "Прямоугольник. Ширина: "+ width.ToString() + ", высота: " + height.ToString() + ", площадь: "+ this.Square().ToString()
    
    interface IPrint with
        member this.Print(): unit = Console.WriteLine(this.ToString())
        end
            
type Square(ap:double,bp:double)=
    inherit Rectangle(ap,bp)
    member this.side: double = ap
    new(a:double) = Square(a,a)
    override this.ToString() = "Квадрат. Сторона: "+ this.side.ToString() + ", площадь: "+ this.Square().ToString()
    interface IPrint with
        member this.Print(): unit = Console.WriteLine(this.ToString())
        end

type Circle(ap:double)=
    inherit Fig()
    let mutable radius = ap
    let pi = Math.PI
    member this.ReadWriteRadius
        with get() = radius
        and set(value) = radius <-value
    override this.Square() = pown radius 2 * pi
    override this.ToString() = "Круг. Радиус: "+ radius.ToString() + ", площадь: "+ this.Square().ToString()
    interface IPrint with
        member this.Print(): unit = Console.WriteLine(this.ToString())
        end

type Gfig = 
    |Rectangl of double * double
    |Squar of double
    |Circl of double 

let pickFigure (a:double, b:double, c:double):Gfig =
    match c with
    |1.0-> Rectangl (a, b)
    |2.0-> Squar a
    |3.0-> Circl b

let cSqr (ap:double) (bp:double) (cp:double) = 
    let figur = pickFigure(ap,bp,cp)
    let res =
        match figur with
            |Rectangl(a,b) -> a*b
            |Squar(c)-> c*c
            |Circl(r)-> r*Math.PI
    res
[<EntryPoint>]
let main argv =
    let Recrent = Rectangle(16.0,20.0)
    Console.WriteLine (Recrent.Square())
    Console.WriteLine(Recrent.ToString())

    let iLame = Square(7.0)
    Console.WriteLine(iLame.Square())
    Console.WriteLine(iLame.ToString())

    let makataO = Circle(3.0)
    Console.WriteLine(makataO.Square())
    Console.WriteLine(makataO.ToString())
    0 