using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelAccounting.Context.Configuration.TypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
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

            builder.Property(x => x.Mail)
                .IsRequired()
                .HasMaxLength(320);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Password)
                .IsRequired();

            builder.HasIndex(x => x.Login)
                .IsUnique()
                .HasFilter($"{nameof(User.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(User)}_{nameof(User.Login)}");
        }
    }
}
