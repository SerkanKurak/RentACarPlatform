using RentACarPlatform.Core.Models.Car;

namespace RentACarPlatform.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarHomeModel>> AllCars();

        Task<IEnumerable<CarCategoryModel>> AllCategories();

        Task<bool> CategoryExist(int categoryId);

        Task<int> Create(CarModel model);
    }
}
