using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreDemo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            //1. Xử lý nghiệp vụ ABC

            //2. gửi dữ liệu qua View để hiển thị
            ViewBag.Data = "Chào mừng anh/chị";

            return View();
        }

        public double Cong(double a, double b)
        {
            return a + b;
        }

        public string Chao(string ten)
        {
            return $"Nhất nghệ kính chào anh/chị {ten}";
        }

        public IActionResult GetData()
        {
            return Json(new {
                HoTen = "Nhất Nghệ",
                Nam = 2003
            });
        }

        public IActionResult OnTap()
        {
            return View();
        }
    }
}