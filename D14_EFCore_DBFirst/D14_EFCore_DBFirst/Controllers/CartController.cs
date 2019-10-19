using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using D14_EFCore_DBFirst.Models;
using D14_EFCore_DBFirst.Helpers;
using EFCore_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace D14_EFCore_DBFirst.Controllers
{
    public class CartController : Controller
    {
        private readonly MyeStoreContext _context;
        private readonly IMapper _mapper;
        public CartController(MyeStoreContext ctx, IMapper mapper)
        {
            _context = ctx; _mapper = mapper;
        }

        public List<CartItem> CartItems
        {
            get
            {
                var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (cart == null)
                {
                    cart = new List<CartItem>();
                }

                return cart;
            }
        }

        public IActionResult AddToCart(int maHH, int soLuong)
        {
            var carts = CartItems;
            var cartItem = carts.SingleOrDefault(p => p.MaHh == maHH);

            if(cartItem!= null)//đã có
            {
                cartItem.SoLuong += soLuong;
            }
            else
            {
                var hh = _context.HangHoa.SingleOrDefault(p => p.MaHh == maHH);
                cartItem = _mapper.Map<CartItem>(hh);
                cartItem.SoLuong = soLuong;

                carts.Add(cartItem);
            }
            HttpContext.Session.Set("GioHang", carts);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(CartItems);
        }
    }
}