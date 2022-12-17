using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.ProtectionData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    /// <summary>
    /// Protection entity
    /// </summary>
    public class Protection
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Protection Type Name - Основен, Среден, Висок
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        /// <summary>
        /// What does this type of protection cover
        /// </summary>
        [Required]
        public string Coverage { get; set; } = null!;


        /// <summary>
        /// Price for the protection type
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}
