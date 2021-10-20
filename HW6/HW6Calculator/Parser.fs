module HW5.Parser

open System
open HW5.ResultBuilder

let (>>=) x f = Result.bind f x

let tryParseOperation (args:string[]) =
    result{
        let! operation =
            match args.[1] with
            | "plus" -> Ok Operations.Plus
            | "minus" -> Ok Operations.Minus
            | "multiply" -> Ok Operations.Multiply
            | "divide" -> Ok Operations.Divide
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
    
let checkDivide (a: decimal, operation, b: decimal) =
    result{
        let! res = match operation with
                   | Operations.Divide -> match b with
                                          | 0m -> Error "Divide by zero(0)"
                                          | _ -> Ok(a, operation, b)
                   | _ -> Ok(a, operation, b)
        return res
    }
    
                           
        
let tryParseArgs args=
    tryParseOperation args>>= tryParseValues  >>= checkDivide