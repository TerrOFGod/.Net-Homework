module HW6Tests.ParserTests

open HW5
open Xunit

[<Theory>]
[<InlineData("plus", Operations.Plus)>]
[<InlineData("minus", Operations.Minus)>]
[<InlineData("multiply", Operations.Multiply)>]
[<InlineData("divide", Operations.Divide)>]
let tryParseArgs_Parse_Correct (operation, excepted) =
    let args = [|"435";operation;"113"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Ok((decimal 435 ),excepted,(decimal 113)), check)
    
[<Fact>]
let tryParseArgs_Parse_FloatAndDouble () =
    let args = [|"4.5";"plus";"2.2"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Ok((decimal 4.5 ),Operations.Plus,(decimal 2.2)), check)
    
[<Fact>]
let tryParseArgs_NotNumber_WillReturnWrongArgFormatInt () =
    let args = [|"4";"plus";"&"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Error "Wrong format of argument: &", check)
    
[<Fact>]
let tryParseArgs_NotOperation_WillReturnWrongOperation () =
    let args = [|"21";"?";"37"|]
    let check = Parser.tryParseArgs args 
    Assert.Equal(Error "The calculator does not recognize this operation: ?", check)
   