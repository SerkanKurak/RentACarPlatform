using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.ProtectionData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class Protection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Coverage { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }
}
