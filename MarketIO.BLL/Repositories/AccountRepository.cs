using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using MarketIO.DAL.Domain;
using MarketIO.DAL.Repositories;

namespace MarketIO.BLL.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        
        
        public static Customers Admin;
        private readonly UserManager<Customers> _userManager;
        private readonly SignInManager<Customers> _signInManager;
        public AccountRepository(UserManager<Customers> userManager , SignInManager<Customers> signInManager )
        {
           
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task<(IdentityResult , bool)> AddAdmin(Customers model , string Password)
        {


            var result = await _userManager.CreateAsync(model, Password);
            if(result.Succeeded)
            {
               var result1 =await _userManager.AddToRoleAsync(model, "Admin");
                return (result1 , result1.Succeeded);
            }
            return (result, false); 

        }

        public async Task<(string, bool)> AdminLogin(string email , string password , bool remmemberme)
        {
            
            var cAdmin = await _userManager.FindByEmailAsync(email);
            if (cAdmin == null && await _userManager.CheckPasswordAsync(cAdmin ,password))
            {
                return (string.Empty ,false);
            }
            await _signInManager.SignOutAsync();
            var result =   await _signInManager.PasswordSignInAsync(cAdmin.UserName, password,remmemberme, false);
            Admin = new Customers { Email = cAdmin.Email, Image = cAdmin.Image, UserName = cAdmin.UserName };

            return (email , result.Succeeded);
        }
        public  async Task SignOut()=> await _signInManager.SignOutAsync();
        
        public Task<bool> CustomerLogin(string email, string password, bool remmemberme)
        {
            throw new NotImplementedException();
        }

        public Customers GetCurrentAdmin() => Admin;

        public Task<bool> ModeratorLogin(string email, string password, bool remmemberme)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> ChangeImage(string CID, string ImagePath)
        {
            var Customer = await _userManager.FindByEmailAsync(CID);
            Customer.Image = ImagePath;
            var result = await _userManager.UpdateAsync(Customer);
            return result.Succeeded;
        }
    }
}
