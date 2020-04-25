using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.MVC.Domain
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Products Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
