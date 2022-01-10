using System.Collections.Generic;
using HW9.Infrastructure.Enums;

namespace HW9.Infrastructure.Constants
{
    public class Dictionaries
    {
        public static readonly Dictionary<Operations, int> Priorities = new()
        {
            { Operations.LBracket,       0 },
            { Operations.RBracket,       0 },
            { Operations.Plus,           1 },
            { Operations.Minus,          1 },
            { Operations.Division,       2 },
            { Operations.Multiplication, 2 }
        };
    }
}