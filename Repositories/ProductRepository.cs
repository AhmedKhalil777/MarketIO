using MarketIO.MVC.Data;
using MarketIO.MVC.Domain;
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
