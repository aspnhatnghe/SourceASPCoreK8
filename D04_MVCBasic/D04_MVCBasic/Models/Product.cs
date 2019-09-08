using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D04_MVCBasic.Models
{
    public class Product
    {
        [Display(Name ="Mã hàng hóa")]
        public int ProductId { get; set; }
        [Display(Name = "Tên hàng hóa")]
        public string ProductName { get; set; }
        [Display(Name = "Đơn giá")]
        public double UnitPrice { get; set; }
    }
}
