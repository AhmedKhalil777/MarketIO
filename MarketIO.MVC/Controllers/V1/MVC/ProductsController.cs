using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.DAL.Domain;
using MarketIO.DAL.Repositories;
using MarketIO.Contracts.V1;
using MarketIO.Contracts.V1.Requests.ResourceParameters;
using MarketIO.Contracts.V1.Responses;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult List(ProductResourceParameters RP)
        {
            IEnumerable<Products> products;
            string title;
           

            if (!string.IsNullOrEmpty(RP.Category))
            {

                products = _productRepository.GetProducts(RP.Category, RP.Brand , RP.SearchQuery);
                title = _categoryRepository.AllCategories
                        .FirstOrDefault(c => c.Cat_Name == RP.Category)?.Cat_Name;
               
            }else if (!string.IsNullOrEmpty(RP.Brand))
            {
                products = _productRepository.GetProducts(RP.Category, RP.Brand, RP.SearchQuery);
                title = _brandRepository.AllBrands
                       .FirstOrDefault(c => c.Brand_Name == RP.Brand)?.Brand_Name;
            }
            else if (!string.IsNullOrEmpty(RP.SearchQuery))
            {
                products = _productRepository.GetProducts(RP.Category, RP.Brand, RP.SearchQuery);
                title = RP.SearchQuery;
            }
            else
            {
                products = _productRepository.AllProducts.OrderBy(p => p.Product_Id);
                title = "All Products";
            }
            var productsListViewModel = new ProductsListViewModel
            {
                Products = products,
                CurrentCategory = title
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
