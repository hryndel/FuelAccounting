using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common.Entity.Repositories;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Repositories.Implementations
{
    public class FuelAccountingItemReadRepository : IFuelAccountingItemReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public FuelAccountingItemReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<FuelAccountingItem>> IFuelAccountingItemReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<FuelAccountingItem>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<FuelAccountingItem?> IFuelAccountingItemReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<FuelAccountingItem>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);
    }
}
