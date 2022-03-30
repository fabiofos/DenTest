using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VendorMachineTest.Data.InitialData;
using VendorMachineTest.Domain.Entities;

namespace VendorMachineTest.Data.Context
{
    public class VendorMachineContext : DbContext
    {
        public VendorMachineContext(DbContextOptions<VendorMachineContext> options) : base(options)
        {
        }

        public DbSet<Machine> Machine { get; set; }
        public DbSet<MachineSlots> MachineSlots { get; set; }
        public DbSet<MachineLanguage> MachineLanguage { get; set; }
        public DbSet<MachineCurrency> MachineCurrency { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().Property(obj => obj.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Sales>().Property(obj => obj.ProductPrice).HasPrecision(18, 2);

            InitialLoadData.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedOn") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property("CreatedOn").CurrentValue == null)
                    {
                        entry.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
