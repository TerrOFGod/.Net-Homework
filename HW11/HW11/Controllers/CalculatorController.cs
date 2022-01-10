using System;
using System.Threading.Tasks;
using HW11.Infrastructure.Interfaces;
using HW11.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW11.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IExpressionCalculator _calculator;
        private readonly IExceptionHandler _exceptionHandler;
        
        public CalculatorController(IExpressionCalculator calculator, IExceptionHandler exceptionHandler)
        {
            _calculator = calculator;
            _exceptionHandler = exceptionHandler;
        }
        
        [HttpGet]
        public IActionResult Calculator() => View();
        
        [HttpPost]
        public async Task<IActionResult> Calculator(string expression)
        {
            CalculatorModel model;
            try
            {
                model = await _calculator.Calculate(expression);
            }
            catch (Exception e)
            {
                _exceptionHandler.HandleException(e);
                model = new CalculatorModel($"Error: {e.Message}");
            }
            return View(model);
        }
    }
}