using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_DBFirst.ViewModels
{
    public class ThongKeViewModel
    {
        [Display(Name ="Loại")]
        public string TenLoai { get; set; }
        [Display(Name = "Doanh thu")]
        public double DoanhThu { get; set; }
        [Display(Name = "Số lượng mặt hàng")]
        public int SoLuongMatHang { get; set; }
        [Display(Name = "Giá nhỏ nhất")]
        public double GiaNhoNhat { get; set; }
        [Display(Name = "Giá trung bình")]
        public double GiaTrungBinh { get; set; }
    }
}
