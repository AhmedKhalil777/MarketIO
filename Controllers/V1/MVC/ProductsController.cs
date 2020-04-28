using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.MVC.Contracts.V1;
using MarketIO.MVC.Contracts.V1.Responses;
using MarketIO.MVC.Domain;
using MarketIO.MVC.Repositories;
using MarketIO.MVC.ResourceParameters;
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
        public IActionResult List(ProductResourceParameters resourceParameters)
        {
            IEnumerable<Products> products;
            string title;
           

            if (!string.IsNullOrEmpty(resourceParameters.Category))
            {

                products = _productRepository.GetProducts(resourceParameters);
                title = _categoryRepository.AllCategories
                        .FirstOrDefault(c => c.Cat_Name == resourceParameters.Category)?.Cat_Name;
               
            }else if (!string.IsNullOrEmpty(resourceParameters.Brand))
            {
                products = _productRepository.GetProducts(resourceParameters);
                title = _brandRepository.AllBrands
                       .FirstOrDefault(c => c.Brand_Name == resourceParameters.Brand)?.Brand_Name;
            }
            else if (!string.IsNullOrEmpty(resourceParameters.SearchQuery))
            {
                products = _productRepository.GetProducts(resourceParameters);
                title = resourceParameters.SearchQuery;
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
