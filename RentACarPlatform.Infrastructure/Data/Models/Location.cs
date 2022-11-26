using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.LocationData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class Location
    {
        [InverseProperty(nameof(Rental.PickUpLocation))]
        public ICollection<Rental> PickUpRental { get; set; } = null!;

        [InverseProperty(nameof(Rental.DropOffLocation))]
        public ICollection<Rental> DropOffRental { get; set; } = null!;


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
