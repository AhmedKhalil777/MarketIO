using MarketIO.MVC.Contracts.V1.Requests;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> AdminLogin(LoginViewModel model);
        Task<bool> ModeratorLogin(LoginViewModel model);
        Task<bool> CustomerLogin(LoginViewModel model);
        Task<(IdentityResult, bool)> AddAdmin(RegisterViewModel model);
    }
}
