﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static RentACarPlatform.Areas.Admin.Constants.AdminConstants;

namespace RentACarPlatform.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin Base controller
    /// </summary>

    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRolleName)]
    public class BaseController : Controller
    {

    }
}
