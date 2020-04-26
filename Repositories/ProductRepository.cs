using MarketIO.MVC.Data;
using MarketIO.MVC.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly MarketIODbContext _db;
        public ProductRepository(MarketIODbContext db)
        {
            _db = db; 
        }

        public IEnumerable<Products> AllProducts => _db.Products;
        public IEnumerable<Products> ProductsOfTheWeek => _db.Products.Include(c => c.Brand)
                        .Include(c => c.Category).Where(p => p.IsProductOfTheWeek && p.InStock);

        public void UpdateProduct(Products product)
        {
            _db.Products.Update(product);
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
            _db.Products.Remove(deletedProduct);
            return deletedProduct;
        }
    }
}
