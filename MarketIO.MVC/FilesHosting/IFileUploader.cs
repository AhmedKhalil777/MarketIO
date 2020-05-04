using Microsoft.AspNetCore.Http;

namespace MarketIO.MVC.FilesHosting
{
    public interface IFileUploader
    {
        void UploadFile(IFormFile file, string Path, string name);
    }
}
