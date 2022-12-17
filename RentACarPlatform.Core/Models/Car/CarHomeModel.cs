namespace RentACarPlatform.Core.Models.Car
{
    /// <summary>
    /// Model for Car on home page
    /// </summary>
    public class CarHomeModel
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    } 
}
