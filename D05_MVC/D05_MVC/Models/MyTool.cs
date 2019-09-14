using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace D05_MVC.Models
{
    public class MyTool
    {
        public static string UploadFileToFolder(IFormFile MyFile, string folder = "Data")
        {
            try
            {
                var fileName = MyFile.FileName;

                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder, fileName);

                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    MyFile.CopyTo(file);
                }

                return fileName;
            }
            catch { return null; }
        }
    }
}
