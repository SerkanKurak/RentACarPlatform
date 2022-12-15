using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.AgentData;

namespace RentACarPlatform.Core.Models.Agent
{
    public class BecomeAgentModel
    {
        [Required]
        [MinLength(PhoneNumberMinLength)]
        [MaxLength(PhoneNumberMaxLength)]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
