using Microsoft.AspNetCore.Mvc;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Models;
using System.Diagnostics;
using static RentACarPlatform.Areas.Admin.Constants.AdminConstants;

namespace RentACarPlatform.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        private readonly ILogger logger;

        public HomeController(
               ICarService _carService,
               ILogger<HomeController> _logger)
        {
            carService = _carService;
            logger = _logger;
        }
              
        public async Task<IActionResult> Index()
        {

            if (User.IsInRole(AdminRolleName))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

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