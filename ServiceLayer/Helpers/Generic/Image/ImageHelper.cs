using CoreLayer.Enumerators;
using CoreLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Generic.Image
{
    public class ImageHelper : IImageHelper
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly string wwwRoot;
        private const string imageFolder = "images";
        private const string identityFolder = "user";
        private const string aboutFolder = "aboutUs";
        private const string portfolioFolder = "portfolios";
        private const string teamFolder = "team";
        private const string testimonalFolder = "testimonials";

        public ImageHelper(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            wwwRoot = _hostEnvironment.ContentRootPath + "/wwwroot/";
        }

        public async Task<ImageUploadModel> ImageUpload(string name, IFormFile imageFile, ImageType imageType, string? folderName)
        {
            if(folderName == null)
            {
                switch (imageType)
                {
                    case ImageType.about:
                        folderName = aboutFolder; 
                        break;
                    case ImageType.identity:
                        folderName = identityFolder;
                        break;
                    case ImageType.team:
                        folderName = teamFolder;
                        break;
                    case ImageType.testimonal:
                        folderName = testimonalFolder;
                        break;
                    case ImageType.portfolio:
                        folderName = portfolioFolder;
                        break;

                }
            }
            if (!Directory.Exists($"{wwwRoot}/{imageFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwRoot}/{imageFolder}/{folderName}");
            }
            string fileExtension = Path.GetExtension( imageFile.FileName ).ToLower();
            if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".gif")
            {
                return new ImageUploadModel { Error = "Please upload an image file with one of the following extensions: .jpg, .jpeg, .png, .gif" };
            }

            DateTime dateTime = DateTime.Now;
            var newFileName = folderName + "_" + dateTime.Microsecond.ToString();
            string path = Path.Combine($"{wwwRoot}/{imageFolder}/{folderName}", newFileName);
            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();
            return new ImageUploadModel {Filename =$"{folderName}/{newFileName}", FileType = imageFile.ContentType};
        }

        public string DeleteImage(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwRoot}/{imageFolder}/{imageName}");
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }
            return "Image Deleted";
        }
    }
}
