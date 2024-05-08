using FuelAccounting.Context.Contracts.Models;

namespace FuelAccounting.Repositories.Contracts.Interfaces
{
    /// <summary>
    /// Репозиторий записи <see cref="User"/>
    /// </summary>
    public interface IUserWriteRepository : IRepositoryWriter<User>
    {
    }
}
