using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D10_ADONET.Models;
using Microsoft.AspNetCore.Mvc;

namespace D10_ADONET.Controllers
{
    public class LoaiController : Controller
    {
        public IActionResult Index()
        {
            return View(LoaiDataAccessLayer.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("TenLoai, MoTa, Hinh")]Loai lo)
        {
            if (ModelState.IsValid)
            {
                Loai loai = LoaiDataAccessLayer.Add(lo);
                if (loai != null)//thành công
                {
                    return Redirect($"/Loai/Edit/{loai.MaLoai}");
                    //return RedirectToAction("Index");
                    //return View("Index", LoaiDataAccessLayer.GetAll());
                }
                ModelState.AddModelError("Loi", "Thêm không thành công");
            }
            else
            {
                ModelState.AddModelError("Loi", "Không hợp lệ");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            bool result = LoaiDataAccessLayer.Remove(id);
            return Json(result);
        }
        public IActionResult Edit(int id)
        {
            Loai lo = LoaiDataAccessLayer.Get(id);
            if(lo != null)
            {
                return View(lo);
            }
            return RedirectToAction(controllerName:"Home", actionName:"Message");
        }

        [HttpPost]
        public IActionResult Edit(Loai lo)
        {
            if(ModelState.IsValid)
            {
                LoaiDataAccessLayer.Update(lo);
            }
            return View();
        }
    }
}