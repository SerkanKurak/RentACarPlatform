using Microsoft.AspNetCore.Identity;
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
                       
            modelBuilder.ApplyConfiguration(new AgentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CarCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CarPurposeConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new ProtectionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; } = null!;
       
        public DbSet<Protection> Protections { get; set; } = null!;

        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<CarPurpose> CarPurposes { get; set; } = null!;

        public DbSet<CarCategory> CarCategories { get; set; } = null!;

        public DbSet<Agent> Agents { get; set; } = null!;
    }
}