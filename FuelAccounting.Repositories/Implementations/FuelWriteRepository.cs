using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace FuelAccounting.Repositories.Implementations
{
    public class FuelWriteRepository : BaseWriteRepository<Fuel>,
        IFuelWriteRepository,
        IRepositoryAnchor
    {
        private readonly IDbWriterContext writerContext;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="IFuelWriteRepository"/>
        /// </summary>
        public FuelWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
            this.writerContext = writerContext;
        }

        public void UpdateFuelCount([NotNull] Fuel item, double count)
        {
            item.Count -= count;
            AuditForUpdate(item);
            writerContext.Writer.Update(item);
        }
    }
}
