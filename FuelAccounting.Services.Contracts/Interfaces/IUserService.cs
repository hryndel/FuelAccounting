using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Получить список всех <see cref="UserModel"/>
        /// </summary>
        Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="UserModel"/> по идентификатору
        /// </summary>
        Task<UserModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый <see cref="UserModel"/>
        /// </summary>
        Task<UserModel> AddAsync(UserRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий <see cref="UserModel"/>
        /// </summary>
        Task<UserModel> EditAsync(UserRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий <see cref="UserModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
