using System.Collections.Generic;
using System.Linq;
using HW13.Infrastructure.Enums;
using HW13.Infrastructure.Exceptions;

namespace HW13.Infrastructure.Extentions
{
    public static class StringExtentions
    {
        public static bool TrySplit(this string str, out List<string> elements)
        {
            elements = new List<string>();
            
            var elemList = str.ToLower()
                .Replace("pl", "+")
                .Split(' ');
            
            foreach (var elem in elemList)
            {
                if (!elem.TryAdd(elements)) return false;
            }
            
            return true;
        }

        private static bool TryAdd(this string elem, ICollection<string> elements)
        {
            if (elem[0] == '(' && elem.Length > 1)
            {
                elements.Add(elem[0].ToString());
                elements.Add(elem[1..]);
                return true;
            }

            if (elem.Last() == ')' && elem.Length > 1)
            {
                elements.Add(elem[..^1]);
                elements.Add(elem.Last().ToString());
                return true;
            }

            if (elem.TryParse(out decimal val))
            {
                elements.Add(elem);
                return true;
            }

            if (!elem.TryParse(out Operations operation)) return false;
            
            elements.Add(elem);
            return true;
        }

        public static void CheckValidness(this string str)
        {
            if (string.IsNullOrEmpty(str)) 
                throw new EmptyExpressionException("User enter null or empty string");
            var balance = 0;
            foreach (var e in str)
            {
                if (balance < 0) 
                    throw new InvalidSyntaxException("Expression can not start with right bracket");
                
                switch (e)
                {
                    case '(':    
                        balance++;    
                        break;
                    case ')':    
                        balance--;    
                        break;
                }
            }

            switch (balance)
            {
                case > 0:
                    throw new InvalidSyntaxException("Expression have wrong balance of brackets(l more r)");
                case < 0:
                    throw new InvalidSyntaxException("Expression have wrong balance of brackets(l less r)");
            }
        }

        public static bool TryParse(this string str, out decimal value) 
            => decimal.TryParse(str, out value);
    }
}