using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface ITruckService
    {
        /// <summary>
        /// Получить список всех <see cref="TruckModel"/>
        /// </summary>
        Task<IEnumerable<TruckModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="TruckModel"/> по идентификатору
        /// </summary>
        Task<TruckModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый <see cref="TruckModel"/>
        /// </summary>
        Task<TruckModel> AddAsync(TruckRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий <see cref="TruckModel"/>
        /// </summary>
        Task<TruckModel> EditAsync(TruckRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий <see cref="TruckModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
