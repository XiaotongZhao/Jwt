using System.Collections.Generic;
using AppService.UserAppService;
using AppService.AuthorizationAppService;
using AppService.UserAppService.ViewModel;
using Infrastructure.Common.Token;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Jwt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserAppService userAppService;
        private readonly IAuthorizationAppService authService;

        public AuthenticateController(IUserAppService userAppService, IAuthorizationAppService authService)
        {
            this.authService = authService;
            this.userAppService = userAppService;
        }

        [HttpGet, Route("GetUsers")]
        public List<UserViewModel> GetUsers()
        {
            return userAppService.GetUsers();
        }

        [HttpPost, Route("Request")]
        public IActionResult RequestToken(TokenRequest request)
        {
            var result = authService.IsAuthenticated(request);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Invalid Request");
        }
    }
}
