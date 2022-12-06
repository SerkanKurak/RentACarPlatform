using Microsoft.AspNetCore.Mvc;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Models;
using System.Diagnostics;

namespace RentACarPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService _carService)
        {
            carService = _carService;
        }
              
        public async Task<IActionResult> Index()
        {
            var model = await carService.AllCars();

            return View(model);
        }
     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}