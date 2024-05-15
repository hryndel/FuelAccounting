using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelAccounting.Context.Configuration.TypeConfigurations
{
    public class TruckEntityTypeConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Trucks");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
                
            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Vin)
                .IsRequired()
                .HasMaxLength(20);
                
            builder.HasIndex(x => x.Vin)
                .IsUnique()
                .HasFilter($"{nameof(Truck.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Truck)}_{nameof(Truck.Vin)}");

            builder.HasMany(x => x.FuelAccountingItem)
                .WithOne(x => x.Truck)
                .HasForeignKey(x => x.TruckId);
        }
    }
}
