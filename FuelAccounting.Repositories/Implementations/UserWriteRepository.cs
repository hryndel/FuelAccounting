using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Repositories.Contracts.Interfaces;

namespace FuelAccounting.Repositories.Implementations
{
    public class UserWriteRepository : BaseWriteRepository<User>,
        IUserWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="IUserWriteRepository"/>
        /// </summary>
        public UserWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
