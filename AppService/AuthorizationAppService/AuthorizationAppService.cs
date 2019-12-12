using Domain.Authorization.service;
using Infrastructure.Common.Token;

namespace AppService.AuthorizationAppService
{
    public class AuthorizationAppService : IAuthorizationAppService
    {
        private IAuthenticateService authenticateService;

        public AuthorizationAppService(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        public TokenResult IsAuthenticated(TokenRequest request)
        {
            return authenticateService.IsAuthenticated(request);
        }
    }
}
