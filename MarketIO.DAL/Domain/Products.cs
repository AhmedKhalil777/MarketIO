using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.DAL.Domain
{
    public class Products
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string P_Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public string Image { get; set; }
        [Range(1,5)]
        public int Evaluation { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public bool InStock { get; set; }

        [Required]
        public int Quantity { get; set; }
        public Brands Brand { get; set; }
        public int BrandId { get; set; }
        public Categories Category { get; set; }
        public int CategoryId { get; set; }




    }
}
