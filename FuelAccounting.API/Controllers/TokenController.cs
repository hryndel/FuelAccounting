using FuelAccounting.Services.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FuelAccounting.API.Controllers
{
    /// <summary>
    /// CRUD контроллер по работе с авторизацией
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Token")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TokenController"/>
        /// </summary>
        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Авторизироваться
        /// </summary>
        [HttpPost("signIn")]
        public async Task<string> Auth(string login, string password, CancellationToken cancellationToken)
        {
            var token = await tokenService.Authorization(login, password, cancellationToken);
            return token;
        }
    }
}
