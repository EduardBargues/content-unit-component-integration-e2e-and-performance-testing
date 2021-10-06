using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using ServiceDiscovery;

namespace WebApi.Controllers
{
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IDependencyService _service;
        private readonly IUrlProvider _serviceDiscovery;

        public Controller(IDependencyService service, IUrlProvider serviceDiscovery)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _serviceDiscovery = serviceDiscovery ?? throw new ArgumentNullException(nameof(serviceDiscovery));
        }

        [HttpGet("dotnet-webapi")]
        public async Task<IActionResult> Get()
        {
            var url = await _serviceDiscovery.GetUrlAsync(Service.Constants.SERVICE_NAME);
            var dependencyResponse = await _service.DoAsync(url);

            return Ok($"dotnet-webapi + {dependencyResponse}");
        }
    }
}
