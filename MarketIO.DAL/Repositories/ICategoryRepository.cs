using MarketIO.DAL.Domain;
using System.Collections.Generic;

namespace MarketIO.DAL.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Categories> AllCategories { get; }
    }
}