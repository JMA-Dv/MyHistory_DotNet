using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHistory.Application.Services.Authentication;
using MyHistory.Domain.Requests.Auth;
using MyHistory.Domain.Responses.Auth;

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
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var authResult = await _auth.Register(
                request.FirstName, request.LastName, request.Email, request.Password
                );
            
            var response = new AuthenticationResponse
            (
                 authResult.Id,
                 authResult.FirstName,
                 authResult.LastName,
                authResult.Email,
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
                 authResult.Id,
                 authResult.FirstName,
                 authResult.LastName,
                authResult.Email,
                 authResult.Token
            );

            return Ok(response);
        }
    }

}
