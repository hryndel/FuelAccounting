using FuelAccounting.Repositories.Contracts.Interfaces;
using FuelAccounting.Services.Contracts.Exceptions;
using FuelAccounting.Services.Contracts.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FuelAccounting.Services.Implementations
{
    public class TokenService : ITokenService, IServiceAnchor
    {
        private readonly IUserReadRepository userReadRepository;

        public TokenService(IUserReadRepository userReadRepository)
        {
            this.userReadRepository = userReadRepository;
        }

        async Task<string> ITokenService.Authorization(string login, string password, CancellationToken cancellationToken)
        {
            var user = await userReadRepository.GetByLoginAsync(login, cancellationToken);
            if (user == null)
            {
                throw new FuelAccountingNotFoundException("Пользователь не найден.");
            }
            
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new FuelAccountingInvalidOperationException("Неверный пароль.");
            }

             var claims = new List<Claim>            
             {
                 new Claim(ClaimTypes.Name, user.Login),
                 new Claim(ClaimTypes.Role, user.UserType.ToString())
             };
             var accessToken = GenerateAccessToken(claims);
             return accessToken;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = Authorization.GetSymmetricSecurityKey();
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
            issuer: Authorization.ISSUER,
                 audience: Authorization.AUDIENCE,
                 claims: claims,
                 expires: DateTime.UtcNow.AddMinutes(Authorization.LIFETIME),
                 signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
