using System;

namespace HW11.Infrastructure.Interfaces
{
    public interface IExceptionHandler<T> where T : Exception
    {
        void Handle(T exception);
    }
    
    public interface IExceptionHandler
    {
        void HandleException<T>(T exception) where T : Exception;
    }
}