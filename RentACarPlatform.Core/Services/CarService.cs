﻿using Microsoft.EntityFrameworkCore;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Exceptions;
using RentACarPlatform.Core.Models.Car;
using RentACarPlatform.Infrastructure.Data.Common;
using RentACarPlatform.Infrastructure.Data.Models;
using System;
using System.Xml.Linq;

namespace RentACarPlatform.Core.Services
{
   public class CarService : ICarService
   {
       private readonly IRepository repo;

       private readonly IGuard guard;

        public CarService(
               IRepository _repo,
               IGuard _guard)
       {
           repo = _repo;
           guard = _guard;
       }

        
        public async Task<CarsQueryModel> All(string? category = null, string? searchTerm = null, string? pickUpLocation = null, string? dropOffLocation = null, CarSorting sorting = CarSorting.Newest, int currPage = 1, int carsOnPage = 1)
       {
           var cars = repo.AllReadonly<Car>()
                          .Where(c => c.IsActive);
   
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
                   .OrderBy(c => c.Availability);
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
                  Id = c.Id,
                  Make = c.Make,
                  Model = c.Model,
                  ImageUrl = c.ImageUrl,
                  PricePerDay = c.PricePerDay,
                  IsRented = c.Availability,
                
              })
              .ToListAsync();
   
           result.TotalCarsCount = await cars.CountAsync();
   
           return result;
       }
   
       public async Task<IEnumerable<CarHomeModel>> AllCars()
       {
           return await repo.AllReadonly<Car>()
                  .Where(c => c.IsActive)
                  .Select(c => new CarHomeModel()
                  {
                      Id = c.Id,
                      Make = c.Make,
                      Model = c.Model,
                      ImageUrl = c.ImageUrl
                  })
                  .ToListAsync();
       }
   
        public async Task<IEnumerable<CarServiceModel>> AllCarsByUserId(string userId)
        {
            return await repo.AllReadonly<Car>()
                .Where(c => c.RenterId == userId)
                .Where(c => c.Availability)
                .Where(c => c.IsActive)
                .Select(c => new CarServiceModel()
                {                  
                   Id = c.Id,
                   Make = c.Make,
                   Model = c.Model,
                   ImageUrl = c.ImageUrl,
                   IsRented = c.RenterId != null,
                   PricePerDay = c.PricePerDay,                   
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

        public async Task<IEnumerable<string>> AllDropOffLocations()
        {
            return await repo.AllReadonly<Location>()
              .Select(c => c.Name)
              .Distinct()
              .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllPickUpLocations()
        {
            return await repo.AllReadonly<Location>()
              .Select(c => c.Name)
              .Distinct()
              .ToListAsync();
        }

        public async Task<CarSpecificationsModel> CarSpecificationsById(int id)
        {
            return await repo.AllReadonly<Car>()
                   .Where(c => c.Id == id)
                   .Where(c => c.IsActive)
                   .Select(c => new CarSpecificationsModel()
                   {
                       Id = c.Id,
                       Make = c.Make,
                       Model = c.Model,
                       ImageUrl = c.ImageUrl,
                       PricePerDay = c.PricePerDay,
                       IsRented = c.Availability, //c.RenterId != null
                       FuelType = c.FuelType,
                       Gearbox = c.Gearbox,
                       Year = c.Year,
                       Doors = c.Doors,
                       Seats = c.Seats,
                       TankCapacity = c.TankCapacity,
                       FuelConsumption = c.FuelConsumption,
                       TrunkVolume = c.TrunkVolume,
                       Horsepower = c.Horsepower,
                       Cubage = c.Cubage,
                       Category = c.Category,
                       Purpose = c.Purpose,
                       Location = c.Location,                                         
                   })
                   .FirstAsync();
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
               CategoryId = model.CategoryId,
           };
   
           await repo.AddAsync(car);
           await repo.SaveChangesAsync();
   
           return car.Id;
       }

        public async Task Delete(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            car.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task Edit(int carId, CarModel model)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            car.Make = model.Make;
            car.Model = model.Model;
            car.FuelType = model.FuelType;
            car.Gearbox = model.Gearbox;
            car.Year = model.Year;
            car.Seats = model.Seats;
            car.Doors = model.Doors;
            car.TankCapacity = model.TankCapacity;
            car.FuelConsumption = model.FuelConsumption;
            car.TrunkVolume = model.TrunkVolume;
            car.Horsepower = model.Horsepower;
            car.Cubage = model.Cubage;
            car.PricePerDay = model.PricePerDay;
            car.ImageUrl = model.ImageUrl;
            car.Availability = model.Availability;
            car.CategoryId = model.CategoryId;

            await repo.SaveChangesAsync();
        }

        public async Task<int> GetCarCategoryId(int carId)
        {
            return (await repo.GetByIdAsync<Car>(carId)).CategoryId;
        }

        public async Task<bool> IsExist(int id)
        {
            return await repo.AllReadonly<Car>().AnyAsync(c => c.Id == id && c.IsActive);              
        }

        public async Task<bool> IsRented(int carId)
        {
            return (await repo.GetByIdAsync<Car>(carId)).RenterId != null;
        }

        public async Task<bool> IsRentedByUserWithId(int carId, string currentUserId)
        {
            bool result = false;

            var car = await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(c => c.Id == carId)
                .FirstOrDefaultAsync();

            if (car != null && car.RenterId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task Leave(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            guard.AgainstNull(car, "Car can not be found");
            car.RenterId = null;

            await repo.SaveChangesAsync();
        }

        public async Task Rent(int carId, string currentUserId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            if (car != null && car.RenterId != null)
            {
                throw new ArgumentException("Car is already rented");
            }

            guard.AgainstNull(car, "Car can not be found");
            car.RenterId = currentUserId;

            await repo.SaveChangesAsync();
        }
    }
}
