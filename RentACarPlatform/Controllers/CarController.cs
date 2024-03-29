﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Models.Car;
using RentACarPlatform.Extensions;
using RentACarPlatform.Models;
using static RentACarPlatform.Areas.Admin.Constants.AdminConstants;


namespace RentACarPlatform.Controllers
{
    /// <summary>
    /// Car Controller
    /// </summary>

    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService carService;

        private readonly IAgentService agentService;

        private readonly ILogger logger;

        public CarController(
               ICarService _carService,
               IAgentService _agentService,
               ILogger<CarController> _logger)
        {
            carService = _carService;
            agentService = _agentService;
            logger = _logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllCarsQueryModel query)
        {
            var result = await carService.All(
                query.Category,
                query.PickUpLocation,
                query.DropOffLocation,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsOnPage);

            query.TotalCarsCount = result.TotalCarsCount;
            query.Categories = await carService.AllCategoriesNames();
            query.PickUpLocations = await carService.AllPickUpLocations();
            query.DropOffLocations = await carService.AllDropOffLocations();
            query.Cars = result.Cars;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
           if (User.IsInRole(AdminRolleName))
           {
               return RedirectToAction("Mine", "Car", new { area = AreaName });
           }

            IEnumerable<CarServiceModel> myCars;

            var userId = User.Id();

            if (await agentService.ExistById(userId))
            {
                int agentId = await agentService.GetAgentId(userId);
                myCars = await carService.AllCarsByAgentId(agentId);
            }
            else
            {
                myCars = await carService.AllCarsByUserId(userId);
            }

            return View(myCars);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Specifications(int id)
        {
            if ((await carService.IsExist(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await carService.CarSpecificationsById(id);
           
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if ((await agentService.ExistById(User.Id())) == false)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            var model = new CarModel()
            {
                CarCategories = await carService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarModel model)
        {
            if ((await agentService.ExistById(User.Id())) == false)
            {
                return RedirectToAction(nameof(AgentController.Become), "Agent");
            }

            if ((await carService.CategoryExist(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.CarCategories = await carService.AllCategories();

                return View(model);
            }

            int agentId = await agentService.GetAgentId(User.Id());

            int id = await carService.Create(model, agentId);

            return RedirectToAction(nameof(Specifications), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await carService.IsExist(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

           if ((await carService.HasAgentWithId(id, User.Id())) == false)
           {
               logger.LogInformation("User with id {0} attempted to open other agent car", User.Id());
          
              // return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
           }

            var car = await carService.CarSpecificationsById(id);
            var categoryId = await carService.GetCarCategoryId(id);

            var model = new CarModel()
            {
               Id = id,
               Make = car.Make,
               Model = car.Model,
               FuelType = car.FuelType,
               Gearbox = car.Gearbox,
               Year = car.Year,
               Seats = car.Seats,
               Doors = car.Doors,
               TankCapacity = car.TankCapacity,
               FuelConsumption = car.FuelConsumption,
               TrunkVolume = car.TrunkVolume,
               Horsepower = car.Horsepower,
               Cubage = car.Cubage,
               PricePerDay = car.PricePerDay,
               ImageUrl = car.ImageUrl,          
               CategoryId = categoryId,
               CarCategories = await carService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await carService.IsExist(model.Id)) == false)
            {
                ModelState.AddModelError("", "Car does not exist");
                model.CarCategories = await carService.AllCategories();

                return View(model);
            }

            //if ((await carService.HasAgentWithId(model.Id, User.Id())) == false)
            //{
            //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            //}

            if ((await carService.CategoryExist(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.CarCategories = await carService.AllCategories();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.CarCategories = await carService.AllCategories();

                return View(model);
            }

            await carService.Edit(model.Id, model);

            return RedirectToAction(nameof(Specifications), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await carService.IsExist(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

           // if ((await carService.HasAgentWithId(id, User.Id())) == false)
           // {
           //     return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
           // }

            var car = await carService.CarSpecificationsById(id);
            var model = new CarSpecificationsViewModel()
            {
                Make = car.Make,
                Model = car.Model,
                ImageUrl = car.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CarSpecificationsViewModel model)
        {
            if ((await carService.IsExist(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

           // if ((await carService.HasAgentWithId(id, User.Id())) == false)
           // {
           //     return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
           // }

            await carService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if ((await carService.IsExist(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }
            
            if (!User.IsInRole(AdminRolleName) && await agentService.ExistById(User.Id()))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (await carService.IsRented(id))
            {
                return RedirectToAction(nameof(All));
            }

            await carService.Rent(id, User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if ((await carService.IsExist(id)) == false ||
                (await carService.IsRented(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

           // if ((await carService.IsRentedByUserWithId(id, User.Id())) == false)
           // {
           //     return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
           // }

            await carService.Leave(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
