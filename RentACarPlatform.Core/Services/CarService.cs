using Microsoft.EntityFrameworkCore;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Models.Car;
using RentACarPlatform.Infrastructure.Data.Common;
using RentACarPlatform.Infrastructure.Data.Models;

namespace RentACarPlatform.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        public CarService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<CarsQueryModel> All(string? category = null, string? searchTerm = null, CarSorting sorting = CarSorting.Newest, int currPage = 1, int carsOnPage = 1)
        {
            var cars = repo.AllReadonly<Car>();

            var result = new CarsQueryModel();

            if (string.IsNullOrEmpty(category) == false)
            {
                cars = cars.Where(c => c.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                cars = cars
                    .Where(c => EF.Functions.Like(c.Make.ToLower(), searchTerm) ||
                        EF.Functions.Like(c.Model.ToLower(), searchTerm));
                       

            }

            switch (sorting)
            {
                case CarSorting.Price:
                    cars = cars
                    .OrderBy(c => c.PricePerDay);
                    break;
                case CarSorting.NotRentedFirst:
                    cars = cars
                    .OrderBy(c => c.Id);
                    break;
                default:
                    cars = cars.OrderByDescending(c => c.Id);
                    break;
            }

            
            result.Cars = await cars
               .Skip((currPage - 1) * carsOnPage)
               .Take(carsOnPage)
               .Select(c => new CarServiceModel()
               {
                   Make = c.Make,
                   Id = c.Id,
                   ImageUrl = c.ImageUrl,
                   PricePerDay = c.PricePerDay,
                   IsRented = c.Availability,
                   Model = c.Model
               })
               .ToListAsync();

            result.TotalCarsCount = await cars.CountAsync();

            return result;
        }

        public async Task<IEnumerable<CarHomeModel>> AllCars()
        {
            return await repo.AllReadonly<Car>()
                   .Select(c => new CarHomeModel()
                   {
                       Id = c.Id,
                       Make = c.Make,
                       Model = c.Model,
                       ImageUrl = c.ImageUrl
                   })
                   .ToListAsync();
        }

        public async Task<IEnumerable<CarCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<CarCategory>()
                .Select(c => new CarCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name                   
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<CarCategory>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExist(int categoryId)
        {
            return await repo.AllReadonly<CarCategory>()
                  .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(CarModel model)
        {
            var car = new Car()
            {
                Make = model.Make,
                Model = model.Model,
                FuelType = model.FuelType,
                Gearbox = model.Gearbox,
                Year = model.Year,
                Doors = model.Doors,
                Seats = model.Seats,
                TankCapacity = model.TankCapacity,
                FuelConsumption = model.FuelConsumption,
                TrunkVolume = model.TrunkVolume,
                Horsepower = model.Horsepower,
                Cubage = model.Cubage,
                PricePerDay = model.PricePerDay,
                ImageUrl = model.ImageUrl,
                Availability = model.Availability,
                CategoryId = model.CategoryId,
            };

            await repo.AddAsync(car);
            await repo.SaveChangesAsync();

            return car.Id;
        }
    }
}
