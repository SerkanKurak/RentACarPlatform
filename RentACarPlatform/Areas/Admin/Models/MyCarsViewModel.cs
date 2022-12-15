using RentACarPlatform.Core.Models.Car;

namespace RentACarPlatform.Areas.Admin.Models
{
    public class MyCarsViewModel
    {
        public IEnumerable<CarServiceModel> AddedHouses { get; set; }
            = new List<CarServiceModel>();

        public IEnumerable<CarServiceModel> RentedHouses { get; set; }
            = new List<CarServiceModel>();
    }
}
