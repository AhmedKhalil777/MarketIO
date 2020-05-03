using MarketIO.DAL.Data;
using MarketIO.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
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
