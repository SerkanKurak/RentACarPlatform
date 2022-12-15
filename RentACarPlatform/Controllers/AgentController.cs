using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACarPlatform.Core.Constants;
using RentACarPlatform.Core.Contracts;
using RentACarPlatform.Core.Models.Agent;
using RentACarPlatform.Extensions;

namespace RentACarPlatform.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
           if (await agentService.ExistById(User.Id()))
           {
               TempData[MessageConstants.ErrorMessage] = "Вие вече сте Агент";
          
               return RedirectToAction("Index", "Home");
           }

            var model = new BecomeAgentModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

          if (await agentService.ExistById(userId))
          {
              TempData[MessageConstants.ErrorMessage] = "Вие вече сте Агент";
        
              return RedirectToAction("Index", "Home");
          }
        
          if (await agentService.UserWithPhoneNumberExist(model.PhoneNumber))
          {
              TempData[MessageConstants.ErrorMessage] = "Телефона вече съществува";
        
              return RedirectToAction("Index", "Home");
          }
        
          if (await agentService.UserHasRents(userId))
          {
              TempData[MessageConstants.ErrorMessage] = "Не трябва да имате наеми за да станете агент";
        
              return RedirectToAction("Index", "Home");
          }

            await agentService.Create(userId, model.PhoneNumber);

            return RedirectToAction("All", "House");
        }
    }
}
