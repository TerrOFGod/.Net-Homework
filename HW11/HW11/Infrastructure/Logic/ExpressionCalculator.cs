using System.Globalization;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HW11.Infrastructure.Extentions;
using HW11.Infrastructure.Interfaces;
using HW11.Models;

namespace HW11.Infrastructure.Logic
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