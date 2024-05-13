namespace FuelAccounting.Services.Contracts.Exceptions
{
    /// <summary>
    /// Запрашиваемый ресурс не найден
    /// </summary>
    internal class FuelAccountingNotFoundException : FuelAccountingException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelAccountingNotFoundException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        public FuelAccountingNotFoundException(string message)
            : base(message) { }
    }
}