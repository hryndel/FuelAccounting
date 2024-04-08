using FuelAccounting.Common.Entity.InterfacesDB;
using FuelAccounting.Context.Configuration;
using FuelAccounting.Context.Contracts;
using FuelAccounting.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelAccounting.Context
{
    public class FuelAccountingContext : DbContext,
        IFuelAccountingContext,
        IDbReader,
        IDbWriter,
        IUnitOfWork
    {
        public DbSet<Driver> Drivers {  get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<FuelAccountingItem> FuelAccountingItems { get; set; }
        public DbSet<FuelStation> FuelStations { get; set;}
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Truck> Trucks { get; set; }

        public FuelAccountingContext(DbContextOptions<FuelAccountingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IContextConfigurationAnchor).Assembly);
        }

        IQueryable<TEntity> IDbReader.Read<TEntity>()
            => base.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();

        void IDbWriter.Add<TEntities>(TEntities entity)
            => base.Entry(entity).State = EntityState.Added;

        void IDbWriter.Update<TEntities>(TEntities entity)
            => base.Entry(entity).State = EntityState.Modified;

        void IDbWriter.Delete<TEntities>(TEntities entity)
            => base.Entry(entity).State = EntityState.Deleted;

        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            var count = await base.SaveChangesAsync(cancellationToken);
            foreach (var entry in base.ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }
            return count;
        }
    }
}
