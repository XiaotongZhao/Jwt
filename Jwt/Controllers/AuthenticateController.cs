using AppService.AuthorizationAppService;
using Infrastructure.Common.Token;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthorizationAppService authService;

        public AuthenticateController(IAuthorizationAppService authService)
        {
            this.authService = authService;
        }
        [HttpPost, Route("request")]
        public IActionResult RequestToken(TokenRequest request)
        {
            var result = authService.IsAuthenticated(request);
            if (result.Success)
            {
                return Ok(result.Token);
            }

            return BadRequest("Invalid Request");
        }
    }
}
