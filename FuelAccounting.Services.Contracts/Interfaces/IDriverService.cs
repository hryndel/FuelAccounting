using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface IDriverService
    {
        /// <summary>
        /// Получить список всех <see cref="DriverModel"/>
        /// </summary>
        Task<IEnumerable<DriverModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="DriverModel"/> по идентификатору
        /// </summary>
        Task<DriverModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового <see cref="DriverModel"/>
        /// </summary>
        Task<DriverModel> AddAsync(DriverRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующую <see cref="DriverModel"/>
        /// </summary>
        Task<DriverModel> EditAsync(DriverRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего <see cref="DriverModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
