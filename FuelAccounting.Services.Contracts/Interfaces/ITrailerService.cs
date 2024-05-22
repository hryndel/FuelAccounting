using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.Services.Contracts.Interfaces
{
    public interface ITrailerService
    {
        /// <summary>
        /// Получить список всех <see cref="TrailerModel"/>
        /// </summary>
        Task<IEnumerable<TrailerModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить список всех свободных <see cref="TrailerModel"/>
        /// </summary>
        Task<IEnumerable<TrailerModel>> GetFreeAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="TrailerModel"/> по идентификатору
        /// </summary>
        Task<TrailerModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый <see cref="TrailerModel"/>
        /// </summary>
        Task<TrailerModel> AddAsync(TrailerRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий <see cref="TrailerModel"/>
        /// </summary>
        Task<TrailerModel> EditAsync(TrailerRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий <see cref="TrailerModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
