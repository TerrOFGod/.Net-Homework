using HW10.Models;

namespace HW10.Infrastructure.Interfaces
{
    public abstract class CalculatorDecorator : IExpressionCalculator
    {
        protected readonly IExpressionCalculator _calculator;

        protected CalculatorDecorator(IExpressionCalculator calculator)
        {
            _calculator = calculator;
        }

        public virtual CalculatorModel Calculate(string expression)
            => _calculator.Calculate(expression);
    }
}