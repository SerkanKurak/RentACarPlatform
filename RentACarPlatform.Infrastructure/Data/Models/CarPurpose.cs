using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.CarPurposeData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    /// <summary>
    /// CarPurpose entity
    /// </summary>
    public class CarPurpose
    {
        public CarPurpose()
        {
            this.Cars = new List<Car>();
        }

        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Car Purpose name - Стандартен, Икономичен, Луксозен...
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        /// <summary>
        /// One Car Purpose have many cars
        /// </summary>
        public List<Car> Cars { get; set; }
    }
}
