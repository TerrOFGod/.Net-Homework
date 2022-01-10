using System.Linq.Expressions;
using HW10.Models;

namespace HW10.Infrastructure.Interfaces
{
    public interface IExpressionCalculator
    {
        CalculatorModel Calculate(string str);
    }
}