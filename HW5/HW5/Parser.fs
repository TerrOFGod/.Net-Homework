module HW4.Parser

open System
    
let checkArgumentCount (args:string[]) =
    args.Length = 3

let tryParseOperation (arg:string) (operation: outref<Operations>) =
    operation <- match arg with
    | "+" -> Operations.Plus
    | "-" -> Operations.Minus
    | "*" -> Operations.Multiply
    | "/" -> Operations.Divide
    | _ -> Operations.Error
    
let tryParseValue (arg:string) (value: outref<int>) =
    if Int32.TryParse(arg, &value) then
        true
    else
        printf $"Value is not int: {arg}"
        false
        
let tryParseArgs (args:string[]) (operation: outref<Operations>) (val1: outref<int>) (val2: outref<int>) =
    tryParseOperation args.[1] &operation
    if tryParseValue args.[0] &val1 = false || tryParseValue args.[2] &val2 = false then
        ErrorCodes.WrongArgFormat
    elif checkArgumentCount args = false then
        printf $"The program requires 3 arguments to work, but the {args.Length} was entered"
        ErrorCodes.WrongArgCount
    elif operation = Operations.Error then
        printf $"The calculator does not recognize this operation: {args.[1]}"
        ErrorCodes.WrongOperation
    else
        ErrorCodes.Correct