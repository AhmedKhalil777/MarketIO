using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.FilesHosting
{

    public class FileUploader : IFileUploader
    {
        private readonly IHostEnvironment _hostEnvironment;
        public FileUploader(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void UploadFile(IFormFile file, string Path , string name)
        {
            
            
            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(Path))
                    {
                        Directory.CreateDirectory(Path);
                    }
                    using (FileStream filestream = File.Create(Path + name))
                    {
                        file.CopyTo(filestream);
                        filestream.Flush();
                    }
                }
                catch
                {
                    throw new FileLoadException();
                }

            }

        }
    }
}
