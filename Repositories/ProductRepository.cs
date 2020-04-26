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

        public IEnumerable<Products> AllProducts => throw new NotImplementedException();

        public IEnumerable<Products> ProductsOfTheWeek => throw new NotImplementedException();

        public void CreateProduct(Products product)
        {
            throw new NotImplementedException();
        }

        public Products GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Products product)
        {
            throw new NotImplementedException();
        }
    }
}
