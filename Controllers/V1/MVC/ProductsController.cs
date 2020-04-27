using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.MVC.Contracts.V1;
using MarketIO.MVC.Contracts.V1.Responses;
using MarketIO.MVC.Domain;
using MarketIO.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketIO.MVC.Controllers.V1.MVC
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        public ProductsController(IProductRepository productRepository
                                 , ICategoryRepository categoryRepository
                                 , IBrandRepository brandRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._brandRepository = brandRepository;
        }
        // GET: /<controller>/
        public IActionResult List(string category="",string brand="")
        {
            IEnumerable<Products> products;
            string currentCategory;
            string currentBrand="";

            if (!string.IsNullOrEmpty(category) || !string.IsNullOrEmpty(brand))
            {

                products = _productRepository.AllProducts.Where(c => c.Category.Cat_Name == category).OrderBy(c => c.P_Name);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.Cat_Name == category)?.Cat_Name;
                currentBrand = _brandRepository.AllBrands.FirstOrDefault(c => c.Brand_Name == brand)?.Brand_Name;

            }
            else
            {
                products = _productRepository.AllProducts.OrderBy(p => p.Product_Id);
                currentCategory = "All Products";
            }
            var productsListViewModel = new ProductsListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory,
                CurrentBrand = currentBrand
            };
            return View(productsListViewModel);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(new ProductDetailViewModel() { Product = product });
        }



    }
}
