using System;
using hw1;
using Xunit;

namespace HW1Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(Operations.Plus, 5, 7, 12)]
        public void Calculate_Plus_Return_Correct_Result(Operations operation,
            int val1, int val2, int excepted)
        {
            var result = Calculator.Calculate(operation, val1, val2);
            Assert.Equal(excepted, result);
        }

    }
}