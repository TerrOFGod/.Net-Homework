using System.Threading.Tasks;
using HW11.Models;

namespace HW11.Infrastructure.Interfaces
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