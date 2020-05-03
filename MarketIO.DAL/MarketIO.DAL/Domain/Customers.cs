using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.DAL.Domain
{
    public class Customers : IdentityUser
    {
        public string Image { get; set; } = "~/images/DefaultImage.png";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public List<Orders> Orders { get; set; } 
    }
}
