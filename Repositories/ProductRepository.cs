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

        public IEnumerable<Products> AllProducts => _db.Products.Include(c => c.Brand);

        //public IEnumerable<Products> ProductsOfTheWeek => _db.Products.Include(c => c.Brand).Where(p => p.IsPieOfTheWeek);

        public void UpdatePie(Products product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        public void CreatePie(Products product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public Products GetPieById(int productId)
        {
            
            return _db.Products.FirstOrDefault(p => p.Product_Id == productId);
        }

    }
}
