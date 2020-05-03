using MarketIO.DAL.Data;
using MarketIO.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly MarketIODbContext _dbContext;

        public BrandRepository(MarketIODbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Brands> AllBrands => _dbContext.Brands;
        public Brands GetBrandById(int id) => _dbContext.Brands.Find(id);

    }
}
