using MarketIO.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.Contracts.V1.Responses
{
    public class ProductsListViewModel
    {
        public IEnumerable<Products> Products{ get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentBrand{ get; set; }
        public string SearchQuery { get; set; }


    }
}
