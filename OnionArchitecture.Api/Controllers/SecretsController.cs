using Microsoft.AspNetCore.Mvc;

namespace OnionArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SecretsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("/test")]
        public IActionResult Test()
        {
            return Ok("Works");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_configuration["MySecret"]);
        }
    }
}
