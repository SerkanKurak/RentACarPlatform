using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Infrastructure.Data.Configurations
{
    internal class CarPurposeConfiguration : IEntityTypeConfiguration<CarPurpose>
    {
        public void Configure(EntityTypeBuilder<CarPurpose> builder)
        {
            builder.HasData(CreateCarPurposes());
        }

        private List<CarPurpose> CreateCarPurposes()
        {
            List<CarPurpose> purposes = new List<CarPurpose>()
            {

                new CarPurpose()
                {
                    Id = 1,
                    Name = "Икономичен"
                },

                new CarPurpose()
                {
                    Id = 2,
                    Name = "Икономичен Комби"
                },

                new CarPurpose()
                {
                    Id = 3,
                    Name = "Компактен"
                },

                new CarPurpose()
                {
                    Id = 4,
                    Name = "Стандартен"
                },

                new CarPurpose()
                {
                    Id = 5,
                    Name = "Стандартен Комби"
                },

                new CarPurpose()
                {
                    Id = 6,
                    Name = "Голям"
                },

                new CarPurpose()
                {
                    Id = 7,
                    Name = "Луксозен"
                },

        };

            return purposes;
        }
    }
}
