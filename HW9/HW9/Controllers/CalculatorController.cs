using HW9.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HW9.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Calculator() => View();
        
        [HttpPost]
        public IActionResult Calculator([FromServices] IExpressionCalculator calculator, string expression)
            => View(calculator.Calculate(expression));
    }
}