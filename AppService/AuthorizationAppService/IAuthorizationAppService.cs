using Infrastructure.Common.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.AuthorizationAppService
{
    public interface IAuthorizationAppService
    {
        TokenResult IsAuthenticated(TokenRequest request);
    }
}
