using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common.Entity.Repositories;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Repositories.Implementations
{
    public class TruckReadRepository : ITruckReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public TruckReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Truck>> ITruckReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Truck>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Truck?> ITruckReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Truck>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Truck>> ITruckReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Truck>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> ITruckReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Truck>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);
    }
}
