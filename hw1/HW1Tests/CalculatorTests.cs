using System;
using hw1;
using Xunit;

namespace HW1Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(Operations.Plus, 6, 9, 15)]
        [InlineData(Operations.Plus, -2, 9, 7)]
        [InlineData(Operations.Plus, 17, -7, 10)]
        [InlineData(Operations.Plus, -3, -5, -8)]
        public void Calculate_Plus_Return_Correct_Result(Operations operation,
            int val1, int val2, int excepted)
        {
            var result = Calculator.Calculate(operation, val1, val2);
            Assert.Equal(excepted, result);
        }
        
        [Theory]
        [InlineData(Operations.Minus, 5, 7, -2)]
        [InlineData(Operations.Minus, 10, -7, 17)]
        [InlineData(Operations.Minus, -7, 7, -14)]
        [InlineData(Operations.Minus, -25, -36, 11)]
        public void Calculate_Minus_Return_Correct_Result(Operations operation,
            int val1, int val2, int excepted)
        {
            var result = Calculator.Calculate(operation, val1, val2);
            Assert.Equal(excepted, result);
        }
        
        [Theory]
        [InlineData(Operations.Multiply, 4, 3, 12)]
        [InlineData(Operations.Multiply, 6, -3, -18)]
        [InlineData(Operations.Multiply, -5, 6, -30)]
        [InlineData(Operations.Multiply, -7, -7, 49)]
        public void Calculate_Multiply_Return_Correct_Result(Operations operation,
            int val1, int val2, int excepted)
        {
            var result = Calculator.Calculate(operation, val1, val2);
            Assert.Equal(excepted, result);
        }
        
        [Theory]
        [InlineData(Operations.Divide, 6, 2, 3)]
        [InlineData(Operations.Divide, 7, -1, -7)]
        [InlineData(Operations.Divide, -10, 5, -2)]
        [InlineData(Operations.Divide, -24, -6, 4)]
        public void Calculate_Divide_Return_Correct_Result(Operations operation,
            int val1, int val2, int excepted)
        {
            var result = Calculator.Calculate(operation, val1, val2);
            Assert.Equal(excepted, result);
        }
    }
}