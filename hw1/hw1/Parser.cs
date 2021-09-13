using System;

namespace hw1
{
    public class Parser
    {
        private const int WrongArgCount = 1;
        private const int WrongArgFormat = 2;
        private const int WrongOperation = 3;

        public static int TryParseArguments(string[] args, out Operations operation, out int val1, out int val2)
        {
            operation = default;
            val1 = default;
            val2 = default;
            
            if (!CheckArgumentsCount(args))
                return WrongArgCount;
            
            if (!TryParseOperation(args[1], out operation))
                return WrongOperation;
            
            if (!(TryParseValue(args[0], out val1) && TryParseValue(args[2], out val2)))
            {
                return WrongArgFormat;
            }
            
            return 0;
        }
        
        private static bool TryParseValue(string args, out int val)
        {
            if (int.TryParse(args, out val)) 
                return true;
            Console.WriteLine($"Value is not int: {args}");
            return false;
        }

        private static bool TryParseOperation(string arg, out Operations operation)
        {
            var temp = arg switch
            {
                "+" => 0,
                "-" => 1,
                "*" => 2,
                "/" => 3,
                _ => 4
            };
            if (!(temp < 4))
            {
                operation = default;
                Console.WriteLine($"The calculator does not recognize this operation: {arg}");
                return false;
            }

            operation = (Operations) temp;
            return true;
        }

            private static bool CheckArgumentsCount(string[] args)
        {
            if (args.Length == 3) return true;
            Console.WriteLine($"The program requires 3 arguments to work, but the {args.Length} was entered");
            return false;
        }
    }
}