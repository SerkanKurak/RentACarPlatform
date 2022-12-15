using Microsoft.AspNetCore.Mvc;

namespace RentACarPlatform.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
