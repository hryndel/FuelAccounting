namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface ITokenService
    {
        Task<string> Authorization(string login, string password, CancellationToken cancellationToken);
    }
}
