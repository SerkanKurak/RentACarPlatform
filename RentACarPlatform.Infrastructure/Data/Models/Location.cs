using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.LocationData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class Location
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
