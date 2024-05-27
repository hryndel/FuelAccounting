using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FuelAccounting.Context
{
    /// <summary>
    /// Фабрика для создания контекста в DesignTime (Миграции)
    /// </summary>
    public class SampleContextFactory : IDesignTimeDbContextFactory<FuelAccountingContext>
    {
        public FuelAccountingContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<FuelAccountingContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new FuelAccountingContext(options);
        }
    }
}
