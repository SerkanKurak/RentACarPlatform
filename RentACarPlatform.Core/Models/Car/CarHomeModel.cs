namespace RentACarPlatform.Core.Models.Car
{
    public class CarHomeModel
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    } 
}
