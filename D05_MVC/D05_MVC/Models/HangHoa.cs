using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D05_MVC.Models
{
    public class HangHoa
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public int GiamGia { get; set; } = 0;
        public double GiaBan => DonGia * (100 - GiamGia) / 100;
    }
}
