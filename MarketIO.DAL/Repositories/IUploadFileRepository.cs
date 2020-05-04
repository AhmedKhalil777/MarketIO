using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.DAL.Repositories
{
    public interface IUploadFileRepository
    {
        string ProcessUploadedFile(IFormFile file, string folderName);
        
    }
}
