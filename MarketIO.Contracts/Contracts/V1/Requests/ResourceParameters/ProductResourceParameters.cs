using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.Contracts.V1.Requests.ResourceParameters
{
    public class ProductResourceParameters
    {

        public string Category { get; set; }
        public string Brand { get; set; }
        public string SearchQuery { get; set; }
    }
}
