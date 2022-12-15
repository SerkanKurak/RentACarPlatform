using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.ApplicationUserData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
                  
        public string? FirstName { get; set; } 
        
        public string? LastName { get; set; } 
      
        public string? CountryName { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
