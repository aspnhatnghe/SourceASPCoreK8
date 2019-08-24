using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreDemo.Controllers
{
    public class HinhChuNhatController : Controller
    {
        static List<HinhChuNhat> dsHCN = new List<HinhChuNhat>();
        public IActionResult Index()
        {
            //gửi dữ liệu thông qua model
            return View(dsHCN);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult XuLyLuu(HinhChuNhat hcn)
        {
            dsHCN.Add(hcn);
            return RedirectToAction("Index");
        }
    }
}