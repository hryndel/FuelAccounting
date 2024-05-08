using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.Repositories.Implementations
{
    public class SupplierWriteRepository : BaseWriteRepository<Supplier>,
        ISupplierWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ISupplierWriteRepository"/>
        /// </summary>
        public SupplierWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
