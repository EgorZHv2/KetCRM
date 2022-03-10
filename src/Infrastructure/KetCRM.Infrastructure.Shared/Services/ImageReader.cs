using KetCRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Infrastructure.Shared.Services
{
    public class ImageReader : IImageReader
    {
        public byte[] ReadImage(IFormFile img)
        {
            byte[] imageData;

            using (var binaryReader = new BinaryReader(img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)(img.Length));
            }

            return imageData;
        }
    }
}
