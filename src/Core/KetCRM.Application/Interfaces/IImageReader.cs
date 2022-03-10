using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetCRM.Application.Interfaces
{
    public interface IImageReader
    {
        byte[] ReadImage(IFormFile UploadedFile);
    }
}
