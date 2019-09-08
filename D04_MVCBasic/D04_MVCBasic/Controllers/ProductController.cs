using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D04_MVCBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace D04_MVCBasic.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> Products = new List<Product>();

        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            var product = GetProductById(model.ProductId);

            if (product == null)//chưa có
            {
                Products.Add(model);
                //chuyển về action Index
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("loi", "Mã này đã có");
            return View();
        }

        private Product GetProductById(int id)
        {
            return Products.SingleOrDefault(p => p.ProductId == id);
        }

        public IActionResult Edit(int id)
        {
            //asp-route-id="3"
            //asp-route-name="Teo"
            var product = GetProductById(id);
            if(product == null)//ko có
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            if (id != model.ProductId) return View();
            var product = GetProductById(id);
            //update
            product.ProductName = model.ProductName;
            product.UnitPrice = model.UnitPrice;

            return RedirectToAction(actionName: "Index", controllerName: "Product");
        }

        public IActionResult Delete(int id)
        {
            var product = GetProductById(id);
            if(product != null)
            {
                //xóa
                Products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}