using AutoMapper;
using FuelAccounting.API.Attribute;
using FuelAccounting.API.Models;
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
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TokenController"/>
        /// </summary>
        public TokenController(ITokenService tokenService, IMapper mapper)
        {
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Авторизироваться
        /// </summary>
        [HttpPost("signIn")]
        [ApiOk(typeof(IEnumerable<TokenResponse>))]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Auth(string login, string password, CancellationToken cancellationToken)
        {
            var token = await tokenService.Authorization(login, password, cancellationToken);
            return Ok(mapper.Map<TokenResponse>(token));
        }
    }
}
