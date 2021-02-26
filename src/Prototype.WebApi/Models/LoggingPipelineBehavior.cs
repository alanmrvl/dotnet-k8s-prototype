using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Prototype.WebApi.Models
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Start: {typeof(TRequest).Name}");

            var response = await next();

            _logger.LogInformation($"End: {typeof(TRequest).Name}");

            return response;
        }
    }
}