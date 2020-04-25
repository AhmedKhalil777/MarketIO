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
    }
}
