namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Авторизация по логину и паролю
        /// </summary>
        Task<string> Authorization(string login, string password, CancellationToken cancellationToken);
    }
}
