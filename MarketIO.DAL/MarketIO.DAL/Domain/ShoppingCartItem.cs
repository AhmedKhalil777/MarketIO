using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.DAL.Domain
{
    public class ShoppingCartItem
    {
        [Key, Column(Order = 1)]
        public Guid ShoppingCartId { get; set; } = Guid.NewGuid();

        [Key, Column(Order = 2)]
        public int Product_Id { get; set; }

        public decimal Current_Price { get; set; }

        public int Amount { get; set; }


        public Orders Order { get; set; }
        

        public Products Product { get; set; }
    }
}
