using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using ServiceDiscovery;

namespace WebApi.Controllers
{
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IDependencyService _service;
        private readonly IUrlProvider _serviceDiscovery;
        private readonly ILogger<Controller> _logger;

        public Controller(IDependencyService service, IUrlProvider serviceDiscovery, ILogger<Controller> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _serviceDiscovery = serviceDiscovery ?? throw new ArgumentNullException(nameof(serviceDiscovery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("api")]
        public async Task<IActionResult> Get()
        {
            _logger.LogWarning($"obtaining {Service.Constants.SERVICE_NAME} url from service-discovery ...");
            var url = await _serviceDiscovery.GetUrlAsync(Service.Constants.SERVICE_NAME);
            _logger.LogWarning($"{Service.Constants.SERVICE_NAME} url is {url}");
            _logger.LogWarning($"calling {Service.Constants.SERVICE_NAME} ...");
            var dependencyResponse = await _service.DoAsync(url);
            _logger.LogWarning($"{Service.Constants.SERVICE_NAME} responded with {dependencyResponse}");

            return Ok($"api + {dependencyResponse}");
        }
    }
}
