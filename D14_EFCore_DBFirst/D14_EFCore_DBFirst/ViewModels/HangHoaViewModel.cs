﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_DBFirst.ViewModels
{
    public class HangHoaViewModel
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public double DonGia { get; set; }
        public string Hinh { get; set; }
        public DateTime NgaySx { get; set; }
        public double GiamGia { get; set; }
        public double GiaBan => DonGia * (1 - GiamGia);
        public string PhanTramGiamGia => $"{GiamGia * 100} %";
        public string TenLoai { get; set; }
    }
}
