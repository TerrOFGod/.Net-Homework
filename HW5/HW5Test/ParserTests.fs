module Tests.ParserTests

open HW5
open Xunit

[<Theory>]
[<InlineData("+", Operations.Plus)>]
[<InlineData("-", Operations.Minus)>]
[<InlineData("*", Operations.Multiply)>]
[<InlineData("/", Operations.Divide)>]
let tryParseArgs_Parse_Correct (operation, excepted) =
    let args = [|"435";operation;"113"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Ok((decimal 435 ),excepted,(decimal 113)), check)
    
[<Fact>]
let tryParseArgs_Parse_FloatAndDouble () =
    let args = [|"4.5";"+";"2.2"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Ok((decimal 4.5 ),Operations.Plus,(decimal 2.2)), check)
    
[<Fact>]
let tryParseArgs_NotNumber_WillReturnWrongArgFormatInt () =
    let args = [|"4";"+";"&"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Error "Wrong format of argument: &", check)
    
[<Fact>]
let tryParseArgs_NotOperation_WillReturnWrongOperation () =
    let args = [|"21";"?";"37"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Error "The calculator does not recognize this operation: ?", check)

[<Fact>]
let tryParseArgs_WrongArgsCount_WillReturnWrongArgCount () =
    let args = [|"11";"*";"142";"dds"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Error "The program requires 3 arguments to work, but the 4 was entered", check)    