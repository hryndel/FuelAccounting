namespace FuelAccounting.API.Infrastructures.Exceptions
{
    /// <summary>
    /// Информация об ошибке работы API
    /// </summary>
    public class ApiExceptionDetail
    {
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
