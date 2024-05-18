using FuelAccounting.Common;
using FuelAccounting.Common.Entity.InterfacesDB;

namespace FuelAccounting.API.Infrastructures
{
    /// <inheritdoc cref="IDbWriterContext"/>
    public class DbWriterContext : IDbWriterContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DbWriterContext"/>
        /// </summary>
        public DbWriterContext(
            IDbWriter writer,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider,
            IIdentityProvider identityProvider)
        {
            Writer = writer;
            UnitOfWork = unitOfWork;
            DateTimeProvider = dateTimeProvider;
            IdentityProvider = identityProvider;
        }

        /// <inheritdoc cref="IDbWriter"/>
        public IDbWriter Writer { get; }

        /// <inheritdoc cref="IUnitOfWork"/>
        public IUnitOfWork UnitOfWork { get; }

        /// <inheritdoc cref="IDateTimeProvider"/>
        public IDateTimeProvider DateTimeProvider { get; }

        /// <inheritdoc cref="IIdentityProvider"/>
        public IIdentityProvider IdentityProvider { get; }
    }
}
