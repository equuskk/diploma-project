using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Serilog;

namespace DiplomaProject.Application.Common.Behaviors
{
    public class PostRequestLogger<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public PostRequestLogger()
        {
            _logger = Log.ForContext<TRequest>();
        }

        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            _logger.Information("Успешно выполнен с ответом:{0} {@1}", Environment.NewLine, response);

            return Task.CompletedTask;
        }
    }
}