using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHistory.Contracts.Authentication;

namespace MyHistory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [Route("register")]
        public IActionResult Register(RegisterRequest request )
        {
            return Ok(request);
        }

        [Route("login")]
        public IActionResult Login (LoginRequest request)
        {
            return Ok(request);
        }
    }

}
