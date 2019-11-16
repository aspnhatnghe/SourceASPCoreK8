using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCore_DBFirst.Models;
using EFCore_DBFirst.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_DBFirst.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyeStoreContext _context;
        private readonly IMapper _mapper;
        public HangHoaController(MyeStoreContext ctx, IMapper mapper)
        {
            _context = ctx; _mapper = mapper;
        }
        public IActionResult Index(int? loai, string ncc, int page = 1)
        {
            var data = _context.HangHoa.AsQueryable();

            if(loai.HasValue)
            {
                data = data.Where(p => p.MaLoai == loai).AsQueryable();
            }
            if (!string.IsNullOrEmpty(ncc))
            {
                data = data.Where(p => p.MaNcc == ncc).AsQueryable();
            }
            var result = data.Skip((page - 1) * MyTools.SoSanPham1Trang).Take(MyTools.SoSanPham1Trang).ToList();

            ViewBag.TongSoTrang = (int)Math.Ceiling(data.Count() * 1.0 / MyTools.SoSanPham1Trang);
            ViewBag.TrangHienTai = page;

            var fullUrl = HttpContext.Request.GetEncodedUrl();

            var host = HttpContext.Request.IsHttps ? "https" : "http" + "://" + HttpContext.Request.Host;
            if(loai.HasValue)
            {
                host += "?loai=" + loai.Value;
            }

            ViewBag.loai = loai;
            ViewBag.ncc = ncc;

            return View(_mapper.Map<List<HangHoaViewModel>>(result));
        }

        public IActionResult Query()
        {
            var data = _context.HangHoa.FromSql("select top 10 hh.* from HangHoa hh JOIN Loai lo ON lo.MaLoai = hh.MaLoai WHERE DonGia BETWEEN 5 AND 50 ");

            return Json(data);
        }

        public IActionResult Excute()
        {
            var rowEffect = _context.Database.ExecuteSqlCommand("UPDATE HangHoa SET DonGia = DonGia * 0.91 WHERE DonGia BETWEEN 100 AND 200");

            return Json(rowEffect);
        }
    }
}