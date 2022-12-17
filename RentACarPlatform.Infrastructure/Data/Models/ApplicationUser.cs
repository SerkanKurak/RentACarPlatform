using Microsoft.AspNetCore.Identity;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    /// <summary>
    /// ApplicationUser entity
    /// </summary>
    public class ApplicationUser : IdentityUser<string>
    {
                  
        public string? FirstName { get; set; } 
        
        public string? LastName { get; set; } 
      
        public string? CountryName { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
