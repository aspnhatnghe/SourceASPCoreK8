using System.Linq;
using D14_EFCore_DBFirst.ViewModels;
using D14_EFCore_DBFirst.Helpers;
using EFCore_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace D14_EFCore_DBFirst.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        private readonly MyeStoreContext _context;
        public KhachHangController(MyeStoreContext db)
        {
            _context = db;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var kh = _context.KhachHang.SingleOrDefault(p => p.MaKh == model.MaKh && p.MatKhau == model.MatKhau);

                if(kh != null)
                {
                    //lưu session đánh dấu đăng nhập thành công
                    HttpContext.Session.Set("KhachHang", kh);
                    return RedirectToAction("Profile", "KhachHang");
                }
            }
            ModelState.AddModelError("loi", "Sai thông tin đăng nhập");
            return View();
        }

        public IActionResult Profile()
        {
            var kh = HttpContext.Session.Get<KhachHang>("KhachHang");
            if (kh == null) return RedirectToAction("Login");

            return View(kh);
        }
    }
}