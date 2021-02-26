using MediatR;

namespace Prototype.WebApi.Models
{
    public class BackendRequest : IRequest<string>
    {
        public string TraceId { get; set; }
    }
}