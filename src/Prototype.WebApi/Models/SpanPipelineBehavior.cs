using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Prototype.WebApi.Models
{
    public class SpanPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private static readonly ActivitySource ActivitySource = new ActivitySource("SpanPipelineBehavior");
        
        //private readonly ActivitySource _activitySource;

        // public SpanPipelineBehavior(ActivitySource activitySource)
        // {
        //     _activitySource = activitySource ?? throw new ArgumentNullException(nameof(activitySource));
        // }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (Activity activity = ActivitySource.StartActivity(typeof(TRequest).Name, ActivityKind.Producer))
            {
                return await next();
            }
        }
    }
}