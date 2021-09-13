using System;

namespace hw1
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var isValid = Parser.TryParseArguments(args, out var operation,
                out var val1, out var val2);
            if (isValid != 0) return isValid;
            
            var result = Calculator.Calculate(operation, val1, val2);
            Console.WriteLine($"Result is: {result}");
            return 0;
        }
    }
}
