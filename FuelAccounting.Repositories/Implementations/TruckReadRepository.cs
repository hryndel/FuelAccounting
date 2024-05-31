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
                .NotDeletedAt()
                .ById(id)
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

        Task<bool> ITruckReadRepository.AnyByNumberAsync(string number, CancellationToken cancellationToken)
            => reader.Read<Truck>()
                .NotDeletedAt()
                .AnyAsync(x => x.Number == number, cancellationToken);

        bool ITruckReadRepository.AnyByNumberAndId(string number, Guid id)
            => reader.Read<Truck>()
                .NotDeletedAt()
                .Any(x => x.Number == number && x.Id != id);

        Task<bool> ITruckReadRepository.AnyByVinAsync(string vin, CancellationToken cancellationToken)
            => reader.Read<Truck>()
                .NotDeletedAt()
                .AnyAsync(x => x.Vin == vin, cancellationToken);

        bool ITruckReadRepository.AnyByVinAndId(string vin, Guid id)
            => reader.Read<Truck>()
                .NotDeletedAt()
                .Any(x => x.Vin == vin && x.Id != id);
    }
}
