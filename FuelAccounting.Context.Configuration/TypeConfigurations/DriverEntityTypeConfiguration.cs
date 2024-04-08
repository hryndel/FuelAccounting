using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelAccounting.Context.Configuration.TypeConfigurations
{
    public class DriverEntityTypeConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Drivers");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Patronymic)
                .HasMaxLength(50);

            builder.Property(x => x.Phone) 
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.DriversLicense)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasIndex(x => x.DriversLicense)
                .IsUnique()
                .HasFilter($"{nameof(Driver.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Driver)}_{nameof(Driver.DriversLicense)}");

            builder.HasMany(x => x.FuelAccountingItem)
                .WithOne(x => x.Driver)
                .HasForeignKey(x => x.DriverId);
        }
    }
}
