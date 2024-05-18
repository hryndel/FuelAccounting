using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface IFuelAccountingItemService
    {
        /// <summary>
        /// Получить список всхе <see cref="FuelAccountingItemModel"/>
        /// </summary>
        Task<IEnumerable<FuelAccountingItemModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="FuelAccountingItemModel"/> по идентификатору
        /// </summary>
        Task<FuelAccountingItemModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый <see cref="FuelAccountingItemModel"/> 
        /// </summary>
        Task<FuelAccountingItemModel> AddAsync(FuelAccountingItemRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий <see cref="FuelAccountingItemModel"/> 
        /// </summary>
        Task<FuelAccountingItemModel> EditAsync(FuelAccountingItemRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий <see cref="FuelAccountingItemModel"/> 
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить сформированный документ <see cref="FuelAccountingItemModel"/>
        /// </summary>
        Task<string> GetDocumentById(Guid id, string path, CancellationToken cancellationToken);
    }
}
