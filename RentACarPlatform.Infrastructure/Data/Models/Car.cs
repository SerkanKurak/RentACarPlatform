using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.CarData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

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
        public decimal PricePerDay { get; set; }

        [Required]
        [MaxLength(MaxImageUrlLenght)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public bool Availability { get; set; } = true;

        [Required]
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
      
        public Location Location { get; set; } = null!;
      
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
      
        public CarCategory Category { get; set; } = null!;
      
        [Required]
        [ForeignKey(nameof(Purpose))]
        public int PurposeId { get; set; }
      
        public CarPurpose Purpose { get; set; } = null!;


        [ForeignKey(nameof(Renter))]
        public string? RenterId { get; set; }
    
        public ApplicationUser? Renter { get; set; }
    }
}
