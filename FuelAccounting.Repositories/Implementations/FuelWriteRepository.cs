using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.Repositories.Implementations
{
    public class FuelWriteRepository : BaseWriteRepository<Fuel>,
        IFuelWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="IFuelWriteRepository"/>
        /// </summary>
        public FuelWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
