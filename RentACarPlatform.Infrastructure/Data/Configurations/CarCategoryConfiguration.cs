using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Infrastructure.Data.Configurations
{
    internal class CarCategoryConfiguration : IEntityTypeConfiguration<CarCategory>
    {
        public void Configure(EntityTypeBuilder<CarCategory> builder)
        {
            builder.HasData(CreateCarCategories());
        }

        private List<CarCategory> CreateCarCategories()
        {
            List<CarCategory> categories = new List<CarCategory>()
            {

                new CarCategory()
                {
                    Id = 1,
                    Name = "Седан"
                },

                new CarCategory()
                {
                    Id = 2,
                    Name = "Комби"
                },

                new CarCategory()
                {
                    Id = 3,
                    Name = "Джип"
                },
                
                new CarCategory()
                {
                    Id = 4,
                    Name = "Пикап"
                },

                new CarCategory()
                {
                    Id = 5,
                    Name = "Купе"
                },

                new CarCategory()
                {
                    Id = 6,
                    Name = "Кабрио"
                },

                new CarCategory()
                {
                    Id = 7,
                    Name = "Ван"
                },

                new CarCategory()
                {
                    Id = 8,
                    Name = "Хечбег"
                },

        };

            return categories;
        }
    }
}
