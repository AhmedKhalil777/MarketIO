using MarketIO.MVC.Contracts.V1.Requests;
using MarketIO.MVC.Contracts.V1.Responses;
using MarketIO.MVC.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public static AdminViewModel Admin;
        private readonly UserManager<Customers> _userManager;
        private readonly SignInManager<Customers> _signInManager;

        public AccountRepository(UserManager<Customers> userManager , SignInManager<Customers> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task<bool> AdminLogin(LoginViewModel model)
        {
            
            var cAdmin = await _userManager.FindByEmailAsync(model.Email);
            if (cAdmin == null && await _userManager.CheckPasswordAsync(cAdmin ,model.Password))
            {
                return false;
            }
            await _signInManager.SignOutAsync();
            var result =   await _signInManager.PasswordSignInAsync(cAdmin.UserName, model.Password, model.RemmemberMe, false);
            Admin = new AdminViewModel { Email = cAdmin.Email, Image = cAdmin.Image, Name = cAdmin.UserName };
            return result.Succeeded;
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

        public bool IsAdminSignedIn()
        {
            return Admin == null;
        }
    }
}
