module HW5.Program

let (>>=) x f = Result.bind f x

[<EntryPoint>]
let main args =
    let r = Parser.tryParseArgs args >>= Calculator.calculate
    match r with
    | Ok result -> printf $"{result}"
                   0
    | Error error -> printf $"{error}"
                     1