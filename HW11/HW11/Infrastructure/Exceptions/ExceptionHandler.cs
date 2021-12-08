using System;
using HW11.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace HW11.Infrastructure.Exceptions
{
    public class ExceptionHandler : IExceptionHandler, IExceptionHandler<InvalidSyntaxException>
        , IExceptionHandler<InvalidOperationException>, IExceptionHandler<EmptyExpressionException>
    {
        private readonly ILogger<ExceptionHandler> _logger;
        
        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }
        
        public void HandleException<T>(T exception) where T : Exception
        {
            if (this is IExceptionHandler<T> handler)
                handler.Handle(exception);
            else
                this.Handle((dynamic) exception);
        }

        private void Handle(Exception exception)
        {
            OnFallBack(exception);
        }

        protected virtual void OnFallBack(Exception exception)
        {
            _logger.LogError($"Fallback: {exception.GetType().Name}");
        }

        public void Handle(InvalidSyntaxException exception)
        {
            _logger.LogError($"Invalid syntax: {exception.Message}");
        }

        public void Handle(InvalidOperationException exception)
        {
            _logger.LogError($"Invalid operation: {exception.Message}");
        }

        public void Handle(EmptyExpressionException exception)
        {
            _logger.LogError(exception.Message);
        }
    }
}