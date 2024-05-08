using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.Repositories.Implementations
{
    public class DriverWriteRepository : BaseWriteRepository<Driver>,
        IDriverWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DriverWriteRepository"/>
        /// </summary>
        public DriverWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
