namespace FuelAccounting.API.ModelsRequest.Trailer
{
    /// <summary>
    /// Модель запроса создания полуприцепа
    /// </summary>
    public class CreateTrailerRequest
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Государственный номер
        /// </summary>
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Вместимость
        /// </summary>
        public double Capacity { get; set; }
    }
}
