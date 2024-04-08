﻿using FuelAccounting.Common.Entity.EntityInterfaces;

namespace FuelAccounting.Common.Entity.InterfacesDB
{
    /// <summary>
    /// Интерфейс создания и модификации записей в хранилище
    /// </summary>
    public interface IDbWriter
    {
        /// <summary>
        /// Добавить новую запись
        /// </summary>
        void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// Изменить запись
        /// </summary>
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// Удалить запись
        /// </summary>
        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;
    }
}
