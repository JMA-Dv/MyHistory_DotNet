using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyHistory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        public async Task<IActionResult> GetAllSpecialists()
        {
            return Ok();
        }
    }
}
