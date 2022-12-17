using System.ComponentModel.DataAnnotations;

namespace RentACarPlatform.Core.Models.Car
{
    /// <summary>
    /// Model for Car Specifications
    /// </summary>
    public class CarServiceModel
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Is Rented")]
        public bool IsRented { get; set; }
    }
}
