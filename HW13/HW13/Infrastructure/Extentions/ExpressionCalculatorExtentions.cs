using System.Collections.Generic;
using System.Linq.Expressions;
using HW13.Infrastructure.Enums;
using static HW13.Infrastructure.Constants.Dictionaries;
using static HW13.Infrastructure.Enums.Operations;

namespace HW13.Infrastructure.Extentions
{
    public static class ExpressionCalculatorExtentions
    {
        public static bool TryParse(this string str, out Expression expression)
        {
            expression = default;
            str.CheckValidness();
            
            if (!str.TrySplit(out var elements)) 
                return false;

            var expressions = new Stack<Expression>();
            var operations = new Stack<Operations>();

            foreach (var element in elements)
            {
                if (element.TryParse(out decimal number))
                    expressions.Push(Expression.Constant(number));
                else if (element.TryParse(out Operations operation))
                {
                    if (operation == RBracket)
                    {
                        var current = operations.Pop();
                        while (current != LBracket)
                        {
                            if (!expressions.TryAddExpression(current)) 
                                return false;
                            current = operations.Pop();
                        }
                    }

                    if (operations.Count != 0 && operation != LBracket && 
                        Priorities[operation] < Priorities[operations.Peek()])
                    {
                        var current = operations.Pop();
                        while (Priorities[operation] < Priorities[current])
                        {
                            if (!expressions.TryAddExpression(current)) 
                                return false;
                            if (operations.Count != 0)
                                current = operations.Pop();
                            else
                                break;
                        }
                    }

                    if (operation != RBracket)
                        operations.Push(operation);
                }
                else return false;
            }

            if (operations.Count != 0)
                if (!expressions.TryAddExpression(operations.Pop())) 
                    return false;

            expression = expressions.Pop();

            return true;
        }

        private static bool TryAddExpression(this Stack<Expression> expressions, Operations current)
        {
            if (!expressions.TryPop(out var right) || !expressions.TryPop(out var left))
                return false;
            expressions.Push(current.TryConvertToExpression(left, right));
            return true;
        }
    }
}