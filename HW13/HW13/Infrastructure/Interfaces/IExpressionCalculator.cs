using System.Threading.Tasks;
using HW13.Models;

namespace HW13.Infrastructure.Interfaces
{
    public interface IExpressionCalculator
    {
        Task<CalculatorModel> Calculate(string str);
    }
}