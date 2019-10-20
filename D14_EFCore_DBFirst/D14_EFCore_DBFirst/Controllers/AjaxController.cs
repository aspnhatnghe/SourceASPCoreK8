using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCore_DBFirst.Models;
using EFCore_DBFirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace D14_EFCore_DBFirst.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MyeStoreContext _context;
        private readonly IMapper _mapper;
        public AjaxController(MyeStoreContext ctx, IMapper mapper)
        {
            _context = ctx; _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GetServerTime()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult AjaxSearch(string keyword)
        {
            var data = _context.HangHoa
                .Where(p => p.TenHh.Contains(keyword))
                .Include(p => p.MaLoaiNavigation)
                .Include(p => p.MaNccNavigation);

            var result = _mapper.Map<List<HangHoaViewModel>>(data.ToList());

            return PartialView(result);
        }

        public IActionResult JsonSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JsonSearch(string tuKhoa, double giaTu, double giaDen)
        {
            var result = _context.HangHoa.Where(p => p.TenHh.Contains(tuKhoa) && p.DonGia >= giaTu && p.DonGia <= giaDen)
             .Include(p => p.MaLoaiNavigation)
             .Select(p => new
             {
                 MaHH = p.MaHh,
                 TenHh = p.TenHh,
                 Hinh = GetBase64(p.Hinh),
                 GiaBan = p.DonGia * (1 - p.GiamGia),
                 Loai = p.MaLoaiNavigation.TenLoai
             });
            return Json(result);
        }

        public string GetBase64(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "HangHoa", fileName);

            if (!System.IO.File.Exists(path))
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "noimages.jpg");
            }

            var data = System.IO.File.ReadAllBytes(path);

            return Convert.ToBase64String(data);
        }
    }
}