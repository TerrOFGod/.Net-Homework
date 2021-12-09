using System.Globalization;
using HW8.Interface;
using static HW8.Enum.Operations;

namespace HW8.Logic
{
    public class Calculator : ICalculator
    {
        private static string Add(double v1, double v2)
            => (v1 + v2).ToString(CultureInfo.InvariantCulture);

        private static string Subtract(double v1, double v2)
            => (v1 - v2).ToString(CultureInfo.InvariantCulture);

        private static string Multiply(double v1, double v2)
            => (v1 * v2).ToString(CultureInfo.InvariantCulture);

        private static string Divide(double v1, double v2)
        {
            if (v1 == 0 && v2 == 0) return "The result is undefined";
            return v2 == 0 ? "You can't divide by zero" : 
                (v1 / v2).ToString(CultureInfo.InvariantCulture);
        }

        public string Calculate(string val1, string operation, string val2)
        {
            var isDoubles = Parser.TryParseValues(val1, val2, 
                out var v1, out var v2);
            if (isDoubles != "correct") return isDoubles;
            var isOperation = Parser.TryParseOperation(operation, out var op);
            if (!isOperation) 
                return $"The calculator does not recognize this operation: {operation}";
            return op switch
            {
                Plus => Add(v1,v2),
                Minus => Subtract(v1,v2),
                Multiplication => Multiply(v1,v2),
                _ => Divide(v1,v2) 
            };
        }
    }
}