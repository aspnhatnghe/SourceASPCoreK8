using System.Linq;
using D14_EFCore_DBFirst.ViewModels;
using D14_EFCore_DBFirst.Helpers;
using EFCore_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

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
        public IActionResult Login(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var kh = _context.KhachHang.SingleOrDefault(p => p.MaKh == model.MaKh && p.MatKhau == model.MatKhau);

                if (kh != null)
                {
                    //lưu session đánh dấu đăng nhập thành công
                    HttpContext.Session.Set("KhachHang", kh);

                    //báo Identity biết đăng nhập thành công
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name,
kh.HoTen),
                        new Claim(ClaimTypes.Email, kh.Email),
                        new Claim(ClaimTypes.Role, "KhachHang")
                    };                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Profile", "KhachHang");
                }
            }

            ModelState.AddModelError("loi", "Sai thông tin đăng nhập");
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Authorize(Roles ="ThuNgan, KhachHang")]
        public IActionResult ThongKe()
        {
            return Content("Trang dành cho thu ngân");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Remove("KhachHang");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            var kh = HttpContext.Session.Get<KhachHang>("KhachHang");
            if (kh == null) return RedirectToAction("Login");

            return View(kh);
        }
    }
}