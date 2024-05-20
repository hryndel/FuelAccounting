namespace FuelAccounting.API.ModelsRequest.User
{
    /// <summary>
    /// Модель запроса редактирования пользователя
    /// </summary>
    public class UserRequest : CreateUserRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
