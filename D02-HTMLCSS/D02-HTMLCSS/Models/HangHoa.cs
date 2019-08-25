using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D02_HTMLCSS.Models
{
    public class HangHoa
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public double DonGia { get; set; }
        public string Hinh { get; set; }
        [Range(0, 99)] //khuyến mãi từ 0 --> 99%
        public int GiamGia { get; set; }
        public bool DangKhuyenMai => GiamGia > 0;
        public bool CoGiaSoc => GiamGia > 50;
        public double GiaBan => DonGia * (100 - GiamGia) / 100.0;
    }
}
