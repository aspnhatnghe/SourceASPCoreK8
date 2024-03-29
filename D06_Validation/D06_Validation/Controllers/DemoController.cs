﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D06_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace D06_Validation.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult CheckUserName(string MaNv)
        {
            List<string> dsUser = new List<string>()
            {
                "admin", "guest", "user", "customer"
            };

            if(dsUser.Contains(MaNv))
            {
                return Json("Mã này đã có");
            }
            return Json(true);
        }

        public IActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterEmployee(EmployeeInfo emp)
        {
            if(ModelState.IsValid)
            {
                //thuc hien
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee emp)
        {
            if(ModelState.IsValid)
            {
                ModelState.AddModelError("thongbao", "Thông tin hợp lệ");
            }
            else
            {
                ModelState.AddModelError("loi", "Còn lỗi");
            }
            return View();
        }

        public IActionResult jquery()
        {
            return View();
        }
    }
}