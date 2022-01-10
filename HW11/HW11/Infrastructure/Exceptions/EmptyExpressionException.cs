using System;

namespace HW11.Infrastructure.Exceptions
{
    public class EmptyExpressionException : Exception
    {
        public EmptyExpressionException(string massage) : base(massage) { }
    }
}