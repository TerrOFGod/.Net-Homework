using System.Linq.Expressions;
using HW10.Infrastructure.Extentions;
using HW10.Infrastructure.Interfaces;
using HW10.Models;

namespace HW10.Infrastructure.Logic
{
    public class ExpressionCalculator : IExpressionCalculator
    {
        public CalculatorModel Calculate(string str)
        {
            CalculatorModel model;
            if (!str.TryParse(out Expression exp))
            {
                model = new CalculatorModel("Wrong parameters was entered.");
            }
            else
            {
                var result = new CalculatorVisitor().Visit(exp);
                model = new CalculatorModel(result.ToString());
            }

            return model;
        }
    }
}