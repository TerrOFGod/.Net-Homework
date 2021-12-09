using HW8.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HW8.Controllers
{
    public class CalculatorController : Controller
    {
        public string Calculate([FromServices] ICalculator calculator, string v1, string op, string v2)
            => calculator.Calculate(v1, op, v2);
    }
}