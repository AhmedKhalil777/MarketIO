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
        public int Order_Id { get; set; }

        [Required]
        public DateTime Order_Date { get; set; }

        public DateTime Required_Date { get; set; }

        public DateTime ShippedDate { get; set; }
        public decimal OrderTotal { get; set; }
        public OrderStatus Status { get; set; }

        public List<Order_Details> Order_Details { get; set; }



        public float Total_Price()
        {
            float TotalPrice = 0;
            Order_Details.ForEach(Order => { TotalPrice += Order.Current_Price * Order.Amount; });
            return TotalPrice;
        }
    }



    public enum OrderStatus
    {
        // If the Market accept to make the quote 
        Accepted = 0,
        // Explain if their are some issues 
        Issue = 1,
        // Explain if the order is recieved to customer
        Recieved = 2,
        // Explain if the Order is out from the store and shipped to the customer
        Shipped =4 
    }
}
