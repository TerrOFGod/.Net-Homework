using System;

namespace HW11.Infrastructure.Exceptions
{
    public class InvalidSyntaxException : Exception
    {
        public InvalidSyntaxException(string massage) : base(massage) { }
    }
}