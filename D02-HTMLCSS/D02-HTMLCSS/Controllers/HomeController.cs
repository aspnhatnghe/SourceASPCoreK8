using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D02_HTMLCSS.Models;

namespace D02_HTMLCSS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult KhuyenMai()
        {
            Random rd = new Random();
            int soHH = rd.Next(9, 50);
            List<HangHoa> dsHangHoa = new List<HangHoa>();
            
            //duyệt qua từng phần tử trong danh sách để tạo data
            for(int i = 0; i < soHH; i++)
            {
                var hh = new HangHoa();
                hh.TenHh = $"SS Galaxy Note {rd.Next(5, 11)}";
                hh.DonGia = rd.Next(1000, 10000);
                hh.GiamGia = rd.Next(0, 99);
                hh.Hinh = "samsung-galaxy-j6-2018.png";
                dsHangHoa.Add(hh);
            }

            return View(dsHangHoa);
        }
    }
}
