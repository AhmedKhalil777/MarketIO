using MarketIO.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.BLL.Repositories
{
    public class UploadFileRepository : IUploadFileRepository
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public UploadFileRepository(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public string ProcessUploadedFile(IFormFile file,string folderName)
        {
            string path = hostingEnvironment.WebRootPath + $"\\images\\{folderName}\\";
            string uniqueFileName = Guid.NewGuid().ToString() + file.FileName;
            if (file.Length > 0)
            {

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream filestream = System.IO.File.Create(path + uniqueFileName))
                {
                    file.CopyTo(filestream);
                    filestream.Flush();
                }
                uniqueFileName = $"{folderName}\\" + uniqueFileName;
                return uniqueFileName;
            }
            return null;
        }
        
    }
}
