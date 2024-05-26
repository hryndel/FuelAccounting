using FuelAccounting.Services.Contracts.Models;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Авторизация по логину и паролю
        /// </summary>
        Task<TokenModel> Authorization(string login, string password, CancellationToken cancellationToken);
    }
}
