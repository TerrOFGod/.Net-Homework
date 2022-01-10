using System.Linq;
using System.Threading.Tasks;
using HW11.Infrastructure.Interfaces;
using HW11.Models;

namespace HW11.Infrastructure.Logic
{
    public class CacheCalculator : CalculatorDecorator
    {
        private readonly ApplicationContext _context;

        public CacheCalculator(IExpressionCalculator calculator, ApplicationContext context) : base(calculator)
        {
            _context = context;
        }

        public override async Task<CalculatorModel> Calculate(string expression)
        {
            var cache = _context.Caches.SingleOrDefault(ex => ex.Expression == expression);
            if (cache != null) 
                return new CalculatorModel(cache.Result);
            var result = await _calculator.Calculate(expression);
            _context.Caches.Add(new Cache 
                { Expression = expression?.Replace("pl","+"), Result = result.Result });
            _context.SaveChanges();
            return result;
        }
    }
}