using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.MVC.Contracts.V1.Responses;
using MarketIO.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketIO.MVC.Controllers.V1.MVC
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository ProductRepository)
        {
            this._productRepository = ProductRepository;
        }
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
