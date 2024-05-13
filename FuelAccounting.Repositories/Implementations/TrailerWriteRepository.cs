using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.Repositories.Implementations
{
    public class TrailerWriteRepository : BaseWriteRepository<Trailer>,
        ITrailerWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ITrailerWriteRepository"/>
        /// </summary>
        public TrailerWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
