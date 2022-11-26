using RentACarPlatform.Contracts;
using RentACarPlatform.Infrastructure.Data;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Services
{
    public class HomeService :IHomeService
    {
        private readonly ApplicationDbContext _context;
        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddLocation(string locationName)
        {
            _context.Locations.Add(new Location { Name = locationName });
            _context.SaveChanges();
        }
    }
}
