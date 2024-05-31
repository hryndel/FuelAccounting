using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common.Entity.Repositories;
using FuelAccounting.Context.Contracts.Enums;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Repositories.Implementations
{
    public class UserReadRepository : IUserReadRepository, IRepositoryAnchor
    {
        private readonly IDbReader reader;

        public UserReadRepository(IDbReader reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<User>> IUserReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<User>()
                .NotDeletedAt()
                .OrderBy(x => x.CreatedAt)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<User?> IUserReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<User>()
                .NotDeletedAt()
                .ById(id)
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, User>> IUserReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<User>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.CreatedAt)
                .ToDictionaryAsync(key => key.Id, cancellationToken);

        Task<IReadOnlyCollection<User>> IUserReadRepository.GetByAdminRoleAsync(CancellationToken cancellationToken)
            => reader.Read<User>()
                .NotDeletedAt()
                .Where(x => x.UserType == UserTypes.Administrator)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<User?> IUserReadRepository.GetByLoginAsync(string login, CancellationToken cancellationToken)
            => reader.Read<User>()
                .NotDeletedAt()
                .Where(x => x.Login == login)
                .FirstOrDefaultAsync(cancellationToken);

        Task<bool> IUserReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<User>()
                .NotDeletedAt()
                .ById(id)
                .AnyAsync(cancellationToken);

        Task<bool> IUserReadRepository.AnyByMailAsync(string mail, CancellationToken cancellationToken)
            => reader.Read<User>()
                .NotDeletedAt()
                .AnyAsync(x => x.Mail == mail, cancellationToken);

        bool IUserReadRepository.AnyByMailAndId(string mail, Guid id)
            => reader.Read<User>()
                .NotDeletedAt()
                .Any(x => x.Mail == mail && x.Id != id);

        Task<bool> IUserReadRepository.AnyByLoginAsync(string login, CancellationToken cancellationToken)
            => reader.Read<User>()
                .NotDeletedAt()
                .AnyAsync(x => x.Login == login, cancellationToken);

        bool IUserReadRepository.AnyByLoginAndId(string login, Guid id)
            => reader.Read<User>()
                .NotDeletedAt()
                .Any(x => x.Login == login && x.Id != id);
    }
}
