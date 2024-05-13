using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common.Entity.Repositories;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Repositories.Implementations
{
    public class FuelReadRepository : IFuelReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public FuelReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Fuel>> IFuelReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Fuel>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Fuel?> IFuelReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Fuel>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Fuel>> IFuelReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Fuel>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> IFuelReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Fuel>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);
    }
}
