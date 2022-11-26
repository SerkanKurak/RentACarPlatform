using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.CarCategory;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class CarCategory
    {
        public CarCategory()
        {
            this.Cars = new List<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Car> Cars { get; set; }
    }
}
