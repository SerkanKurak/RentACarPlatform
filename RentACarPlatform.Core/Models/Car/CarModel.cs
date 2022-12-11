using System.ComponentModel.DataAnnotations;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.CarData;

namespace RentACarPlatform.Core.Models.Car
{
    public class CarModel
    {
        [Required]
        [MaxLength(MakeMaxLength)]
        [MinLength(MakeMinLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        [MinLength(ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(FuelTypeMaxLength)]
        [MinLength(FuelTypeMinLength)]
        public string FuelType { get; set; } = null!;

        [Required]
        [MaxLength(GearboxMaxLength)]
        [MinLength(GearboxMinLength)]
        public string Gearbox { get; set; } = null!;

        [Required]
        public string Year { get; set; } = null!;

        [Required]
        [Range(DoorsMinCount, DoorsMaxCount)]
        public int Doors { get; set; }

        [Required]
        [Range(SeatsMinCount, SeatsMaxCount)]
        public int Seats { get; set; }

        [Required]
        [Range(MinTankCapacity, MaxTankCapacity)]
        public int TankCapacity { get; set; }

        [Required]
        [Range(MinFuelConsumption, MaxFuelConsumption)]
        public double FuelConsumption { get; set; }

        [Required]
        public int TrunkVolume { get; set; }

        [Required]
        [Range(MinHorsepower, MaxHorsepower)]
        public int Horsepower { get; set; }

        [Required]
        [Range(MinCubage, MaxCubage)]
        public int Cubage { get; set; }

        [Required]
        [Display(Name = "Price per day")]
        [Range(50.00, 1000.00, ErrorMessage = "Price per day must be more than {1} and less than {2} leva")]
        public decimal PricePerDay { get; set; }

        [Required]
        [MaxLength(MaxImageUrlLenght)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public bool Availability { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CarCategoryModel> CarCategories { get; set; } = new List<CarCategoryModel>();
    }
}
