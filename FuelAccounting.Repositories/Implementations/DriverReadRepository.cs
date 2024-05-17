using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common.Entity.Repositories;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Repositories.Implementations
{
    public class DriverReadRepository : IDriverReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public DriverReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Driver>> IDriverReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Driver>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Driver?> IDriverReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Driver>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Driver>> IDriverReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Driver>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> IDriverReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Driver>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);

        Task<bool> IDriverReadRepository.AnyByDriversLicenseAsync(string driversLicense, CancellationToken cancellationToken)
            => reader.Read<Driver>()
                .NotDeletedAt()
                .AnyAsync(x => x.DriversLicense == driversLicense, cancellationToken);

        bool IDriverReadRepository.AnyByDriversLicenseAndId(string driversLicense, Guid id)
            => reader.Read<Driver>()
                .NotDeletedAt()
                .Any(x => x.DriversLicense == driversLicense && x.Id != id);

        Task<bool> IDriverReadRepository.AnyByPhoneAsync(string phone, CancellationToken cancellationToken)
            => reader.Read<Driver>()
                .NotDeletedAt()
                .AnyAsync(x => x.Phone == phone, cancellationToken);

        bool IDriverReadRepository.AnyByPhoneAndId(string phone, Guid id)
            => reader.Read<Driver>()
                .NotDeletedAt()
                .Any(x => x.Phone == phone && x.Id != id);
    }
}
