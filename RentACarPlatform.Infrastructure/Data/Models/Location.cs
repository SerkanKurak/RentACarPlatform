using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.LocationData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class Location
    {
        public virtual ICollection<Rental> PickUpRental { get; set; } = null!;
       
        public virtual ICollection<Rental> DropOffRental { get; set; } = null!;


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
