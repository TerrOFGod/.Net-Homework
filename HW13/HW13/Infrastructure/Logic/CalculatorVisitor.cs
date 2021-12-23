using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HW13.Infrastructure.Logic
{
    public class CalculatorVisitor
    {        
        public virtual async Task<Expression> Visit(Expression expression) 
            => await Visit((dynamic) expression);

        protected virtual async Task<Expression> Visit(ConstantExpression constantNode)
            => constantNode;

        protected virtual async Task<Expression> Visit(BinaryExpression node)
        {
            await Task.Delay(1000);
            var left = await Visit(node.Left);
            var right = await Visit(node.Right);
        
            var leftResult = (decimal)((ConstantExpression) left).Value!;
            var rightResult = (decimal)((ConstantExpression) right).Value!;
            
            var res = node.NodeType switch
            {
                ExpressionType.Add        => leftResult + rightResult,
                ExpressionType.Subtract   => leftResult - rightResult,
                ExpressionType.Multiply   => leftResult * rightResult,
                ExpressionType.Divide     => leftResult / rightResult
            };
        
            return Expression.Constant(res);
        }
    }
}