using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.AgentData;


namespace RentACarPlatform.Infrastructure.Data.Models
{
    /// <summary>
    /// Agent entity
    /// </summary>
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Agent Phone number
        /// </summary>
        [Required]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;


        /// <summary>
        /// User which is Agent
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;
    }
}
