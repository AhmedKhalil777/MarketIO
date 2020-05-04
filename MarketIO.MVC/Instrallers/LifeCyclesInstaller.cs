using MarketIO.DAL.Repositories;
using MarketIO.MVC.FilesHosting;
using MarketIO.MVC.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketIO.MVC.Instrallers
{
    public class LifeCyclesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
        }
    }
}
