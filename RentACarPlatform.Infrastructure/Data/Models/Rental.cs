using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public Car Car { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;


        public int? PickUpLocationId { get; set; }

        public Location PickUpLocation { get; set; } = null!;


        public int? DropOffLocationId { get; set; }

        public Location DropOffLocation { get; set; } = null!;


        [Required]
        public DateTime PickUpTime { get; set; }


        [Required]
        public DateTime DropOffTime { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
