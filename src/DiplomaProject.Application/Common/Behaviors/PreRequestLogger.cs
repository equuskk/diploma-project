using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Serilog;

namespace DiplomaProject.Application.Common.Behaviors
{
    public class PreRequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public PreRequestLogger()
        {
            _logger = Log.ForContext<TRequest>();
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.Debug("Выполнение с параметрами: {@0}", request);

            return Task.CompletedTask;
        }
    }
}