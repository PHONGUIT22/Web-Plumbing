using CoreLayer.Enumerators;
using CoreLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Generic.Image
{
    public interface IImageHelper
    {
        Task<ImageUploadModel> ImageUpload(string name, IFormFile imageFile, ImageType imageType, string?
            folderName);
        string DeleteImage(string imageName);
    }
}
