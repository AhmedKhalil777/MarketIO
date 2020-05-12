using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.Contracts.V1.Responses
{
    public class AdminViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
