module HW6Tests.CalculatorTests

open Xunit
open HW5
open HW5.ResultBuilder


[<Theory>]
[<InlineData(6.1, 8.9, 15)>]
[<InlineData(17.3, -7.3, 10)>]
[<InlineData(-2.6, 9.6, 7)>]
[<InlineData(-3.37, -4.63, -8)>]
let Calculate_Plus_WillReturnCorrectResult (val1, val2, expected) =
     let result = Calculator.calculate (val1, Operations.Plus, val2)
     Assert.Equal(expected, result)
    
    
[<Theory>]
[<InlineData(5, 7, -2)>]
[<InlineData(10, -7, 17)>]
[<InlineData(-7, 7, -14)>]
[<InlineData(-25, -36, 11)>]
let Calculate_Minus_WillReturnCorrectResult (val1, val2, expected) = 
    let result = Calculator.calculate (val1, Operations.Minus, val2)
    Assert.Equal(expected, result)
    
[<Theory>]
[<InlineData(4, 3, 12)>]
[<InlineData(6, -3, -18)>]
[<InlineData(-5, 6, -30)>]
[<InlineData(-7, -7, 49)>]
let Calculate_Multiply_WillReturnCorrectResult (val1, val2, expected) = 
    let result = Calculator.calculate (val1, Operations.Multiply, val2)
    Assert.Equal(expected, result)

[<Theory>]
[<InlineData(6, 2, 3)>]
[<InlineData(7, -1, -7)>]
[<InlineData(-10, 5, -2)>]
[<InlineData(-24, -6, 4)>]
[<InlineData(7, 2, 3.5)>]
let Calculate_Divide_WillReturnCorrectResult (val1,  val2, expected) = 
    let result = Calculator.calculate (val1, Operations.Divide, val2)
    Assert.Equal(expected, result)

