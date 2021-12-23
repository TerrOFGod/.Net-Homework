using System.Collections.Concurrent;
using System.Threading.Tasks;
using HW13.Infrastructure.Interfaces;
using HW13.Models;

namespace HW13.Infrastructure.Logic
{
    public class CacheCalculator : CalculatorDecorator
    {
        private readonly ConcurrentDictionary<string, CalculatorModel> _caches = new();

        public CacheCalculator(IExpressionCalculator calculator) : base(calculator)
        { }

        public override async Task<CalculatorModel> Calculate(string expression)
        {
            var hasCache = _caches.ContainsKey(expression);
            if (hasCache) 
                return _caches[expression];
            var result = _caches.GetOrAdd
                (expression?.Replace("pl","+") , await _calculator.Calculate(expression));
            return result;
        }
    }
}