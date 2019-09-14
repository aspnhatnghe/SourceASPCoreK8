using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using D05_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D05_MVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadOneFile(IFormFile MyFile)
        {
            if(MyFile != null)//nếu có file trên TM temp của server
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", MyFile.FileName);

                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    MyFile.CopyTo(file);
                }
            }
            return View("UploadFile");
        }

        public IActionResult UploadMultiFile(List<IFormFile> MyFile)
        {
            foreach(var singleFile in MyFile)
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", singleFile.FileName);

                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    singleFile.CopyTo(file);
                }
            }

            return View("UploadFile");
        }

        public IActionResult DemoSync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Demo demo = new Demo();
            demo.Test01();
            demo.Test02();
            demo.Test03();

            sw.Stop();

            return Content($"Tốn {sw.ElapsedMilliseconds} ms");
        }

        public async Task<IActionResult> DemoAsync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Demo demo = new Demo();
            var x = demo.Test01Async();
            var y = demo.Test02Async();
            var z = demo.Test03Async();
            await x; await y; await z;

            sw.Stop();

            return Content($"Tốn {sw.ElapsedMilliseconds} ms");
        }

        public IActionResult DemoPassData()
        {
            //Dữ liệu đọc ở file, csdl,...

            ViewBag.Ten = "Nhất Nghệ";
            ViewBag.Tuoi = 16;

            ViewBag.SanPham = new HangHoa
            {
                MaHh = 1, TenHh = "Bia Sài Gòn",
                DonGia = 13900, GiamGia = 1
            };

            return View();
        }
    }
}