using RentACarPlatform.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarPlatform.Core.Models.Car
{
    public class CarSpecificationsModel : CarServiceModel
    {
        [Display(Name = "Fuel type")]
        public string FuelType { get; set; } = null!;
     
        public string Gearbox { get; set; } = null!;

        public string Year { get; set; } = null!;
        
        public int Doors { get; set; }
      
        public int Seats { get; set; }

        public int TankCapacity { get; set; }

        [Display(Name = "Fuel consumption")]
        public double FuelConsumption { get; set; }

        [Display(Name = "Trunk volume")]
        public int TrunkVolume { get; set; }

        public int Horsepower { get; set; }

        public int Cubage { get; set; }

        public CarCategory Category { get; set; } = null!;
        
        public CarPurpose Purpose { get; set; } = null!;

        public Location Location { get; set; } = null!;

    }
}
