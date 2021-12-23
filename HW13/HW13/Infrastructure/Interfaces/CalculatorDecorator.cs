using System.Threading.Tasks;
using HW13.Models;

namespace HW13.Infrastructure.Interfaces
{
    public abstract class CalculatorDecorator : IExpressionCalculator
    {
        protected readonly IExpressionCalculator _calculator;

        protected CalculatorDecorator(IExpressionCalculator calculator)
        {
            _calculator = calculator;
        }

        public virtual Task<CalculatorModel> Calculate(string expression)
            => _calculator.Calculate(expression);
    }
}