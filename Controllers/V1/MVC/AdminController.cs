using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.MVC.Contracts.V1;
using Microsoft.AspNetCore.Mvc;

namespace MarketIO.MVC.Controllers.V1.MVC
{
    public class AdminController : Controller
    {
        [HttpGet(MVCRoutes.Admin.AdminHome)]
        public IActionResult Index()
        {
            return View();
        }
    }
}