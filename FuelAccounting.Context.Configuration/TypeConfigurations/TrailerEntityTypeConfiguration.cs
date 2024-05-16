using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelAccounting.Context.Configuration.TypeConfigurations
{
    public class TrailerEntityTypeConfiguration : IEntityTypeConfiguration<Trailer>
    {
        public void Configure(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailers");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();
            
            builder.Property(x => x.Name)
                .IsRequired()
               .HasMaxLength(100);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Capacity)
                .IsRequired();

            builder.HasIndex(x => x.Number)
                .IsUnique()
                .HasFilter($"{nameof(Trailer.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Trailer)}_{nameof(Trailer.Number)}");

            builder.HasMany(x => x.FuelAccountingItem)
                .WithOne(x => x.Trailer)
                .HasForeignKey(x => x.TrailerId);
        }
    }
}
