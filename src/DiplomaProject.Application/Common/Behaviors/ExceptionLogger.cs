using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Serilog;

namespace DiplomaProject.Application.Common.Behaviors
{
    public class ExceptionLogger<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
            where TException : Exception
    {
        private readonly ILogger _logger;

        public ExceptionLogger()
        {
            _logger = Log.ForContext<TRequest>();
        }

        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
                           CancellationToken cancellationToken)
        {
            _logger.Warning("Произошло исключение при выполнении запроса {0} ({1}):{2}{3}", typeof(TException),
                            exception.Message, Environment.NewLine, exception.StackTrace);

            return Task.CompletedTask;
        }
    }
}