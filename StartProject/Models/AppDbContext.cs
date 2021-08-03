using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartProject.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PickupDocument> PickupDocuments { get; set; }
        public DbSet<PickupProduct> PickupProducts { get; set; }
        public DbSet<StoreHouse> StoreHouses { get; set; }
        public DbSet<StoreHouseAvailability> StoreHouseAvailabilities { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.EAN)
                .HasMaxLength(30);
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.EAN)
                .IsUnique();

            modelBuilder.Entity<StoreHouse>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(l => l.Address)
                .HasMaxLength(100);
            modelBuilder.Entity<Location>()
                .HasIndex(l => l.Address)
                .IsUnique();
        }
    }
}
