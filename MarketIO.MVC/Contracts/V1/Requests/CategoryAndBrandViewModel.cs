using MarketIO.DAL.Domain;
using System.Collections.Generic;

namespace MarketIO.MVC.Contracts.V1.Requests
{
    public class CategoryAndBrandViewModel
    {
        public IEnumerable<Categories> Categories { get; set; }
        public IEnumerable<Brands> Brands{ get; set; }
    }
}
