using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Domain
{
    public class Brands
    {
        [Key]
        public int Brand_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Brand_Name { get; set; }

        public string Brand_Logo { get; set; }

        public List<Products> Products { get; set; }


    }
}
