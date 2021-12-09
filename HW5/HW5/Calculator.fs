module HW5.Calculator

open HW5.ResultBuilder

let divideBy numerator denominator =
    if denominator = decimal 0 then Error "Denominator is zero(0)"
    else Ok(numerator / denominator)
    
let calculate (val1, operation, val2) =
    result{
        match operation with
        | Operations.Plus -> return val1 + val2
        | Operations.Minus -> return val1 - val2
        | Operations.Multiply -> return val1 * val2
        | _ -> let! res =  divideBy val1 val2
               return res
    }