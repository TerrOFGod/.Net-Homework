using HW8.Enum;

namespace HW8.Logic
{
    public class Parser
    {
        public static bool TryParseOperation(string str, out Operations result)
        {
            var correctView = char.ToUpper(str[0]) + str[1..str.Length].ToLower();
            var isOperation = System.Enum.TryParse(correctView, out result);
            return isOperation;
        }

        private static string TryParseValue(string str, out double result)
        {
            var isDouble = double.TryParse(str, out result);
            return !isDouble ? $"Value is not double: {str}" : "correct";
        }
        
        public static string TryParseValues(string first, string second, out double v1, out double v2)
        {
            var isDouble1 = TryParseValue(first, out v1);
            var isDouble2 = TryParseValue(second, out v2);
            if (isDouble1 != "correct" && isDouble2 != "correct") return isDouble1 + " and " + isDouble2;
            if (isDouble1 != "correct") return isDouble1;
            if (isDouble2 != "correct") return isDouble2;
            return "correct";
        }
    }
}