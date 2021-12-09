module HW5.Parser

open HW5.ResultBuilder

let (>>=) x f = Result.bind f x
   
let checkArgumentCount (args:string[]) =
    match args.Length with
    | 3 -> Ok args
    | _ -> Error $"The program requires 3 arguments to work, but the {args.Length} was entered"

let tryParseOperation (args:string[]) =
    result{
        let! operation =
            match args.[1] with
            | "+" -> Ok Operations.Plus
            | "-" -> Ok Operations.Minus
            | "*" -> Ok Operations.Multiply
            | "/" -> Ok Operations.Divide
            | _ -> Error $"The calculator does not recognize this operation: {args.[1]}"  
        return  args.[0], operation, args.[2]
    }
    
let tryParseValue arg =
    try Ok(arg |> decimal)
    with _ -> Error $"Wrong format of argument: {arg}"

let tryParseValues (a, operation, b) =
    result{
        let! val1 = tryParseValue a
        let! val2 = tryParseValue b
        return val1, operation, val2 
    }
        
let tryParseArgs args=
    checkArgumentCount args >>= tryParseOperation >>= tryParseValues  