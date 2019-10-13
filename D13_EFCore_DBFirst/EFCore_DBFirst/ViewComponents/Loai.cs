using EFCore_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EFCore_DBFirst.ViewComponents
{
    public class LoaiViewComponent : ViewComponent
    {
        private readonly MyeStoreContext _context;
        public LoaiViewComponent(MyeStoreContext ctx)
        {
            _context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.Loai
                .Where(lo => lo.HangHoa.Count() > 0)
                .OrderBy(lo => lo.TenLoai);
            return View(data);
        }
    }
}
