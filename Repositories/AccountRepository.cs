using MarketIO.MVC.Contracts.V1.Requests;
using MarketIO.MVC.Contracts.V1.Responses;
using MarketIO.MVC.Domain;
using Microsoft.AspNetCore.Http;
using MarketIO.MVC.Caching;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace MarketIO.MVC.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        
        
        public static AdminViewModel Admin;
        private readonly UserManager<Customers> _userManager;
        private readonly SignInManager<Customers> _signInManager;
        private readonly IHostEnvironment _hostEnvironment;

        public AccountRepository(UserManager<Customers> userManager , SignInManager<Customers> signInManager ,IHostEnvironment hostEnvironment )
        {
           
            _userManager = userManager;
            _signInManager = signInManager;
            _hostEnvironment = hostEnvironment;

        }

        public async Task<(IdentityResult , bool)> AddAdmin(RegisterViewModel model)
        {
            var User = new Customers
            {
                Email = model.Email,
                UserName = model.FirstName + model.LastName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(User, model.Password);
            if(result.Succeeded)
            {
               var result1 =await _userManager.AddToRoleAsync(User, "Admin");
                return (result1 , result1.Succeeded);
            }
            return (result, false); 

        }

        public async Task<(string, bool)> AdminLogin(LoginViewModel model)
        {
            
            var cAdmin = await _userManager.FindByEmailAsync(model.Email);
            if (cAdmin == null && await _userManager.CheckPasswordAsync(cAdmin ,model.Password))
            {
                return (string.Empty ,false);
            }
            await _signInManager.SignOutAsync();
            var result =   await _signInManager.PasswordSignInAsync(cAdmin.UserName, model.Password, model.RemmemberMe, false);
            Admin = new AdminViewModel { Email = cAdmin.Email, Image = cAdmin.Image, Name = cAdmin.UserName };

            return (model.Email , result.Succeeded);
        }
        public  async Task SignOut()=> await _signInManager.SignOutAsync();
        
        public Task<bool> CustomerLogin(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public AdminViewModel GetCurrentAdmin() => Admin;

        public Task<bool> ModeratorLogin(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool IsAdminSignedIn(RazorPageBase Base)
        {
            return _signInManager.IsSignedIn(Base.User);
        }

        public async Task<bool> ChangeImage(string CID, IFormFile image)
        {
            string Path = _hostEnvironment.ContentRootPath + "\\wwwroot\\images\\Users\\";
            var Customer = await _userManager.FindByEmailAsync(CID);
            var name = Guid.NewGuid().ToString() + image.FileName;
            if (image.Length >0 )
            {
                try
                {
                    if (!Directory.Exists(Path))
                    {
                        Directory.CreateDirectory(Path);
                    }
                    using (FileStream filestream  = File.Create(Path + name))
                    {
                        image.CopyTo(filestream);
                        filestream.Flush();
                    }
                    Customer.Image = "images\\Users\\" + name;
                    var result = await _userManager.UpdateAsync(Customer);
                    return result.Succeeded;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
    }
}
