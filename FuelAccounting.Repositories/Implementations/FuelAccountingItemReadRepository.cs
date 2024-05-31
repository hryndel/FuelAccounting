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
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);
        Task<FuelAccountingItem?> IFuelAccountingItemReadRepository.GetByDriverIdAsync(Guid driverId, CancellationToken cancellationToken)
            => reader.Read<FuelAccountingItem>()
                .NotDeletedAt()
                .Where(x => x.DriverId == driverId)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);

        Task<FuelAccountingItem?> IFuelAccountingItemReadRepository.GetByTrailerIdAsync(Guid trailerId, CancellationToken cancellationToken)
            => reader.Read<FuelAccountingItem>()
                .NotDeletedAt()
                .Where(x => x.TrailerId == trailerId)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);

        Task<FuelAccountingItem?> IFuelAccountingItemReadRepository.GetByTruckIdAsync(Guid truckId, CancellationToken cancellationToken)
            => reader.Read<FuelAccountingItem>()
                .NotDeletedAt()
                .Where(x => x.TruckId == truckId)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
