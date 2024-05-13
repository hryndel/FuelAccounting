namespace FuelAccounting.Services.Contracts.Exceptions
{
    /// <summary>
    /// Ошибка выполнения операции
    /// </summary>
    public class FuelAccountingInvalidOperationException : FuelAccountingException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FuelAccountingInvalidOperationException"/>
        /// с указанием сообщения об ошибке
        /// </summary>
        public FuelAccountingInvalidOperationException(string message)
            : base(message) { }
    }
}
