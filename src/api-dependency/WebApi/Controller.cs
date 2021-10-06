using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpGet("dependency")]
        public IActionResult Get()
        {
            return Ok($"you reached me :) !");
        }
    }
}
