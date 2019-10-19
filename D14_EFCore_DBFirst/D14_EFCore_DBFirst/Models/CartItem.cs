using EFCore_DBFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D14_EFCore_DBFirst.Models
{
    public class CartItem : HangHoaViewModel
    {   
        public int SoLuong { get; set; }
        public double ThanhTien => SoLuong * GiaBan;
    }
}
