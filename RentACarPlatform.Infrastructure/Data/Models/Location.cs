using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.LocationData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    /// <summary>
    /// Location entity
    /// </summary>
    public class Location
    {
        
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Location Name - София - Летище Терминал 1, Варна - Летище ....
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
