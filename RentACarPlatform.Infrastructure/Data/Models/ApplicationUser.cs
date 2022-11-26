using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.ApplicationUserData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;


        [Required]
        [MaxLength(CountryNameMaxLength)]
        public string CountryName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
