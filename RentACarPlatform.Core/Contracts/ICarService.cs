using RentACarPlatform.Core.Models.Car;

namespace RentACarPlatform.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarHomeModel>> AllCars();

        Task<IEnumerable<CarCategoryModel>> AllCategories();

        Task<bool> CategoryExist(int categoryId);

        Task<int> Create(CarModel model, int agentId);

        Task<CarsQueryModel> All(
             string? category = null,
             string? searchTerm = null,
             string? pickUpLocation = null,
             string? dropOffLocation = null,
             CarSorting sorting = CarSorting.Newest,
             int currPage = 1,
             int carsOnPage = 1);


        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<string>> AllPickUpLocations();

        Task<IEnumerable<string>> AllDropOffLocations();

        Task<IEnumerable<CarServiceModel>> AllCarsByUserId(string userId);

        Task<IEnumerable<CarServiceModel>> AllCarsByAgentId(int id);

        Task<CarSpecificationsModel>  CarSpecificationsById(int id);

        Task<bool> IsExist(int id);

        Task Edit(int carId, CarModel model);

        Task<bool> HasAgentWithId(int carId, string currentUserId);

        Task<int> GetCarCategoryId(int carId);

        Task Delete(int carId);

        Task<bool> IsRented(int carId);

        Task<bool> IsRentedByUserWithId(int carId, string currentUserId);

        Task Rent(int carId, string currentUserId);

        Task Leave(int carId);

    }
}
