using Infrastructure.Common.Token;

namespace Domain.Authorization.service
{
    public interface IAuthenticateService
    {
        TokenResult IsAuthenticated(TokenRequest request);
    }
}
