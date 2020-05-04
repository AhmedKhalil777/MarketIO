using MarketIO.DAL.Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MarketIO.DAL.Repositories
{
    public interface IAccountRepository
    {
        Task<(string,bool)> AdminLogin(string email, string password , bool remmemberme);
        Task<bool> ModeratorLogin(string email, string password, bool remmemberme);
        Task<bool> CustomerLogin(string email, string password, bool remmemberme);
        Task<(IdentityResult, bool)> AddAdmin(Customers model, string Password);
        Customers GetCurrentAdmin();
        Task SignOut();
        Task<bool> ChangeImage(string CID, string ImagePath);
    }
}
