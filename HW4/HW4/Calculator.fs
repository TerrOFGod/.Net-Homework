module HW4.Calculator

let calculate operation val1 val2 =
    let xd = val1 |> double
    let yd = val2 |> double
    match operation with
    | Plus -> xd + yd
    | Minus -> xd - yd
    | Multiply -> xd * yd
    | _ -> xd / yd