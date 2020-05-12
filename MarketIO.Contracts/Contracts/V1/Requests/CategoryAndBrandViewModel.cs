using MarketIO.DAL.Domain;
using System.Collections.Generic;

namespace MarketIO.Contracts.V1.Requests
{
    public class CategoryAndBrandViewModel
    {
        public IEnumerable<Categories> Categories { get; set; }
        public IEnumerable<Brands> Brands{ get; set; }
    }
}
