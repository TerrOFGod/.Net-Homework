using System.Threading.Tasks;
using HW11.Models;

namespace HW11.Infrastructure.Interfaces
{
    public interface IExpressionCalculator
    {
        Task<CalculatorModel> Calculate(string str);
    }
}