using MarketIO.MVC.Contracts.V1.Requests;
using MarketIO.MVC.Contracts.V1.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
{
    public interface IAccountRepository
    {
        Task<(string,bool)> AdminLogin(LoginViewModel model);
        Task<bool> ModeratorLogin(LoginViewModel model);
        Task<bool> CustomerLogin(LoginViewModel model);
        Task<(IdentityResult, bool)> AddAdmin(RegisterViewModel model);
        AdminViewModel GetCurrentAdmin();
        Task SignOut();
        bool IsAdminSignedIn(RazorPageBase @base);

        Task<bool> ChangeImage(string CID, IFormFile image);
    }
}
