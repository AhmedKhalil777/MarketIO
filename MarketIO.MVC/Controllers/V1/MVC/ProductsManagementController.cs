using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarketIO.DAL.Repositories;
using MarketIO.MVC.Contracts.V1;
using MarketIO.MVC.Contracts.V1.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketIO.MVC.Controllers.V1.MVC
{
    public class ProductsManagementController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProductsManagementController(IProductRepository productRepository, ICategoryRepository categoryRepository
                                            ,IBrandRepository brandRepository,IWebHostEnvironment hostingEnvironment)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._brandRepository = brandRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: /<controller>/
        [HttpGet(MVCRoutes.Moderator.Products.GetProducts)]
        public IActionResult Index()
        {
            var products = _productRepository.AllProducts.OrderBy(p => p.P_Name);
            return View(products);
        }

        [HttpGet(MVCRoutes.Moderator.Products.CreateProduct)]
        public IActionResult AddProduct()
        {
            var categories = _categoryRepository.AllCategories;
            var brands = _brandRepository.AllBrands;

            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.Cat_Name, Value = c.Cat_Id.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().Cat_Id, 
                Brands = brands.Select(b => new SelectListItem() { Text = b.Brand_Name, Value = b.Brand_Id.ToString() }).ToList(),
                BrandId = brands.FirstOrDefault().Brand_Id
            };
            return View(productEditViewModel);
        }

        [HttpPost(MVCRoutes.Moderator.Products.CreateProduct)]
        public IActionResult AddProduct(ProductEditViewModel productEditViewModel)
        {
           
            if (ModelState.IsValid)
            {
                productEditViewModel.Product.Image = ProcessUploadedFile(productEditViewModel);
                productEditViewModel.Product.BrandId = productEditViewModel.BrandId;
                productEditViewModel.Product.CategoryId = productEditViewModel.CategoryId;

                _productRepository.CreateProduct(productEditViewModel.Product);
                return RedirectToAction("Index");
            }
            else
            {
                var categories = _categoryRepository.AllCategories;
                var brands = _brandRepository.AllBrands;

                productEditViewModel = new ProductEditViewModel
                {
                    Categories = categories.Select(c => new SelectListItem() { Text = c.Cat_Name, Value = c.Cat_Id.ToString() }).ToList(),
                    CategoryId = categories.FirstOrDefault().Cat_Id,
                    Brands = brands.Select(b => new SelectListItem() { Text = b.Brand_Name, Value = b.Brand_Id.ToString() }).ToList(),
                    BrandId = brands.FirstOrDefault().Brand_Id
                };
            }
            return View(productEditViewModel);
        }

        [HttpGet(MVCRoutes.Moderator.Products.UpdateProduct)]
        public IActionResult EditProduct([FromRoute]int ProductId)
        {
            var categories = _categoryRepository.AllCategories;
            var brands = _brandRepository.AllBrands;

            var Product = _productRepository.AllProducts.FirstOrDefault(p => p.Product_Id == ProductId);

            var ProductEditViewModel = new ProductEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.Cat_Name, Value = c.Cat_Id.ToString() }).ToList(),
                Brands = brands.Select(b => new SelectListItem() { Text = b.Brand_Name, Value = b.Brand_Id.ToString() }).ToList(),
                Product = Product,
                CategoryId = Product.CategoryId,
                BrandId = Product.BrandId
            };
            var item = ProductEditViewModel.Categories.FirstOrDefault(c => c.Value == Product.Category.Cat_Id.ToString());
            item = ProductEditViewModel.Categories.FirstOrDefault(c => c.Value == Product.Brand.Brand_Id.ToString());
            item.Selected = true;
            return View(ProductEditViewModel);
        }

        [HttpPost(MVCRoutes.Moderator.Products.UpdateProduct)]
        public IActionResult EditProduct(ProductEditViewModel ProductEditViewModel)
        {
            ProductEditViewModel.Product.CategoryId = ProductEditViewModel.CategoryId;
            ProductEditViewModel.Product.BrandId = ProductEditViewModel.BrandId;
            if (ModelState.GetValidationState("Product.Price") == ModelValidationState.Valid && ProductEditViewModel.Product.Price < 0)
            {
                ModelState.AddModelError(nameof(ProductEditViewModel.Product.Price), "invalid price");
            }
            if (ModelState.IsValid)
            {
                if (ProductEditViewModel.Photo!=null)
                {
                    ProductEditViewModel.Product.Image = ProcessUploadedFile(ProductEditViewModel);
                }
                ProductEditViewModel.Product.BrandId = ProductEditViewModel.BrandId;
                ProductEditViewModel.Product.CategoryId = ProductEditViewModel.CategoryId;

                _productRepository.UpdateProduct(ProductEditViewModel.Product);
                return RedirectToAction("Index");
            }

            var categories = _categoryRepository.AllCategories;
            var brands = _brandRepository.AllBrands;

            ProductEditViewModel = new ProductEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.Cat_Name, Value = c.Cat_Id.ToString() }).ToList(),
                Brands = brands.Select(c => new SelectListItem() { Text = c.Brand_Name, Value = c.Brand_Id.ToString() }).ToList(),

                CategoryId = ProductEditViewModel.Product.CategoryId,
                BrandId = ProductEditViewModel.Product.BrandId
            };
            var item = ProductEditViewModel.Categories.FirstOrDefault(c => c.Value == ProductEditViewModel.CategoryId.ToString());
            item.Selected = true;
            item = ProductEditViewModel.Brands.FirstOrDefault(c => c.Value == ProductEditViewModel.BrandId.ToString());
            item.Selected = true;

            return View(ProductEditViewModel);
        }

        [HttpPost(MVCRoutes.Moderator.Products.DeleteProduct)]
        public IActionResult DeleteProduct(int ProductId)
        {
            
            _productRepository.DeleteProduct(ProductId ,hostingEnvironment.ContentRootPath);

            return RedirectToAction(nameof(Index));
        }

        private string ProcessUploadedFile(ProductEditViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
