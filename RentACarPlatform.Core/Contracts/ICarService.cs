using RentACarPlatform.Core.Models.Car;

namespace RentACarPlatform.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarHomeModel>> AllCars();
    }
}
