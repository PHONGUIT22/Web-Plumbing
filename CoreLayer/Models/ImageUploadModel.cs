using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class ImageUploadModel
    {
        public string? Filename { get; set; }
        public string? FileType { get; set; }
        public string? Error { get; set; }

    }
}
