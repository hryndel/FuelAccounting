using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelAccounting.Context.Configuration.TypeConfigurations
{
    public class FuelEntityTypeConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.ToTable("Fuels");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            
            builder.Property(x => x.Price)
                .IsRequired();
        
            builder.Property(x => x.Count)
                .IsRequired();

            builder.HasIndex(x => x.FuelType)
                .HasFilter($"{nameof(Fuel.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Fuel)}_{nameof(Fuel.FuelType)}");

            builder.HasMany(x => x.FuelAccountingItem)
                .WithOne(x => x.Fuel)
                .HasForeignKey(x => x.FuelId);
        }
    }
}
