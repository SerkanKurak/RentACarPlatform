using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.ApplicationUserData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
               
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; } 


        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; } 

    
        [MaxLength(CountryNameMaxLength)]
        public string? CountryName { get; set; } 

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
