using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.Repositories.Implementations
{
    public class FuelDeliveryItemWriteRepository : BaseWriteRepository<FuelAccountingItem>,
        IFuelAccountingItemWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelDeliveryItemWriteRepository"/>
        /// </summary>
        public FuelDeliveryItemWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
