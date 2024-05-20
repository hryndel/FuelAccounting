namespace FuelAccounting.Common.Entity.InterfacesDB
{
    /// <summary>
    /// Интерфейс аудита авторизации
    /// </summary>
    public interface IIdentityProvider
    {
        public Guid Id { get; }

        public string Name { get; }

        public IEnumerable<KeyValuePair<string, string>> Claims { get; }
    }
}
