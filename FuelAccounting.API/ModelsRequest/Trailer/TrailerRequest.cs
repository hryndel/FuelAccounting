namespace FuelAccounting.API.ModelsRequest.Trailer
{
    /// <summary>
    /// Модель запроса редактирования полуприцепа
    /// </summary>
    public class TrailerRequest : CreateTrailerRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
