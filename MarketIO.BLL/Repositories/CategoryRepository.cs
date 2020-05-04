using MarketIO.DAL.Data;
using MarketIO.DAL.Domain;
using MarketIO.DAL.Repositories;
using System.Collections.Generic;

namespace MarketIO.BLL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketIODbContext _dbContext;

        public CategoryRepository(MarketIODbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Categories> AllCategories => _dbContext.Categories;
    }
}
