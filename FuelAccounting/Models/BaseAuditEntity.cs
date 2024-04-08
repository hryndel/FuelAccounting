using FuelAccounting.Common.Entity.EntityInterfaces;

namespace FuelAccounting.Context.Contracts.Models
{
    /// <summary>
    /// Базовый класс с аудитом
    /// </summary>
    public abstract class BaseAuditEntity : IEntity,
        IEntityAuditCreated,
        IEntityAuditDeleted,
        IEntityAuditUpdated,
        IEntityWithId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Автор создания
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Автор изменения
        /// </summary>
        public string UpdatedBy { get; set;} = string.Empty;

        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
