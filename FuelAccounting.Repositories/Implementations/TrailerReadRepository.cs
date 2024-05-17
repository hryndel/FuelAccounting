using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common.Entity.Repositories;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Repositories.Implementations
{
    public class TrailerReadRepository : ITrailerReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public TrailerReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Trailer>> ITrailerReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Trailer>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Trailer?> ITrailerReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Trailer>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Trailer>> ITrailerReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Trailer>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<bool> ITrailerReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Trailer>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);

        Task<bool> ITrailerReadRepository.AnyByNumberAsync(string number, CancellationToken cancellationToken)
            => reader.Read<Trailer>()
                .NotDeletedAt()
                .AnyAsync(x => x.Number == number, cancellationToken);

        bool ITrailerReadRepository.AnyByNumberAndId(string number, Guid id)
            => reader.Read<Trailer>()
                .NotDeletedAt()
                .Any(x => x.Number == number && x.Id != id);
    }
}
