namespace FuelAccounting.Services.Contracts.Exceptions
{
    /// <summary>
    /// Запрашиваемая сущность не найдена
    /// </summary>
    public class FuelAccountingEntityNotFoundException<TEntity> : FuelAccountingNotFoundException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelAccountingEntityNotFoundException{TEntity}"/>
        /// </summary>
        public FuelAccountingEntityNotFoundException(Guid id)
            : base($"Сущность {typeof(TEntity)} c id = {id} не найдена.")
        { }
    }
}
