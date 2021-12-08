using System;

namespace HW11.Infrastructure.Exceptions
{
    public class InvalidOperationException : Exception
    {
        public InvalidOperationException(string massage) : base(massage){ }
    }
}