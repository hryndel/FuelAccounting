namespace FuelAccounting.API.ModelsRequest.FuelStation
{
    /// <summary>
    /// Модель запроса создания поставщика
    /// </summary>
    public class CreateFuelStationRequest
    {
        /// <summary>
        /// Название АЗС
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
    }
}
