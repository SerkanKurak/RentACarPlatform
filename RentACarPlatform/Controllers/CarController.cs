using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Models.Car;

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


        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = new CarsQueryModel();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new CarsQueryModel();

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Specifications(int id)
        {
            var model = new CarSpecificationsModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarModel model)
        {
            int id = 1;

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
