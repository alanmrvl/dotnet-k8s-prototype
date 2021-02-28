using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prototype.WebApi.Models;

namespace Prototype.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var traceId = Activity.Current.TraceId.ToString();

            var result1 = await _mediator.Send(new BackendRequest { TraceId = traceId });

            var result2 = await _mediator.Send(new BackendRequest { TraceId = traceId });

            return new[] { traceId, result1, result2 };
        }
    }
}