using MarketIO.DAL.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketIO.Contracts.V1.Responses
{
    public class ProductEditViewModel
    {
        public Products Product { get; set; }
        public IFormFile Photo { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public int BrandId { get; set; }
    }
}
