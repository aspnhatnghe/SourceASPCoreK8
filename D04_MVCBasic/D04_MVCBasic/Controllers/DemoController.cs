using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace D04_MVCBasic.Controllers
{
    public class DemoController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("/ABC")]

        public IActionResult TestRoute()
        {
            return Content("In Action TestRoute");
        }

        [Route("dien-thoai/{name}")]
        [Route("{loai}/{name}")]
        public string GetName(string name, string loai)
        {
            return $"{loai} ==> {name}";
        }

        // /Demo/Test/<so>
        // /Demo/Test?id=<so>
        public int Test(int id)
        {
            return new Random().Next(id);
        }

        // /Demo/Test2?so=<so>
        [HttpPost]
        public int Test2(int so)
        {
            return new Random().Next(so);
        }
    }
}