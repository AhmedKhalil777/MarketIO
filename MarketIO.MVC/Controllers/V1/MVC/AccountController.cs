using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.DAL.Domain;
using MarketIO.DAL.Repositories;
using MarketIO.Contracts.V1;
using MarketIO.Contracts.V1.Requests;
using MarketIO.MVC.FilesHosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace MarketIO.MVC.Controllers.V1.MVC
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _account;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IFileUploader _fileUploader;
        public AccountController(IAccountRepository account , IHostEnvironment hostEnvironment , IFileUploader fileUploader )
        {
            _account = account;
            _hostEnvironment = hostEnvironment;
            _fileUploader = fileUploader;
        }
        [AllowAnonymous]
        [HttpGet(MVCRoutes.Admin.Base)]
        public IActionResult AdminLogin()
        {
            
            return View();
        }


        [AllowAnonymous]
        [HttpGet(MVCRoutes.Application.Register)]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost(MVCRoutes.Application.Register)]
        public IActionResult Register(CustomerRegisterViewModel model)
        {
            var Customer = new Customers
            {
                
            };

            return View();
        }

        [AllowAnonymous]
        [HttpPost(MVCRoutes.Admin.Base)]
        public async Task<IActionResult> AdminLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _account.AdminLogin(model.Email , model.Password , model.RemmemberMe);

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
                var User = new Customers
                {
                    Email = model.Email,
                    UserName = model.FirstName + model.LastName,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = await _account.AddAdmin(User , model.Password);
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
           var Admin = _account.GetCurrentAdmin();
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
            var name = Guid.NewGuid().ToString() + imagefile.FileName;
            string Path = _hostEnvironment.ContentRootPath + "\\wwwroot\\images\\Users\\";
            string ImagePath = "\\images\\Users\\" + name;
            _fileUploader.UploadFile(imagefile, Path, name);
            var result = await _account.ChangeImage(HttpContext.Session.GetString("AdminId"), ImagePath);
            if (result)
            {
                return Ok(new { status = 1 ,  Message ="Image Changed Successfuly" });
            }
            return BadRequest(new { status = 0, Message = "Error of Uploading Retry another time" });
        }

    }
}