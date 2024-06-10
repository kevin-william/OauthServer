using Microsoft.AspNetCore.Mvc;

namespace OauthServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OauthServerController : ControllerBase
    {

        private readonly ILogger<OauthServerController> _logger;

        public OauthServerController(ILogger<OauthServerController> logger)
        {
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("It Works");
        }
    }
}
