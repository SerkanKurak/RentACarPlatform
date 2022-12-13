using RentACarPlatform.Core.Models.Car;

namespace RentACarPlatform.Models
{
    public class AllCarsQueryModel
    {

        public const int CarsOnPage = 3;

        public CarPickUpLocation PickUpLocation { get; set; }

        //public string? DropOffLocation { get; set; }

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public CarSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalCarsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<CarServiceModel> Cars { get; set; } = Enumerable.Empty<CarServiceModel>();
    }
}
