using MarketIO.DAL.Data;
using MarketIO.DAL.Domain;
using MarketIO.DAL.Repositories;
using System.Collections.Generic;

namespace MarketIO.BLL.Repositories
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
