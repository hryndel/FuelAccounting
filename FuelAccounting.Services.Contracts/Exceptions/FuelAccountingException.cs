namespace FuelAccounting.Services.Contracts.Exceptions
{
    /// <summary>
    /// Базовый класс исключений
    /// </summary>
    public abstract class FuelAccountingException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelAccountingException"/> без параметров
        /// </summary>
        protected FuelAccountingException() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelAccountingException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        protected FuelAccountingException(string message)
            : base(message) { }
    }
}
