using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpGet("discover")]
        public IActionResult Get([FromQuery] string serviceName)
        {
            var url = Environment.GetEnvironmentVariable(serviceName);
            if (url == null)
                return NotFound();
            else
                return Ok(url);
        }
    }
}
