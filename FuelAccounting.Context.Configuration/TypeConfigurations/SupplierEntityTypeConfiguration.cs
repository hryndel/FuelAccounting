using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelAccounting.Context.Configuration.TypeConfigurations
{
    public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Inn)
                .IsRequired();

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Description)
                .HasMaxLength(100);

            builder.HasIndex(x => x.Inn)
                .IsUnique()
                .HasFilter($"{nameof(Supplier.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Supplier)}_{nameof(Supplier.Inn)}");

            builder.HasMany(x => x.Fuel)
                .WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SupplierId);
        }
    }
}
