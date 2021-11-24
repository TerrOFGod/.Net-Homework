using System.Linq.Expressions;
using HW9.Models;

namespace HW9.Infrastructure.Interfaces
{
    public interface IExpressionCalculator
    {
        CalculatorModel Calculate(string str);
    }
}