using FuelAccounting.Common.Entity.EntityInterfaces;

namespace FuelAccounting.Common.Entity.InterfacesDB
{
    /// <summary>
    /// Интерфейс получения записей из бд
    /// </summary>
    public interface IDbReader
    {
        /// <summary>
        /// Предоставляет функциональные возможности для выполнения запросов
        /// </summary> 
        IQueryable<TEntity> Read<TEntity>() where TEntity : class, IEntity;
    }
}
