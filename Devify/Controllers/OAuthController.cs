using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devify.Controllers
{
    [Route("api/oauth")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        [HttpGet("google", Name = "oauth-google")]
        public IActionResult google()
        {
            return Ok();
        }
    }
}
