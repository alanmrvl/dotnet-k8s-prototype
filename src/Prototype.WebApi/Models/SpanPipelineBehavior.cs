using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Prototype.WebApi.Models
{
    public class SpanPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private static readonly ActivitySource ActivitySource = new ActivitySource(Constants.ActivitySourceName);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (Activity activity = ActivitySource.StartActivity(typeof(TRequest).Name))
            {                
                return await next();
            }
        }
    }
}