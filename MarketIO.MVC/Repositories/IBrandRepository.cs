using MarketIO.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brands> AllBrands { get; }
        Brands GetBrandById(int id);
    }
}
