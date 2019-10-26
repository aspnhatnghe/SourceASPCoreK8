using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EFCore_DBFirst.ApiModels;
using EFCore_DBFirst.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EFCore_DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyeStoreContext _context;
        private readonly AppSettings _appSetting;

        public LoginController(MyeStoreContext context, IOptions<AppSettings> appSetting)
        {
            _context = context;
            _appSetting = appSetting.Value;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginModel model)
        {
            var kh = _context.KhachHang.SingleOrDefault(p=> p.MaKh == model.MaKh && p.MatKhau == model.MatKhau);
            if (kh == null) return BadRequest();

            //sinh token
            var key = Encoding.UTF8.GetBytes(_appSetting.JwtSecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, kh.HoTen.ToString()),
                    new Claim(ClaimTypes.Role, "KhachHang")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return this.Ok(new TokenModel
            {
                Token = tokenHandler.WriteToken(token)
            });
        }
    }
}