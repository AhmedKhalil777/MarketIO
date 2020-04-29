using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        public async Task<bool> UploadFile(IFormFile file, string path)
        {
            return true;
        }
    }
}
