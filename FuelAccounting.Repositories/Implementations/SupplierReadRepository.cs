using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common.Entity.Repositories;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Repositories.Implementations
{
    public class SupplierReadRepository : ISupplierReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public SupplierReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Supplier>> ISupplierReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Supplier>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Supplier?> ISupplierReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Supplier>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Supplier>> ISupplierReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Supplier>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> ISupplierReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Supplier>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);
    }
}
