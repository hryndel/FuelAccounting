using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common.Entity.Repositories;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Repositories.Implementations
{
    public class FuelStationReadRepository : IFuelStationReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public FuelStationReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<FuelStation>> IFuelStationReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<FuelStation>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<FuelStation?> IFuelStationReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<FuelStation>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, FuelStation>> IFuelStationReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<FuelStation>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> IFuelStationReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<FuelStation>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);

        Task<bool> IFuelStationReadRepository.AnyByAddressAsync(string address, CancellationToken cancellationToken)
            => reader.Read<FuelStation>()
                .NotDeletedAt()
                .AnyAsync(x => x.Address == address, cancellationToken);

        bool IFuelStationReadRepository.AnyByAddressAndId(string address, Guid id)
            => reader.Read<FuelStation>()
                .NotDeletedAt()
                .Any(x => x.Address == address && x.Id != id);
    }
}
