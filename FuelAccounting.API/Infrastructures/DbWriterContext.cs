using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Common;

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

        /// <inheritdoc/>
        public IDbWriter Writer { get; }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork { get; }

        /// <inheritdoc/>
        public IDateTimeProvider DateTimeProvider { get; }

        /// <inheritdoc/>
        public string UserName { get; } = "FuelAccounting.API";
    }
}
