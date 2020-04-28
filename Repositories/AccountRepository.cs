using MarketIO.MVC.Contracts.V1.Requests;
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
            
            var result =   await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemmemberMe, false);
            return result.Succeeded;
        }

        public Task<bool> CustomerLogin(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModeratorLogin(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
