using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCore_DBFirst.Models;
using EFCore_DBFirst.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

            return View(_mapper.Map<List<HangHoaViewModel>>(result));
        }
    }
}