using MarketIO.MVC.Data;
using MarketIO.MVC.Domain;
using MarketIO.MVC.ResourceParameters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly MarketIODbContext _db;
        private readonly IWebHostEnvironment hostEnvironment;

        public ProductRepository(MarketIODbContext db,IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this.hostEnvironment = hostEnvironment;
        }

        public IEnumerable<Products> AllProducts => _db.Products;
        public IEnumerable<Products> ProductsOfTheWeek => _db.Products.Include(c => c.Brand)
                        .Include(c => c.Category).Where(p => p.IsProductOfTheWeek && p.InStock);


        public IEnumerable<Products> GetProducts(ProductResourceParameters productResourceParameters)
        {
            if (productResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(productResourceParameters));
            }
            var collection = _db.Products as IQueryable<Products>;
            if (!string.IsNullOrWhiteSpace(productResourceParameters.Category))
            {
                var mainCategory = productResourceParameters.Category.Trim();
                collection = collection.Where(a => a.Category.Cat_Name == mainCategory);
            }
            if (!string.IsNullOrWhiteSpace(productResourceParameters.Brand))
            {
                var mainBrand = productResourceParameters.Brand.Trim();
                collection = collection.Where(a => a.Brand.Brand_Name == mainBrand);
            }
            if (!string.IsNullOrWhiteSpace(productResourceParameters.SearchQuery))
            {
                var searchQuery = productResourceParameters.SearchQuery.Trim();
                collection = collection.Where(c => c.Category.Cat_Name.ToLower().Contains(searchQuery.ToLower())
                || c.Brand.Brand_Name.ToLower().Contains(searchQuery.ToLower())
                || c.P_Name.ToLower().Contains(searchQuery.ToLower()));
            }
            return collection.ToList();
        }


        public void UpdateProduct(Products product)
        {
            var oldProduct = _db.Products.Attach(product);
            oldProduct.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void CreateProduct(Products product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public Products GetProductById(int productId)
        {
            return _db.Products.FirstOrDefault(p => p.Product_Id == productId);
        }

        public Products DeleteProduct(int productId)
        {
            var deletedProduct = _db.Products.FirstOrDefault(p => p.Product_Id == productId);
            if (deletedProduct.Image!=null)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, deletedProduct.Image);
                File.Delete(filePath);
            }
            _db.Products.Remove(deletedProduct);
            _db.SaveChanges();
            return deletedProduct;
        }
    }
}
