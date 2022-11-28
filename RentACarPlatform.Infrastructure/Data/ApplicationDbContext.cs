using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACarPlatform.Infrastructure.Data.Configurations;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            
            modelBuilder.Entity<Rental>()
                 .HasOne(r => r.DropOffLocation)
                 .WithMany(r => r.DropOffRental)
                 .HasForeignKey(r => r.DropOffLocationId)
                 .OnDelete(DeleteBehavior.ClientSetNull);
        
              modelBuilder.Entity<Rental>()
             .HasOne(r => r.PickUpLocation)
             .WithMany(r => r.PickUpRental)
             .HasForeignKey(r => r.PickUpLocationId)
             .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.ApplyConfiguration(new CarCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CarPurposeConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Rental> Rentals { get; set; } = null!;

        public DbSet<Protection> Protections { get; set; } = null!;

        public DbSet<Location> Locations { get; set; } = null!;


        public DbSet<CarPurpose> CarPurposes { get; set; } = null!;

        public DbSet<CarCategory> CarCategories { get; set; } = null!;

        public DbSet<ApplicationUser> Users { get; set; } = null!;
    }
}