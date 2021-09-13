using hw1;
using Xunit;

namespace HW1Tests
{
    public class ParserTests
    {
        private const int Correct = 0;
        private const int WrongArgCount = 1;
        private const int WrongArgFormat = 2;
        private const int WrongOperation = 3;
        
        [Theory]
        [InlineData("+", Operations.Plus)]
        [InlineData("-", Operations.Minus)]
        [InlineData("*", Operations.Multiply)]
        [InlineData("/", Operations.Divide)]
        public void TryParseArguments_Return_Correct(string operation, Operations operationExpected)
        {
            var args = new[] { "6", operation, "35" };
            var isValid = Parser.TryParseArguments(args, out var operationActual, out var val1, out var val2);
            Assert.Equal(Correct, isValid);
            Assert.Equal(6, val1);
            Assert.Equal(operationExpected, operationActual);
            Assert.Equal(35, val2);
        }
        
        [Fact]
        public void TryParseArguments_WrongCount_WillReturnWrongArgCount()
        {
            var args = new[] { "7", "+"};
            var check = Parser.TryParseArguments(args, out _, out _, out _);
            Assert.Equal(WrongArgCount, check);
        }
        
        [Fact]
        public void TryParseArguments_NotInt_WillReturnWrongArgFormat()
        {
            var args = new[] { "7", "*", "4.6" };
            var isValid = Parser.TryParseArguments(args, out _, out _, out _);
            Assert.Equal(WrongArgFormat, isValid);
        }
        
        [Fact]
        public void TryParseArguments_WrongOperation_WillReturnWrongOperation()
        {
            var args = new[] { "51", "%", "25" };
            var check = Parser.TryParseArguments(args, out _, out _, out _);
            Assert.Equal(WrongOperation, check);
        }
    }
}