using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HW10.Infrastructure.Logic
{
    public class CalculatorVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var n = node.ToString();
            var left = Task.Run(() => Visit(node.Left));
            var right = Task.Run(() => Visit(node.Right));
            
            Thread.Sleep(1000);
            Task.WhenAll(left, right);
        
            var leftResult = (decimal)((ConstantExpression) left.Result)?.Value!;
            var rightResult = (decimal)((ConstantExpression) right.Result)?.Value!;
            
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