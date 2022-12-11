namespace RentACarPlatform.Core.Models.Car
{
    public class CarsQueryModel
    {
        public int TotalCarsCount { get; set; }

        public IEnumerable<CarServiceModel> Cars { get; set; } = new List<CarServiceModel>();
    }
}
