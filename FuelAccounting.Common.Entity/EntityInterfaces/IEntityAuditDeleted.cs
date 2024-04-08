namespace FuelAccounting.Common.Entity.EntityInterfaces
{
    /// <summary>
    /// Аудит удаления сущности
    /// </summary>
    public interface IEntityAuditDeleted
    {
        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
