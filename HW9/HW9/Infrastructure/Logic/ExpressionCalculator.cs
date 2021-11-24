using System.Linq.Expressions;
using HW9.Infrastructure.Extentions;
using HW9.Infrastructure.Interfaces;
using HW9.Models;

namespace HW9.Infrastructure.Logic
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