using EFCore_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_DBFirst.ViewComponents
{
    public class NhaCungCap : ViewComponent
    {
        private readonly MyeStoreContext _context;
        public NhaCungCap(MyeStoreContext ctx)
        {
            _context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.NhaCungCap
                .Where(lo => lo.HangHoa.Count() > 0)
                .OrderBy(lo => lo.TenCongTy);
            return View(data);
        }
    }
}
