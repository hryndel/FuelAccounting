using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.Repositories.Implementations
{
    public class FuelStationWriteRepository : BaseWriteRepository<FuelStation>,
        IFuelStationWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="IFuelStationWriteRepository"/>
        /// </summary>
        public FuelStationWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
