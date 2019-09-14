using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using D05_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace D05_MVC.Controllers
{
    public class HangHoaController : Controller
    {
        string textFullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "HangHoa.txt");
        string jsonFullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "HangHoa.json");

        public IActionResult ReadFile(string type)
        {
            var hh = new HangHoa();

            if(type == "JSON")
            {
                var content = System.IO.File.ReadAllText(jsonFullPath);
                hh = JsonConvert.DeserializeObject<HangHoa>(content);
            }
            else if(type == "Text")
            {
                var content = System.IO.File.ReadAllLines(textFullPath);
                hh.MaHh = int.Parse(content[0]);
                hh.TenHh = content[1];
                hh.Hinh = content[2];
                hh.DonGia = double.Parse(content[3]);
                hh.GiamGia = int.Parse(content[4]); 
            }

            return View("Index", hh);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveFile(HangHoa model, string FileType, IFormFile fHinh)
        {
            if (ModelState.IsValid)
            {
                //upload file
                var fileName = MyTool.UploadFileToFolder(fHinh, "Data");
                if (fileName == null)
                {
                    fileName = "no_image_available.png";
                }

                model.Hinh = fileName;

                if (FileType == "Save file Text")
                {
                    string[] lines = {
                        model.MaHh.ToString(), model.TenHh,
                        model.Hinh, model.DonGia.ToString(),
                        model.GiamGia.ToString(),
                        model.GiaBan.ToString()
                    };
                    
                    System.IO.File.WriteAllLines(textFullPath, lines);
                }
                else if (FileType == "Save file JSON")
                {
                    var json = JsonConvert.SerializeObject(model);
                    System.IO.File.WriteAllText(jsonFullPath, json);
                }
            }

            return View("Index");
        }
    }
}