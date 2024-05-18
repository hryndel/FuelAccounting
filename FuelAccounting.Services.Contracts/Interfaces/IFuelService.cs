using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface IFuelService
    {
        /// <summary>
        /// Получить список всех <see cref="FuelModel"/>
        /// </summary>
        Task<IEnumerable<FuelModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="FuelModel"/> по идентификатору
        /// </summary>
        Task<FuelModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новое <see cref="FuelModel"/>
        /// </summary>
        Task<FuelModel> AddAsync(FuelRequestModel request, CancellationToken cancellationToken);

        // <summary>
        /// Редактирует существующее <see cref="FuelModel"/>
        /// </summary>
        Task<FuelModel> EditAsync(FuelRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующее <see cref="FuelModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
