using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Models.Car;
using RentACarPlatform.Models;

namespace RentACarPlatform.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService carService;

        public CarController(ICarService _carService)
        {
            carService = _carService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllCarsQueryModel query)
        {
            var result = await carService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsOnPage);

            query.TotalCarsCount = result.TotalCarsCount;
            query.Categories = await carService.AllCategoriesNames();
            query.Cars = result.Cars;

            return View(query);
        }

        public async Task<IActionResult> Mine()
        {
            IEnumerable<CarServiceModel> myCars;

            var userId = User.Claims.ToString();

            myCars = await carService.AllCarsByUserId(userId);

            return View(myCars);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Specifications(int id)
        {
            if (!(await carService.IsExist(id)))
            {
                return RedirectToAction(nameof(All));
            }

            var model = await carService.CarSpecificationsById(id);          

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CarModel()
            {
                CarCategories = await carService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarModel model)
        {
            if ((await carService.CategoryExist(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }


            if (!ModelState.IsValid)
            {
                model.CarCategories = await carService.AllCategories();

                return View(model);
            }

            int id = await carService.Create(model);

            return RedirectToAction(nameof(Specifications), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new CarModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarModel model)
        {
            return RedirectToAction(nameof(Specifications), new { id });
        }      

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
