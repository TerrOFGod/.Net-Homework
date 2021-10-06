module HW4Tests.CalculatorTests

open Xunit
open HW4

[<Theory>]
[<InlineData(6, 9, 15)>]
[<InlineData(17, -7, 10)>]
[<InlineData(-2, 9, 7)>]
[<InlineData(-3, -5, -8)>]
let ``Calculate_Plus_WillReturnCorrectResult`` (val1, val2, expected) =
    let result = Calculator.calculate Operations.Plus val1 val2
    Assert.Equal(expected, result)
    
[<Theory>]
[<InlineData(5, 7, -2)>]
[<InlineData(10, -7, 17)>]
[<InlineData(-7, 7, -14)>]
[<InlineData(-25, -36, 11)>]
let ``Calculate_Minus_WillReturnCorrectResult`` (val1, val2, expected) = 
    let result = Calculator.calculate Operations.Minus val1 val2
    Assert.Equal(expected, result)
    
[<Theory>]
[<InlineData(4, 3, 12)>]
[<InlineData(6, -3, -18)>]
[<InlineData(-5, 6, -30)>]
[<InlineData(-7, -7, 49)>]
let ``Calculate_Multiply_WillReturnCorrectResult`` (val1, val2, expected) = 
    let result = Calculator.calculate Operations.Multiply val1 val2
    Assert.Equal(expected, result)

[<Theory>]
[<InlineData(6, 2, 3)>]
[<InlineData(7, -1, -7)>]
[<InlineData(-10, 5, -2)>]
[<InlineData(-24, -6, 4)>]
[<InlineData(7, 2, 3.5)>]
let ``Calculate_Divide_WillReturnCorrectResult`` (val1,  val2, expected) = 
    let result = Calculator.calculate Operations.Divide val1 val2
    Assert.Equal(expected, result)