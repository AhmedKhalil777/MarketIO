using MarketIO.DAL.Domain;
using System.Collections.Generic;

namespace MarketIO.MVC.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Categories> AllCategories { get; }
    }
}