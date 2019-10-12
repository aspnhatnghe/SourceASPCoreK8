using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_DBFirst.Controllers
{
    public class DemoController : Controller
    {
        private readonly MyeStoreContext _context;
        public DemoController(MyeStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string TuKhoa, double GiaTu, double GiaDen)
        {
            return View();
        }
    }
}