using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.MVC.Contracts.V1;
using Microsoft.AspNetCore.Mvc;

namespace MarketIO.MVC.Controllers.V1.MVC
{
    public class AccountController : Controller
    {
        [HttpGet(MVCRoutes.Admin.Base)]
        public IActionResult AdminLogin()
        {
            return View();
        }
    }
}