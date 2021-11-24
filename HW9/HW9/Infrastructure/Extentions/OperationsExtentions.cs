using System.Linq.Expressions;
using HW9.Infrastructure.Enums;
using static HW9.Infrastructure.Enums.Operations;

namespace HW9.Infrastructure.Extentions
{
    public static class OperationsExtentions
    {
        public static bool TryParse(this string str, out Operations operation)
        {
            operation = str switch
            {
                "+" => Plus,
                "-" => Minus,
                "*" => Multiplication,
                "/" => Division,
                "(" => LBracket,
                ")" => RBracket,
                _   => Undefined
            };

            return operation != Undefined;
        }
        
        public static BinaryExpression TryConvertToExpression(this Operations operation, 
            Expression left, Expression right) 
            => operation switch 
            {
                Plus             => Expression.Add(left, right),
                Minus            => Expression.Subtract(left, right),
                Division         => Expression.Divide(left, right),
                Multiplication   => Expression.Multiply(left, right)
            };
    }
}