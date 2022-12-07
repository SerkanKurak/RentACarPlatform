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
