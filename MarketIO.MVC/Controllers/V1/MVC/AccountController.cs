using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.MVC.Contracts.V1;
using MarketIO.MVC.Contracts.V1.Requests;
using MarketIO.MVC.Contracts.V1.Responses;
using MarketIO.MVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [AllowAnonymous]
        [HttpGet(MVCRoutes.Admin.Base)]
        public IActionResult AdminLogin()
        {
            
            return View();
        }

        [AllowAnonymous]
        [HttpPost(MVCRoutes.Admin.Base)]
        public async Task<IActionResult> AdminLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _account.AdminLogin(model);

                if (result.Item2)
                {
                    HttpContext.Session.SetString("AdminId", result.Item1);
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
        [Authorize(Roles = "Admin")]
        [HttpGet(MVCRoutes.Admin.EditAdmin)]
        public  IActionResult EditAdmin() 
        {
           AdminViewModel Admin = _account.GetCurrentAdmin();
           return View(Admin); 
        }
        [Authorize(Roles = "Admin")]
        [HttpPost(MVCRoutes.Admin.EditAdmin)]
        public IActionResult EditAdmin(EditAdminViewModel model)
        {
            return View();
        }


        [HttpPost(MVCRoutes.ChangeImage)]
        public async Task<IActionResult> ChangeImage(IFormFile imagefile)
        {
            var result = await _account.ChangeImage(HttpContext.Session.GetString("AdminId"), imagefile);
            if (result)
            {
                return Ok(new { status = 1 ,  Message ="Image Changed Successfuly" });
            }
            return BadRequest(new { status = 0, Message = "Error of Uploading Retry another time" });
        }

    }
}