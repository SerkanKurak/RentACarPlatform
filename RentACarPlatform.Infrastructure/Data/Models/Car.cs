using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RentACarPlatform.Infrastructure.Data.Constants.DataConstants.CarData;

namespace RentACarPlatform.Infrastructure.Data.Models
{
    /// <summary>
    /// Car entity
    /// </summary>
    public class Car
    {
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Car Make - BMW, Mercedes, Audi ....
        /// </summary>
        [Required]
        [MaxLength(MakeMaxLength)]
        [MinLength(MakeMinLength)]
        public string Make { get; set; } = null!;


        /// <summary>
        /// Car Model A8 , S500, Corolla ....
        /// </summary>
        [Required]
        [MaxLength(ModelMaxLength)]
        [MinLength(ModelMinLength)]
        public string Model { get; set; } = null!;


        /// <summary>
        /// Car FuelType - Дизел or Бензин
        /// </summary>
        [Required]
        [MaxLength(FuelTypeMaxLength)]
        [MinLength(FuelTypeMinLength)]
        public string FuelType { get; set; } = null!;


        /// <summary>
        /// Gearbox type - Автоматична or Ръчна
        /// </summary>
        [Required]
        [MaxLength(GearboxMaxLength)]
        [MinLength(GearboxMinLength)]
        public string Gearbox { get; set; } = null!;
        

        /// <summary>
        /// Car manufacture year 
        /// </summary>
        [Required]
        public string Year { get; set; } = null!;


        /// <summary>
        /// Car doors count - 2, 4
        /// </summary>
        [Required]
        [Range(DoorsMinCount, DoorsMaxCount)]
        public int Doors { get; set; }


        /// <summary>
        /// Seats count on car - 2, 5, 7
        /// </summary>
        [Required]
        [Range(SeatsMinCount, SeatsMaxCount)]
        public int Seats { get; set; }


        /// <summary>
        /// Car Tank capacity in liters
        /// </summary>
        [Required]
        [Range(MinTankCapacity, MaxTankCapacity)]
        public int TankCapacity { get; set; }


        /// <summary>
        /// Car Fuel consumption for 100km
        /// </summary>
        [Required]
        [Range(MinFuelConsumption, MaxFuelConsumption)]
        public double FuelConsumption { get; set; }


        /// <summary>
        /// Car Trunk volume in m3
        /// </summary>
        [Required]
        public int TrunkVolume { get; set; }


        /// <summary>
        /// Car Horsepower
        /// </summary>
        [Required]
        [Range(MinHorsepower, MaxHorsepower)]
        public int Horsepower { get; set; }


        /// <summary>
        /// Car Cubage - 2000, 3000, 3500 ...
        /// </summary>
        [Required]
        [Range(MinCubage, MaxCubage)]
        public int Cubage { get; set; }


        /// <summary>
        /// Price per day for rent
        /// </summary>
        [Required]       
        public decimal PricePerDay { get; set; }


        /// <summary>
        /// Car image
        /// </summary>
        [Required]
        [MaxLength(MaxImageUrlLenght)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public bool Availability { get; set; } = true;


        /// <summary>
        /// Location where is the car
        /// </summary>
        [Required]
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
      
        public Location Location { get; set; } = null!;
      

        /// <summary>
        /// Car Category - Седан, Комби, Джип ....
        /// </summary>
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
      
        public CarCategory Category { get; set; } = null!;
      

        /// <summary>
        /// Purpose of the car - Локсозен, Икономичен, Стандартен ...
        /// </summary>
        [Required]
        [ForeignKey(nameof(Purpose))]
        public int PurposeId { get; set; }
      
        public CarPurpose Purpose { get; set; } = null!;

        
        [Required]
        [ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }

        public Agent Agent { get; set; } = null!;


        [ForeignKey(nameof(Renter))]
        public string? RenterId { get; set; }
    
        public ApplicationUser? Renter { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
