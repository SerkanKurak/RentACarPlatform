﻿using RentACarPlatform.Core.Models.Car;

namespace RentACarPlatform.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarHomeModel>> AllCars();

        Task<IEnumerable<CarCategoryModel>> AllCategories();

        Task<bool> CategoryExist(int categoryId);

        Task<int> Create(CarModel model);

        Task<CarsQueryModel> All(
             string? category = null,
             string? searchTerm = null,
             // CarPickUpLocation carPickUpLocation = CarPickUpLocation.СофияОфис,
             CarSorting sorting = CarSorting.Newest,
             int currPage = 1,
             int carsOnPage = 1);


        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<CarServiceModel>> AllCarsByUserId(string userId);
         
        Task<CarSpecificationsModel>  CarSpecificationsById(int id);

        Task<bool> IsExist(int id);

        Task Edit(int carId, CarModel model);

        Task<int> GetCarCategoryId(int carId);

        Task Delete(int carId);

    }
}
