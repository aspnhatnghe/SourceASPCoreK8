using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace D04_MVCBasic.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double A, double B, string PhepToan)
        {
            double KQ = 0;
            switch(PhepToan)
            {
                case "+": KQ = A + B; break;
                case "-": KQ = A - B; break;
                case "*": KQ = A * B; break;
                case "/": KQ = A / B; break;
                case "^": KQ = Math.Pow(A, B); break;
                case "%": KQ = A % B; break;
            }

            ViewBag.A = A;
            ViewBag.B = B;
            ViewBag.KQ = KQ;
            ViewBag.PhepToan = PhepToan;

            return View("Index");
        }
    }
}