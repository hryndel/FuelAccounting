using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelAccounting.Context.Configuration.TypeConfigurations
{
    public class FuelStationEntityTypeConfiguration : IEntityTypeConfiguration<FuelStation>
    {
        public void Configure(EntityTypeBuilder<FuelStation> builder)
        {
            builder.ToTable("FuelStations");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(100);

            builder.HasIndex(x => x.Address)
                .IsUnique()
                .HasFilter($"{nameof(FuelStation.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(FuelStation)}_{nameof(FuelStation.Address)}");

            builder.HasMany(x => x.FuelAccountingItem)
                .WithOne(x => x.FuelStation)
                .HasForeignKey(x => x.FuelStationId);
        }
    }
}
