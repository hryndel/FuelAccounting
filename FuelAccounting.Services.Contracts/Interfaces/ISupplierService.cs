using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface ISupplierService
    {
        /// <summary>
        /// Получить список всех <see cref="SupplierModel"/>
        /// </summary>
        Task<IEnumerable<SupplierModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="SupplierModel"/> по идентификатору
        /// </summary>
        Task<SupplierModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового <see cref="SupplierModel"/>
        /// </summary>
        Task<SupplierModel> AddAsync(SupplierRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего <see cref="SupplierModel"/>
        /// </summary>
        Task<SupplierModel> EditAsync(SupplierRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего <see cref="SupplierModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
