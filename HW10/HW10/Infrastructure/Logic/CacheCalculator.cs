using System.Linq;
using HW10.Infrastructure.Interfaces;
using HW10.Models;

namespace HW10.Infrastructure.Logic
{
    public class CacheCalculator : CalculatorDecorator
    {
        private readonly ApplicationContext _context;

        public CacheCalculator(IExpressionCalculator calculator, ApplicationContext context) : base(calculator)
        {
            _context = context;
        }

        public override CalculatorModel Calculate(string expression)
        {
            var cache = _context.Caches.SingleOrDefault(ex => ex.Expression == expression);
            if (cache != null) 
                return new CalculatorModel(cache.Result);
            var result = _calculator.Calculate(expression);
            _context.Caches.Add(new Cache 
                { Expression = expression?.Replace("pl","+"), Result = result.Result });
            _context.SaveChanges();
            return result;
        }
    }
}