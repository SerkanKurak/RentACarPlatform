using RentACarPlatform.Core.Models.Car;

namespace RentACarPlatform.Areas.Admin.Models
{
    public class MyCarsViewModel
    {
        public IEnumerable<CarServiceModel> AddedCars { get; set; }
           = new List<CarServiceModel>();

        public IEnumerable<CarServiceModel> RentedCars { get; set; }
            = new List<CarServiceModel>();
    }
}
