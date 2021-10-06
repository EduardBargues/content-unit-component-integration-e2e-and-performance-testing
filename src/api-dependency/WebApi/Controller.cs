using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<Controller> _logger;

        public Controller(IRepository repository, ILogger<Controller> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("dependency")]
        public IActionResult Call()
        {
            _logger.LogWarning($"saving call ...");
            var call = _repository.Save();
            return Created($"/calls/{call.Id}", call);
        }

        [HttpGet("calls")]
        public IActionResult GetCalls()
        {
            _logger.LogWarning($"getting all calls ...");
            return Ok(_repository.Get());
        }
    }
}
