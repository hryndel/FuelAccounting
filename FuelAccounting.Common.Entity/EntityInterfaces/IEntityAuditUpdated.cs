namespace FuelAccounting.Common.Entity.EntityInterfaces
{
    /// <summary>
    /// Аудит создания сущности
    /// </summary>
    public interface IEntityAuditUpdated
    {
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTimeOffset UpdatedAt {  get; set; }

        /// <summary>
        /// Автор изменения
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}
