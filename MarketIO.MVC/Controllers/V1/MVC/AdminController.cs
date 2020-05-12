using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.DAL.Repositories;
using MarketIO.Contracts.V1;
using MarketIO.Contracts.V1.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketIO.MVC.Controllers.V1.MVC
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        
        private readonly IAccountRepository _account;
        public AdminController(IAccountRepository account)
        {
            _account = account;
        }
        
        [HttpGet(MVCRoutes.Admin.AdminHome)]
        public IActionResult Index()
        {
            return View();
        }



    }
}