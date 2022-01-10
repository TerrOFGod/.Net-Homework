using System;

namespace HW13.Infrastructure.Exceptions
{
    public class EmptyExpressionException : Exception
    {
        public EmptyExpressionException(string massage) : base(massage) { }
    }
}