using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Domain
{
    public class Orders
    {
        [Key]
        public Guid Order_Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime Order_Date { get; set; }

        public DateTime Required_Date { get; set; }

        public DateTime ShippedDate { get; set; }
        public decimal OrderTotal { get; set; }
        public OrderStatus Status { get; set; }
        public Customers Customer { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }



        //public float Total_Price()
        //{
        //    float TotalPrice = 0;
        //    Order_Details.ForEach(Order => { TotalPrice += Order.Current_Price * Order.Amount; });
        //    return TotalPrice;
        //}
    }
}
