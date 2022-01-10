using System;

namespace HW13.Infrastructure.Exceptions
{
    public class InvalidOperationException : Exception
    {
        public InvalidOperationException(string massage) : base(massage){ }
    }
}