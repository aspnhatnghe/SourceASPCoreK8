using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D07_jQueryValidation.Models;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace D07_jQueryValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Partial()
        {
            string[] data = new string[]{
                "Sharp", "Samsung", "Nokia"
            };
            return PartialView("_Category", data);
        }
        public IActionResult Demo1()
        {
            return View();
        }
        public IActionResult Demo2()
        {
            return View();
        }

        public IActionResult Register()
        {
            #region Generate Security Code
            Random rd = new Random();
            string pattern = @"qazwsxedcrfvtgbyhnujmik,ol.p[]{}~!@#$%^&*()";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.Append(pattern[rd.Next(0, pattern.Length)]);
            }
            #endregion

            ViewBag.SecurityCode = sb.ToString();
            HttpContext.Session.SetString("MaBaoMat", sb.ToString());

            return View();
        }

        public IActionResult KiemTraMaBaoMat(string MaBaoMat)
        {
            var maBM = HttpContext.Session.GetString("MaBaoMat");

            return Content(MaBaoMat == maBM ? "true" : "false");
        }

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
    }
}
