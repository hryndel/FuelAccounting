namespace FuelAccounting.API.ModelsRequest.User
{
    public class UserRequest : CreateUserRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
