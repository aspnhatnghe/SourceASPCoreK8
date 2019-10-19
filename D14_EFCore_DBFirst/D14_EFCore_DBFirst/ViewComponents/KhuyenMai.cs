using AutoMapper;
using EFCore_DBFirst.Models;
using EFCore_DBFirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_DBFirst.ViewComponents
{
    public class KhuyenMai : ViewComponent
    {
        private readonly MyeStoreContext _context;
        private readonly IMapper _mapper;
        public KhuyenMai(MyeStoreContext ctx, IMapper mapper)
        {
            _context = ctx; _mapper = mapper;
        }
        public IViewComponentResult Invoke(int soLuong = 5)
        {
            var data = _context.HangHoa
                .Where(p => p.GiamGia > 0)
                .OrderBy(hh => Guid.NewGuid())//ngẫu nhiên
                .Take(soLuong);

            return View(_mapper.Map< List<HangHoaKhuyenMai>>(data.ToList()));
        }
    }
}
