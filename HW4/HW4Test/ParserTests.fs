module Tests.ParserTests

open System
open HW4
open Xunit

[<Theory>]
[<InlineData("+", Operations.Plus)>]
[<InlineData("-", Operations.Minus)>]
[<InlineData("*", Operations.Multiply)>]
[<InlineData("/", Operations.Divide)>]
let ``tryParseArgs_Operation_Parse_Correct`` (operation, operationExpected) =
    let args = [|"435";operation;"113"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = Operations.Plus
    let check = Parser.tryParseArgs args &operationResult &val1 &val2
    Assert.Equal(ErrorCodes.Correct, check)
    Assert.Equal(435, val1)
    Assert.Equal(operationExpected, operationResult)
    Assert.Equal(113, val2)
    
[<Fact>]
let ``tryParseArgs_NotNumber_WillReturnWrongArgFormatInt`` () =
    let args = [|"4";"+";"3.6"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = Operations.Plus
    let check = Parser.tryParseArgs args &operationResult &val1 &val2
    Assert.Equal(ErrorCodes.WrongArgFormat, check)
    
[<Fact>]
let ``tryParseArgs_NotOperation_WillReturnWrongOperation`` () =
    let args = [|"21";"?";"37"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = Operations.Plus
    let check = Parser.tryParseArgs args &operationResult &val1 &val2
    Assert.Equal(ErrorCodes.WrongOperation, check)

[<Fact>]
let ``tryParseArgs_WrongArgsCount_WillReturnWrongArgCount`` () =
    let args = [|"11";"*";"142";"dds"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = Operations.Plus
    let check = Parser.tryParseArgs args &operationResult &val1 &val2
    Assert.Equal(ErrorCodes.WrongArgCount, check)    