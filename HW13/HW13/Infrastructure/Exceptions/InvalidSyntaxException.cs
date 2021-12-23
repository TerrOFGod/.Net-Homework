using System;

namespace HW13.Infrastructure.Exceptions
{
    public class InvalidSyntaxException : Exception
    {
        public InvalidSyntaxException(string massage) : base(massage) { }
    }
}