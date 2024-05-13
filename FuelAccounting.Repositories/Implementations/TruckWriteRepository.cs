using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.Repositories.Implementations
{
    public class TruckWriteRepository : BaseWriteRepository<Truck>,
        ITruckWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ITruckWriteRepository"/>
        /// </summary>
        public TruckWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
