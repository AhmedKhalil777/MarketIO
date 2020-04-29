using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.MVC.Contracts.V1;
using MarketIO.MVC.Contracts.V1.Requests;
using MarketIO.MVC.Contracts.V1.Responses;
using MarketIO.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarketIO.MVC.Controllers.V1.MVC
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _account;
        public AccountController(IAccountRepository account)
        {
            _account = account;
        }
        [HttpGet(MVCRoutes.Admin.Base)]
        public IActionResult AdminLogin()
        {
            
            return View();
        }

        [HttpPost(MVCRoutes.Admin.Base)]
        public async Task<IActionResult> AdminLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _account.AdminLogin(model);

                if (result)
                {
                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                

            }
            return View();
            
            
        }

        [HttpGet(MVCRoutes.Trapdoor)]
        public IActionResult Trapdoor()
        {
            return View();
        }

        [HttpGet(MVCRoutes.Signout)]
        public async Task<IActionResult> Signout() 
        {
            await _account.SignOut();
            return RedirectToAction("Index", "Home");
                
        }


        [HttpPost(MVCRoutes.Trapdoor)]
        public async Task<IActionResult> Trapdoor(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _account.AddAdmin(model);
                if(result.Item2)
                {
                    return RedirectToAction("AdminLogin");
        
                }
                result.Item1.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }

            return View();
           

        }

        [HttpGet(MVCRoutes.Admin.EditAdmin)]
        public  IActionResult EditAdmin() 
        {
           AdminViewModel Admin = _account.GetCurrentAdmin();
           return View(Admin); 
        }

        [HttpPost(MVCRoutes.Admin.EditAdmin)]
        public IActionResult EditAdmin(EditAdminViewModel model)
        {
            return View();
        }

    }
}