using Microsoft.AspNetCore.Mvc;
using RentACarPlatform.Areas.Admin.Models;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Extensions;

namespace RentACarPlatform.Areas.Admin.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService carService;

        private readonly IAgentService agentService;

        public CarController(
            ICarService _carService,
            IAgentService _agentService)
        {
            carService = _carService;
            agentService = _agentService;
        }

        public async Task<IActionResult> Mine()
        {
            var myCars = new MyCarsViewModel();
            var adminId = User.Id();
            myCars.RentedHouses = await carService.AllCarsByUserId(adminId);
            var agentId = await agentService.GetAgentId(adminId);
            myCars.AddedHouses = await carService.AllCarsByAgentId(agentId);

            return View(myCars);
        }
    }
}
