using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Domain
{
    public class ShoppingCartItem
    {
        [Key, Column(Order = 1)]
        public int ShoppingCartId { get; set; }

        [Key, Column(Order = 2)]
        public int Product_Id { get; set; }

        public decimal Current_Price { get; set; }

        public int Amount { get; set; }


        public Orders Order { get; set; }
        

        public Products Product { get; set; }
    }
}
