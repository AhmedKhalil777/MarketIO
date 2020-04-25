using MarketIO.MVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Contracts.V1.Responses
{
    public class HomeViewModel
    {
        public IEnumerable<Products> ProductsOfTheWeak { get; set; }
    }
}
