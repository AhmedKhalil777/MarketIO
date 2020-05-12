using MarketIO.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.Contracts.V1.Responses
{
    public class HomeViewModel
    {
        public IEnumerable<Products> ProductsOfTheWeak { get; set; }
        public string SearchQuery { get; set; }
    }
}
