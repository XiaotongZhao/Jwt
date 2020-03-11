using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Infrastructure.Common.Token;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Authorization.service
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly TokenManagement _tokenManagement;
        public TokenAuthenticationService(IOptions<TokenManagement> tokenManagement)
        {
            _tokenManagement = tokenManagement.Value;
        }

        public TokenResult IsAuthenticated(TokenRequest request)
        {
            var claim = new[]
            {
                new Claim(ClaimTypes.Name, request.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            return new TokenResult() { Success = true, Id = 1, UserName = request.Username, Token = new JwtSecurityTokenHandler().WriteToken(jwtToken) };
        }
    }
}
