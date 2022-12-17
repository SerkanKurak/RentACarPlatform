using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Infrastructure.Data.Configurations
{
    internal class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(CreateLocations());
        }

        /// <summary>
        /// Create Locations 
        /// </summary>
        private List<Location> CreateLocations()
        {
            List<Location> locations = new List<Location>()
            {

                new Location()
                {
                    Id = 1,
                    Name = "София - Офис"
                },

                new Location()
                {
                    Id = 2,
                    Name = "София - Избран от вас адрес"
                },

                new Location()
                {
                    Id = 3,
                    Name = "София - Летище Терминал 1"
                },

                new Location()
                {
                    Id = 4,
                    Name = "София - Летище Терминал 2"
                },

                new Location()
                {
                    Id = 5,
                    Name = "Варна - Офис"
                },

                new Location()
                {
                    Id = 6,
                    Name = "Варна - Избран от вас адрес"
                },

                new Location()
                {
                    Id = 7,
                    Name = "Варна - Летище"
                },

                new Location()
                {
                    Id = 8,
                    Name = "Пловдив - Офис"
                },

                new Location()
                {
                    Id = 9,
                    Name = "Пловдив - Избран от вас адрес"
                },

                new Location()
                {
                    Id = 10,
                    Name = "Пловдив - Летище"
                },

        };

            return locations;
        }
    }
}
