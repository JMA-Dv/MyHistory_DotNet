using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHistory.Application.Services.Authentication;
using MyHistory.Contracts.Authentication;

namespace MyHistory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAutheService _auth;

        public AuthenticationController(IAutheService auth)
        {
            _auth = auth;
        }

        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _auth.Register(
                request.FirstName, request.LastName, request.Email, request.Password
                );

            var response = new AuthenticationResponse
            (
                 authResult.user.Id,
                 authResult.user.FirstName,
                 authResult.user.LastName,
                authResult.user.Email,
                 authResult.Token
            );
            return Ok(response);
        }

        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _auth.Login(
                 request.Email, request.Password
                );

            var response = new AuthenticationResponse
            (
                 authResult.user.Id,
                 authResult.user.FirstName,
                 authResult.user.LastName,
                authResult.user.Email,
                 authResult.Token
            );

            return Ok(response);
        }
    }

}
