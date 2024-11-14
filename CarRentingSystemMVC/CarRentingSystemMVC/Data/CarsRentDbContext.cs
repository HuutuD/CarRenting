using CarRentingSystemMVC.Data.Models;
using CarRentingSystemMVC.Seeding;
using CarRentingSystemMVC.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Composition;

namespace CarRentingSystemMVC.Data
{
    public class CarsRentDbContext : IdentityDbContext
    {
        public CarsRentDbContext() { }
        public CarsRentDbContext(DbContextOptions<CarsRentDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<RentalHistory> RentalHistories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>()
                .HasData(DataSeeder.UserSeed());

            builder.Entity<Category>()
                .HasData(DataSeeder.CategoriesSeed().Select(c => c));

            builder.Entity<Car>()
                .HasData(DataSeeder.CarsSeed().Select(c => c));

            builder.Entity<Car>()
                .Property(c => c.Price)
                .HasDefaultValue(DataConstants.PriceDefault);

            base.OnModelCreating(builder);
        }
    }
}