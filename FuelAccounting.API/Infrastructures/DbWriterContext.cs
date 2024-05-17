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
            IDateTimeProvider dateTimeProvider)
        {
            Writer = writer;
            UnitOfWork = unitOfWork;
            DateTimeProvider = dateTimeProvider;
        }

        /// <inheritdoc cref="IDbWriter"/>
        public IDbWriter Writer { get; }

        /// <inheritdoc cref="IUnitOfWork"/>
        public IUnitOfWork UnitOfWork { get; }

        /// <inheritdoc cref="IDateTimeProvider"/>
        public IDateTimeProvider DateTimeProvider { get; }

        /// <inheritdoc cref="UserName"/>
        public string UserName { get; } = "FuelAccounting.API";
    }
}
