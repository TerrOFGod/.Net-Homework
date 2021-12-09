module HW5.Calculator

let calculate (val1: decimal, operation, val2) =
    match operation with
    | Operations.Plus -> val1 + val2
    | Operations.Minus -> val1 - val2
    | Operations.Multiply -> val1 * val2
    | _ ->  val1 / val2
  