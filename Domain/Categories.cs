using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Domain
{
    public class Categories
    {
        [Key]
        public  int Cat_Id { get; set; }

        [MaxLength(50, ErrorMessage = "The Maximum Length is 50 ")]
        public string Cat_Name { get; set; }

        public string Cat_Image { get; set; }

        public List<Products> Products { get; set; }
    }
}
