module HW4.Program

[<EntryPoint>]
let main args =
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operation = Operations.Plus
    let check = Parser.tryParseArgs args &operation &val1 &val2
    if check = ErrorCodes.Correct then
        printf $"Result: {Calculator.calculate operation val1 val2}"
        0
    else
        printf $"Arguments have error(s)"
        int check