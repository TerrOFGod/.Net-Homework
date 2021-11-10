using HW8.Controllers;
using HW8.Logic;
using Xunit;

namespace HW8Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("4", "plus", "3", "7")]
        [InlineData("32", "minus", "2", "30")]
        [InlineData("6", "division", "5", "1.2")]
        [InlineData("4,5", "multiplication", "2", "9")]
        public void Calculate_ValidArguments(string v1, string op, string v2, string excepted)
        {
            MakeGeneralPartTests(v1, op, v2, excepted);
        }
        
        [Theory]
        [InlineData("error1", "plus", "7", "Value is not double: error1")]
        [InlineData("44", "minus", "error2", "Value is not double: error2")]
        [InlineData("error1", "minus", "error2", "Value is not double: error1 and Value is not double: error2")]
        [InlineData("64", "error", "88", "The calculator does not recognize this operation: error")]
        [InlineData("66", "division", "0", "You can't divide by zero")]
        [InlineData("0", "division", "0", "The result is undefined")]
        public void Calculate_InvalidArguments(string v1, string op, string v2, string excepted)
        {
            MakeGeneralPartTests(v1, op, v2, excepted);
        }
        
        private static void MakeGeneralPartTests(string v1, string op, string v2, string excepted)
        {
            var result = new CalculatorController()
                .Calculate(new Calculator(), v1, op, v2);
            Assert.Equal(excepted, result);
        }
    }
}