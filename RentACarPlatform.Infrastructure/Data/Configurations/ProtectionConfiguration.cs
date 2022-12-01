using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Infrastructure.Data.Configurations
{
    internal class ProtectionConfiguration : IEntityTypeConfiguration<Protection>
    {
        public void Configure(EntityTypeBuilder<Protection> builder)
        {
            builder.HasData(CreateProtections());
        }

        private List<Protection> CreateProtections()
        {
            List<Protection> protections = new List<Protection>()
            {

                new Protection()
                {
                    Id = 1,
                    Name = "Основен",
                    Coverage = "Защита от кражба",
                    Price = 0.00M
                },

                new Protection()
                {
                    Id = 2,
                    Name = "Среден",
                    Coverage = "Защита от кражба," +
                               "Застраховка злополука," +
                               "Покрива щети на челното стъкло, фарове и гуми",
                    Price = 30.00M
                },

                new Protection()
                {
                    Id = 3,
                    Name = "Висок",
                    Coverage = "Защита от кражба," +
                               "Застраховка злополука," +
                               "Покрива щети на челното стъкло, фарове и гуми," +
                               "Застраховка на багажа",
                    Price = 50.00M
                },

             };

            return protections;
        }
    }
}
