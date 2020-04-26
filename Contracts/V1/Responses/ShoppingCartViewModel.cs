using MarketIO.MVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Contracts.V1.Responses
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartItem ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }

    }
}
