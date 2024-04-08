using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelAccounting.Context.Configuration.TypeConfigurations
{
    public class FuelAccountingItemEntityTypeConfiguration : IEntityTypeConfiguration<FuelAccountingItem>
    {
        public void Configure(EntityTypeBuilder<FuelAccountingItem> builder)
        {
            builder.ToTable("FuelAccountingItems");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired();

            builder.HasIndex(x => new { x.StartDate, x.EndDate })
                .HasFilter($"{nameof(FuelAccountingItem.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(FuelAccountingItem)}_{nameof(FuelAccountingItem.StartDate)}_{nameof(FuelAccountingItem.EndDate)}");
        }
    }
}
