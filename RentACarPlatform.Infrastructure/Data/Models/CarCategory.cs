using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.CarCategoryData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    /// <summary>
    /// CarCategory entity 
    /// </summary>
    public class CarCategory
    {
        public CarCategory()
        {
            this.Cars = new List<Car>();
        }

        /// <summary>
        /// Car Category Id
        /// </summary>
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Car Category name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// One Car Category have many cars
        /// </summary>
        public List<Car> Cars { get; set; }
    }
}
