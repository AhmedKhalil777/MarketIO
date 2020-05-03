using MarketIO.MVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Contracts.V1.Requests
{
    public class CategoryAndBrandViewModel
    {
        public IEnumerable<Categories> Categories { get; set; }
        public IEnumerable<Brands> Brands{ get; set; }
    }
}
