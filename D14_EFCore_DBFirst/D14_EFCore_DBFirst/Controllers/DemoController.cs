using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCore_DBFirst.Models;
using EFCore_DBFirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using D14_EFCore_DBFirst.Helpers;

namespace EFCore_DBFirst.Controllers
{
    public class DemoController : Controller
    {
        private readonly MyeStoreContext _context;
        private readonly IMapper _mapper;
        public DemoController(MyeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string TuKhoa, double GiaTu, double GiaDen)
        {
            var hanghoa = _context.HangHoa
                .Where(hh => hh.TenHh.Contains(TuKhoa)).AsQueryable();

            if (GiaTu > 0)
            {
                hanghoa = hanghoa.Where(p => p.DonGia >= GiaTu).AsQueryable();
            }

            if (GiaDen > 0)
            {
                hanghoa = hanghoa.Where(p => p.DonGia <= GiaDen).AsQueryable();
            }

            var hanghoas = hanghoa.Include(hh => hh.MaLoaiNavigation)
                .OrderBy(p => p.DonGia)
                .ThenByDescending(p => p.SoLanXem)
                .ThenBy(p => p.GiamGia)
                .ToList();

            ViewBag.KetQua = _mapper.Map<List<HangHoaViewModel>>(hanghoas);
            return View();
        }

        public IActionResult ThongKe()
        {
            var data = _context.ChiTietHd
                .GroupBy(p => p.MaHhNavigation.MaLoaiNavigation)
                .Select(p => new ThongKeViewModel
                {
                    TenLoai = p.Key.TenLoai,
                    DoanhThu = p.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia)),
                    GiaNhoNhat = p.Min(cthd => cthd.DonGia),
                    GiaTrungBinh = p.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia)) / p.Sum(cthd => cthd.SoLuong),
                    SoLuongMatHang = p.Select(cthd => cthd.MaHh).Distinct().Count()
                });

            return View(data);
        }

        public IActionResult DoanhThu()
        {
            var data = _context.ChiTietHd
                .GroupBy(cthd => new
                {
                    Thang = cthd.MaHdNavigation.NgayDat.Month,
                    Nam = cthd.MaHdNavigation.NgayDat.Year,
                    Loai = cthd.MaHhNavigation.MaLoaiNavigation
                })
                .Select(p => new
                {
                    Loai = p.Key.Loai.TenLoai,
                    ThangNam = $"{p.Key.Thang}/{p.Key.Nam}",
                    DoanhThu = p.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia))
                }).ToList();

            return Json(data);
        }

        public IActionResult DanhSach(int page = 1)
        {
            int SoPhanTu1Trang = 10;
            var data = _context.HangHoa
                .Include(p => p.MaLoaiNavigation)
                //.Include(p => p.ChiTietHd)
                .OrderByDescending(p => p.TenHh)
                .Skip((page - 1) * SoPhanTu1Trang)
                .Take(SoPhanTu1Trang);


            var result = _mapper.Map<List<HangHoaViewModel>>(data.ToList());

            return View(result);
        }

        public IActionResult Session()
        {
            //gán session
            HttpContext.Session.SetString("HoTen", "Nguyễn Văn tèo");
            HttpContext.Session.SetInt32("NamSinh", 1980);

            var hh = new HangHoaViewModel
            {
                MaHh = 1, TenHh = "Bia Sài Gòn",
                DonGia = 15900, TenLoai = "Bia"
            };
            HttpContext.Session.Set<HangHoaViewModel>("Bia", hh);

            return View();
        }
    }
}