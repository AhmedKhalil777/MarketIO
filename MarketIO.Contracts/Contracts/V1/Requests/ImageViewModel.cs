using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.Contracts.V1.Requests
{
    public class ImageViewModel
    {
        public IFormFile Image { get; set; }
    }
}
