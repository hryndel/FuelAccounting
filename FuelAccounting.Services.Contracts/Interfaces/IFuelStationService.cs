using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface IFuelStationService
    {
        /// <summary>
        /// Получить список всех <see cref="FuelStationModel"/>
        /// </summary>
        Task<IEnumerable<FuelStationModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="FuelStationModel"/> по идентификатору
        /// </summary>
        Task<FuelStationModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новую <see cref="FuelStationModel"/>
        /// </summary>
        Task<FuelStationModel> AddAsync(FuelStationRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующую <see cref="FuelStationModel"/>
        /// </summary>
        Task<FuelStationModel> EditAsync(FuelStationRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующую <see cref="FuelStationModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
