using Microsoft.AspNetCore.Mvc;
using MyProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        /*Chỉ có 1 action duy nhất là Invoke()*/
        public IViewComponentResult Invoke()
        {
            //Gải sử đã lấy được dữ liệu Category
            var data = new List<Category>()
            {
                new Category{CaterogyId = 1, CaterogyName = "Bia"},
                new Category{CaterogyId = 2, CaterogyName = "Nước ngọt"},
                new Category{CaterogyId = 3, CaterogyName = "Điện máy"},
            };

            //return View(data);
            return View("Default", data);
        }
    }
}
