using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
                 .HasForeignKey(r => r.DropOffLocationId);
        
              modelBuilder.Entity<Rental>()
             .HasOne(r => r.PickUpLocation)
             .WithMany(r => r.PickUpRental)
             .HasForeignKey(r => r.PickUpLocationId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Rental> Rentals { get; set; }
        
        public DbSet<Protection> Protections { get; set; }
        
        public DbSet<Location> Locations { get; set; }
        
        
        public DbSet<CarPurpose> CarPurposes { get; set; }
        
        public DbSet<CarCategory> CarCategories { get; set; }
    }
}