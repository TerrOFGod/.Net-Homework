using System.Linq.Expressions;
using System.Threading.Tasks;
using HW13.Infrastructure.Extentions;
using HW13.Infrastructure.Interfaces;
using HW13.Models;

namespace HW13.Infrastructure.Logic
{
    
    public class ExpressionCalculator : IExpressionCalculator
    {
        private readonly CalculatorVisitor _visitor = new();
        
        public async Task<CalculatorModel> Calculate(string str)
        {
            CalculatorModel model;
            if (!str.TryParse(out Expression exp))
            {
                model = new CalculatorModel("Wrong parameters was entered.");
            }
            else
            {
                var result = await _visitor.Visit(exp);
                model = new CalculatorModel(result.ToString());
            }

            return model;
        }
    }
}