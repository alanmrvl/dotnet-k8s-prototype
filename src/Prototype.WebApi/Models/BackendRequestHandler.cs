using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Prototype.WebApi.Models
{
    public class BackendRequestHandler : IRequestHandler<BackendRequest, string>
    {
        public readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<BackendRequestHandler> _logger;

        public BackendRequestHandler(IHttpClientFactory clientFactory, ILogger<BackendRequestHandler> logger)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<string> Handle(BackendRequest request, CancellationToken cancellationToken)
        {
            var client = _clientFactory.CreateClient("backend");

            var result = await client.GetAsync(string.Empty);

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStringAsync();
        }
    }
}