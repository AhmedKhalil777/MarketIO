using MarketIO.DAL.Repositories;
using MarketIO.Contracts.V1;
using MarketIO.Contracts.V1.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketIO.MVC.Controllers.V1.MVC
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository ProductRepository)
        {
            this._productRepository = ProductRepository;
        }
        [HttpGet(MVCRoutes.Application.Base)]
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                ProductsOfTheWeak = _productRepository.ProductsOfTheWeek
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
